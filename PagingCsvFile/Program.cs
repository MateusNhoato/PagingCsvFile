using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        const int SONGS_PER_PAGE = 10;
        const int TOTAL_PAGES = 1108;

        int pageNumber;

        do
        {
            Console.Clear();
            Console.WriteLine("Spotify's top hit songs by order\n");
            Console.Write("Type the number of a page(1-1108): ");

            if (int.TryParse(Console.ReadLine(), out pageNumber))
            {
                if (pageNumber > 0 && pageNumber <= TOTAL_PAGES)
                {
                    var data = ReadCsv();

                    var pageData = data.Skip((pageNumber - 1) * SONGS_PER_PAGE)
                                       .Take(SONGS_PER_PAGE).ToList();

                    Console.WriteLine();
                    foreach (var s in pageData)
                        Console.WriteLine($"Position:{s.Position} | Song Name: {s.Name} | Artist: {s.Artist}");

                }
                else
                    Console.WriteLine("Invalid page.");
            }
            else
                Console.WriteLine("Invalid page.");

            Console.ReadKey();

        } while (true);
    }

    static List<Song> ReadCsv()
    {
        string path = @"..\..\..\Spotify_final_dataset.csv";

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
        };

        List<Song> songs;

        using (StreamReader reader = new StreamReader(path))
        {
            using (var csv = new CsvReader(reader, config))
            {
                songs = csv.GetRecords<Song>().ToList();
            }
        }
        return songs;
    }
}



