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
        string testUserName = "test";
        string testPasswort = "test";

        public bool ConnectionExists()
        {
            //try Synchronisation
            return true;
        }

        public bool Login(string userName, string passwort)
        {
            //if credentials from Syncronisation then load static lists
            if (userName == testUserName && passwort == testPasswort)
                return true;
            return false;
        }

        public void DeleteTour(Tour tour)
        {
            throw new NotImplementedException();
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
