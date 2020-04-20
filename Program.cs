using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CharacterCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();           //create new data dictionary
            string response;    //holds file name if incorrectly entered via console arg
            string filePath = GetFilePath(args[0]); //get full file path of text file
            bool cSensitive = true; //default if arg[1] is not entered
            const string caseInput = "caseoff";

            //Checks if second parameter has been entered
            if (args.Length > 1)
            {
                if (args[1].ToLower() != caseInput)     
                {       //If unvalid input has been entered in arg[1]
                    response = GetValidInput();

                    if (response == "n" || response == "N")
                        cSensitive = false;
                    else 
                        cSensitive = true;

                }
                else
                {
                    cSensitive = false;
                }
            }



            //General program instructions

            filePath = GetValidFile(filePath);
            Console.WriteLine("\nThis program reads a text file, count how many times a character appears in said text file and prints the top 10 letters found in count\n");

            StreamReader rdr = new StreamReader(File.OpenRead(filePath));

            int totalCount = 0; //keep track of total number of characters read
           
            while (!rdr.EndOfStream)        //Loop until end of file
            {
                char ch = (char)rdr.Read(); //Read 1 character from file
                if (Char.IsLetter(ch))          //Check if it is a letter
                {
                    if (!cSensitive )        //Convert to lowercase if not case sensitive count
                        ch = Char.ToLower(ch);
                    UpdateDict(ch,  dictionary);
                    totalCount += 1;

                }
            }
            
            //Create new dictionary with only top 10 counts in descending order
            var sortedDict = dictionary.OrderByDescending(entry => entry.Value)
                                 .Take(10)              //Take top 10 counts
                                 .ToDictionary(pair => pair.Key, pair => pair.Value);       //add to new dictionary

            //Print total count and top 10
            Console.WriteLine("Total Count: {0}", totalCount);
            foreach (KeyValuePair<char, int> kvp in sortedDict)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);            
            }


        }

        static string GetFilePath(string arg)
        {
            string curDir = Directory.GetCurrentDirectory();
                string filePath = curDir + "\\" + arg; //Makes full file path to open text file
                return filePath;
        }
        //adds keys and values to dictionary or updates key value
        static void UpdateDict(char ch,  Dictionary<char,int> dict)
        {
            if (!dict.ContainsKey(ch))
            {
                dict.Add(ch, 1);         //if not add with count of 1
            }
            else
            {
                dict[ch] += 1;           //else update count by 1
            }

        }

        //checks if file entered in console exists, if not loops until valid file entered
        static string GetValidFile(string file)
        {
            while(!File.Exists(file))
            {
                    //Error message
                    Console.Write("Error, file could not be opened. Please enter a valid file name e.g. Test.txt (Make sure text file is in program folder.)\n");
                    file= Console.ReadLine();
                    file = GetFilePath(file); //get full file path
            }
            return file;
        }

        //checks if user input is correct, loops until expected input
        static string GetValidInput()
        {
            string input;
            do
            {
                Console.WriteLine("Invalid Argument entered. Please enter N if you with to switch off case sensitivity or Y to keep it\n");
                input = Console.ReadLine();

            } while (input != "n" && input != "N" && input != "y" && input != "Y");
            return input;
        }
    }


}



















