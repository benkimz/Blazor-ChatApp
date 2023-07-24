using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.MessageAggregate
{
    public enum DeliveryStates
    {
        Pending, 
        Failed, 
        Sent, 
        Delivered, 
        Read
    }
}
