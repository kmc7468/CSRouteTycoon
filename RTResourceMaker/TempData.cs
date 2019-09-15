using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTResourceMaker
{
    public static class TempData
    {
        public static class UIData
        {
            public static frmMain _frmMain = null;
            public static Form _frmMain_set;

            public static UI.edits.edit _edit = null;
            public static UserControl _edit_set;

            public static void Init()
            {
                _frmMain = _frmMain_set as frmMain;
                _edit = _edit_set as UI.edits.edit;
            }
        }

        public static class NewProjectData
        {
            public static string resname;
            public static string resmaker;
            public static string resinfo;
            public static string resver;
            public static string loc;
        }
    }
}
