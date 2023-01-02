namespace BoardGamesListAPI.Domain
{
    public class BGGcsvrecords
    {
        public int Guid { get; set; }

        public string Name { get; set; }

        public int Year_Published { get; set; }

        public int Min_player { get; set; }

        public int Max_player { get; set; }

        public int PlayTime { get; set; }

        public int MinAge { get; set; }

        public int UserRated { get; set; }

        public double RatingAverage { get; set; }

        public int BggRank { get; set; }

        public double ComplexityAverge { get; set; }

        public int OwnedUser { get; set; }

        public string[] Mechanics { get; set; }

        public string[] Domains { get; set; }
    }
}
