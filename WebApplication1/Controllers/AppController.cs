using ConsoleApp1;
using ConsoleApp1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        //החזרת כל הפציינטים
        [HttpGet]
        public Task<List<Patient>> Get()
        {
            Service s = new Service();
            return s.GetAll();
        }
        //החזרת פציינט נבחר 
        [HttpGet("{id}")]
        public Task<Patient> Get(string id)
        {
            Service s = new Service();
            var one =  s.GetById(id);
            return one;
        }
        //הוספת פציינט
        [HttpPost]
        public void Post([FromBody] Patient patient)
        {
            Service s = new Service();
            s.Create(patient);
            if (s.Create(patient))
                Console.WriteLine("succeed");
            else
                Console.WriteLine("error");
        }

    }
}
