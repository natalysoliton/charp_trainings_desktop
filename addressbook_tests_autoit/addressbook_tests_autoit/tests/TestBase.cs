using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_tests_autoit
{
    [TestFixture]
    public class TestBase
    {
        protected ApplicationManager app;

        [OneTimeSetUp]
        public void initApplication() 
        {
            app = new ApplicationManager();
        }

        [OneTimeTearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}
