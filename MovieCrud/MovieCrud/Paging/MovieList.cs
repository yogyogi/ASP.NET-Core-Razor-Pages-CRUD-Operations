using MovieCrud.Models;

namespace MovieCrud.Paging
{
    public class MovieList
    {
        public IEnumerable<Movie> movie { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}
