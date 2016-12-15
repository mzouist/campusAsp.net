using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CampusTravel.Models
{
    public class CampusDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\UHM\ICS 415\Assignment 7\CampusTravel\CampusTravel\Campus1200Database.mdf;Integrated Security=True;Connect Timeout=30";
        
        public IEnumerable<AgentViewModels> GetAgentBookings()
        {
            List<AgentViewModels> list = new List<AgentViewModels>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "SELECT AgentName, OfficeLocation, SUM(1) AS NumBookings, SUM(IIF(Amount IS NULL, 0, Amount)) AS Total" +
                " FROM AGENT LEFT JOIN OFFICE ON OfficeKey=OfficeId LEFT JOIN SALE ON AgentKey=AgentId" +
                " GROUP BY AgentName, OfficeLocation ORDER BY Total DESC";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var model = new AgentViewModels();
                        model.agentName = reader["AgentName"].ToString();
                        model.numBookings = (int)reader["NumBookings"];
                        model.total = (decimal)reader["Total"];
                        model.officeLocation = reader["OfficeLocation"].ToString();
                        list.Add(model);
                    }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }
            return list;   
        }

        public IEnumerable<SaleViewModels> GetSales()
        {
            List<SaleViewModels> list = new List<SaleViewModels>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "SELECT SaleId, SaleDate, Amount, DestinationName, AgentName, OfficeLocation "+
                    "FROM SALE INNER JOIN AGENT ON AgentKey=AgentId INNER JOIN OFFICE ON OfficeKey=OfficeId INNER JOIN "+
                    "DESTINATION ON DestinationKey=DestinationId";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var model = new SaleViewModels();
                        model.saleId = (int)reader["SaleId"];
                        model.saleDate = (DateTime)reader["SaleDate"];
                        model.amount = (decimal)reader["Amount"];
                        model.destinationName = reader["DestinationName"].ToString();
                        model.agentName = reader["AgentName"].ToString();
                        model.officeLocation = reader["OfficeLocation"].ToString();
                        list.Add(model);
                    }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }
            return list;
        }

        public List<AgentViewModels> GetLocations()
        {
            List<AgentViewModels> list = new List<AgentViewModels>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "SELECT * FROM OFFICE";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var model = new AgentViewModels();
                        model.officeId = (int)reader["OfficeId"];
                        model.officeLocation = reader["OfficeLocation"].ToString();
                        list.Add(model);
                    }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }
            return list;

        }

        public List<AgentViewModels> GetAgents()
        {
            List<AgentViewModels> list = new List<AgentViewModels>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "SELECT * FROM AGENT";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var model = new AgentViewModels();
                        model.agentId = (int)reader["AgentId"];
                        model.agentName = reader["AgentName"].ToString();
                        list.Add(model);
                    }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }
            return list;

        }

        public List<DestinationViewModel> GetDestination()
        {
            List<DestinationViewModel> list = new List<DestinationViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "SELECT * FROM DESTINATION";

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var model = new DestinationViewModel();
                        model.destinationId = (int)reader["DestinationId"];
                        model.destinationName = reader["DestinationName"].ToString();
                        list.Add(model);
                    }
                    reader.Close();
                }
                catch (SqlException ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
            }
            return list;

        }

        public void AddAgent(AgentViewModels vm)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "INSERT INTO AGENT (AgentName, OfficeKey) VALUES (@agentName, @officeKey)";
                command.Parameters.AddWithValue("@agentName", vm.agentName);
                command.Parameters.AddWithValue("@officeKey", vm.officeLocation);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch ( SqlException ex) { throw ex; }
                finally
                {
                    connection.Close();
                }

            }

        }

        public void AddSale(SaleViewModels vm)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                //Change the query
                command.CommandText = "INSERT INTO SALE (SaleDate, AgentKey, Amount, DestinationKey) VALUES (@saleDate, @agentKey, @amount, @destinationKey)";
                
                command.Parameters.AddWithValue("@saleDate", vm.saleDate);
                command.Parameters.AddWithValue("@agentKey", vm.agentName);
                command.Parameters.AddWithValue("@amount", vm.amount);
                command.Parameters.AddWithValue("@destinationKey", vm.destinationName);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex) { throw ex; }
                finally
                {
                    connection.Close();
                }

            }

        }


    }
}