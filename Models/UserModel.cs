using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace User_System_Test_App.Models
{
    public class UserModel
    {
        public int Id { get; private set; } = -1;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        private DateTime _dateOfBirth;
        private bool _hasDob = false;
        public DateTime? DateOfBirth
        {
            get
            {
                if (!_hasDob)
                    return null;
                return new DateTime(_dateOfBirth.Year, _dateOfBirth.Month, _dateOfBirth.Day);
            }
            private set
            {
                if (value != null)
                {
                    _hasDob = true;
                    _dateOfBirth = value.Value;
                } else
                {
                    _hasDob = false;
                }
            }
        }

        public bool IsAdmin { get; private set; }
        //public int VehicleCount { get; set; }

        public UserModel(string lName, string email, bool isAdmin = false)
        {
            Setup("", lName, email, null, isAdmin);
        }

        public UserModel(string fName, string lName, string email, bool isAdmin = false)
        {
            Setup(fName, lName, email, null, isAdmin);
        }

        public UserModel(string lName, string email, DateTime dob, bool isAdmin = false)
        {
            Setup("", lName, email, dob, isAdmin);
        }

        public UserModel(string fName, string lName, string email, DateTime dob, bool isAdmin = false)
        {
            Setup(fName, lName, email, dob, isAdmin);
        }

        public UserModel(DataTable set, int id)
        {
            var rows = set.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                if ((int)row["Id"] == id)
                {
                    Id = id;
                    FirstName = row["FirstName"].ToString();
                    LastName = row["LastName"].ToString();
                    Email = row["Email"].ToString();
                    DateOfBirth = (DateTime)row["DateOfBirth"];
                    IsAdmin = (int)row["IsAdmin"] == 1;
                    //VehicleCount = (int)row["Vehicles"];
                    break;
                }
            }
        }

        private void Setup(string fName, string lName, string email, DateTime? dob, bool isAdmin)
        {
            FirstName = fName;
            LastName = lName;
            Email = email;
            DateOfBirth = dob;
            IsAdmin = isAdmin;
        }
    }
}