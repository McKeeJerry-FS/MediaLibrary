﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Shared.Model
{
    public class MovieModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<CategoryType> Categories { get; set; } = new List<CategoryType>();
        public int Year { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? DirectorId { get; set; }
        public int? MusicComposerId { get; set; }
        public int[] ActorIds { get; set; } = Array.Empty<int>();
    }
}
