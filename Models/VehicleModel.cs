using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_System_Test_App.Models
{
    public class VehicleModel
    {
        public int Id { get; set; } = -1;
        public int UserId { get; private set; }
        public string Descript { get; private set; }
        public string Reg { get; private set; }
        public DateTime? DateRegistered
        {
            get
            {
                if (DateRegistered == null)
                    return null;
                return new DateTime(DateRegistered.Value.Year, DateRegistered.Value.Month, DateRegistered.Value.Day);
            }
            private set
            {
                if (value != null)
                    DateRegistered = value;
            }
        }

        public VehicleModel(int user, string desc)
        {
            Setup(user, desc, "", null);
        }

        public VehicleModel(int user, string desc, string reg)
        {
            Setup(user, desc, reg, null);
        }

        public VehicleModel(int user, string desc, string reg, DateTime regDate)
        {
            Setup(user, desc, reg, regDate);
        }

        private void Setup(int user, string desc, string reg, DateTime? regDate)
        {
            UserId = user;
            Descript = desc;
            Reg = reg;
            DateRegistered = regDate;
        }
    }
}