namespace NarutoBattle;

// A Fighter holds everything we know about one character.
// Every screen shares this one class, so the data is defined in one place.
public class Fighter
{
    public string Name { get; set; } = "";
    public string Image { get; set; } = "";   // image file name in Resources/Images
    public int MaxHp { get; set; } = 100;     // starting health
    public int Hp { get; set; } = 100;        // current health (changes during a battle)
    public int Attack { get; set; }           // higher = hits harder
    public int Defense { get; set; }          // higher = takes less damage
    public int Speed { get; set; }            // higher = strikes first each round
}
