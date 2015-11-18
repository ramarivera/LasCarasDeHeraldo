using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LasCarasDeHeraldo.Tests
{
    public class Trial
    {

        // you could also move these definitions to a config file
        private static IDictionary<string, string> _groupRoleMappings = new Dictionary<string, string>()
        {
        {"MYAPPUSERGRP", MyRoles.Standard},
        {"MYAPPSUPPORTGRP", MyRoles.Extended},
        {"MYAPPADMINGRP", MyRoles.Admin},
        };

        
        private static void Prin()
        {
            var windowsId = WindowsIdentity.GetCurrent();
            if (windowsId != null)
            {
                var allRoleNames = getGroupCorrespondingRoles(windowsId);
                var newPrincipal = new GenericPrincipal(windowsId, allRoleNames);
                Thread.CurrentPrincipal = newPrincipal;


                
            }
            else
            {
                throw new NotSupportedException("There must be a logged on Windows User.");
            }
        }

        private static string[] getGroupCorrespondingRoles(WindowsIdentity id)
        {
            // you also could do this more elegant with LINQ
            var allMappedRoleNames = new List<string>();

            string roleName;

            foreach (var grp in id.Groups)
            {
                var groupName = grp.Translate(typeof(NTAccount)).Value.ToUpper();
                if (_groupRoleMappings.TryGetValue(groupName, out roleName))
                {
                    allMappedRoleNames.Add(roleName);
                }
            }

            return allMappedRoleNames.ToArray();
        }
    }


    public static class MyRoles
    {
        public const string Standard = "standard_role";
        public const string Extended = "extended_role";
        public const string Admin = "admin_role";
    }

}
