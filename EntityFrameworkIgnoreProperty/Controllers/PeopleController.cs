using EntityFrameworkIgnoreProperty.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace EntityFrameworkIgnoreProperty.Controllers
{
    public class PeopleController : ODataController
    {
        private Context Context;

        public PeopleController()
        {
            this.Context = new Context();
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Person> Get()
        {
            return this.Context.People;
        }
    }
}