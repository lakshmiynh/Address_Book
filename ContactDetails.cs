using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;


namespace Address_Book
{
    public class ContactDetails
    {
        private SqlConnection connection;
        private string connectionString = "server=(localdb)\\MSSQLLOCALDB; Initial Catalog = Contacts; Integrated Security = SSPI";
        public ContactDetails()
        {
            connection = new SqlConnection(connectionString);
        }
        static Dictionary<string, AddressBook> list = new Dictionary<string, AddressBook>();
        public void CreateContactTable()
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                CREATE TABLE ContactDetailsTable1 (
                ID INT PRIMARY KEY IDENTITY,
                FirstName NVARCHAR(50),
                LastName NVARCHAR(50),
                Address NVARCHAR(255),
                City NVARCHAR(50),
                State NVARCHAR(50),
                Zip NVARCHAR(10),
                PhoneNumber NVARCHAR(15),
                Email NVARCHAR(100))";

                command.ExecuteNonQuery();
                Console.WriteLine("ContactDetailsTable created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating table: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public void Details()
        {
            string firstname = ValidateInput("First Name", @"^[A-Za-z]+$");

            string lastname = ValidateInput("Last Name", @"^[A-Za-z]+$");

            string key = $"{firstname.ToLower()}_{lastname.ToLower()}";

            if (list.ContainsKey(key))
            {
                throw new InvalidException("Contact with the same first name and last name already exists.");
            }

            Console.WriteLine("Enter your Address");
            string address = Console.ReadLine();
            File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\newfile.txt", $"{address}\n.");

            Console.WriteLine("Enter your City");
            string city = Console.ReadLine();

            File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\newfile.txt", $"{city}\n.");

            Console.WriteLine("Enter your State");
            string state = Console.ReadLine();

            File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\newfile.txt", $"{state}\n.");

            string zip = ValidateInput("Zip Code", @"^\d{6}$");

            string phonenumber = ValidateInput("Phone Number", @"^\d{10}$");

            string email = ValidateInput("Email", @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            Console.WriteLine(File.ReadAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\newfile.txt"));

            AddressBook customer1 = new AddressBook(firstname, lastname, address, city, state, zip, phonenumber, email);
            list.Add(key, customer1);

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO ContactDetailsTable1 (FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email) VALUES (@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email)";
                command.Parameters.AddWithValue("@FirstName", firstname);
                command.Parameters.AddWithValue("@LastName", lastname);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@Zip", zip);
                command.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Displaytable()
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ContactDetailsTable1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}");
                    Console.WriteLine($"First Name: {reader["FirstName"]}");
                    Console.WriteLine($"Last Name: {reader["LastName"]}");
                    Console.WriteLine($"Address: {reader["Address"]}");
                    Console.WriteLine($"City: {reader["City"]}");
                    Console.WriteLine($"State: {reader["State"]}");
                    Console.WriteLine($"Zip Code: {reader["Zip"]}");
                    Console.WriteLine($"Phone Number: {reader["PhoneNumber"]}");
                    Console.WriteLine($"Email: {reader["Email"]}");
                    Console.WriteLine();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving data: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void Update(string name, int Id)
        {
            string updateData = "updateTABLE ContactDetailsTable1  set @Firstname = Name where @ID =  ID";
            SqlCommand sqlCommand = new(updateData, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@Firstname", name);
            sqlCommand.Parameters.AddWithValue("@ID", Id);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Name update to " + name);
            connection.Close();
        }

        public void Delete(int id)
        {
            string deleteData = "delete ContactDetailsTable1 where ID = @Id";
            SqlCommand sqlCommand = new(deleteData, connection);
            connection.Open();
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Deleted!");
            connection.Close();
        }



        private string ValidateInput(string fieldName, string regexPattern)
        {
            string input;
            Regex regex = new Regex(regexPattern);
            do
            {
                Console.WriteLine($"Enter your {fieldName}");
                input = Console.ReadLine();

                File.AppendAllText("C:\\Users\\laksh\\OneDrive\\Desktop\\newfile.txt", $"{input}\n.");

                if (!regex.IsMatch(input))
                {
                    Console.WriteLine($"Invalid {fieldName}. Please try again.");
                }
            } while (!regex.IsMatch(input));
            return input;
        }

        public class InvalidException : Exception
        {
            public InvalidException(string message) : base(message)
            {
            }
        }

        public void Display()
        {
            foreach (var contact in list)
            {

                AddressBook person = contact.Value;
                Console.WriteLine($"First Name: {person.Firstname}");
                Console.WriteLine($"Last Name: {person.Lastname}");
                Console.WriteLine($"Address: {person.Address}");
                Console.WriteLine($"City: {person.City}");
                Console.WriteLine($"State: {person.State}");
                Console.WriteLine($"Zip Code: {person.Zip}");
                Console.WriteLine($"Phone Number: {person.Phonenumber}");
                Console.WriteLine($"Email: {person.Email}");
                Console.WriteLine();
            }
        }

        public void EditDetails()
        {
            bool continueEditing = true;
            while (continueEditing)
            {
                Console.WriteLine("Do you want to change anything? Type your first name or type 'exit' to quit editing:");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                {
                    continueEditing = false;
                    break;
                }

                if (list.ContainsKey(name) && name.ToLower() == name.ToLower())
                {
                    AddressBook person = list[name];

                    Console.WriteLine($"Choose the option to edit for {name}:");
                    Console.WriteLine("1. First name");
                    Console.WriteLine("2. Last name");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. City");
                    Console.WriteLine("5. State");
                    Console.WriteLine("6. Zip");
                    Console.WriteLine("7. Phone number");
                    Console.WriteLine("8. Email");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter new first name:");
                            person.Firstname = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter new last name:");
                            person.Lastname = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter new address:");
                            person.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter new city:");
                            person.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter new state:");
                            person.State = Console.ReadLine();
                            break;
                        case 6:
                            Console.WriteLine("Enter new zip code:");
                            person.Zip = Console.ReadLine();
                            break;
                        case 7:
                            Console.WriteLine("Enter new phone number:");
                            person.Phonenumber = Console.ReadLine();
                            break;
                        case 8:
                            Console.WriteLine("Enter new email:");
                            person.Email = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    Console.WriteLine("Details updated successfully.");
                }
                else
                {
                    Console.WriteLine($"No contact found with the first name {name}.");
                }

                Console.WriteLine("Do you want to continue editing? (yes/no)");
                string response = Console.ReadLine();
                if (response.ToLower() != "yes")
                {
                    continueEditing = false;
                }
            }
        }

        public void DeletePerson()
        {
            Console.WriteLine("enter your name");
            string name = Console.ReadLine();

            if (list.ContainsKey(name))
            {
                list.Remove(name);
                Console.WriteLine($"Contact with the first name {name} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No contact found with the first name {name}.");
            }
        }

        public void Add()
        {
            try
            {
                Details();
            }
            catch (InvalidException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void DisplaybyCity()
        {
            Console.WriteLine("Enter the city");
            string city = Console.ReadLine();

            var contactsInCity = list.Values
        .Where(person => person.City.ToLower() == city.ToLower());

            if (contactsInCity.Any())  // linq  method
            {

                foreach (var person in contactsInCity)
                {
                    Display();

                }
            }
            else
            {
                Console.WriteLine($"No contacts found in the city: {city}");
            }
        }

        public void CountContactsByCity()
        {
            Console.WriteLine("Enter the city");
            string city = Console.ReadLine();

            var contactsCount = list.Values
                .Where(person => person.City.ToLower() == city.ToLower())
                .Count();

            if (contactsCount > 0)
            {
                Console.WriteLine($"Number of contacts in {city}: {contactsCount}");
            }
            else
            {
                Console.WriteLine($"No contacts found in {city}.");
            }
        }

    }
}
