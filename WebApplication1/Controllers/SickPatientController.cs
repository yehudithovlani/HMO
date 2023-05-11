using ConsoleApp1.Models;
using ConsoleApp1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SickPatientController : ControllerBase
    {

        //החזרת כל הפציינטים שהיו / עכשיו חולים
        [HttpGet]
        public Task<List<SickPatient>> GetAllSick()
        {
            Service s = new Service();
            return s.GetAllSick();
        }
        //החזרת כל הפציינטים שעכשיו חולים
        [HttpGet("sick-patients")]
        public Task<List<SickPatient>> GetAllSickNow()
        {
            Service s = new Service();
            return s.GetAllSickNow();
        }

        //החזרת פציינט שהיה / עשיו חולה ספציפי
        [HttpGet("{id}")]
        public Task<SickPatient> GetOneSick(string id)
        {
            Service s = new Service();
            var one = s.GetOneSick(id);
            return one;
        }

        //הוספת פציינט שהיה / עכשיו חולה
        [HttpPost]
        public void Post([FromBody] SickPatient sickPatient)
        {
            Service s = new Service();
            s.CreateSick(sickPatient);
            if (s.CreateSick(sickPatient))
                Console.WriteLine("succeed");
            else
                Console.WriteLine("error");
        }
    }
}
