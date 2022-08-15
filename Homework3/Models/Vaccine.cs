using homework2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework2.Models
{
    //vaccine class with its properties
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DosesRequired { get; set; }
        public int DaysBetweenDoses { get; set; }
        public int TotalDosesReceived { get; set; }
        public int TotalDosesLeft { get; set; }


        //this method takes an integer and addes to the total doses
        public void AddDoses(int addDoses)
        {
            TotalDosesReceived = TotalDosesReceived + addDoses;
        }

        public void editDoses(int dosesRequired, int daysBetweenDoses)
        {
            this.DosesRequired = dosesRequired;
            this.DaysBetweenDoses = daysBetweenDoses;
        }

        public void TakeDoses(int takeDoses)
        {
            TotalDosesLeft = TotalDosesReceived - takeDoses;
        }

        public Vaccine() {

        }



        //default constructor from previous homework
        public Vaccine(int Id, string Name, int DosesRequired, int DaysBetweenDoses, int TotalDosesReceived, int TotalDosesLeft)
        {


            this.Id = Id;
            this.Name = Name;
            this.DosesRequired = DosesRequired;
            this.DaysBetweenDoses = DaysBetweenDoses;
            this.TotalDosesReceived = TotalDosesReceived;
            this.TotalDosesLeft = TotalDosesLeft;
        }

        public Vaccine(string Name, int DosesRequired, int DaysBetweenDoses)
        {

            int idCounter = 0;
            using var db = new AppDbContext();
            //creating vaccine obj of type List<Vaccine> it will take the entire db data turned into a list
            List<Vaccine> vaccines = db.Vaccines.ToList();


            //pull up number of vaccines in database. once we get the number that shows that we need to increase 
            //by one to get new unique id for new vaccine data.
            foreach (var vaccine in vaccines)
            {
                idCounter++;
            }


            this.Id = idCounter;
            this.Name = Name;
            this.DosesRequired = DosesRequired;
            this.DaysBetweenDoses = DaysBetweenDoses;
            this.TotalDosesReceived = 0;
            this.TotalDosesLeft = 0;
        }



        public override string ToString()
        {
            return $"[{Name}, {DosesRequired}, {DaysBetweenDoses}, {TotalDosesReceived}]";
        }

    }
}
