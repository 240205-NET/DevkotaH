using System;

namespace Program
{
    public class PremiumMembership : Person
    {
        //fields
        public int? memberId;


        //constructors 
        public PremiumMembership()
        { }

        public PremiumMembership(string name, string email, int phoneNo, string gender)
        {
            this.memberId = base.idSeed;
            this.name = name;
            this.email = email;
            this.phoneNo = phoneNo;
            this.gender = gender;
            this.isPremimum = true;
            base.idSeed++;
        }
        public PremiumMembership(int? memberId, string? name, string? email, int? phoneNo, string? gender)
        {
            this.memberId = memberId;
            this.name = name;
            this.email = email;
            this.phoneNo = phoneNo;
            this.gender = gender;
            this.isPremimum = true;
        }

        //methods


        public override string ToString()
        {
            return ($"Premium Member: {this.isPremimum}\nName: {this.name}\nGender: {this.gender}\nMemberID: {this.memberId}\nEmail: {this.email}\nPhoneNo: {this.phoneNo}");
        }
    }
}