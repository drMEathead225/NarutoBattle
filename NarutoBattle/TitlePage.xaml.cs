namespace NarutoBattle;

public partial class TitlePage : ContentPage
{
    public TitlePage()
    {
        InitializeComponent();
    }

    // Screen 1 -> Screen 2
    private async void OnEnterClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CharacterSelectPage));
    }
}
