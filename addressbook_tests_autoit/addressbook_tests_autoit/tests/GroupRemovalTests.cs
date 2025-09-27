using System;
using System.Collections.Generic;
using NUnit.Framework;
//using NUnit.Framework.Legacy;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count == 1)
            {
                GroupData newGroup = new GroupData()    
                {
                    Name = "GroupToDelete"
                };
                app.Groups.Add(newGroup);               
                oldGroups = app.Groups.GetGroupList();  
            }
            app.Groups.Remove(); 

            List<GroupData> newGroups = app.Groups.GetGroupList();

            Assert.That
                (newGroups.Count,       
                Is.EqualTo              
                (oldGroups.Count - 1)); 
        }
    }
}