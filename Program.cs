using System;

namespace CsvReadApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string sampleCSV = string.Empty;
            int position = 0;
            string searchInput = string.Empty;
            Console.WriteLine("Enter the file path to read");
            sampleCSV = Console.ReadLine();
            if (string.IsNullOrEmpty(sampleCSV))
            {
                Console.WriteLine("Please enter the path");
                return;
            }
            string[] words = sampleCSV.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0)
                    sampleCSV = @words[0];
                else if (i == 1)
                    position = Convert.ToInt32(words[1]);
                else if (i == 2)
                    searchInput = words[2];
            }

            // Get the file's text.
            string[] values = { "Record Not Found" };
            string[] read_lines = System.IO.File.ReadAllLines(sampleCSV);
            //if no search input will pass all data
            if (position == 0 || string.IsNullOrEmpty(searchInput))
            {
                //For all data it'll display on separate line 
                for (int i = 0; i < read_lines.Length; i++)
                {
                    Console.WriteLine(read_lines[i]);
                }
            }
            else
            {
                values = SearchitemfromCSV(read_lines, position, searchInput);
                // Display the sarch data to show we have it.

                for (int c = 0; c < values.Length; c++)
                {
                    if (c == 0)
                        Console.Write(values[c]);
                    else
                        Console.Write("," + values[c]);

                }

            }



            Console.ReadLine();
        }
        private static string[] SearchitemfromCSV(string[] filename, int position, string searchInput)
        {

            //Serching with the input param
            string[] fields = { };
            for (int i = 0; i < filename.Length; i++)
            {
                fields = filename[i].Split(',');
                if (fields[position].Equals(searchInput))
                {
                    return fields;
                }
            }
            return fields;
        }
    }
}
