using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace mvcPractice.Controllers
{
    public class BaseController : Controller
    {
        public Guid GetUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userIdValue = null;
            if (claimsIdentity != null)
            {
                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userIdValue = userIdClaim.Value;
                }
            }

            Guid userIdGuid;
            Guid.TryParse(userIdValue, out userIdGuid);

            return userIdGuid;
        }
    }
}