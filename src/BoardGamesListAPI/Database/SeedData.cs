using BoardGamesListAPI.Domain;
using Marten;
using Marten.Schema;

namespace BoardGamesListAPI.Database
{
    public class SeedData : IInitialData
    {
        private readonly CsvParser csvParser;
        private readonly string fileName;

        public SeedData(CsvParser csvParser, string fileName)
        {
            this.csvParser = csvParser;
            this.fileName = fileName;
        }

        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            await using var session = store.LightweightSession();
            var result = this.csvParser.ParseCsvData(this.fileName);
            if (result.IsSucess)
            {
                session.Store(result.Value.ToArray());
                await session.SaveChangesAsync();
            }
            else; // Log
        }
    }
}
