using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace db_final.Models
{
    public class CRUD
    {
        public static string connectionString = "data source=(localdb)\\MSSQLLocalDB; Initial Catalog=PlanEveDB;Integrated Security=true";

        public static List<Venue> getAllVenues()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllVenues", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Venue> list = new List<Venue>();
                while (rdr.Read())
                {
                    Venue v = new Venue();

                    v.providerID = rdr["ProviderID"].ToString();
                    v.venueName = rdr["Name"].ToString();
                    v.venueAddress = rdr["Address"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Photographer> getAllPhotographers()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllPhotographers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Photographer> list = new List<Photographer>();
                while (rdr.Read())
                {
                    Photographer v = new Photographer();

                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.samplesLink = rdr["SamplesLink"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<DJ> getAllDJs()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllDJs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<DJ> list = new List<DJ>();
                while (rdr.Read())
                {
                    DJ v = new DJ();

                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<Caterer> getAllCaterers()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllCaterers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Caterer> list = new List<Caterer>();
                while (rdr.Read())
                {
                    Caterer v = new Caterer();

                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.samplesLink = rdr["SamplesLink"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<Decorator> getAllDecorators()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllDecorators", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Decorator> list = new List<Decorator>();
                while (rdr.Read())
                {
                    Decorator v = new Decorator();

                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.samplesLink = rdr["SamplesLink"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static int signupNewUser(string username, string name, string email, string contactNum, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("CustomerSignupProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 200).Value = email;
                cmd.Parameters.Add("@num", SqlDbType.NVarChar, 15).Value = contactNum;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 32).Value = password;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int signupNewServiceProvider(string username, string cnic, string email, string contactNum, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("SP_SignupProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 200).Value = email;
                cmd.Parameters.Add("@num", SqlDbType.NVarChar, 15).Value = contactNum;
                cmd.Parameters.Add("@cnic", SqlDbType.NVarChar, 20).Value = cnic;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 32).Value = password;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static List<Venue> getSearchedVenues(string searchName, string searchAddress, int maxPrice, int minPrice)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getSearchedVenues", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name_input", SqlDbType.NVarChar, 50).Value = searchName;
                cmd.Parameters.Add("@address_input", SqlDbType.NVarChar, 50).Value = searchAddress;
                cmd.Parameters.Add("@minPrice_input", SqlDbType.Int).Value = minPrice;
                cmd.Parameters.Add("@maxPrice_input", SqlDbType.Int).Value = maxPrice;


                SqlDataReader rdr = cmd.ExecuteReader();
                

                List<Venue> list = new List<Venue>();
                while (rdr.Read())
                {
                    Venue v = new Venue();

                    v.venueName = rdr["Name"].ToString();
                    v.venueAddress = rdr["Address"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Photographer> getSearchedPhotographers(int maxPrice, int minPrice)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getSearchedPhotographers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@minPrice_input", SqlDbType.Int).Value = minPrice;
                cmd.Parameters.Add("@maxPrice_input", SqlDbType.Int).Value = maxPrice;


                SqlDataReader rdr = cmd.ExecuteReader();


                List<Photographer> list = new List<Photographer>();
                while (rdr.Read())
                {
                    Photographer v = new Photographer();

                    v.name = rdr["Name"].ToString();
                    v.samplesLink = rdr["SamplesLink"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<DJ> getSearchedDJs(int maxPrice, int minPrice)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getSearchedDJs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@minPrice_input", SqlDbType.Int).Value = minPrice;
                cmd.Parameters.Add("@maxPrice_input", SqlDbType.Int).Value = maxPrice;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<DJ> list = new List<DJ>();
                while (rdr.Read())
                {
                    DJ v = new DJ();

                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<Caterer> getSearchedCaterers(int maxPrice, int minPrice)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getSearchedCaterers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@minPrice_input", SqlDbType.Int).Value = minPrice;
                cmd.Parameters.Add("@maxPrice_input", SqlDbType.Int).Value = maxPrice;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Caterer> list = new List<Caterer>();
                while (rdr.Read())
                {
                    Caterer v = new Caterer();

                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.samplesLink = rdr["SamplesLink"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static List<Decorator> getSearchedDecorators(int maxPrice,int minPrice)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getSearchedDecorators", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@minPrice_input", SqlDbType.Int).Value = minPrice;
                cmd.Parameters.Add("@maxPrice_input", SqlDbType.Int).Value = maxPrice;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Decorator> list = new List<Decorator>();
                while (rdr.Read())
                {
                    Decorator v = new Decorator();

                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.samplesLink = rdr["SamplesLink"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static int loginServiceProvider(string username, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("SP_LoginProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 32).Value = password;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static ServiceProvider getDetailsOfSP(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getDetailsOfSP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("username", SqlDbType.NVarChar,50).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                ServiceProvider sp = new ServiceProvider();
                rdr.Read();

                sp.username = rdr["ProviderID"].ToString();
                sp.email = rdr["Email"].ToString();
                sp.cnic = rdr["CNIC"].ToString();
                sp.contactNum = rdr["ContactNum"].ToString();
                sp.password = rdr["Password"].ToString();
                sp.accountActivationDate = rdr["AccountActivationDate"].ToString().Remove(10,12);

                rdr.Close();
                con.Close();

                return sp;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static int changePasswordOfSP(string username, string oldPassword, string newPassword)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("changePasswordOfSP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@oldPassword", SqlDbType.NVarChar, 32).Value = oldPassword;
                cmd.Parameters.Add("@newPassword", SqlDbType.NVarChar, 32).Value = newPassword;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int changeDetailsOfSP(string username, string contactNum, string email)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("changeDetailsOfSP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@contactNum", SqlDbType.NVarChar, 32).Value = contactNum;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 32).Value = email;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int loginUser(string username, string password)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("CustomerLoginProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 32).Value = password;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static Customer getDetailsOfCustomer(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getDetailsOfCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("username", SqlDbType.NVarChar, 50).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                Customer sp = new Customer();
                rdr.Read();

                sp.username = rdr["CustomerID"].ToString();
                sp.email = rdr["Email"].ToString();
                sp.name = rdr["Name"].ToString();
                sp.contactNum = rdr["ContactNum"].ToString();
                sp.password = rdr["Password"].ToString();
                sp.accountActivationDate = rdr["AccountActivationDate"].ToString().Remove(10, 12);

                rdr.Close();
                con.Close();

                return sp;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static int changePasswordOfCustomer(string username, string oldPassword, string newPassword)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("changePasswordOfCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@oldPassword", SqlDbType.NVarChar, 32).Value = oldPassword;
                cmd.Parameters.Add("@newPassword", SqlDbType.NVarChar, 32).Value = newPassword;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int changeDetailsOfCustomer(string username, string name, string contactNum, string email)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("changeDetailsOfCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
                cmd.Parameters.Add("@contactNum", SqlDbType.NVarChar, 32).Value = contactNum;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 32).Value = email;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static List<Review> getReviewsOfSP(string username, string category)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllReviewsOfSP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 40).Value = category;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Review> list = new List<Review>();
                while (rdr.Read())
                {
                    Review v = new Review();

                    v.serviceProviderID = rdr["ProviderID"].ToString();
                    v.serviceCategory = rdr["ServiceCategory"].ToString();
                    v.reviewCustomerID = rdr["ReviewCustomerID"].ToString();
                    v.reviewComments = rdr["ReviewComments"].ToString();
                    v.reviewRating = rdr["ReviewRating"].ToString();
                    
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }
    
        public static string getAverageRatingOfSP(string username, string category)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                string result;
                cmd = new SqlCommand("getAverageRatingOfSP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 40).Value = category;

                //cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                //cmd.ExecuteNonQuery();
                //result = Convert.ToInt32(cmd.Parameters["@output"].Value);

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();

                result = rdr["AvgRating"].ToString();

                rdr.Close();
                con.Close();

                return result;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }

        }

        public static int postComment(string SP_username, string Cust_username, string category, string reviewComment, int reviewRating)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("postComment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SP_username", SqlDbType.NVarChar, 50).Value = SP_username;
                cmd.Parameters.Add("@Cust_username", SqlDbType.NVarChar, 50).Value = Cust_username;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 20).Value = category;
                cmd.Parameters.Add("@comment", SqlDbType.NVarChar, 500).Value = reviewComment;
                cmd.Parameters.Add("@rating", SqlDbType.Int).Value = reviewRating;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static List<Venue> getAllVenuesbySp(String username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllVenuesbySP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Venue> list = new List<Venue>();
                while (rdr.Read())
                {
                    Venue v = new Venue();

                    v.venueName = rdr["Name"].ToString();
                    v.venueAddress = rdr["Address"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                    list.Add(v);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static int addNewVenue(string username, string venueName, string address, int price, int discount)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("addNewVenue", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@address", SqlDbType.NVarChar, 1200).Value = address;
                cmd.Parameters.Add("@venueName", SqlDbType.NVarChar, 40).Value = venueName;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int deleteVenue(string username, string venueName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("deleteVenue", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@vname", SqlDbType.NVarChar, 150).Value = venueName;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int updateVenue(string username, string vname, int? price, int? discount)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("Updatevenue", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@vname", SqlDbType.NVarChar, 150).Value = vname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static DJ getAllDJsBySP(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getDJbySP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();
                DJ v = new DJ();

                
                if (rdr.HasRows)
                {
                    rdr.Read();
                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                }
                else
                {
                    v.providerID = "";
                    v.name = "";
                    v.price = "";
                    v.discount = "";
                    v.featured = "";
                }
                    
                
                rdr.Close();
                con.Close();

                return v;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static int checkSP(String spid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("chkSP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.VarChar, 50).Value = spid;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int signupDJ(String spid, String djname, int? price, int? discount)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("DJSignupProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.VarChar, 50).Value = spid;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = djname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int deleteDJ(string username, string name)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("deletedj", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int updateDJ(string username, string djname, int? price, int? discount)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("UpdateDJ", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = djname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static Decorator getAllDecoratorsBySP(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getDecoratorsBySP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();
                Decorator v = new Decorator();


                if (rdr.HasRows)
                {
                    rdr.Read();
                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                }
                else
                {
                    v.providerID = "";
                    v.name = "";
                    v.price = "";
                    v.discount = "";
                    v.featured = "";
                }


                rdr.Close();
                con.Close();

                return v;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static int signupDecorator(String spid, String vname, int? price, int? discount, string samples)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("DecorSignupProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.VarChar, 50).Value = spid;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = vname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                cmd.Parameters.Add("@samples", SqlDbType.NVarChar, 1200).Value = samples;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int DeletingDecorator(string username, string vname)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("deletedecorator", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = vname;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int updatedecorator(string username, string Decoratorname, int? price, int? discount, string samples)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("UpdateDecorator", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = Decoratorname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                cmd.Parameters.Add("@samples", SqlDbType.NVarChar, 1200).Value = samples;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static Photographer getAllPhotographersBySP(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllPhotographersBySP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();
                Photographer v = new Photographer();


                if (rdr.HasRows)
                {
                    rdr.Read();
                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                }
                else
                {
                    v.providerID = "";
                    v.name = "";
                    v.price = "";
                    v.discount = "";
                    v.featured = "";
                }


                rdr.Close();
                con.Close();

                return v;


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }
        }

        public static Caterer getAllCaterersBySP(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getAllCaterersBySP", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();
                Caterer v = new Caterer();


                if (rdr.HasRows)
                {
                    rdr.Read();
                    v.providerID = rdr["ProviderID"].ToString();
                    v.name = rdr["Name"].ToString();
                    v.price = rdr["Price"].ToString();
                    v.discount = rdr["Discount"].ToString();
                    v.featured = rdr["Featured"].ToString();
                }
                else
                {
                    v.providerID = "";
                    v.name = "";
                    v.price = "";
                    v.discount = "";
                    v.featured = "";
                }


                rdr.Close();
                con.Close();

                return v;


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }
        }

        public static int signupPhotographer(String spid, String vname, int? price, int? discount, string samples)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("PhotographerSignupProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.VarChar, 50).Value = spid;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = vname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                cmd.Parameters.Add("@samples", SqlDbType.NVarChar, 1200).Value = samples;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int DeletingPhotographer(string username, string vname)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("deletePhotographer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = vname;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int updatePhotographer(string username, string Decoratorname, int? price, int? discount, string samples)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("UpdatePhotographer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = Decoratorname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                cmd.Parameters.Add("@samples", SqlDbType.NVarChar, 1200).Value = samples;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int signupCaterer(String spid, String vname, int? price, int? discount, string samples)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("CatererSignupProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@SPId", SqlDbType.VarChar, 50).Value = spid;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 150).Value = vname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                cmd.Parameters.Add("@link", SqlDbType.NVarChar, 1200).Value = samples;
                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int DeletingCaterer(string username, string vname)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("deleteCaterer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = vname;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public static int updateCaterer(string username, string Decoratorname, int? price, int? discount, string samples)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            int result;

            try
            {
                cmd = new SqlCommand("UpdateCaterer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@spid", SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = Decoratorname;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@discount", SqlDbType.Int).Value = discount;
                cmd.Parameters.Add("@samples", SqlDbType.NVarChar, 1200).Value = samples;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1;

            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }

    
    
    
}
    
    
