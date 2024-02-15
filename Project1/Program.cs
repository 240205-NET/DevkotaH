using System;
using System.Xml.Serialization;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Gym.\n");
            // Members members = new Members();

            Menu();

            // Console.WriteLine(members.ViewMembership());
            // members.AddRegularMembership();
            // Console.WriteLine(members.ViewMembership());

            Console.WriteLine("\nThank you for your visit. See you soon.");

        }
        public static void Menu()
        {
            string path = @".\GymMembership.txt";
            RegularMembership regularMember;
            Members members = new Members();
            Console.WriteLine("Please Select from the following options.");
            Console.WriteLine("1: Write To File.");
            Console.WriteLine("2: Read From File.");
            Console.WriteLine("3: Serialize Xml .");
            Console.WriteLine("4: Deserialize Xml");
            Console.WriteLine("5: Exit");
            Console.Write("Enter your Option: ");

            string? option = Console.ReadLine();
            while (option != "5")
            {
                switch (option)
                {
                    case "1":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        regularMember = members.AddRegularMembership();
                        WriteToFile(regularMember, path);
                        break;
                    case "2":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        ReadFromFile(path);
                        break;
                    case "3":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        regularMember = members.AddRegularMembership();
                        Serialize(regularMember, path);
                        break;
                    case "4":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        regularMember = DeserializeXML(path);
                        Console.WriteLine(regularMember.ToString());
                        break;
                    case "5":
                        Console.WriteLine("You have have successfully exited the program");
                        break;

                    default:
                        Console.WriteLine("invalid Choice, Try again!");
                        break;

                }
                Console.WriteLine("\n");
                Console.WriteLine("==========================");
                Console.WriteLine("Please Select from the following options.");
                Console.WriteLine("1: Write To File.");
                Console.WriteLine("2: Read From File.");
                Console.WriteLine("3: Serialize Xml .");
                Console.WriteLine("4: Deserialize Xml");
                Console.WriteLine("5: Exit");
                Console.Write("Enter your Option: ");
                option = Console.ReadLine();
            }
            Console.WriteLine("You have have successfully exited the program");

        }

        static void WriteToFile(RegularMembership regularMember, string path)
        {
            Console.WriteLine("Writing to file....");
            string write = regularMember.ToString();

            if (File.Exists(path))
            {
                File.AppendAllText(path, write);
            }
            else
            {
                File.WriteAllText(path, write);
            }
            Console.WriteLine("Written to file completed.");

        }

        static void ReadFromFile(string path)
        {
            Console.WriteLine("Reading File .....");

            //Checking for file and reading it.
            if (File.Exists(path))
            {
                string[] read = File.ReadAllLines(path);
                foreach (string s in read)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist in the given path.");
            }
        }

        static void Serialize(RegularMembership regularMember, string path)
        {
            //Serialize the object regularMember
            Console.WriteLine(regularMember.SerializeXML());

            //Saving Serialize object into file
            string[] write = { regularMember.SerializeXML() };
            File.WriteAllLines(path, write);
        }
        static RegularMembership DeserializeXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RegularMembership));
            RegularMembership regularMembership = new RegularMembership();
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found....");
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (RegularMembership)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    regularMembership = record;
                }
            }
            return regularMembership;
        }


    }

}

