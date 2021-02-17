using System;
using Sandbox.Game;

namespace Sandbox
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Gamos())
                game.Run();
        }
    }
}
