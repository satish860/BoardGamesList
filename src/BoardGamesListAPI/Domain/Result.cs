namespace BoardGamesListAPI.Domain
{
    public class Result<T>
    {
        public bool IsSucess { get; set; }

        public string Errors { get; set; }

        public T Value { get; set; }
    }
}
