using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rediRND
{
    internal class StakeLedgerEntry
    {
        decimal stake { get; set; }

        IStaker Staker { get; set; }

        public StakeLedgerEntry(IStaker staker, decimal stake) 
        {
            this.stake= stake;
            Staker= staker;
        }
    }
}
