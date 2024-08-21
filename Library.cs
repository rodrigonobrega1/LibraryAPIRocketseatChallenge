namespace LibraryAPIRocketseatChallenge;

public class Library
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public float Price {get; set; } 

    public int Quantity { get; set; }

}
