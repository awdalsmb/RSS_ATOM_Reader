﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rss_atom_reader_server.Models
{
    public class NewsFeed
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonRequired]
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
    }
}