namespace NarutoBattle;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register the other four screens so we can navigate to them by name
        Routing.RegisterRoute(nameof(CharacterSelectPage), typeof(CharacterSelectPage));
        Routing.RegisterRoute(nameof(BattleTypePage), typeof(BattleTypePage));
        Routing.RegisterRoute(nameof(SoloBattlePage), typeof(SoloBattlePage));
        Routing.RegisterRoute(nameof(VictoryPage), typeof(VictoryPage));
    }
}
