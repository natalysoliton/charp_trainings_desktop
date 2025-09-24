using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();

            // aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.62e44912"); // рефактор OpenGroupsDialogue();
            // aux.WinWait(GROUPWINTITLE); // рефактор OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4493");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");

            CloseGroupsDialogue();
            // aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4494"); //рефактор CloseGroupsDialogue();
        }

        private void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.62e44912");
            aux.WinWait(GROUPWINTITLE);
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.62e4494");
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>(); // создаем список для результатов

            OpenGroupsDialogue();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.62e4491", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
               string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.62e4491", "GetText", "#0|#" +i, "");
                list.Add(new GroupData()
                {
                    Name = item
                } );
            }

            CloseGroupsDialogue();
            return list; // возвращаем заполненный список
        }
    }
}