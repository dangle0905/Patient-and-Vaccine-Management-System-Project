using homework2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework2.Services
{
    public interface IVaccineService
    {
        List<Vaccine> GetVaccines();
        Vaccine GetVaccine(int id);
        Vaccine GetVaccine(string name);
        void AddVaccine(Vaccine vaccine);
        void AddDoses(int Id, int doses);
        void EditVaccine(int Id, int dosesRequired, int daysBetweenDoses);
        void SaveChanges();

    }
    public class VaccineService : IVaccineService
    {
        private readonly AppDbContext _db;

        //constructor
        public VaccineService(AppDbContext db){
            _db = db;
        }
       


        public List<Vaccine> GetVaccines() {
            return _db.Vaccines.ToList();
        }

        public Vaccine GetVaccine(int id) {
            return _db.Vaccines.Where(e => e.Id == id).SingleOrDefault();
        }

        public Vaccine GetVaccine(string name)
        {
            return _db.Vaccines.Where(e => e.Name == name).SingleOrDefault();
        }


        public void AddVaccine(Vaccine vaccine) {
            _db.Vaccines.Add(vaccine);
            _db.SaveChanges();
        }

        public void AddDoses(int id, int dosesReceived) {

            _db.Vaccines.Find(id).AddDoses(dosesReceived);
            
            _db.SaveChanges();




        }

        public void EditVaccine(int Id, int dosesRequired, int daysBetweenDoses) {

        

            _db.Vaccines.Find(Id).editDoses(dosesRequired,daysBetweenDoses);
             _db.SaveChanges();

        }


        public void SaveChanges() => _db.SaveChanges();




    }


}
