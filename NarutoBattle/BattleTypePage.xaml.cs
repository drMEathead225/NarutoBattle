namespace NarutoBattle;

public partial class BattleTypePage : ContentPage
{
    public BattleTypePage()
    {
        InitializeComponent();
    }

    // OnAppearing runs each time the page is shown, so it always displays the latest picks
    protected override void OnAppearing()
    {
        base.OnAppearing();

        Image1.Source = GameState.Fighter1.Image;
        Name1.Text = GameState.Fighter1.Name;
        Image2.Source = GameState.Fighter2.Image;
        Name2.Text = GameState.Fighter2.Name;
    }

    // Screen 3 -> Screen 4
    private async void OnSoloClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SoloBattlePage));
    }

    // ".." means "go back one page"
    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
