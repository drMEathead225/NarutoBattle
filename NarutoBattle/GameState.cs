namespace NarutoBattle;

// A static class lives for the whole app, so every page can read and write it.
// This is how the pages "pass" information to each other (same idea as Cart in FootballShop).
public static class GameState
{
    // The full list of characters the user can pick from (stats are editable)
    public static List<Fighter> Roster = new List<Fighter>
    {
        new Fighter { Name = "Naruto",      Image = "naruto.jpg",      Attack = 90, Defense = 70, Speed = 85 },
        new Fighter { Name = "Madara",      Image = "madara.jpg",      Attack = 98, Defense = 90, Speed = 80 },
        new Fighter { Name = "Pain",        Image = "pain.jpg",        Attack = 92, Defense = 80, Speed = 78 },
        new Fighter { Name = "Sakura",      Image = "sakura.jpg",      Attack = 70, Defense = 65, Speed = 70 },
        new Fighter { Name = "Orochimaru",  Image = "orochimaru.jpg",  Attack = 85, Defense = 70, Speed = 80 },
        new Fighter { Name = "Itachi",      Image = "itachi.jpg",      Attack = 95, Defense = 75, Speed = 95 },
        new Fighter { Name = "Gaara",       Image = "gaara.jpg",       Attack = 80, Defense = 95, Speed = 65 },
        new Fighter { Name = "Kurenai",     Image = "kurenai.jpg",     Attack = 60, Defense = 60, Speed = 75 }
    };

    // The two fighters the user picked on the Character Select screen
    public static Fighter Fighter1 = new Fighter();
    public static Fighter Fighter2 = new Fighter();

    // Filled in at the end of the battle and shown on the Victory screen
    public static Fighter Winner = new Fighter();
    public static string WinReason = "";
}
