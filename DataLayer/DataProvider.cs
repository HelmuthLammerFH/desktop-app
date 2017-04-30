using Shared;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        SR_Synchronisation_Dummy.Client client;
        static List<Tour> tourList;
        static TourGuide tourGuide;

        public bool ConnectionExists()
        {
            client = new SR_Synchronisation_Dummy.Client();
            if (client == null)
                return false;
            return true;
        }

        public bool Login(string userName, string passwort)
        {
            if (client.Login(userName, passwort))
            {
                tourGuide = client.GetTourGuid(userName, passwort);
                tourList = client.GetTourListByGuideId(tourGuide.TourGuideID);
                return true;
            }      
            return false;
        }

        public void DeleteTour(Tour tour)
        {
            int index = -1;
            foreach (Tour t in tourList)
            {
                if (t.TourID == tour.TourID)
                    index = tourList.IndexOf(t);
            }
            if (index != -1)
                tourList.RemoveAt(index);
        }

        public List<Tour> QueryAllTours()
        {
            return tourList;
        }

        public void UpdateTour(Tour tour)
        {
            int index = -1;
            foreach (Tour t in tourList)
            {
                if (t.TourID == tour.TourID)
                    index = tourList.IndexOf(t);                
            }
            if(index != -1)
                tourList[index] = tour;
        }
    }
}
