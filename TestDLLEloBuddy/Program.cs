using System;
using System.Drawing;
using System.IO;
using System.Reflection;

using EloBuddy;
using EloBuddy.SDK.Events;

namespace TestDLLEloBuddy
{
    class Program
    {
        private static readonly string dllPath = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\EloBuddy\Addons\Libraries\ChampionScriptDLLTest.dll";
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (File.Exists(dllPath))
            {
                File.Delete(dllPath);
            }


            var dllpath = Assembly.LoadFrom(dllPath);
            var main = dllpath.GetType("e").GetMethod("a", BindingFlags.NonPublic | BindingFlags.Static);

            main.Invoke(null, null);
            Chat.Print("test");
        }
    }
}
