using System;


namespace Program
{
    public abstract class Person
    {
        //Fields
        public string? name;
        public string? email;
        public int? phoneNo;
        public string? gender;

        public bool isPremimum = false;
        public int idSeed =1;



        //Constructors

        // public Person(string name, string email, int phoneNo, string gender)
        // {
        //     this.name = name;
        //     this.email = email;
        //     this.phoneNo=phoneNo;
        //     this.gender=gender;
        // }

        //Methods

        public abstract string ToString();


    }

}