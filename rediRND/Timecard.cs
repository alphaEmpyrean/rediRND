using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    /// <summary>
    /// This is a class to keep track of time card data directly necessary for stake calculation
    /// </summary>
    internal class Timecard
    {

        public Timecard(Dictionary<User, decimal> ledger) 
        {
            Ledger = ledger;

            foreach (User user in Ledger.Keys)
            {
                TotalHoursWorked += Ledger[user];
            }
        }

        public Dictionary<User, decimal> Ledger { get; private set; }

        public decimal TotalHoursWorked { get; private set; }

        public decimal HoursWorkedTodayByUser(User user)
        {
            return Ledger[user];
        }

        public void AddEntry(User user, int hours) 
        {
            Ledger[user] += hours;
            TotalHoursWorked += hours;
        }
    }
}
