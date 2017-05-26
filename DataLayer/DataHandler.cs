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
                command.CommandText = "select t.id,t.name,t.maxAttendees,t.price,t.startDate,t.endDate,s.name from tours t INNER JOIN tour_guides tu on tu.id = t.tour_guide_id INNER JOIN statuses s on s.id = t.Status_id where t.tour_guide_id = " + id + " and t.deleteFlag <> 1";
                SQLiteDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    tours.Add(new DummyTour() { ID = Int16.Parse(reader[0].ToString()), Name = reader[1].ToString(), MaxAttendees = Int16.Parse(reader[2].ToString()), Price = float.Parse(reader[3].ToString()), StartDate = DateTime.Parse(reader[4].ToString()), EndDate = DateTime.Parse(reader[5].ToString()), State = reader[6].ToString() });
                }
                SQLiteCommand command2 = new SQLiteCommand(connection);
                for (int i = 0; i < tours.Count; i++)
                { 
                    command2.CommandText = "Select tp.id,tp.name,ttp.startdate, ttp.enddate,ttp.price,tp.position from tour_positions tp INNER JOIN tour_to_tour_positions ttp on tp.id = ttp.tour_position_id where ttp.Tour_id = " + tours[i].ID + " and tp.deleteFlag <> 1";
                    SQLiteDataReader readerPosition = command2.ExecuteReader();
                    tours[i].Positions = new List<DummyPosition>();
                    while (readerPosition.Read())
                    {
                        tours[i].Positions.Add(new DummyPosition() { PositionID = Int16.Parse(readerPosition[0].ToString()), Title = readerPosition[1].ToString(), Startdate = DateTime.Parse(readerPosition[2].ToString()), Enddate = DateTime.Parse(readerPosition[3].ToString()), Cost = Int16.Parse(readerPosition[4].ToString()), GPSPosition = readerPosition[5].ToString() });
                    }
                    command2.Dispose();
                }
                SQLiteCommand command3 = new SQLiteCommand(connection);
                for (int i = 0; i < tours.Count; i++)
                {
                    command3.CommandText = "select c.id,cit.participated,u.id,u.firstname, u.lastname, u.birthdate, u.address, u.city,u.email from customers c INNER JOIN users u on u.id = c.User_id INNER JOIN customer_in_tours cit on cit.Customer_id = c.id where cit.Tour_id = " + tours[i].ID + " and u.deleteflag <> 1";
                    SQLiteDataReader readerMembers = command3.ExecuteReader();
                    tours[i].Members = new List<DummyMember>();
                    while (readerMembers.Read())
                    {
                        tours[i].Members.Add(new DummyMember() {MemberID = Int16.Parse(readerMembers[0].ToString()), AttendTour = Boolean.Parse(readerMembers[1].ToString()), User = new DummyUser() { ID = Int16.Parse(readerMembers[2].ToString()), Firstname = readerMembers[3].ToString(), Lastname = readerMembers[4].ToString(), Birthdate = DateTime.Parse(readerMembers[5].ToString()), Address= readerMembers[6].ToString(), City = readerMembers[7].ToString(), Email = readerMembers[8].ToString() } });
                    }
                    command3.Dispose();
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
