using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;


namespace LINQLearning
{
    class Program
    {
        static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LINQLearning.Properties.Settings.sani_usermanagementConnectionString"].ToString();

        //SANI: for Linq - SQL
        static LinqToSQLDataContext db = new LinqToSQLDataContext(connectString);
        static user userObject = new user();  //SANI: Create a user object

        //SANI: for Linq - Object
        static List<user> users = new List<user> { };

        //SANI: for LINQ - Dataset
        static DataSet ds = new DataSet();
        static DataTable usersTable = new DataTable("Users");

        //SANI: for LINQ - ENTITIES
        // Use your EF DbContext
        //static LinqToSQLDataContext dbContext = new LinqToSQLDataContext(connectString);

        static void Main(string[] args)
        {
            //LINQ-SQL
            //LINQSQLinsertUser();
            //LINQSQLlistSingleUserRecord();
            //LINQSQLupdateUser();
            //LINQSQLdeleteUser();
            //LINQSQLlistAllUsers();


            //LINQ-Object
            //LINQObjectinsertUser();
            //LINQObjectlistSingleUserRecord();
            //LINQObjectupdateUser();
            //LINQObjectdeleteUser();
            //LINQObjectlistAllUsers();


            //LINQ-Dataset
            //LINQDatasetinsertUser();
            //LINQDatasetlistSingleUserRecord();
            //LINQDatasetupdateUser();
            //LINQDatasetdeleteUser();
            //LINQDatasetlistAllUsers();


            //LINQ-Entities
            //LINQEntitiesinsertUser();
            //LINQEntitieslistSingleUserRecord();
            //LINQEntitiesupdateUser();
            //LINQEntitiesdeleteUser();
            //LINQEntitieslistAllUsers();

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }



        // LINQ - SQL
        static void LINQSQLinsertUser()
        {

            userObject.name = "Sani";
            userObject.email = "sani@gmail.com";
            userObject.phone = "03327399488";
            userObject.picture = "default.png";
            userObject.gender_id = 1;
            userObject.education_id = 1;
            userObject.interests = "Cricket";
            userObject.aboutme = "Sani Hyne";
            userObject.password = "123456789";
            userObject.status = 1;
            userObject.is_default = false;

            //Add new User to database
            db.users.InsertOnSubmit(userObject);

            //Save changes to Database.
            db.SubmitChanges();
        }

        static void LINQSQLlistSingleUserRecord()
        {
            user userRecord = db.users.FirstOrDefault(e => e.name.Equals("Sani"));


            Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                             userRecord.id, userRecord.name, userRecord.email,
                             userRecord.phone, userRecord.interests);
        }


