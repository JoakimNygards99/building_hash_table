using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HashTable
{
    public class student
    {
        //h21jonyg
        public string UserName { get; set; }
        public string Name { get; set; }
        public int PhoneNumer { get; set; }
        public string Email { get; set; }
        public string Programme { get; set; }

        public student(string username, string name, int phonenumber, string email, string programme) 
        { 
            this.UserName = username;
            this.Name = name;
            this.PhoneNumer = phonenumber;
            this.Email = email;
            this.Programme = programme;
        }

        public override string ToString()
        {
            return $"{{'Username': '{UserName}', 'Name': '{Name}', 'Phonenumber': '{PhoneNumer}', 'Email': '{Email}, 'Programme': '{Programme}}}";
        }
    }
}
