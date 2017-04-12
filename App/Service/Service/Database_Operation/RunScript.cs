using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Service.Database_Operation
{
    class RunScript
    {
        /// <summary>
        /// Insert SQL script into database
        /// </summary>
        /// <param name="file">File with SQL script</param>
        public static void FromFile(OpenFileDialog openFileDialog, Connection connection)
        {
            string file = openFileDialog.FileName;
            string sqlScript = File.ReadAllText(file);
            Execute(sqlScript, connection);
        }

        /// <summary>
        /// Insert SQL script into database
        /// </summary>
        /// <param name="sqlScript">SQL script string</param>
        public static void Execute(string sqlScript, Connection connection)
        {
            // Get SQL Connection
            SqlConnection myConnection = connection.GetConnection();

            // Prepare SQL
            IEnumerable<string> commandStrings = SplitSqlStatements(sqlScript);

            // Do command
            SqlCommand myCommand;
            foreach (string oneCommand in commandStrings)
            {
                myCommand = new SqlCommand(oneCommand, myConnection)
                {
                    CommandType = CommandType.Text
                };
                myCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Remove GO statement from script, also all white characters and not necessary chars
        /// </summary>
        /// <param name="sqlScript">SQL script string</param>
        /// <returns>String prepared for run</returns>
        private static IEnumerable<string> SplitSqlStatements(string sqlScript)
        {
            // Split by "GO" statements
            var statements = Regex.Split(
                    sqlScript,
                    @"^\s*GO\s*$",
                    RegexOptions.Multiline |
                    RegexOptions.IgnorePatternWhitespace |
                    RegexOptions.IgnoreCase);

            // Remove empties, trim, and return
            return statements
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim(' ', '\r', '\n'));
        }
    }
}
