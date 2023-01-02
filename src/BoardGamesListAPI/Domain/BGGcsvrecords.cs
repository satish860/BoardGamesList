using CsvHelper.Configuration.Attributes;

namespace BoardGamesListAPI.Domain
{
    public class BGGcsvrecords
    {
        [Name("ID")]
        public int? Id { get; set; }

        [Name("Name")]
        public string Name { get; set; }

        [Optional]
        [Name("Year Published")]
        public int? Year_Published { get; set; }

        [Name("Min Players")]
        public int? Min_player { get; set; }

        [Name("Max Players")]
        public int Max_player { get; set; }

        [Name("Play Time")]
        public int PlayTime { get; set; }

        [Name("Min Age")]
        public int MinAge { get; set; }

        [Name("Users Rated")]
        public int UserRated { get; set; }

        [Name("Rating Average")]
        public double RatingAverage { get; set; }

        [Name("BGG Rank")]
        public int BggRank { get; set; }

        [Name("Complexity Average")]
        public double ComplexityAverge { get; set; }

        [Name("Owned Users")]
        public int? OwnedUser { get; set; }

        [Name("Mechanics")]
        public string Mechanics { get; set; }

        [Name("Domains")]
        public string Domains { get; set; }
    }
}
