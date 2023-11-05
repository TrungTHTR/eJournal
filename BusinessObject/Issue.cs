﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessObject
{
    public  class Issue:BaseEntity
    {
        public string Volumn { get; set; }
        public string Description { get; set; }
        public DateTime DateRelease { get; set; }
        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
