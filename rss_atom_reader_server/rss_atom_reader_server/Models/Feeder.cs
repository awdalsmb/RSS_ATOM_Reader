using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rss_atom_reader_server.Models
{
    public class Feeder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string PublishDate { get; set; }
        public string Description { get; set; }
    }
}
