using System.Collections.Generic;
using System.Diagnostics;

namespace AkkaSelectionNettyEnvExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                ExecuteLoop("AkkaSelectionNettyEnvClient.exe");
            else
                ExecuteLoop(args[0]);
        }

        public static void ExecuteLoop(string filename)
        {
            ProcessStartInfo info = new ProcessStartInfo()
            {
                FileName = filename,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            while (true)
            {
                List<Process> pList = new List<Process>
                {
                    Process.Start(info),
                };

                foreach (var p in pList)
                {
                    p.WaitForExit();
                    p.Dispose();
                }

                pList = null;
            }
        }
    }
}
