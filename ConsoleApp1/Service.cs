using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Service
    {
        //עידכון שם
        public bool ChangeName(string pid, string name)
        {
            // בגלל שאוביקט גדול מאוד עדיף להרוס אותו כמה שיותר מהר ולכן עושים כך: 
            using (MyDb mydb = new MyDb())
            {
                var seartch = mydb.Patients.ToList().Find(x => x.PersonId == pid) ?? throw new Exception("מוצר לא תקין");

                seartch.FirstName = name;
                mydb.SaveChanges(); // עדכון נתונים בדטה בייס
                return true;
            }


        }
        //הוספת פציינט
        public bool Create(Patient patient)
        {
            DateTime currentTime = DateTime.Now;
            string CellPhone = (patient.CellPhone).ToString();
            string HomePhone = (patient.HomePhone).ToString();
            try
            {
                if (patient == null) throw new ArgumentNullException("No normal patient was entered");
                if (patient.PersonId.Length == 9 ) throw new Exception("Invalid ID number");
                if (patient.FirstName.Length < 2) throw new Exception("Invalid first name");
                if (patient.LastName.Length < 2) throw new Exception("Invalid last name");
                if (patient.DateOfBirth > currentTime) throw new Exception("Invalid date");//לבדוק שכך משווים בין תאריך
                if (patient.City.Length < 2) throw new Exception("Invalid city name");
                if (patient.Street.Length < 2) throw new Exception("Invalid street name");
                if (patient.HouseNumber <= 0) throw new Exception("Invalid house number");
                if (!((CellPhone.Substring(0, 1) == "0") && (CellPhone.Length == 10))) throw new Exception("Invalid Phone number");
                if (!((HomePhone.Substring(0, 1) == "0") && (CellPhone.Length == 10 || CellPhone.Length == 9))) throw new Exception("Invalid house number");
                else
                {
                    MyDb mydb = new MyDb();

                    mydb.Patients.Add(patient);

                    int x = mydb.SaveChanges();

                    return (x == 0) ? false : true;

                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
           
        }
        //החזרת רשימת כל הפציינטים בקופת החולים
        public async Task<List<Patient>> GetAll()
        {
            MyDb mydb = new MyDb();

            var patient = mydb.Patients.ToList<Patient>();

            return patient;
        }
        //החזרת פציינט נבחר
        //מי תופס את השגיאה
        public async Task<Patient> GetById(string id)
        {
            if (id.Length < 8) throw new Exception("Invalid ID number");
            else
            {
                MyDb mydb = new MyDb();

                var patient = mydb.Patients.ToList().Find(p => p.PersonId == id) ?? throw new Exception("There is no patient with this ID");

                return patient;
            }
        }
        // הוספת פציינט שהיה או עכשיו חולה
        public bool CreateSick(SickPatient sickpatient)
        {
            DateTime currentTime = DateTime.Now;
            DateTime future  = sickpatient.PositiveResult.Value.AddDays(14);
            if (sickpatient == null) throw new ArgumentNullException("No normal patient was entered");
            if (sickpatient.PersonId.Length < 8) throw new Exception("Invalid ID number");
            if (sickpatient.PositiveResult > currentTime) throw new Exception("Invalid date");
            if (sickpatient.Recuperation < future) throw new Exception("Invalid date");//לבדוק שכך משווים בין תאריך
            else
            {
                MyDb mydb = new MyDb();

                mydb.SickPatients.Add(sickpatient);

                int x = mydb.SaveChanges();

                return (x == 0) ? false : true;

            }

        }

        //הצגת כל מי שהיה החולים בקורונה
        public async Task<List<SickPatient>> GetAllSick()
        {
            MyDb mydb = new MyDb();

            var sickpatients = mydb.SickPatients.ToList<SickPatient>();
            return sickpatients;
        }
        //הצגת מי שהיה חולה ספציפי
        public async Task<SickPatient> GetOneSick(string id)
        {
            if (id.Length < 8) throw new Exception("Invalid ID number");
            else
            {
                MyDb mydb = new MyDb();

                var sickpatient = mydb.SickPatients.ToList().Find(p => p.PersonId == id) ?? throw new Exception("There is no sick patient with this ID ");

                return sickpatient;
            }

        }
        // הוספת פרטי קורונה 
        public bool CreateSickDetails(CoronaDetail sickpatientDetails)
        {
            DateTime currentTime = DateTime.Now;
            if (sickpatientDetails == null) throw new ArgumentNullException("No normal patient and details was entered");
            if (sickpatientDetails.PersonId.Length < 8) throw new Exception("Invalid ID number");
            if (sickpatientDetails.GettingVaccinated1 > currentTime) throw new Exception("Invalid name of Vaccine Manu facturer");
            if (sickpatientDetails.VaccineManufacturer1.Length<2) throw new Exception("Invalid name of Vaccine Manu facturer");
            else
            {
                MyDb mydb = new MyDb();

                mydb.CoronaDetails.Add(sickpatientDetails);

                int x = mydb.SaveChanges();

                return (x == 0) ? false : true;
            }

        }
        //הצגת כל פירטי קורונה של כל הפציינטים
        public async Task<List<CoronaDetail>> GetAllDetails()
        {
            MyDb mydb = new MyDb();

            var patientDetailsk = mydb.CoronaDetails.ToList<CoronaDetail>();
            return patientDetailsk;
        }
      // הצגת פרטי קורנה של פציינט ספציפי
             public async Task<CoronaDetail> GetOneDetails(string id)
        {
            if (id.Length < 8) throw new Exception("Invalid ID number");
            else
            {
                MyDb mydb = new MyDb();

                var patientDetailsk = mydb.CoronaDetails.ToList().Find(p => p.PersonId == id) ?? throw new Exception("There is no details of patient with this ID");

                return patientDetailsk;
            }

        }
        //שלפית רשימת כל החולים עכשיו
        //שגיאה
        //public async Task<List<SickPatient>> GetAllSickNow()
        //{
        //    DateTime currentTime = DateTime.Now;
        //    MyDb mydb = new MyDb();
        //    var sickpatientsNoe = mydb.SickPatients.ToList().Find(p => p.Recuperation.Value > currentTime)();
        //    return sickpatientsNoe;
        //}

    }
}
