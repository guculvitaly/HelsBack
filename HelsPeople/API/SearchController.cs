using HelsPeople.EFRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelsPeople.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchRepository searchRepository;

        public SearchController(ISearchRepository _searchRepository)
        {
            searchRepository = _searchRepository;
        }

        [HttpGet("_search/{query}")]
       
        public async Task<IActionResult> Search(string query)
        {
            var es = searchRepository.Search(query);

            if (es.Count == 0)
            {
                return NotFound();
            }

            return Ok(es);

        }
    }
}
