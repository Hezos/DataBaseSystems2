using Microsoft.Data.Sqlite;

namespace Beadando1.Model
{
    public class PreaperedStatements
    {
        /// <summary>
        /// Give the right command to right type
        /// </summary>
        /// <param name="commandCase"></param>
        /// <param name="table"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string CommandString(string commandCase, string table,  string command )
        {
            string result = "";
       
                    switch (commandCase)
                    {
                        case "CREATE TABLE":
                            return $"{commandCase} {table} ({command});";
                        case "INSERT INTO":
                            return $"{commandCase} {table} VALUES({command})";
                        case "DELETE FROM":
                            return $"{commandCase} {table} WHERE {command}";
                        case "UPDATE":
                            return $"{commandCase} {table} SET {command}";
                        case "SELECT":
                            return $"{commandCase} {command}";
                        case "ALTER TABLE":
                            return $"{commandCase} {table} ADD {command}";
                        default:
                            break;
                    }                   
            return result;
        }
    }
}
