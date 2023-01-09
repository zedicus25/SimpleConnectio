using Microsoft.AspNetCore.Mvc;
using SimpleConnectio.Models;

namespace SimpleConnectio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmarphonesController
    {
        private  SmartphonesDataBaseContext _context = new SmartphonesDataBaseContext();

        [HttpGet]
        [Route("GetAll")]
        public IResult Get()
        {
            return Results.Json(_context.Smartphones.ToList());
        }

        [HttpPost]
        [Route("Add")]
        public IResult Add([FromForm]Smartphone smartphone)
        {
            if (smartphone == null)
                return Results.StatusCode(400);

            _context.Smartphones.Add(smartphone);
            _context.SaveChanges();
            return Results.StatusCode(201);
        }

        [HttpDelete]
        [Route("Delete")]
        public IResult Remove([FromForm] int id)
        {
            if (id <= 0)
                return Results.StatusCode(400);

            var con = _context.Smartphones.FirstOrDefault(x => x.Id == id);
            if (con == null)
                return Results.StatusCode(404);
            _context.Smartphones.Remove(con);
            _context.SaveChanges();
            return Results.StatusCode(200);
        }

        [HttpPut]
        [Route("Update")]
        public IResult Update([FromForm] int id, Smartphone smartphone)
        {
            if (id <= 0)
                return Results.StatusCode(400);

            var con = _context.Smartphones.FirstOrDefault(x => x.Id == id);
            if (con == null)
                return Results.StatusCode(404);

            con.Model = smartphone.Model;
            con.Name = smartphone.Name;

            _context.SaveChanges();
            return Results.StatusCode(200);
        }
    }
}
