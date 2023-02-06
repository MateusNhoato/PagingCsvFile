using CsvHelper.Configuration.Attributes;

internal class Song
{
    [Name("Position")]
    public int Position { get; set; }
    [Name("Artist Name")]
    public string Artist { get; set; }
    [Name("Song Name")]
    public string Name { get; set; }
    [Name("Total Streams")]
    public long TotalStream { get; set; }
}

