using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.TwentyOne;

namespace Casino.Interfaces
{
    interface IWalkAway //--.NET allows for multiple inheritances of interfaces Naming convention starts with "I".
    {
        void WalkAWay(Player player);
    }
}
