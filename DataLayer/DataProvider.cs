using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        public void DeleteTour(Tour tour)
        {
            throw new NotImplementedException();
        }

        public bool Login(string userName, string passwort, bool angemeldetBleiben)
        {
            //anmelden und daten in ein statische liste laden
            return true;
        }

        public List<Tour> QueryAllTours()
        {
            throw new NotImplementedException();
        }

        public void UpdateTour(Tour tour)
        {
            throw new NotImplementedException();
        }
    }
}
