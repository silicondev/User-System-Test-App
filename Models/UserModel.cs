using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_System_Test_App.Models
{
    public class UserModel
    {
        public int Id { get; set; } = -1;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime? DateOfBirth
        {
            get
            {
                if (DateOfBirth == null)
                    return null;
                return new DateTime(DateOfBirth.Value.Year, DateOfBirth.Value.Month, DateOfBirth.Value.Day);
            }
            private set
            {
                if (value != null)
                    DateOfBirth = value;
            }
        }

        public UserModel(string lName, string email)
        {
            Setup("", lName, email, null);
        }

        public UserModel(string fName, string lName, string email)
        {
            Setup(fName, lName, email, null);
        }

        public UserModel(string fName, string lName, string email, DateTime dob)
        {
            Setup(fName, lName, email, dob);
        }

        private void Setup(string fName, string lName, string email, DateTime? dob)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            DateOfBirth = dob;
        }
    }
}