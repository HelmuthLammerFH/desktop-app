using Shared;
using Shared.DummyEntities;
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
        static List<DummyTour> tourList;
        static List<DummyTourGuide> tourGuideList;
        static DummyTourGuide tourGuide;

        public bool ConnectionExists()
        {
            client = new SR_Synchronisation_Dummy.Client();
            if (client == null)
                return false;
            return true;
        }

        public void Synchronies()
        {
            client.SetTourList(tourList);
        }

        public bool Login(string userName, string passwort)
        {
            if (client.Login(userName, passwort))
            {
                tourGuide = client.GetTourGuide(userName, passwort);
                tourGuideList = client.GetTourGuideList();
                tourList = client.GetTourListByGuideId(tourGuide.TourGuideID);
                return true;
            }      
            return false;
        }

        public void DeleteTour(DummyTour tour)
        {
            int index = -1;
            foreach (DummyTour t in tourList)
            {
                if (t.TourID == tour.TourID)
                    index = tourList.IndexOf(t);
            }
            if (index != -1)
                tourList.RemoveAt(index);
        }

        public List<DummyTourGuide> QueryAllTourGuides()
        {
            return tourGuideList;
        }

        public List<DummyTour> QueryAllTours()
        {
            return tourList;
        }

        public void UpdateTour(DummyTour tour)
        {
            int index = -1;
            foreach (DummyTour t in tourList)
            {
                if (t.TourID == tour.TourID)
                    index = tourList.IndexOf(t);                
            }
            if(index != -1)
                tourList[index] = tour;
        }
        public void SaveTour(DummyTour tour)
        {
            tour.TourID = Guid.NewGuid();
            tourList.Add(tour);
        }
    }
}
