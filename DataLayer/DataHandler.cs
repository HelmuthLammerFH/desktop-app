using Shared.DummyEntities;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataHandler
    {
        const string path = "C:\\Users\\Dejvid\\Documents\\Wirtschaftsinformatik\\4.Semester\\Fallstudie 4\\Implementierung\\desktop-app\\DataLayer\\Database\\desktop-app.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=" +  path);
       

        public List<DummyTour> GetAllToursByGuide(int id)
        {
            List<DummyTour> tours = new List<DummyTour>();
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select t.id,t.name,t.maxAttendees,t.price,t.startDate,t.endDate,s.name from tours t INNER JOIN tour_guides tu on tu.id = t.tour_guide_id INNER JOIN statuses s on s.id = t.Status_id where t.tour_guide_id = " + id;
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tours.Add(new DummyTour() { ID = Int16.Parse(reader[0].ToString()), Name = reader[1].ToString(), MaxAttendees = Int16.Parse(reader[2].ToString()), Price = float.Parse(reader[3].ToString()), StartDate = DateTime.Parse(reader[4].ToString()), EndDate = DateTime.Parse(reader[5].ToString()), State = reader[6].ToString()});
                }
                connection.Close();
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return tours;
        }

        public int GetCredentials(string username, string passwort)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select u.id from users u INNER JOIN tour_guides tu on u.id = tu.User_id where u.passwort = '"+ passwort + "' and u.username = '" + username + "'";
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var temp = Int16.Parse(reader[0].ToString());
                    connection.Close();
                    return temp;
                }
                else
                {
                    connection.Close();
                    return 0;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
