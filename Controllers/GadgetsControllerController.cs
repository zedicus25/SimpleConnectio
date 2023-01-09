using Microsoft.AspNetCore.Mvc;
using SimpleConnectio.DBController;
using SimpleConnectio.Models;

namespace SimpleConnectio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GadgetsControllerController : Controller
    {


        [HttpGet]
        [Route("GetAll")]
        public IResult Get()
        {
            return Results.Json(new SmartphonesController().GetAll());
        }

        [HttpPost]
        [Route("Add")]
        public IResult Add([FromForm]Smartphone smartphone)
        {
            return new SmartphonesController().Add(smartphone) ? Results.StatusCode(201) : Results.StatusCode(400);
        }

        [HttpDelete]
        [Route("Delete")]
        public IResult Remove([FromForm] int id)
        {
            return new SmartphonesController().Remove(id) ? Results.StatusCode(200) : Results.StatusCode(400);
        }

        [HttpPut]
        [Route("Update")]
        public IResult Update([FromForm] int id, Smartphone smartphone)
        {
            return new SmartphonesController().Update(id, smartphone) ? Results.StatusCode(200) : Results.StatusCode(400);
        }
    }
}
