// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using ConsoleApp1.Models;

public class Program
{
    
    static async void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");

        //Service s = new Service();
        ////עידכון
        //try
        //{
        //    if (s.ChangeName("325301091", "yehuda"))
        //        Console.WriteLine("succeed");
        //    else
        //        Console.WriteLine("error");
        //}

        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
        //Console.Read();
        //החזרת רשימת כל הפציינטים בקופת החולים
        //var all = await s.GetAll();
        //all.ForEach(all => Console.WriteLine(all));
        ////החזרת פציינט נבחר
        //// איך הצד לקוח מכניס תז
        //var one = await s.GetById("325301091");
        //Console.WriteLine(one);
        //// הוספת פציינט
        //// איך הצד לקוח מכניס נתונים
        //DateTime time = DateTime.Now;
        //Patient p = new Patient() { PersonId = "213870413", LastName = "Menaged", FirstName = "Routh", City = "Jerusalem", Street = "Bidan", HouseNumber = 7, DateOfBirth = time, CellPhone = "0583253919", HomePhone = "025825969" };
        //if (s.Create(p))
        //    Console.WriteLine("succeed");
        //else
        //    Console.WriteLine("error");
        //// הוספת פציינט חולה
        //// איך שולחים תאריך
        //DateTime time1 = DateTime.Now;
        //SickPatient sickpatient = new SickPatient() { PersonId = "213870413", PositiveResult = time1, Recuperation = time1 };
        //if (s.CreateSick(sickpatient))
        //    Console.WriteLine("succeed");
        //else
        //    Console.WriteLine("error");
        ////החזרת רשימת כל הפציינטים החולים
        //var allSick = await s.GetAllSick();
        //allSick.ForEach(allSick => Console.WriteLine(allSick));
        ////החזרת פציינט חולה ספציפי
        //var oneSick = await s.GetById("325301091");
        //Console.WriteLine(oneSick);
        //// הכנסת פרטים לחולה ספציפי בקורונה
        //CoronaDetail c = new CoronaDetail() { PersonId = "325301091", GettingVaccinated1 = time1, VaccineManufacturer1 = "faizer" };
        //s.CreateSickDetails(c);
        ////הצגת כל פירטי קורונה של כל הפציינטים
        //var allDetails = await s.GetAllDetails();
        //allDetails.ForEach(allDetails => Console.WriteLine(allDetails));
        ////הצגת פרטי קורנה של פציינט ספציפי
        //var oneDetails = await s.GetOneDetails("325301091");
        //Console.WriteLine(oneDetails);
        ////הצגת כל החולים עכשיו בקורונה
        //var allSickNow = await s.GetAllSickNow();
        //allSickNow.ForEach(allSickNow => Console.WriteLine(allSickNow));
    }
}