using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using Beadando1.Model;
using System.Data;
using SQLite;

namespace Beadando1.DataHandling
{
    public class SQLhandler
    {
        public SqliteConnection connection;
        string connectionString;
        public List<SqliteParameter> parameters;
        SQLite.SQLiteConnection connection2;


        public SQLhandler()
        {
            //Journal Mode=Persist;Synchronous=Full; Version=3; UTF8Encoding=True; New=True"
            System.Data.SQLite.SQLiteConnection.CreateFile("MyDatabase.db");
            string baseConnectionString = "Data Source=Data.db;";  
            connectionString = new SqliteConnectionStringBuilder(baseConnectionString)
            {
                Mode = SqliteOpenMode.ReadWriteCreate,
                
            }.ToString();
            connection = new SqliteConnection(connectionString);
            parameters = new List<SqliteParameter>();
            //Advanced SQLite.SQLiteConnection
             connection2 = new SQLite.SQLiteConnection("MyDatabase");
            //Alter table and foreign key is missing
            //Update, BackUp, BeginTransaction


        }

        public void CreateTable(string ClassName)
        {        
            try
            {
                switch (ClassName)
                {
                    case "Owner":
                        connection2.CreateTable<Owner>();
                        break;
                    case "Customer":
                        connection2.CreateTable<Customer>();
                        break;
                    case "Deliver":
                        connection2.CreateTable<Deliver>();
                        break;
                    case "Delivery":
                        connection2.CreateTable<Delivery>();
                        break;
                    case "Order":
                        connection2.CreateTable<Order>();
                        break;
                    case "PickUpProduct":
                        connection2.CreateTable<PickUpProduct>();
                        break;
                    case "Product":
                        connection2.CreateTable<Product>();
                        break;
                    case "ProductPicture":
                        connection2.CreateTable<ProductPicture>();
                        break;
                    case "ProductRating":
                        connection2.CreateTable<ProductRating>();
                        break;
                    case "Upload":
                        connection2.CreateTable<Upload>();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Table added!");
                connection2.Commit();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void AlterTable(string ClassName)
        {
            string CommandType = "ALTER TABLE";
            string CommandString = "";
            connection2.Execute("PRAGMA foreign_keys=ON");
            switch (ClassName)
            {
                case "Owner":
                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName,"FOREIGN KEY (did) REFERENCES Delivery(did);");
                    break;
                case "Deliver":
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (did) REFERENCES Delivery(did)");
                    connection2.Execute("PRAGMA foreign_keys=ON");
                    //connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (cid) REFERENCES Customer(cid)");
                    break;
                case "Order":
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (productid) REFERENCES Product(pid)");
                   // connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (cid) REFERENCES Customer(cid)");
                    break;
                case "PickUpProduct":
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (pid) REFERENCES Product(pid)");
                   // connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (oid) REFERENCES Owner(id)");
                    break;
                case "Product":
                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName, "ownerid int");
                   // connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName, "FOREIGN KEY (ownerid) REFERENCES Owner(id)");
                   // connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");

                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName, "did int");
                   // connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName, "FOREIGN KEY (did) REFERENCES Delivery(did)");
                  //  connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                     
                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName, "cid int");
                  //  connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName, "FOREIGN KEY (cid) REFERENCES Customer(cid)");
                    break;
                case "ProductPicture":
                    CommandString = PreaperedStatements.CommandString("ALTER TABLE", ClassName,"FOREIGN KEY (pid) REFERENCES Product(pid)");
                    break;
                case "ProductRating":
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName,  "FOREIGN KEY (pid) REFERENCES Product(pid)");
                    break;
                case "Upload":
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (ownerid) REFERENCES Owner(id)");
                   // connection2.Execute(CommandString);
                    Console.WriteLine("Table altered!");
                    CommandString = PreaperedStatements.CommandString(CommandType, ClassName, "FOREIGN KEY (pid) REFERENCES Product(pid)");
                    break;
                default:
                    break;
            }
            try
            {
                connection2.Execute(CommandString);
                Console.WriteLine("Table altered!");
                connection2.Commit();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Will know wihich table into from Type.
        /// </summary>
        /// <param name="modul"></param>
        public void InsertIntoTable(IModul modul)
        {
            try
            {
                connection2.InsertOrReplace(modul);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            connection2.Commit();
        }

        public void InsertTables(DataFromFile dataFromFile)
        {
            foreach (Owner item in dataFromFile.owners)
            {
                InsertIntoTable(item);
            }
            foreach (ProductRating item in dataFromFile.rates)
            {
                InsertIntoTable(item);
            }
            foreach (ProductPicture item in dataFromFile.picture)
            {
                InsertIntoTable(item);
            }
            foreach (Product item in dataFromFile.products)
            {
                InsertIntoTable(item);
            }
            foreach (Customer item in dataFromFile.customers)
            {
                InsertIntoTable(item);
            }
            foreach (Delivery item in dataFromFile.deliveries)
            {
                InsertIntoTable(item);
            }
            foreach (Deliver item in dataFromFile.delivers)
            {
                InsertIntoTable(item);
            }
            foreach (PickUpProduct item in dataFromFile.pickUps)
            {
                InsertIntoTable(item);
            }
            foreach (Upload item in dataFromFile.uploads)
            {
                InsertIntoTable(item);
            }
            foreach (Order item in dataFromFile.orders)
            {
                InsertIntoTable(item);
            }
        }

        public List<string> GetSelectQuery(string field, string tableName, string commandString)
        {
            List<string> query = new List<string>();
            string CommandText = $" SELECT {field} FROM {tableName} WHERE {commandString}";

            // Select in select maybe?
            if (commandString.Equals(string.Empty))
            {
                commandString = $"SELECT {field} FROM {tableName};";
            }
            if (commandString.Contains("JOIN"))
            {
                commandString = $"SELECT{field} FROM {tableName} {commandString}";
            }
            try
            {
                switch (tableName)
                {
                    case "Owner":
                        foreach (var item in connection2.Query<Owner>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "Deliver":
                        foreach (var item in connection2.Query<Deliver>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "Delivery":
                        foreach (var item in connection2.Query<Delivery>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                    case "Order":
                        foreach (var item in connection2.Query<Order>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "PickUpProduct":
                        foreach (var item in connection2.Query<PickUpProduct>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "Product":
                        foreach (var item in connection2.Query<Product>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "productrating":
                        foreach (var item in connection2.Query<ProductPicture>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "ProductRating":
                        foreach (var item in connection2.Query<ProductRating>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "Upload":
                        foreach (var item in connection2.Query<Upload>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                case "Customer":
                        foreach (var item in connection2.Query<Customer>(CommandText))
                        {
                            query.Add(item.ToString());
                        }
                        break;
                    default:
                    break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            return query;
        }

        public void UpdateTable(IModul TableItem)
        {
            connection2.Update(TableItem);
        }
        
        public void DeleteItem(IModul TableItem)
        {
            connection2.Delete(TableItem);
        }

        public List<string> GetTableMetaData(string tableName)
        {
            List<string> tableMetaData = new List<string>();
            List<SQLite.SQLiteConnection.ColumnInfo> columns = connection2.GetTableInfo(tableName).ToList();
            foreach (var item in columns)
            {
                tableMetaData.Add(item.ToString());
            }   
            return tableMetaData;          
        }

        public void SetTransaction(string command, string command2)
        {
            using (var transaction = connection.BeginTransaction(deferred: true))
            {
                // Before the first statement of the transaction is executed, both concurrent
                // reads and writes are allowed

                SqliteCommand readCommand = connection.CreateCommand();
                readCommand.CommandText = command;
                int value = (int)readCommand.ExecuteScalar();

                // After a the first read statement, concurrent writes are blocked until the
                // transaction completes. Concurrent reads are still allowed

                var writeCommand = connection.CreateCommand();
                writeCommand.CommandText = command2;
                writeCommand.ExecuteNonQuery();

                // After the first write statement, both concurrent reads and writes are blocked
                // until the transaction completes

                transaction.Commit();
            }
        }

        public void SetTransactionWithSavePoint(string command, string command2)
        {
            using (var transaction = connection.BeginTransaction())
            {
                // Transaction may include additional statements before the savepoint

                var updated = false;
                do
                {
                    // Begin savepoint
                    transaction.Save("optimistic-update");

                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = command;
                    insertCommand.ExecuteScalar();

                    var updateCommand = connection.CreateCommand();
                    updateCommand.CommandText = command2;
                    var recordsAffected = updateCommand.ExecuteNonQuery();
                    if (recordsAffected == 0)
                    {
                        // Concurrent update detected! Rollback savepoint and retry
                        transaction.Rollback("optimistic-update");
                    }
                    else
                    {
                        // Update succeeded. Commit savepoint and continue with the transaction
                        transaction.Release("optimistic-update");

                        updated = true;
                    }
                }
                while (!updated);

                
                transaction.Commit();
            }
        }
    }
}
