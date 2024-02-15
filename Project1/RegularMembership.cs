using System;
using System.Xml.Serialization;

namespace Program
{
    public class RegularMembership : Person
    {
        //fields
        public int memberId { get; set; }
        private XmlSerializer serializer = new XmlSerializer(typeof(RegularMembership));

        //constructors 
        public RegularMembership()
        { }
        public RegularMembership(string? name, string? email, int? phoneNo, string? gender)
        {
            this.memberId = idSeed;
            this.name = name;
            this.email = email;
            this.phoneNo = phoneNo;
            this.gender = gender;

            idSeed++;


        }



        //methods


        public override string ToString()
        {
            return ($"Premium Member: {this.isPremimum}\nName: {this.name}\nGender: {this.gender}\nMemberID: {this.memberId}\nEmail: {this.email}\nPhoneNo: {this.phoneNo}\n");
        }

        public string SerializeXML()
        {
            var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }
    }
}