using Microsoft.VisualBasic.FileIO;
using OutsuranceFileProcessor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsuranceFileProcessor
{
    public class Program
    {
        #region Private Members
        /// <summary>
        /// Import file location, usually in app.config, private variable as it is only used here
        /// </summary>
        private static string importFile = "Import/data.csv";
        /// <summary>
        /// Export location, usually in app.config, private variable as it is only used here
        /// </summary>
        private static string exportLocation = "Export";

        #endregion

        static void Main(string[] args)
        {
            //Write initial console instructions
            Console.WriteLine("Console Commands :");
            Console.WriteLine("1. G : Generate Text Files in Export directory");
            Console.WriteLine("2. U : Unit tests");
            Console.WriteLine("3. Press ESC to Close");

            //Listen on key input and inspect command 
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.G:
                        Console.WriteLine("Generating Text Files from CSV input");
                        var generateResult = GenerateTextFiles();

                        if (!generateResult)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Something went wrong.");
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Files Generated Successfully.");
                        }
                        break;
                    case ConsoleKey.U:
                        var unitTestResult = UnitTests();
                        if (!unitTestResult)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Something went wrong.");
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Unit tests Successful.");
                        }

                        Console.WriteLine("Mocking objects for unit testing");
                        break;
                    default:
                        Console.WriteLine("Unknown Command");
                        break;
                }

            } while (key != ConsoleKey.Escape);
        }

        #region Private Methods
        /// <summary>
        /// UnitTests
        /// Runs the unit tests for the managed Users class.
        /// </summary>
        /// <returns>return a boolean value indicating success</returns>
        private static bool UnitTests()
        {
            try
            {
                UsersTests userTests = new UsersTests();

                Console.WriteLine("");

                Console.WriteLine("----First Test : Populate test users");
                userTests.PopulateUsers();
                Console.WriteLine("----Successful");

                Console.WriteLine("");

                Console.WriteLine("----Second Test : Return grouped first and last names");
                List<UserGroupedNameInfo> groupedNames = userTests.TestGroupedFirstAndLastNames();
                groupedNames.ForEach(group =>
                {
                    Console.WriteLine(string.Format("{0},{1}", group.Name, group.Count));
                });
                Console.WriteLine("----Successful");

                Console.WriteLine("");

                Console.WriteLine("----Third Test");
                List<string> addresses = userTests.TestDistinctAddressList();
                addresses.ForEach(address =>
                {
                    Console.WriteLine(string.Format("{0}", address));
                });
                Console.WriteLine("----Successful");

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(string.Format("An exception occured : ", ex.Message));
                return false;
            }
        }

        /// <summary>
        /// GenerateTextFiles
        /// Generates two text files from a csv datasource
        /// </summary>
        /// <returns>return a boolean value indicating success</returns>
        public static bool GenerateTextFiles()
        {
            try
            {
                //initialise user list model
                Users users = new Users();

                //validate import file existance
                if (!File.Exists(importFile))
                {
                    Console.WriteLine("Import file not found");
                    return false;
                }

                //use existing csv parser found in Microsoft.VisualBasic.dll
                using (TextFieldParser parser = new TextFieldParser(importFile))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    bool headers = true;
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        if (headers)
                        {
                            headers = false;
                            continue;
                        }

                        //add entity to user list model through custom list add method
                        users.AddUser(fields);
                    }
                }

                //validate export directory existance
                if (!Directory.Exists(exportLocation)) Directory.CreateDirectory(exportLocation);
                Console.WriteLine("");

                //generate the first file
                #region First File
                Console.WriteLine("----First File");

                StringBuilder file1 = new StringBuilder();
                List<UserGroupedNameInfo> groupedNames = users.getGroupedFirstAndLastNames();
                groupedNames.ForEach(group => 
                {
                    string result = string.Format("{0},{1}", group.Name, group.Count);
                    Console.WriteLine(result);
                    file1.AppendLine(result);
                });

                //write string builder content to file
                File.WriteAllText(Path.Combine(exportLocation, "File1.txt"), file1.ToString());
                Console.WriteLine("");
                #endregion

                //generate the second file
                #region Second File
                Console.WriteLine("----Second File");

                StringBuilder file2 = new StringBuilder();
                List<string> addresses = users.getDistinctAddressList();
                addresses.ForEach(address => 
                {
                    string result = string.Format("{0}", address);
                    Console.WriteLine(result);
                    file2.AppendLine(result);
                });

                //write string builder content to file
                File.WriteAllText(Path.Combine(exportLocation, "File2.txt"), file2.ToString());
                #endregion
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("An exception occured : ", ex.Message));
                return false;
            }
        }
        #endregion
    }
}
