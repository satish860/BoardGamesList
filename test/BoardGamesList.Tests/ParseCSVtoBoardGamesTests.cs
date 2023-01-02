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

        }

        [Fact]
        public void Should_be_ParseCSVAndGetMechanics()
        {

        }

        [Fact]
        public void Should_Be_Able_to_Parse_Domains()
        {

        }

        [Fact]
        public void Validate_If_the_Fields_Are_of_correct_Value()
        {

        }

        [Fact]
        public void Throw_Validation_error_If_the_File_Is_Not_found()
        {
            CsvParser csvParser = new CsvParser();
            var result = csvParser.ParseCsvData("somelocation");
            Assert.False(result.IsSucess);
            Assert.Equal("File does not exist in the Location specified", result.Errors);
        }
    }
}
