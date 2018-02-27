using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace lab5
{
    class Program
    {
        static void getTable(SqlConnection connection, string tableName)
        {

            string queryString = "SELECT * FROM " + tableName;

            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            Console.WriteLine("\n"+ tableName + ":");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (i != row.ItemArray.Length - 1)
                    {
                        Console.Write(row.ItemArray[i] + ", ");
                    }
                    else
                    {
                        Console.Write(row.ItemArray[i] + ";\n");
                    }
                }
            }

        }

        static void addClient(SqlConnection connection, string FirstName, string LastName)
        {
            string queryString = "INSERT INTO Clients (FirstName, LastName) VALUES ('" + FirstName + "', '" + LastName + "')";
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("\nClient added to database");
            command.Connection.Close();
        }

        static void updateClient(SqlConnection connection, string FirstName1, string LastName1, string FirstName2, string LastName2)
        {
            string queryString = "UPDATE Clients SET FirstName = '" + FirstName2 + "', LastName = '" + LastName2 +
                "' WHERE (FirstName = '" + FirstName1 + "') AND ( LastName = '" + LastName1 + "')";
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("\nClient updated");
            command.Connection.Close();
        }

        static void deleteClient(SqlConnection connection, string FirstName, string LastName)
        {
            string queryString = "DELETE FROM Clients  WHERE (FirstName = '" + FirstName + "') AND ( LastName = '" + LastName + "')";
            SqlCommand command = new SqlCommand(queryString, connection);

            command.Connection.Open();
            int number = command.ExecuteNonQuery();
            Console.WriteLine("\nClient deleted");
            command.Connection.Close();
        }


        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=VALENTINE\SQLEXPRESS;Initial Catalog=CSharpDB;Integrated Security=True";

            getTable(connection, "Clients");
            getTable(connection, "Joys");
            getTable(connection, "OrderTypes");
            getTable(connection, "Orders");
            getTable(connection, "Discounts");

            addClient(connection, "Nastya", "Starchenko");
            getTable(connection, "Clients");
            updateClient(connection, "Nastya", "Starchenko", "Illya", "Volkov");
            getTable(connection, "Clients");
            deleteClient(connection, "Illya", "Volkov");
            getTable(connection, "Clients");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
