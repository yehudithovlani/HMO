using ConsoleApp1.Models;
using ConsoleApp1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDetailsController : ControllerBase
    {
    
        // הכנסת פרטים עבור חולה בקורונה 
        [HttpPost]
        public void Post([FromBody] CoronaDetail coronaDetail)
        {

            Service s = new Service();
            s.CreateSickDetails(coronaDetail);
            if (s.CreateSickDetails(coronaDetail))
                Console.WriteLine("succeed");
            else
                Console.WriteLine("error");
        }

        //הצגת כל פירטי קורונה של כל הפציינטים
        [HttpGet]
        public Task<List<CoronaDetail>> GetAllDetails()
        {
            Service s = new Service();
            return s.GetAllDetails();
        }
        // הצגת פרטי קורנה של פציינט ספציפי
        [HttpGet("{id}")]
        public Task<CoronaDetail> GetOneDetails(string id)
        {
            Service s = new Service();
            var one = s.GetOneDetails(id);
            return one;
        }

        // POST: PatientDetailsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
