using BoardGamesListAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesList.Tests
{
    public class ParseCSVtoBoardGamesTests
    {
        [Fact]
        public void Should_Be_ParseCSVToBoardGame()
        {
            CsvParser parser = new CsvParser();
            var result = parser.ParseCsvData("bgg_dataset.csv");
            Assert.True(result.IsSucess);
            Assert.Equal(20327, result.Value.Count);
        }

        [Fact]
        public void Should_be_ParseCSVAndGetMechanics()
        {
            CsvParser parser = new CsvParser();
            var result = parser.ParseCsvData("bgg_dataset.csv");
            Assert.True(result.IsSucess);
            var value = result.Value.FirstOrDefault();
            Assert.Contains(value.Mechanics.AsEnumerable(), p => p.Contains("Action Queue"));
        }

        [Fact]
        public void Should_Be_Able_to_Parse_Domains()
        {
            CsvParser parser = new CsvParser();
            var result = parser.ParseCsvData("bgg_dataset.csv");
            Assert.True(result.IsSucess);
            var value = result.Value.FirstOrDefault();
            Assert.Contains(value.Domains.AsEnumerable(), p => p.Contains("Strategy Games"));
        }

        [Fact]
        public void Throw_Validation_error_If_the_File_Is_Not_found()
        {
            CsvParser csvParser = new CsvParser();
            var result = csvParser.ParseCsvData("BoardGameList1.csv");
            Assert.False(result.IsSucess);
            Assert.Equal("File does not exist in the Location specified", result.Errors);
        }
    }
}
