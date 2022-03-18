using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using SmartApartmentElasticsearch.Core.ConfigExtensions;
using SmartApartmentElasticSearch.Models;
using SmartApartmentElasticSearch.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace SmartApartmentElasticsearch.Core.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepo _searchrepo;
        private readonly ILogger<SearchController> _log;
        
        public SearchController (ISearchRepo searchRepo, ILogger<SearchController> log)
            {
            _searchrepo = searchRepo;
            _log = log;
        }

        [HttpGet("match-all")]
        public async Task<IActionResult> MatchAll()
        {
            try
            {
                var result = await _searchrepo.MatchAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
            }

            return BadRequest("Failed to get results");
        }

        // GET api/<SearchController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SearchController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SearchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SearchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
