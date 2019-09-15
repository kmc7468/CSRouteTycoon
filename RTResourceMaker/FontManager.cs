using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTResourceMaker
{
    internal class FontManager
    {
        private static FontManager _Instance;

        internal static FontManager Get()
        {
            if (_Instance == null)
            {
                _Instance = new FontManager();
            }

            return _Instance;
        }



        internal bool isInit { get; set; }
        internal bool isGet { get; set; }

        internal List<string> fonts = new List<string>();
        internal FontFamily EnvironmentFont = null;

        internal void Init()
        {
            InitFont();

            isInit = true;
        }

        internal void InitFont()
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            isGet = true;
        }

        internal List<string> GetFontNameByWindowsFontDir()
        {
            List<string> fonts = new List<string>();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            return fonts;
        }


        internal void SetFontByString(string myFont)
        {
            if (!isGet) return;

            for (int i = 0; i < fonts.Count(); i++)
            {
                if (fonts[i].Equals(myFont))
                {
                    EnvironmentFont = new FontFamily(myFont);
                    return;
                }
            }

            EnvironmentFont = new FontFamily("굴림");
            MessageBox.Show("' " + myFont + " ' 폰트이(가) 발견되지 않았습니다", "RTResourceMaker", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
