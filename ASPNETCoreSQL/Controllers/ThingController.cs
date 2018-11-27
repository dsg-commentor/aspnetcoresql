using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreSQL.Data;

namespace ASPNETCoreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        private DataContext _dataContext;

        public ThingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public Thing Thing(int id)
        {
            return _dataContext.Things.Find(id);
        }

        [HttpGet]
        public IEnumerable<Thing> Things()
        {
            return _dataContext.Things;
        }

        [HttpPost]
        public Thing Thing(Thing thing)
        {
            _dataContext.Add(thing);
            _dataContext.SaveChanges();
            return thing;
        }

    }
}