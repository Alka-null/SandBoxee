using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TobeSandboxed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I ran in a sandbox");
        }

        public class UntrustedClassTobeInstantiated
        {
            public UntrustedClassTobeInstantiated(string position) {
                this.Position= position;
            }
            private string Position { get; set; }

            public string callmelater(string callmelater)
            {
                return "by noon";
            }
        }
        public class UntrustedClass
        {
            // Pretend to be a method checking if a number is a Fibonacci
            // but which actually attempts to read a file.
            public static bool IsFibonacci(int number)
            {
                File.ReadAllText("C:\\Temp\\file.txt");
                
                return false;
            }

            public static string PrintMyNameAsync(string firstname, string surname)
            {
                File.ReadAllText("C:\\Temp\\file.txt");
                string lines =
                
                    "First line, Second line, Third line"
                ;
                File.WriteAllText("WriteLines.txt", lines);

                return "My name is " + firstname + " " + surname;
            }

            public static string makewebrequest(string accept)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                //var json = await client.GetStringAsync(
                //                        "https://api.github.com/orgs/dotnet/repos"
                //                        );

                return "just json";
            }
        }

        public class AnotherUntrustedClass
        {
            public void makesomenoise(string sound)
            {
                Console.WriteLine(sound);
            }
        }
    }
}
