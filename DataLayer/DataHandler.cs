using Shared.DummyEntities;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataLayer
{
    public class DataHandler
    {
        const string path =  @"Database\desktop-app.db";
        SQLiteConnection connection = new SQLiteConnection("Data Source=" +  path);
       

        public List<DummyTour> GetAllToursByGuide(int id)
        {
            List<DummyTour> tours = new List<DummyTour>();
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select t.id,t.name,t.maxAttendees,t.price,t.startDate,t.endDate,s.name from tours t INNER JOIN tourguides tu on tu.id = t.tourguide_id INNER JOIN statuses s on s.id = t.Status_id where t.tourguide_id = " + id + " and t.deleteFlag <> 'True'";
                SQLiteDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    tours.Add(new DummyTour() { ID = Int16.Parse(reader[0].ToString()), Name = reader[1].ToString(), MaxAttendees = Int16.Parse(reader[2].ToString()), Price = Single.Parse(reader[3].ToString()), StartDate = DateTime.Parse(reader[4].ToString()), EndDate = DateTime.Parse(reader[5].ToString()), State = reader[6].ToString() });
                }
                SQLiteCommand command2 = new SQLiteCommand(connection);
                for (int i = 0; i < tours.Count; i++)
                { 
                    command2.CommandText = "Select tp.id,tp.name,ttp.startdate, ttp.enddate,tp.price,tp.position,tp.description from tourpositions tp INNER JOIN tour_to_positions ttp on tp.id = ttp.Tourposition_id where ttp.Tour_id = " + tours[i].ID + " and tp.deleteFlag <> 'True'";
                    SQLiteDataReader readerPosition = command2.ExecuteReader();
                    tours[i].Positions = new List<DummyPosition>();
                    while (readerPosition.Read())
                    {
                        tours[i].Positions.Add(new DummyPosition() { PositionID = Int16.Parse(readerPosition[0].ToString()), Title = readerPosition[1].ToString(), Startdate = DateTime.Parse(readerPosition[2].ToString()), Enddate = DateTime.Parse(readerPosition[3].ToString()), Cost = Single.Parse(readerPosition[4].ToString()), GPSPosition = readerPosition[5].ToString(), Description = readerPosition[6].ToString() });
                    }
                    command2.Dispose();
                }
                SQLiteCommand command3 = new SQLiteCommand(connection);
                for (int i = 0; i < tours.Count; i++)
                {
                    command3.CommandText = "select c.id,cit.participated,u.id,u.firstname, u.lastname, u.birthdate, u.address, u.city,u.email from customers c INNER JOIN users u on u.id = c.User_id INNER JOIN customer_in_tours cit on cit.Customer_id = c.id where cit.Tour_id = " + tours[i].ID + " and u.deleteflag <> 'True'";
                    SQLiteDataReader readerMembers = command3.ExecuteReader();
                    tours[i].Members = new List<DummyMember>();
                    while (readerMembers.Read())
                    {
                        bool participated = false;
                        switch (readerMembers[1].ToString())
                        {
                            case "0":
                                participated = false;
                                break;
                            case "1":
                                participated = true;
                                break;
                            default:
                                participated = false;
                                break;
                        }
                        tours[i].Members.Add(new DummyMember() {MemberID = Int16.Parse(readerMembers[0].ToString()), AttendTour = participated, User = new DummyUser() { ID = Int16.Parse(readerMembers[2].ToString()), Firstname = readerMembers[3].ToString(), Lastname = readerMembers[4].ToString(), Birthdate = DateTime.Parse(readerMembers[5].ToString()), Address= readerMembers[6].ToString(), City = readerMembers[7].ToString(), Email = readerMembers[8].ToString() } });
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

        public int? UpdateMembers(int tourid, int memberid, int participated)
        {
            try
            {

                int? affectedID = null;
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT id from customer_in_tours where customer_id = @customer_id and tour_id = @tour_id";
                command.Parameters.AddWithValue("@customer_id", memberid);
                command.Parameters.AddWithValue("@tour_id", tourid);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    affectedID = Int16.Parse(reader[0].ToString());
                    reader.Close();
                }
                else
                {
                    connection.Close();
                    return null;
                }
                command.Parameters.Clear();
                command.CommandText = "UPDATE customer_in_tours SET participated = " + participated + " WHERE customer_id = " + memberid + " and tour_id = " + tourid;
                command.ExecuteScalar();
                connection.Close();
                return affectedID;
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<DummyStatus> GetAllStatus()
        {
            List<DummyStatus> status = new List<DummyStatus>();
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select id,name from statuses";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    status.Add(new DummyStatus() { ID = Int16.Parse(reader[0].ToString()), Description = reader[1].ToString()});
                }
                connection.Close();
            }
            catch(Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
            return status;
        }

        public List<DummyPosition> GetAllPositions()
        {
            List<DummyPosition> positions = new List<DummyPosition>();
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select id,name,position,description,price,createdFrom,changedFrom from tourpositions where deleteFlag <> 'True'";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    positions.Add(new DummyPosition() { PositionID = Int16.Parse(reader[0].ToString()), Title = reader[1].ToString(), GPSPosition = reader[2].ToString(), Description = reader[3].ToString(), Cost = float.Parse(reader[4].ToString()), CreatedFrom = reader[5].ToString(), ChangedFrom = reader[6].ToString() });
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
            return positions;
        }

        public DummyRating GetRatingForMember(int memberID, int tourID)
        {
            DummyRating rating = new DummyRating();
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select id,starRating,feedbackTourGuid from customer_in_tours where customer_ID = " + memberID + " and tour_ID = " + tourID + " and deleteFlag <> 'True'";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rating = new DummyRating() { ID = Int16.Parse(reader[0].ToString()), StarRating = Int32.Parse(reader[1].ToString()), Feedback = reader[2].ToString() };
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
            return rating;
        }

        public void SaveRating(int id, int rating, string feedback)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "update CUSTOMER_IN_TOURS set starRating=@rating, feedbackTourGuid=@feedback WHERE id =@id";
                command.Parameters.AddWithValue("@rating", rating);
                command.Parameters.AddWithValue("@feedback", feedback);
                command.Parameters.AddWithValue("@id",id);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateTour(int id, string name,DateTime startDate, DateTime endtime,string status)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "UPDATE tours SET Name = '"+name+"', startDate = '"+startDate.ToString("yyyy-MM-dd HH:mm:ss") + "', endDate = '" + endtime.ToString("yyyy-MM-dd HH:mm:ss") + "', status_id = (select id from statuses where name = '" + status+"') WHERE id = "+ id;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public bool DeletePosition(int tourid, int positionid)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "DELETE FROM tour_to_positions WHERE tour_id = "+ tourid + " and Tourposition_id =" + positionid;
                command.ExecuteScalar();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public int GetCredentials(string username, string passwort)
        {
            try
            {
               
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "select tu.id, u.passwort from users u INNER JOIN tourguides tu on u.id = tu.User_id where u.username = '" + username + "'";
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (!BCrypt.CheckPassword(passwort, "$2y$10$" + reader[1].ToString()))
                    {
                        connection.Close();
                        return 0;
                    }
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
                connection.Close();
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public int? SavePicture(int tourid, byte[] picture)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "Insert into ressource_for_tours(id, picture,created_at,updated_at,tour_id) values((select IFNULL(MAX(id),0) + 1 from ressource_for_tours),'" + Convert.ToBase64String(picture)+"','"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',"+ tourid + ")";
                command.ExecuteNonQuery();
                command.CommandText = "Select IFNULL(MAX(id),0) FROM ressource_for_tours";
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
                    return null;
                }
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void InsertCustomer(Kunde customer)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO customers(id,note,createdFrom,changedFrom,syncedFrom,deleteFlag,user_id,created_at,updated_at) VALUES "+
                    "("+ customer.ID+",'"+ customer.Note+"','"+ customer.CreatedFrom+"','"+ customer.ChangedFrom+"',"+ customer.SyncedFrom+",'"+ customer.DeleteFlag+"',"+ customer.UserID+",'"+ customer.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','"+ customer.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void InsertCustomerToTours(KundeInTour customertotours)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO customer_in_tours(id,bookedDate,participated,starRating,feedbackTourGuid,createdFrom,changedFrom,syncedFrom,deleteFlag,customer_id,tour_id,created_at,updated_at) VALUES " +
                    "(" + customertotours.ID + ",'" + customertotours.BookedDate.ToString("yyyy-MM-dd HH:mm:ss") + "',"+ customertotours.Participated+ ","+customertotours.StarRating+",'"+ customertotours.FeedbackTourGuid+ "','" + customertotours.CreatedFrom + "','"+customertotours.ChangedFrom + "'," +customertotours.SyncedFrom + ",'"+customertotours.DeleteFlag + "'," + customertotours.CustomerID + "," + customertotours.TourID + ",'" + customertotours.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + customertotours.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void InsertStatus(Status state)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO statuses(id,name,createdFrom,changedFrom,syncedFrom,deleteFlag,created_at,updated_at) VALUES " +
                    "(" + state.ID + ",'" + state.Name + "','" + state.CreatedFrom + "','" + state.ChangedFrom + "'," + state.SyncedFrom + ",'" + state.DeleteFlag + "','" + state.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + state.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void InsertTourGuides(TourGuide tourguide)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO tourguides(id,tourGuideSince,createdFrom,changedFrom,syncedFrom,deleteFlag,user_id,created_at,updated_at) VALUES " +
                    "(" + tourguide.ID + ",'" + tourguide.TourGuideSince.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tourguide.CreatedFrom + "','" + tourguide.ChangedFrom + "'," + tourguide.SyncedFrom + ",'" + tourguide.DeleteFlag + "',"+tourguide.UserID+ ",'" + tourguide.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tourguide.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void InsertTourPosition(TourPosition tourposition)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO tourpositions(id,name,position,description,price,createdFrom,changedFrom,syncedFrom,deleteFlag,created_at,updated_at) VALUES " +
                    "(" + tourposition.ID + ",'" + tourposition.Name + "','" + tourposition.Position + "','" + tourposition.Description + "'," + tourposition.Price + ",'" + tourposition.CreatedFrom + "','" + tourposition.ChangedFrom + "'," + tourposition.SyncedFrom + ",'" + tourposition.DeleteFlag + "','" + tourposition.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tourposition.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void InsertTour(Tour tour)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO tours(id,name,maxAttendees,price,startDate,endDate,createdFrom,changedFrom,syncedFrom,deleteFlag,status_id,Tourguide_id,created_at,updated_at) VALUES " +
                    "(" + tour.ID + ",'" + tour.Name + "'," + tour.MaxAttendees + "," + tour.Price + ",'" + tour.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tour.EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tour.CreatedFrom + "','" + tour.ChangedFrom + "'," + tour.SyncedFrom + ",'" + tour.DeleteFlag + "',"+tour.StatusID+","+tour.TourGuideID+",'" + tour.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tour.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public void InsertTourToPositions(TourToPositions tourtoposition)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO tour_to_positions(id,startDate,endDate,createdFrom,changedFrom,syncedFrom,deleteFlag,tour_id,Tourposition_id,created_at,updated_at) VALUES" +
                    "(" + tourtoposition.ID + ",'" + tourtoposition.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tourtoposition.EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tourtoposition.CreatedFrom + "','" + tourtoposition.ChangedFrom + "'," + tourtoposition.SyncedFrom + ",'" + tourtoposition.DeleteFlag + "',"+tourtoposition.TourID+","+ tourtoposition.TourpositionID+ ",'" + tourtoposition.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + tourtoposition.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }

        public int? UpdateTourToPositions(TourToPositions tourtoposition)
        {
            try
            {
                int? affectedID = null;
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT id from tour_to_positions where tour_id = @tour_id and Tourposition_id = @tourPosition_Id";
                command.Parameters.AddWithValue("@tour_id", tourtoposition.TourID);
                command.Parameters.AddWithValue("@tourPosition_Id", tourtoposition.TourpositionID);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    affectedID = Int16.Parse(reader[0].ToString());
                    reader.Close();
                }
                else
                {
                    connection.Close();
                    return null;
                }
                command.Parameters.Clear();
                command.CommandText = "UPDATE tour_to_positions " +
                    "set startDate = @startDate, endDate = @endDate , changedFrom = @changedFrom, syncedFrom = @syncedFrom, updated_at = @updated_at, deleteFlag=@deleteFlag" +
                    " where tour_id = @tour_id and Tourposition_id = @tourPosition_Id";
                command.Parameters.AddWithValue("@startDate", tourtoposition.StartDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@endDate", tourtoposition.EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@changedFrom", tourtoposition.ChangedFrom);
                command.Parameters.AddWithValue("@syncedFrom", tourtoposition.SyncedFrom);
                command.Parameters.AddWithValue("@updated_at", tourtoposition.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@deleteFlag", tourtoposition.DeleteFlag);
                command.Parameters.AddWithValue("@tour_id", tourtoposition.TourID);
                command.Parameters.AddWithValue("@tourPosition_Id", tourtoposition.TourpositionID);

                command.ExecuteNonQuery();
                connection.Close();
                return affectedID;
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void InsertUsers(User user)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "INSERT or Replace INTO users(id,firstname,lastname,birthdate,address,city,email,username,passwort,createdFrom,changedFrom,syncedFrom,deleteFlag,created_at,updated_at) VALUES " +
                    "(" + user.ID + ",'" + user.Firstname + "','" + user.Lastname + "','" + user.Birthdate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + user.Address + "','" + user.City + "','" + user.Email + "','" + user.Username + "','" + user.Passwort + "',"+
                    "'" + user.CreatedFrom + "','" + user.ChangedFrom + "'," + user.SyncedFrom + ",'" + user.DeleteFlag + "','" + user.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "','" + user.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
            }
        }


        public int? DeleteTourToPositions(TourToPositions tourtoposition)
        {
            try
            {
                int? affectedID = null;
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "SELECT id from tour_to_positions where tour_id = @tour_id and Tourposition_id = @tourPosition_Id";
                command.Parameters.AddWithValue("@tour_id", tourtoposition.TourID);
                command.Parameters.AddWithValue("@tourPosition_Id", tourtoposition.TourpositionID);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    affectedID = Int16.Parse(reader[0].ToString());
                    reader.Close();
                }
                else
                {
                    connection.Close();
                    return null;
                }
                command.Parameters.Clear();
                command.CommandText = "DELETE FROM tour_to_positions " +
                    " where tour_id = @tour_id and Tourposition_id = @tourPosition_Id and id = @id";
                command.Parameters.AddWithValue("@id", affectedID);
                command.Parameters.AddWithValue("@tour_id", tourtoposition.TourID);
                command.Parameters.AddWithValue("@tourPosition_Id", tourtoposition.TourpositionID);

                command.ExecuteNonQuery();
                connection.Close();
                return affectedID;
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Betrifft Tour_to_Positions
        public int? InsertPosition(int tourid, int positionid, DateTime date)
        {
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = "Insert or Replace into tour_to_positions(id, tour_id, Tourposition_id,startDate,endDate,created_at, updated_at) values((select IFNULL(MAX(id),0)+1 from tour_to_positions)," + tourid + "," + positionid + ",'" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "','" + date.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                command.ExecuteNonQuery();
                command.CommandText = "Select IFNULL(MAX(id),0) FROM tour_to_positions";
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
                    return null;
                }
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
