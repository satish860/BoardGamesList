namespace BoardGamesListAPI.Controllers
{
    public class RestDTO<T>
    {
        public T Data { get; set; }

        public long PageSize { get; set; }

        public long PageIndex { get; set; } = 0;

        public long TotalCount { get; set; }
    }
}
