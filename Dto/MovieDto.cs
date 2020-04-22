using System;
using System.Collections.Generic;

namespace CGIBack.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<string> Categories { get; set; }

        public decimal Rating { get; set; }
        public string Description { get; set; }
    }
}
