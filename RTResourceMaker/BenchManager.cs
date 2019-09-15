using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RTResourceMaker
{
    internal static class BenchManager
    {
        internal static string mainloc = Environment.GetEnvironmentVariable("appdata");
        internal const string team = "\\Atus";
        internal const string program = "\\RTResourceManager";
        internal const string projects = "\\Projects";

        internal const string extension = "rt";
        internal const string pextension = "rts";

        internal static string EnvironmentLoc { get { return mainloc + team + program; } }


        internal static bool isInit { get; set; }

        internal static void Init()
        {
            if (!isCreated()) CreateBench();
            isInit = true;
        }

        internal static bool isCreated()
        {
            if (!Directory.Exists(mainloc)) return false;
            if (!Directory.Exists(mainloc + team)) return false;
            if (!Directory.Exists(mainloc + team + program)) return false;
            if (!Directory.Exists(EnvironmentLoc + projects)) return false;

            return true;
        }

        internal static void CreateBench()
        {
            if (!Directory.Exists(mainloc)) Directory.CreateDirectory(mainloc);
            if (!Directory.Exists(mainloc + team)) Directory.CreateDirectory(mainloc + team);
            if (!Directory.Exists(mainloc + team + program)) Directory.CreateDirectory(mainloc + team + program);
            if (!Directory.Exists(EnvironmentLoc + projects)) Directory.CreateDirectory(EnvironmentLoc + projects);
        }
    }
}
