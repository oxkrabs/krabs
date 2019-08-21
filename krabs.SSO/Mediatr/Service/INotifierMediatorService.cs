using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace krabs.SSO.Mediatr.Service
{
    public interface INotifierMediatorService
    {
        void Notify(string notifyText);
    }
}
