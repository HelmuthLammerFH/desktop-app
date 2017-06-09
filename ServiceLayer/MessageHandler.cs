using Newtonsoft.Json;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MessageHandler
    {
        const string path = "http://wi-gate.technikum-wien.at:60632";
        private HttpClient client;

        public MessageHandler()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/users.json?clientID=2").Result;
            users = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings{ NullValueHandling = NullValueHandling.Ignore});
            return users;
        }

        public List<Tour> GetAllTours()
        {
            List<Tour> tours = new List<Tour>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/tours.json?clientID=2").Result;
            tours = JsonConvert.DeserializeObject<List<Tour>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return tours;
        }

        public List<TourPosition> GetAllPositions()
        {
            List<TourPosition> positions = new List<TourPosition>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/tourpositions.json?clientID=2").Result;
            positions = JsonConvert.DeserializeObject<List<TourPosition>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return positions;
        }

        public List<Status> GetAllStatuse()
        {
            List<Status> status = new List<Status>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/statuses.json?clientID=2").Result;
            status = JsonConvert.DeserializeObject<List<Status>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return status;
        }

        public List<TourGuide> GetAllTourGuides()
        {
            List<TourGuide> tourguides = new List<TourGuide>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/tourguides.json?clientID=2").Result;
            tourguides = JsonConvert.DeserializeObject<List<TourGuide>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return tourguides;
        }

        public List<Kunde> GetAllCustomers()
        {
            List<Kunde> customers = new List<Kunde>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/customers.json?clientID=2").Result;
            customers = JsonConvert.DeserializeObject<List<Kunde>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return customers;
        }

        public List<TourToPositions> GetAllToursToPosition()
        {
            List<TourToPositions> tourstoposition = new List<TourToPositions>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/tour_to_positions.json?clientID=2").Result;
            tourstoposition = JsonConvert.DeserializeObject<List<TourToPositions>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return tourstoposition;
        }

        public List<KundeInTour> GetAllCustomersToTour()
        {
            List<KundeInTour> customertotour = new List<KundeInTour>();
            HttpResponseMessage response = client.GetAsync(path + "/api/v1/customer_in_tours.json?clientID=2").Result;
            customertotour = JsonConvert.DeserializeObject<List<KundeInTour>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return customertotour;
            
        }

        public bool SendTour(Tour tour)
        {
            tour.ID = 10630;
            HttpResponseMessage response = client.PutAsync(path + "/api/v1/tours/" + tour.ID + ".json?clientID=2",new StringContent(JsonConvert.SerializeObject(tour).ToString(),Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool SendMediaData(Ressources ressource)
        {

            HttpResponseMessage response = client.PutAsync(path + "/api/v1/ressource_for_tours.json?clientID=2", new StringContent(JsonConvert.SerializeObject(ressource).ToString(), Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool SendTourToPositionen(TourToPositions TourPosition)
        {

            HttpResponseMessage response = client.PutAsync(path + "/api/v1/tour_to_position.json?clientID=2", new StringContent(JsonConvert.SerializeObject(TourPosition).ToString(), Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
