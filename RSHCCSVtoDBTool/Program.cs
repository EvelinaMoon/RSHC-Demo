using System;

using System.Data;

using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ConsoleApp1

{

    class Program
    {

        public static string ValidateString(string value)
        {

            string newValue = "No Data";

            if (string.IsNullOrEmpty(value))
                return string.Empty;

            else
            {
                try
                {
                    newValue = Regex.Replace(value, "[@,\\.\";'\\\\]", string.Empty);
                    newValue = Regex.Replace(newValue, @"\s+", "");
                }
                catch (FormatException fx)
                {

                }
            }
            return newValue;
        }


        public static string RemoveEmptySpaces(string value)
        {

            string newValue = value;

            if (string.IsNullOrEmpty(value))
                return string.Empty;

            else
            {
                try
                {
                    // newValue = Regex.Replace(value, "[@,\\.\";'\\\\]", string.Empty);
                    newValue = Regex.Replace(value, @"\s+", "");
                }
                catch (FormatException fx)
                {

                }
            }
            return newValue;
        }
        static void Main(string[] args)
        {

            var lineNumber = 0;
            SqlCommand command = null;
            //string connectionString = '';
            string UserId, FirstName, MI, LastName, OfficeID, Phone, DisplayName, EMail, Title, ShortName, Initials, FullName, AdmittedIn;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                "Data Source=rshc-production.database.windows.net;" +
                "Initial Catalog=rshc-shared;" +
                "User id=rshc-production-server-admin;" +
                "Password=;";
                conn.Open();

                using (StreamReader reader = new StreamReader(@"C:\RSHC\Flat File.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (lineNumber != 0 && lineNumber > 1)
                        {
                            var values = line.Split(',');

                            if (values[0].ToString().Contains("Report Total Records"))
                            {
                                break;
                            }

                            using (command = new SqlCommand("INSERT INTO Persons (UserID, LastName, FirstName, MI, DisplayName, FullName, Initials, OfficeId, ShortName, Title, Phone, EMail, AdmittedIn) " +
                                                                        "VALUES (@UserID, @LastName, @FirstName, @MI, @DisplayName, @FullName, @Initials, @OfficeId, @ShortName, @Title, @Phone, @EMail, @AdmittedIn)", conn))
                            {

                                //command.Parameters.Add(new SqlParameter("@UserID", "test1"));
                                //command.Parameters.Add(new SqlParameter("@LastName", "test2"));
                                //command.Parameters.Add(new SqlParameter("@FirstName", "test3"));
                                //command.Parameters.Add(new SqlParameter("@DisplayName", "test4"));

                                //Regex.Replace("He\"ll,o Wo'r.ld", "[@,\\.\";'\\\\]", string.Empty);
                                UserId = RemoveEmptySpaces(values[11]);
                                FirstName = ValidateString(values[3]);
                                MI = ValidateString(values[4]);


                                LastName = ValidateString(values[5]);
                                OfficeID = ValidateString(values[6])[0].ToString();
                                Phone = ValidateString(values[12]);
                                DisplayName = FirstName + " " + LastName;
                                FullName = FirstName + " " + MI + " " + LastName;
                                EMail = RemoveEmptySpaces(values[11]);
                                Title = ValidateString(values[8]);
                                ShortName = FirstName + " " + LastName;
                                Initials = FirstName[0].ToString().ToUpper() + LastName[0].ToString().ToUpper();
                                AdmittedIn = DateTime.UtcNow.ToShortDateString();

                                if (UserId != string.Empty)
                                    command.Parameters.Add(new SqlParameter("@UserID", UserId));
                                else
                                    command.Parameters.Add(new SqlParameter("@UserID", FullName));

                                command.Parameters.Add(new SqlParameter("@LastName", LastName));
                                command.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                                command.Parameters.Add(new SqlParameter("@MI", MI));
                                command.Parameters.Add(new SqlParameter("@DisplayName", DisplayName));
                                command.Parameters.Add(new SqlParameter("@FullName", FullName));
                                command.Parameters.Add(new SqlParameter("@Initials", Initials));
                                command.Parameters.Add(new SqlParameter("@OfficeId", OfficeID));
                                command.Parameters.Add(new SqlParameter("@ShortName", ShortName));
                                command.Parameters.Add(new SqlParameter("@Title", Title));
                                command.Parameters.Add(new SqlParameter("@Phone", Phone));
                                command.Parameters.Add(new SqlParameter("@EMail", EMail));
                                command.Parameters.Add(new SqlParameter("@AdmittedIn", AdmittedIn));

                                command.Connection = conn;

                                command.ExecuteNonQuery();
                            }
                        }

                        lineNumber++;
                    }
                }

                conn.Close();
            }

            Console.WriteLine("Products import completed");
            Console.ReadLine();
        }
    }
}
