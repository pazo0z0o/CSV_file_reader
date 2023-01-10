using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tutorial
{
    internal class Person
    {
        // private fields 
        private string _firstName = "";
        private string _lastName = "";
        private int _age = 0;
        private string _occupation = "";

        //public fields - getters only for our private variables
        public string Firstname { get { return _firstName; }  }
        public string Lastname { get { return _lastName; } }
        public int Age { get { return _age; } }
        public string Occupation { get { return _occupation; } }

        public Person(string firstName, string lastName, int age, string occupation)
        {//CONSTRUCTOR
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _occupation = occupation;
      
        }
























    }
}
