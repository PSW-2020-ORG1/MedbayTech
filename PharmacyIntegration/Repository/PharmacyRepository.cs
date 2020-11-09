using PharmacyIntegration.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace PharmacyIntegration.Repository
{
    public class PharmacyRepository
    {
        private MySqlContext Context;

        public PharmacyRepository(MySqlContext Context)
        {
            this.Context = Context;
        }

        public PharmacyRepository()
        {
        }

        public bool Add(Pharmacy pharmacy)
        {
            if(Context.Pharmacies.FirstOrDefault(p => p.Id.Equals(pharmacy.Id)) != null)
            {
                return false;
            }

            Context.Pharmacies.Add(pharmacy);
            Context.SaveChanges();
            return true;
        }

        public bool Remove(string Id)
        {
            Pharmacy p = Context.Pharmacies.FirstOrDefault(p => p.Id.Equals(Id));
            if (p == null)
            {
                return false;
            }
            Context.Pharmacies.Remove(p);
            Context.SaveChanges();
            return true;
        }

        public bool Update(Pharmacy pharmacy)
        {
            Pharmacy p = Context.Pharmacies.FirstOrDefault(p => p.Id.Equals(pharmacy.Id));
            if(p == null)
            {
                return false;
            }
            Context.Pharmacies.Update(pharmacy);
            Context.SaveChanges();
            return true;
        }

        public Pharmacy Get(string Id)
        {
            Pharmacy p = this.GetAll().FirstOrDefault(p => p.Id.Equals(Id));
            
            return p;
            //  return this.GetAll().FirstOrDefault(p => p.Id.Equals(Id));
        }

        public List<Pharmacy> GetAll()
        {
            return Context.Pharmacies.ToList<Pharmacy>();
        }
    }
}
