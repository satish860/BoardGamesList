using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace BoardGamesListAPI.Domain
{
    public class CsvParser 
    {
        public Result<List<BoardGames>> ParseCsvData(string fileName)
        {
            Result<List<BoardGames>> result = new Result<List<BoardGames>>();
            if (!File.Exists(fileName))
            {

                result.IsSucess = false;
                result.Errors = "File does not exist in the Location specified";
                return result;
            }
            List<BoardGames> boardGames = new List<BoardGames>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
                HeaderValidated = null
            };
            using(var reader = new StreamReader(fileName))
            using(var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<BGGcsvrecords>();
                foreach (var item in records)
                {
                    if (item.Id != null)
                    {
                        var BoardGame = new BoardGames
                        {
                            Id = item.Id.Value,
                            Name = item.Name,
                            BggRank = item.BggRank,
                            ComplexityAverge=item.ComplexityAverge,
                            Max_player=item.Max_player,
                            MinAge=item.MinAge,
                            Min_player = item.Min_player,
                            PlayTime=item.PlayTime,
                            OwnedUser=item.OwnedUser,
                            RatingAverage=item.RatingAverage,
                            UserRated=item.UserRated,
                            Year_Published=item.Year_Published
                            
                        };
                        boardGames.Add(BoardGame);
                    }
                }
                result.Value = boardGames;
            }
            result.IsSucess = true;
            return result;
        }

    }
}
