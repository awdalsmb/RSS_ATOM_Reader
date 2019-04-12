using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rss_atom_reader_server.IRepository;
using rss_atom_reader_server.Models;

namespace rss_atom_reader_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly INewsFeedRepository _newsFeedRepository;

        public NewsFeedController(INewsFeedRepository newsFeedRepository)
        {
            _newsFeedRepository = newsFeedRepository;
        }
        // GET api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return this.Get();
        }

        // POST api/[controller]
        [HttpPost]
        public async Task<string> Post([FromBody] NewsFeed newsFeed)
        {
            await _newsFeedRepository.Add(newsFeed);
            return "";
        }

        // DELETE api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<string> Delete()
        {
            await _newsFeedRepository.RemoveAll();
            return "";
        }
    }
}
