using System;
using System.Text.RegularExpressions;

namespace Assignment13
{
    class Program
    {
        public void Main()
        {
            Console.WriteLine("Enter a piece of text (sentence or paragraph):");
            string inputText = Console.ReadLine();

            int wordCount = CountWords(inputText);
            Console.WriteLine($"Word Count: {wordCount}");

            ValidateEmails(inputText);

            MobileNumbers(inputText);

            Console.WriteLine("Enter a custom regular expression:");
            string customRegex = Console.ReadLine();
            CustomRegexSearch(inputText, customRegex);
        }

        public int CountWords(string text)
        {
            string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public void ValidateEmails(string text)
        {
            Console.WriteLine("Email Addresses:");
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            MatchCollection matches = Regex.Matches(text, emailPattern);


            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

        }

        public void MobileNumbers(string text)
        {
            Console.WriteLine("Mobile Numbers:");

            string mobilePattern = @"\b\d{10}\b";

            MatchCollection matches = Regex.Matches(text, mobilePattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }

        public void CustomRegexSearch(string text, string customRegex)
        {
            Console.WriteLine("Custom Regex Search Results:");

            try
            {

                MatchCollection matches = Regex.Matches(text, customRegex);


                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error in custom regex: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
