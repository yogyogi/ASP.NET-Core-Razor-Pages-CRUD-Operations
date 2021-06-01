using MovieCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCrud.Paging
{
    public class MovieList
    {
        public IEnumerable<Movie> movie { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}
