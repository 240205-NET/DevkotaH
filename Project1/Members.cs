using System;
using System.Text;

namespace Program
{
    class Members
    {
        private List<PremiumMembership> premiumMembershipList;
        private List<RegularMembership> regularMembershipList;

        public Members(){
            this.premiumMembershipList=new List<PremiumMembership>();
            this.regularMembershipList=new List<RegularMembership>();

            // regularMembership.Add(new RegularMembership("Tom", "tom@tom.tom",210210210, "Male"));
        }

        //methods
        public RegularMembership AddRegularMembership(){
            Console.WriteLine("To Write To File Please add Regular Membership");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender=Console.ReadLine();
            Console.WriteLine("Enter Phone number (Must be 10 digit): ");
            int phoneNo= int.Parse(Console.ReadLine());
            while(phoneNo.ToString().Length!=10){
                Console.WriteLine("Please Enter 10 Digit phone number:" );
                phoneNo= int.Parse(Console.ReadLine());   
            }
            Console.WriteLine("Enter e-mail: ");
            string email= Console.ReadLine();
            RegularMembership regularMember = new RegularMembership( name,  email,  phoneNo,  gender);
            regularMembershipList.Add(regularMember);
            return regularMember;

        }
        // public  void CancelMembership();
        // public  void SearchMembership();
        // public  void EditMembership();
        public string ViewMembership(){
            var sb = new StringBuilder();
            foreach(RegularMembership rm in regularMembershipList){
                sb.AppendLine(rm.ToString());
            }
            return sb.ToString();

        }




    }

}