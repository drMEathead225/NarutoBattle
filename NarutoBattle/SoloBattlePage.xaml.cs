namespace NarutoBattle;

public partial class SoloBattlePage : ContentPage
{
    private Random _random = new Random();   // used for random damage
    private int _round = 0;                  // counts how many rounds have been fought

    // Shortcuts to the two fighters chosen earlier
    private Fighter _f1 = GameState.Fighter1;
    private Fighter _f2 = GameState.Fighter2;

    public SoloBattlePage()
    {
        InitializeComponent();
    }

    // Start every battle fresh: full health, round 0, empty log
    protected override void OnAppearing()
    {
        base.OnAppearing();

        _f1 = GameState.Fighter1;
        _f2 = GameState.Fighter2;
        _f1.Hp = _f1.MaxHp;
        _f2.Hp = _f2.MaxHp;
        _round = 0;
        LogLabel.Text = "";
        AttackButton.IsEnabled = true;

        UpdateDisplay();
    }

    // Copies the fighters' current numbers onto the screen
    private void UpdateDisplay()
    {
        Image1.Source = _f1.Image;
        Name1.Text = _f1.Name;
        Hp1Bar.Progress = (double)_f1.Hp / _f1.MaxHp;   // ProgressBar uses 0.0 to 1.0
        Hp1Label.Text = $"HP: {_f1.Hp} / {_f1.MaxHp}";

        Image2.Source = _f2.Image;
        Name2.Text = _f2.Name;
        Hp2Bar.Progress = (double)_f2.Hp / _f2.MaxHp;
        Hp2Label.Text = $"HP: {_f2.Hp} / {_f2.MaxHp}";

        RoundLabel.Text = $"Round {_round}";
    }

    // One click = one round of the fight
    private async void OnAttackClicked(object? sender, EventArgs e)
    {
        _round++;

        // The faster fighter strikes first each round
        Fighter first = (_f1.Speed >= _f2.Speed) ? _f1 : _f2;
        Fighter second = (first == _f1) ? _f2 : _f1;

        string log = $"--- Round {_round} ---\n";
        log += Strike(first, second);

        // The second fighter only strikes back if they survived
        if (second.Hp > 0)
        {
            log += Strike(second, first);
        }

        LogLabel.Text = log + "\n" + LogLabel.Text;   // newest on top
        UpdateDisplay();

        // Battle is over when either fighter reaches 0 HP
        if (_f1.Hp <= 0 || _f2.Hp <= 0)
        {
            await EndBattleAsync();
        }
    }

    // One attack: random damage plus a bonus/penalty from Attack vs Defense.
    // Returns a text line for the battle log.
    private string Strike(Fighter attacker, Fighter defender)
    {
        int damage = _random.Next(8, 16) + (attacker.Attack - defender.Defense) / 5;

        if (damage < 3)
        {
            damage = 3;   // every hit does at least a little damage
        }

        defender.Hp -= damage;
        if (defender.Hp < 0)
        {
            defender.Hp = 0;   // health never goes below zero
        }

        return $"{attacker.Name} hits {defender.Name} for {damage}.\n";
    }

    // Decide the winner, store the result, then go to the Victory screen
    private async Task EndBattleAsync()
    {
        AttackButton.IsEnabled = false;

        Fighter winner = (_f1.Hp > 0) ? _f1 : _f2;
        Fighter loser = (winner == _f1) ? _f2 : _f1;

        GameState.Winner = winner;
        GameState.WinReason = BuildReason(winner, loser);

        await Task.Delay(1200);   // short pause so the user sees the final blow
        await Shell.Current.GoToAsync(nameof(VictoryPage));
    }

    // Finds the stat where the winner had the biggest advantage and explains it
    private string BuildReason(Fighter winner, Fighter loser)
    {
        int attackEdge = winner.Attack - loser.Attack;
        int defenseEdge = winner.Defense - loser.Defense;
        int speedEdge = winner.Speed - loser.Speed;
        int best = Math.Max(attackEdge, Math.Max(defenseEdge, speedEdge));

        string why;
        if (best <= 0)
        {
            why = "powerful hits and a little luck, even though the stats were close";
        }
        else if (best == attackEdge)
        {
            why = $"a stronger Attack ({winner.Attack} vs {loser.Attack})";
        }
        else if (best == defenseEdge)
        {
            why = $"a tougher Defense ({winner.Defense} vs {loser.Defense})";
        }
        else
        {
            why = $"a faster Speed ({winner.Speed} vs {loser.Speed}), which let them strike first";
        }

        return $"{winner.Name} won after {_round} rounds with {winner.Hp} HP left, thanks to {why}.";
    }
}
