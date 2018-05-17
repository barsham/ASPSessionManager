using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegacySessionManager.UnitTest
{
    [TestClass]
    public class SessionPageTest
    {

        private static void SetupMocks()
        {

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter())
                )
            {
                User = new GenericPrincipal(
                    new GenericIdentity("username"),
                    new string[0]
                    )
            };

            // User is logged in

            // User is logged out
            HttpContext.Current.User = new GenericPrincipal(
                new GenericIdentity(String.Empty),
                new string[0]
                );
        }

        [TestMethod]
        public void CreateSessionPage()
        {

            SetupMocks();

            var sessionPage = new SessionPage();

            Assert.IsNotNull(sessionPage.Session);

        }
    }
}
