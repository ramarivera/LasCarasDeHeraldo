using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LasCarasDeHeraldo
{
    class MYIdentity : IIdentity
    {
        string IIdentity.AuthenticationType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IIdentity.IsAuthenticated
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IIdentity.Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    class MyPrincipal : IPrincipal
    {
        IIdentity IPrincipal.Identity
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IPrincipal.IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
