using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.Utilities
{
    public static class ClaimUtility
    {
        public static long? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var claimsIdentity = User.Identity as ClaimsIdentity;
                    //long userId = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    return long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }


        public static string? GetUserEmail(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                 
                    //if(!string.IsNullOrEmpty(claimsIdentity.FindFirst(ClaimTypes.Email).Value))
                    return claimsIdentity.FindFirst(ClaimTypes.Email).Value;
                //return null;
            }
            catch (Exception)
            {

                return null;
            }

        }


        public static List<string> Getroles(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                List<string> roles = new List<string>();
                foreach (var item in claimsIdentity.Claims.Where(p => p.Type.EndsWith("role")))
                {
                    roles.Add(item.Value);
                }
                return roles;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
