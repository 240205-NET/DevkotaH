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


        //Methods

        public abstract string ToString();


    }

}