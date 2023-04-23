using MediaLibrary.Server.Services;

namespace MediaLibrary.Server.Controllers;

public class MovieController : BaseController<Shared.Models.MovieModel, Data.Movie, MovieService>
{
    public MovieController(MovieService service) : base(service, "/movies")
    {
    }
}
