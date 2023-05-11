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
            try
            {
                // בגלל שהאוביקט גדול מאוד עדיף להרוס אותו כמה שיותר מהר ולכן עושים כך: 
                using (MyDb mydb = new MyDb())
                {
                    var seartch = mydb.Patients.ToList().Find(x => x.PersonId == pid) ?? throw new Exception("מוצר לא תקין");

                    seartch.FirstName = name;
                    mydb.SaveChanges(); // עדכון נתונים בדטה בייס
                    return true;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

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
                if (patient.PersonId.Length == 9) throw new Exception("Invalid ID number");
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

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }
        //החזרת רשימת כל הפציינטים בקופת החולים
        public async Task<List<Patient>> GetAll()
        {
            MyDb mydb = new MyDb();
            try
            {
                var patient = mydb.Patients.ToList<Patient>();
                return patient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Patient>();
            }



        }
        //החזרת פציינט נבחר
        public async Task<Patient> GetById(string id)
        {
            try
            {
                if (id.Length != 9) throw new Exception("Invalid ID number");
                else
                {
                    MyDb mydb = new MyDb();

                    var patient = mydb.Patients.ToList().Find(p => p.PersonId == id) ?? throw new Exception("There is no patient with this ID");

                    return patient;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Patient();
            }

        }
        // הוספת פציינט שהיה או עכשיו חולה
        public bool CreateSick(SickPatient sickpatient)
        {
            DateTime currentTime = DateTime.Now;
            try
            {
                DateTime future = sickpatient.PositiveResult.Value.AddDays(14);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //הצגת כל מי שהיה חולה בקורונה
        public async Task<List<SickPatient>> GetAllSick()
        {
            MyDb mydb = new MyDb();
            try
            {
                var sickpatients = mydb.SickPatients.ToList<SickPatient>();
                return sickpatients;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<SickPatient>();
            }

        }
        //הצגת מי שהיה חולה ספציפי
        public async Task<SickPatient> GetOneSick(string id)
        {
            try
            {
                if (id.Length != 9) throw new Exception("Invalid ID number");
                else
                {
                    MyDb mydb = new MyDb();

                    var sickpatient = mydb.SickPatients.ToList().Find(p => p.PersonId == id) ?? throw new Exception("There is no sick patient with this ID ");

                    return sickpatient;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new SickPatient();
            }

        }
        // הוספת פרטי קורונה 
        public bool CreateSickDetails(CoronaDetail sickpatientDetails)
        {
            DateTime currentTime = DateTime.Now;
            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //הצגת כל פירטי קורונה של כל הפציינטים
        public async Task<List<CoronaDetail>> GetAllDetails()
        {
            MyDb mydb = new MyDb();
            try
            {
                var patientDetailsk = mydb.CoronaDetails.ToList<CoronaDetail>();
                return patientDetailsk;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<CoronaDetail>();
            }

        }
        // הצגת פרטי קורנה של פציינט ספציפי
        public async Task<CoronaDetail> GetOneDetails(string id)
        {
            try
            {
                if (id.Length != 9) throw new Exception("Invalid ID number");
                else
                {
                    MyDb mydb = new MyDb();

                    var patientDetailsk = mydb.CoronaDetails.ToList().Find(p => p.PersonId == id) ?? throw new Exception("There is no details of patient with this ID");

                    return patientDetailsk;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new CoronaDetail();
            }


        }
        //שלפית רשימת כל החולים עכשיו
        public async Task<List<SickPatient>> GetAllSickNow()
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                MyDb mydb = new MyDb();
                var sickPatientsNow = mydb.SickPatients.ToList().FindAll(p => p.Recuperation.Value > currentTime)?? throw new Exception("There are no sick patients now "); ;
                return sickPatientsNow;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<SickPatient>();
            }


        }

    }
}
