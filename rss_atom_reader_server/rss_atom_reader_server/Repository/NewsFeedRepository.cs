using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using rss_atom_reader_server.DataBaseModels;
using rss_atom_reader_server.IRepository;
using rss_atom_reader_server.Models;
using Remotion.Linq.Clauses;

namespace rss_atom_reader_server.Repository
{
    public class NewsFeedRepository : INewsFeedRepository
    {
        private readonly ObjectContext _context = null;
        List<NewsFeed> feed = new List<NewsFeed>();

        public void MappingXml(string RssFeedUrl)
        {
            try
            {
                XDocument xDoc = new XDocument();
                xDoc = XDocument.Load(RssFeedUrl);
                var news = (from x in xDoc.Descendants("item")
                    select new
                    {
                        title = x.Element("title").Value,
                        link = x.Element("link").Value,
                        pubDate = x.Element("pubDate").Value,
                        description = x.Element("description").Value
                    });

                if (news != null)
                {
                    foreach (var item in news)
                    {
                        NewsFeed n = new NewsFeed
                        {
                            Title = item.title,
                            Link = item.link,
                            Description = item.description,
                            PublishDate = DateTime.Parse(item.pubDate)
                        };

                        feed.Add(n);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public NewsFeedRepository(IOptions<Settings> settings)
        {
            _context = new ObjectContext(settings);
        }

        public async Task Add(NewsFeed feed)
        {
            MappingXml("https://fakty.interia.pl/feed");
            await _context.NewsFeeds.InsertManyAsync(this.feed);
        }

        public Task<IEnumerable<NewsFeed>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<DeleteResult> RemoveAll()
        {
            throw new NotImplementedException();
        }
    }
}
