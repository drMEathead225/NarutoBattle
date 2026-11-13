namespace NarutoBattle;

public partial class CharacterSelectPage : ContentPage
{
    public CharacterSelectPage()
    {
        InitializeComponent();

        // Fill the CollectionView with every character in the roster
        FighterList.ItemsSource = GameState.Roster;
    }

    // Runs every time the user taps (selects or deselects) a character
    private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        int count = FighterList.SelectedItems.Count;
        CountLabel.Text = $"Selected {count} of 2";

        // Only allow Continue when exactly 2 fighters are chosen
        ContinueButton.IsEnabled = (count == 2);
    }

    // Screen 2 -> Screen 3
    private async void OnContinueClicked(object? sender, EventArgs e)
    {
        // Save the two chosen fighters in the shared GameState.
        // SelectedItems holds "object", so we cast each one back to Fighter.
        GameState.Fighter1 = (Fighter)FighterList.SelectedItems[0];
        GameState.Fighter2 = (Fighter)FighterList.SelectedItems[1];

        await Shell.Current.GoToAsync(nameof(BattleTypePage));
    }
}
