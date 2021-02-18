using System;

using Sandbox.Game;

namespace Sandbox
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var sandbox = new SandboxApp())
                sandbox.Run();
        }
    }
}
