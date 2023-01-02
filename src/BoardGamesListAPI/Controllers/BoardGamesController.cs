using BoardGamesListAPI.Domain;
using Marten;
using Marten.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesListAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BoardGamesController : ControllerBase
    {
        private readonly IDocumentStore documentStore;

        public BoardGamesController(IDocumentStore documentStore)
        {
            this.documentStore = documentStore;
        }

        [HttpGet]
        public async Task<ActionResult<RestDTO<List<BoardGames>>>> Get(
            int pageIndex = 1
            , int pagesize = 10
            , string sortColumn = "Name",
             string sortOrder = "ASC")
        {
            using (var session = documentStore.LightweightSession())
            {
                var query = session.Query<BoardGames>();
                if (sortOrder == "ASC")
                    query.OrderBy(p => p.Name);
                else
                {
                    query.OrderByDescending(p => p.Name);
                }
                var dbResult= await query.ToPagedListAsync(pageIndex,pagesize);

                var responsedata = new RestDTO<List<BoardGames>>
                {
                    Data = dbResult.ToList(),
                    PageIndex = dbResult.PageNumber,
                    PageSize = dbResult.PageSize,
                    TotalCount = dbResult.TotalItemCount
                };
                return Ok(responsedata);
            }
        }
    }
}
