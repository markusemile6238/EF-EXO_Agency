using Domaine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Interfaces.IActivity
{
    public interface IActivityDestination
    {
        IActivityPrice SetDestination(int destinationId);
    }
}