        static void LINQSQLlistAllUsers()
        {
            var userObject = db.users; //from db context to variable list

            foreach (user userRecord in userObject)
            {
                Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                             userRecord.id, userRecord.name, userRecord.email,
                             userRecord.phone, userRecord.interests);
            }


        }


        static void LINQSQLupdateUser()
        {
            user userObject = db.users.FirstOrDefault(e => e.id.Equals("4005"));


            userObject.name = "Sani Hyne";
            userObject.email = "sani.hyne@gmail.com";
            userObject.phone = "03327399488";
            userObject.picture = "default.png";
            userObject.gender_id = 1;
            userObject.education_id = 1;
            userObject.interests = "Cricket";
            userObject.aboutme = "Sani Hyne";
            userObject.password = "123456789";
            userObject.status = 1;
            userObject.is_default = false;

            //Save changes to Database.
            db.SubmitChanges();
        }

        static void LINQSQLdeleteUser()
        {
            user userObject = db.users.FirstOrDefault(e => e.id.Equals("4005"));


            db.users.DeleteOnSubmit(userObject);

            //Save changes to Database.
            db.SubmitChanges();
        }














        // LINQ - Object
        static void LINQObjectinsertUser()
        {
            // Create a new user
            var newUser = new user
            {
                name = "Sani",
                email = "hyne@gmail.com",
                phone = "03327399488",
                interests = "Cricket"
            };

            // Add to the in-memory list
            users.Add(newUser);

            Console.WriteLine("User inserted successfully.");
        }


        static void LINQObjectlistAllUsers()
        {
            foreach (var userRecord in users)
            {
                Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                                 userRecord.id, userRecord.name, userRecord.email,
                                 userRecord.phone, userRecord.interests);
            }


        }

        static void LINQObjectlistSingleUserRecord()
        {
            // Find a user by name
            var userRecord = users.FirstOrDefault(e => e.name.Equals("abcd", StringComparison.OrdinalIgnoreCase));

            if (userRecord != null)
            {
                Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                                 userRecord.id, userRecord.name, userRecord.email,
                                 userRecord.phone, userRecord.interests);
            }
            else
            {
                Console.WriteLine("User not found.");
            }


        }

        static void LINQObjectupdateUser()
        {
            var userRecord = users.FirstOrDefault(e => e.id == 3007);

            if (userRecord != null)
            {
                userRecord.name = "Sani Hyne";
                userRecord.email = "sani.hyne@gmail.com";

                Console.WriteLine("User updated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }


        static void LINQObjectdeleteUser()
        {
            var userRecord = users.FirstOrDefault(e => e.id == 3007);

            if (userRecord != null)
            {
                users.Remove(userRecord);

                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }










        // LINQ - Dataset
        static void LINQDatasetinsertUser()
        {
            //// Create columns for the Users DataTable
            usersTable.Columns.Add("id", typeof(int));
            usersTable.Columns.Add("name", typeof(string));
            usersTable.Columns.Add("email", typeof(string));
            usersTable.Columns.Add("phone", typeof(string));
            usersTable.Columns.Add("interests", typeof(string));

            //Way one
            //// Add the DataTable to the DataSet
            //ds.Tables.Add(usersTable);

            //// Insert some initial data (in a real-world scenario, this could come from a DB)
            //usersTable.Rows.Add(3009, "Sani", "sani@gmail.com", "03327399488", "Cricket");

            //Way two
            // Create a new row
            DataRow newRow = usersTable.NewRow();
            newRow["id"] = 3009;
            newRow["name"] = "Sani";
            newRow["email"] = "sani@gmail.com";
            newRow["phone"] = "03327399488";
            newRow["interests"] = "Reading";

            // Add the new row to the DataTable
            usersTable.Rows.Add(newRow);

            Console.WriteLine("User inserted successfully.");
        }

        static void LINQDatasetlistSingleUserRecord()
        {
            // Query to find the user with the name "Sani"
            var userRecord = usersTable.AsEnumerable()
                                       .FirstOrDefault(user => user.Field<string>("name") == "Sani");

            // Check if the user record was found
            if (userRecord != null)
            {
                Console.WriteLine($"Id = {userRecord["id"]}, Name = {userRecord["name"]}, Email = {userRecord["email"]}, Phone = {userRecord["phone"]}, Interests = {userRecord["interests"]}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void LINQDatasetupdateUser()
        {
            var userToUpdate = usersTable.AsEnumerable().FirstOrDefault(e => e.Field<int>("id") == 3009);
            if (userToUpdate != null)
            {
                userToUpdate["name"] = "hyne";
                userToUpdate["email"] = "hyne@gmail.com";
                userToUpdate["phone"] = "03327399488";
                userToUpdate["interests"] = "Basketball";

                Console.WriteLine("User updated successfully.");
            }
        }

        static void LINQDatasetdeleteUser()
        {
            var userToDelete = usersTable.AsEnumerable().FirstOrDefault(e => e.Field<int>("id") == 3009);
            if (userToDelete != null)
            {
                userToDelete.Delete();
                Console.WriteLine("User deleted successfully.");
            }
        }

        static void LINQDatasetlistAllUsers()
        {
            var userList = from user in usersTable.AsEnumerable()
                           select new
                           {
                               Id = user["id"],
                               Name = user["name"],
                               Email = user["email"],
                               Phone = user["phone"],
                               Interests = user["interests"]
                           };

            foreach (var user in userList)
            {
                Console.WriteLine($"Id = {user.Id}, Name = {user.Name}, Email = {user.Email}, Phone = {user.Phone}, Interests = {user.Interests}");
            }
        }
















        // LINQ - Entities


        static void LINQEntitiesinsertUser()
        {
            var userObject = new user
            {
                name = "Sani",
                email = "sani@gmail.com",
                phone = "03327399488",
                picture = "default.png",
                gender_id = 1,
                education_id = 1,
                interests = "Cricket",
                aboutme = "Sani Hyne",
                password = "123456789",
                status = 1,
                is_default = false
            };

            // Add new User to database
            users.Add(userObject);
           
        }

        static void LINQEntitieslistSingleUserRecord()
        {
            var userRecord = db.users.FirstOrDefault(e => e.name == "Sani");

            if (userRecord != null)
            {
                Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                                 userRecord.id, userRecord.name, userRecord.email,
                                 userRecord.phone, userRecord.interests);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void LINQEntitiesupdateUser()
        {
            var userRecord = db.users.FirstOrDefault(e => e.id == 4005);

            if (userRecord != null)
            {
                userRecord.name = "Sani Hyne";
                userRecord.email = "sani.hyne@gmail.com";
                userRecord.phone = "03327399488";
                userRecord.picture = "default.png";
                userRecord.gender_id = 1;
                userRecord.education_id = 1;
                userRecord.interests = "Cricket";
                userRecord.aboutme = "Sani Hyne";
                userRecord.password = "123456789";
                userRecord.status = 1;
                userRecord.is_default = false;

                // Save changes to the database
                //db.SaveChanges();
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void LINQEntitiesdeleteUser()
        {
            var userRecord = db.users.FirstOrDefault(e => e.id == 4005);

            if (userRecord != null)
            {
                //db.users.Remove(userRecord);

                // Save changes to the database
                //db.SaveChanges();
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void LINQEntitieslistAllUsers()
        {
            var users = db.users.ToList(); // Convert the DbSet to a List

            foreach (var userRecord in users)
            {
                Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                                 userRecord.id, userRecord.name, userRecord.email,
                                 userRecord.phone, userRecord.interests);
            }
        }
    }
}
