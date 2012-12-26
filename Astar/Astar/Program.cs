using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar {
    class Program {
        static void Main(string[] args) {
            GameMap gm = new GameMap(20, 60);
            gm.AstarRun();
            gm.Draw();
        }
    }
}
