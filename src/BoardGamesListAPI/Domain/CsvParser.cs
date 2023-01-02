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

            }

            return result;
        }

    }
}
