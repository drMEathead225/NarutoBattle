namespace NarutoBattle;

public partial class VictoryPage : ContentPage
{
    public VictoryPage()
    {
        InitializeComponent();
    }

    // Read the result saved by the Solo Battle screen
    protected override void OnAppearing()
    {
        base.OnAppearing();

        WinnerImage.Source = GameState.Winner.Image;
        WinnerLabel.Text = $"{GameState.Winner.Name} Wins!";
        ReasonLabel.Text = GameState.WinReason;
    }

    // "//TitlePage" is an absolute route: it clears the page stack and returns to the start
    private async void OnPlayAgainClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//TitlePage");
    }
}
