using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer_Pattern
{
    public interface IBeneficiary
    {
        void Notify(IAccount account);
    }
}
