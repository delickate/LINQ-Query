### LINQ (Language-Integrated Query)

This project demonstrates the usage of **Language Integrated Query (LINQ)** in C# with various data sources. It covers the following types of LINQ:

- **LINQ to Objects**
- **LINQ to SQL**
- **LINQ to XML**
- **LINQ to Entities**
- **LINQ to DataSet**

## Overview

LINQ (Language Integrated Query) is a powerful feature in C# that allows querying data from different sources in a uniform way. This project provides examples and tutorials on using LINQ to query different data sources.

## Table of Contents

- [LINQ to Objects](#linq-to-objects)
- [LINQ to SQL](#linq-to-sql)
- [LINQ to XML](#linq-to-xml)
- [LINQ to Entities](#linq-to-entities)
- [LINQ to DataSet](#linq-to-dataset)
- [How to Run](#how-to-run)

## LINQ to Objects

**LINQ to Objects** allows you to query collections like arrays, lists, or any other in-memory data structures.

Example:

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };

var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;

foreach(var num in evenNumbers)
{
    Console.WriteLine(num); // Outputs: 2, 4
}
```
**LINQ to SQL**
```
using (var db = new YourDataContext())
{
    var users = from user in db.Users
                where user.Name == "Sani"
                select user;

    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id} - {user.Name}");
    }
}

```
**LINQ to XML**
```
XDocument doc = XDocument.Load("sample.xml");

var elements = from el in doc.Descendants("User")
               where (string)el.Element("Name") == "Sani"
               select el;

foreach (var element in elements)
{
    Console.WriteLine(element);
}

```
**LINQ to ENTITIES**
```
using (var context = new YourDbContext())
{
    var users = from user in context.Users
                where user.Name == "Sani"
                select user;

    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id} - {user.Name}");
    }
}

```
**LINQ to DataSet**
```
DataSet ds = new DataSet();
ds.ReadXml("sample.xml");

var users = from user in ds.Tables["User"].AsEnumerable()
            where user.Field<string>("Name") == "Sani"
            select user;

foreach (var user in users)
{
    Console.WriteLine(user.Field<int>("Id") + " - " + user.Field<string>("Name"));
}

```


### Explanation of the Sections:
- **Overview**: Gives a high-level introduction to LINQ and its capabilities.
- **Table of Contents**: Lists the sections in the document for easy navigation.
- **LINQ to Objects, LINQ to SQL, LINQ to XML, LINQ to Entities, and LINQ to DataSet**: Provides examples of LINQ queries with the respective data sources.
- **How to Run**: Explains the basic steps for running the project.
- **Prerequisites**: Lists the requirements for running the project.
- **License**: Basic license information.
- **Contributing**: Encourages contributions to the project.
- **Acknowledgments**: Credits relevant resources.

Feel free to adjust and enhance the content based on your project’s specific setup and requirements!


#### Basic concept
- integration of query capabilities directly into the C# language.
- LINQ Queries are the first-class language construct in C# .NET, just like classes, methods, events.
- The LINQ provides a consistent query experience to 
  - LINQ to Objects: Refers to using LINQ queries with any IEnumerable or IEnumerable<T> collection directly in memory.
  - LINQ to SQL: Allows querying of SQL Server databases, translating LINQ queries into SQL queries that are then executed against the database.
  - LINQ to XML (formerly known as XLINQ): Provides an in-memory XML programming interface that leverages LINQ to offer a simpler and more declarative way to read, manipulate, and write XML data.
  - LINQ to Entities: A part of the ADO.NET Entity Framework, LINQ to Entities allows querying data sources defined by the Entity Data Model (EDM) through LINQ.
  - LINQ to DataSet: Designed to work with ADO.NET DataSets, allowing for queries on data cached in DataSet objects.
- LINQ allows developers to write queries to retrieve, manipulate, and transform data from different data sources, such as databases, collections, XML, and In-Memory objects.
- Need to understand following concepts before learning to LINQ.
  - Collections in .NET: A good grasp of the Collection Framework in .NET, such as Arrays, List<T>, Dictionary<TKey, TValue>, and especially the interfaces IEnumerable and IEnumerable<T>, since these are the core interfaces that LINQ queries work with.
  - Generics: Understanding Generics in .NET is important because LINQ is heavily based on generic collections (IEnumerable<T>, IQueryable<T>, etc.).
  - Lambda Expressions: LINQ heavily relies on Lambda Expressions to express criteria, projections, and transformations within queries. They provide a concise way to represent anonymous methods.
  - Extension Methods: LINQ queries are implemented as Extension Methods for the IEnumerable and IQueryable types. Understanding how extension methods work will help you understand how LINQ integrates with object collections.
  - Anonymous Types: LINQ frequently uses Anonymous Types to store select query results. Knowing how they work will allow you to create and manipulate such types easily.  
- We can use LINQ queries in two ways:
    Query Syntax
    Method Syntax
##### Steps for writing the Query syntax:
1) add the System.Linq namespace in the code.
- using System.Linq;  
2) create the data source
```
List list = new List()  
{  
  " Hi! ",  
  " Sani ",  
  " Learning LINQ."  
  " Any Queries "  
};  
```
3) query for the data source
```
var r = from l in list  
        where l.Contains(" Sani ")  
        select l;  
```
4) execute the query using the for each loop.
```
foreach(var i in r)  
{  
  Console.WriteLine(i);  
}  
````
##### Steps for writing the Method syntax:
1) add the System.Linq namespace in the code.
- using System.Linq;  
2) create the data source
```
List list = new List()  
{  
  " Hi! ",  
  " Sani ",  
  " Learning LINQ."  
  " Any Queries "  
};  
```
3) create the query using the methods provided by the Enumerable or Queryable static classes
```
var r = list.Where(a=> a.Contains(" Sani "));  
```
4) execute the query using the for each loop.
```
foreach(var i in r)  
{  
  Console.WriteLine(i);  
}  
````
    The client doesn't have to learn new query languages for an alternate type of data format or data source.
    It increments the clarity of the code.
    The query can be reused.
    It gives type checking of the object at assemble time.
    It gives IntelliSense to conventional collections.
    It tends to be utilized with collections or arrays.
    LINQ upholds ordering, grouping, filtering, and sorting.
    It makes debugging simple since it is coordinated with the C# language.
    It gives straightforward change suggesting you can without a doubt change more than one data type into another data type like changing SQL data into XML data.
##### CRUD using LINQ Query
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LINQLearning
{
    class Program
    {
        static string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["LINQLearning.Properties.Settings.sani_usermanagementConnectionString"].ToString();

        static LinqToSQLDataContext db = new LinqToSQLDataContext(connectString);

        //SANI: Create a user object
        static user userObject = new user();

        static void Main(string[] args)
        {
            //insertUser();
            //listSingleUserRecord();
            //updateUser();
            //deleteUser();
            listAllUsers();

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }

        static void insertUser()
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

        static void listSingleUserRecord()
        {
            user userRecord = db.users.FirstOrDefault(e => e.name.Equals("Sani"));


            Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                             userRecord.id, userRecord.name, userRecord.email,
                             userRecord.phone, userRecord.interests);
        }


        static void listAllUsers()
        {
            var userObject = db.users; //from db context to variable list

            foreach (user userRecord in userObject)
            {
                Console.WriteLine("Id = {0} , Name = {1}, Email = {2}, ContactNo = {3}, Address = {4}",
                             userRecord.id, userRecord.name, userRecord.email,
                             userRecord.phone, userRecord.interests);
            }

            
        }


        static void updateUser()
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

        static void deleteUser()
        {
            user userObject = db.users.FirstOrDefault(e => e.id.Equals("4005"));


            db.users.DeleteOnSubmit(userObject);

            //Save changes to Database.
            db.SubmitChanges();
        }
    }
}

```
##### LINQ-OBJECT
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

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

    }
}

``` 
##### 	LINQ - ENTITIES   
```
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
















        
    }
}

```
##### LINQ - ENTITIES   
```
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

``` 

