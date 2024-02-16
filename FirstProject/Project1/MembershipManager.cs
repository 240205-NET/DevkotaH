using System;
using System.Text;

namespace Program
{
    public class MembershipManager
    {
        // private List<PremiumMembership> premiumMembershipList;
        private List<RegularMembership> regularMembershipList;

        public MembershipManager()
        {
            // this.premiumMembershipList = new List<PremiumMembership>();
            this.regularMembershipList = new List<RegularMembership>();

            regularMembershipList.Add(new RegularMembership("Name ", "email@email.tom", 0000000000, "Gender"));
        }

        //methods

        public RegularMembership AddRegularMembership()
        {
            Console.WriteLine("To Write To File Please add Regular Membership");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Gender (M/F ) : ");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter Phone number: ");
            int phoneNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter e-mail: ");
            string email = Console.ReadLine();
            RegularMembership regularMember = new RegularMembership(name, email, phoneNo, gender);
            regularMembershipList.Add(regularMember);
            return regularMember;

        }



        public string ViewRegularMembership()
        {
            var sb = new StringBuilder();
            foreach (RegularMembership rm in regularMembershipList)
            {
                sb.AppendLine(rm.ToString());
            }
            return sb.ToString();
            // Console.WriteLine(sb.ToString());
        }



        public void ViewMembershipById(int id)
        {
            if (regularMembershipList.Count > 0)
            {
                foreach (RegularMembership rm in regularMembershipList)
                {
                    if (rm.memberId == id)
                    {

                        Console.WriteLine(rm.ToString());

                        break;
                    }


                }


            }

            else
            {
                Console.WriteLine("Member with the given doesn't exist.");
            }

        }
        public List<RegularMembership> GetRegularMembershipsList()
        {
            return regularMembershipList;
        }




    }

}