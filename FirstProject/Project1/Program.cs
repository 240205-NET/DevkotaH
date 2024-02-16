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
            MembershipManager members = new MembershipManager();
            Console.WriteLine("Please Select from the following options.");
                Console.WriteLine("1: Add Membership.");
                Console.WriteLine("2: View Membership.");
                Console.WriteLine("3: View Membership by Id .");
                Console.WriteLine("4: Write To File.");
                Console.WriteLine("5: Read From File.");
                Console.WriteLine("6: Serialize Xml .");
                Console.WriteLine("7: Deserialize Xml");
                Console.WriteLine("8: Exit");
                Console.Write("Enter your Option: ");;

            string? option = Console.ReadLine();
            while (option != "8")
            {
                switch (option)
                {
                    case "1":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        members.AddRegularMembership();
                        break;
                    case "2":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        Console.WriteLine(members.ViewRegularMembership());
                        break;
                    case "3":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        Console.WriteLine("Enter the id you want to view");
                        int id = int.Parse(Console.ReadLine());
                        members.ViewMembershipById(id);
                        break;
                    case "4":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        string memberInfo = members.ViewRegularMembership();
                        // regularMember = members.AddRegularMembership();
                        WriteToFile(memberInfo, path);
                        break;
                    case "5":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        ReadFromFile(path);
                        break;
                    case "6":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        regularMember = members.AddRegularMembership();
                        Serialize(regularMember, path);
                        break;
                    case "7":
                        Console.WriteLine("\n");
                        Console.WriteLine("==========================");
                        regularMember = DeserializeXML(path);
                        Console.WriteLine(regularMember.ToString());
                        break;
                    case "8":
                        Console.WriteLine("You have have successfully exited the program");
                        break;

                    default:
                        Console.WriteLine("invalid Choice, Try again!");
                        break;

                }
                Console.WriteLine("\n");
                Console.WriteLine("==========================");
                Console.WriteLine("Please Select from the following options.");
                Console.WriteLine("1: Add Membership.");
                Console.WriteLine("2: View Membership.");
                Console.WriteLine("3: View Membership by Id .");
                Console.WriteLine("4: Write To File.");
                Console.WriteLine("5: Read From File.");
                Console.WriteLine("6: Serialize Xml .");
                Console.WriteLine("7: Deserialize Xml");
                Console.WriteLine("8: Exit");
                Console.Write("Enter your Option: ");
                option = Console.ReadLine();
            }
            Console.WriteLine("You have have successfully exited the program");

        }

        static void WriteToFile(string memberInfo, string path)
        {
            Console.WriteLine("Writing to file....");
            string write = memberInfo;

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

