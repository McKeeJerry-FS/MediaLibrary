using MediaLibrary.Server.Services;

namespace MediaLibrary.Server.Controllers;

public partial class PersonController : BaseController<Shared.Models.PersonModel, Data.Person, PersonService>
{
    public PersonController(PersonService service) : base(service, "/persons")
    {
    }
}