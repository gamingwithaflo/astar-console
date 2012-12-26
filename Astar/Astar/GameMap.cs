using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Astar {
    public class GameMap {
        private NavigateNode[,] mMap;
        private NavigateNode[] mPath;
        private int mRow;
        private int mColumn;
        private const int goalX = 13;
        private const int goalY = 31;



        public GameMap(int row, int column) {
            mMap = new NavigateNode[row, column];
            mRow = row;
            mColumn = column;
            // initialize all nodes to navigable
            for (int x = 0; x < mMap.GetLength(0); ++x) {
                for (int y = 0; y < mMap.GetLength(1); ++y) {
                    mMap[x, y] = new NavigateNode(x, y, NavigateNode.StateEnum.NAVIGABLE);
                }
            }

            mMap[1, 4].State = NavigateNode.StateEnum.WALL;
            mMap[2, 4].State = NavigateNode.StateEnum.WALL;
            mMap[3, 4].State = NavigateNode.StateEnum.WALL;
            mMap[4, 4].State = NavigateNode.StateEnum.WALL;
            mMap[5, 4].State = NavigateNode.StateEnum.WALL;


            for (int i = 0; i < 18; ++i) {
                mMap[i, 10].State = NavigateNode.StateEnum.WALL;
            }


            for (int i = 0; i < 18; ++i) {
                mMap[i, 25].State = NavigateNode.StateEnum.WALL;
            }

            mMap[18, 25].State = NavigateNode.StateEnum.WALL;
            mMap[18, 26].State = NavigateNode.StateEnum.WALL;
            mMap[18, 27].State = NavigateNode.StateEnum.WALL;
            mMap[18, 28].State = NavigateNode.StateEnum.WALL;
            mMap[18, 29].State = NavigateNode.StateEnum.WALL;
            mMap[18, 30].State = NavigateNode.StateEnum.WALL;
            mMap[18, 31].State = NavigateNode.StateEnum.WALL;
            mMap[18, 32].State = NavigateNode.StateEnum.WALL;
            mMap[18, 33].State = NavigateNode.StateEnum.WALL;
            mMap[18, 34].State = NavigateNode.StateEnum.WALL;
            mMap[18, 35].State = NavigateNode.StateEnum.WALL;
            mMap[18, 36].State = NavigateNode.StateEnum.WALL;

            mMap[18, 36].State = NavigateNode.StateEnum.WALL;
            mMap[17, 36].State = NavigateNode.StateEnum.WALL;
            mMap[16, 36].State = NavigateNode.StateEnum.WALL;
            mMap[15, 36].State = NavigateNode.StateEnum.WALL;
            mMap[14, 36].State = NavigateNode.StateEnum.WALL;
            mMap[13, 36].State = NavigateNode.StateEnum.WALL;
            mMap[12, 36].State = NavigateNode.StateEnum.WALL;
            mMap[11, 36].State = NavigateNode.StateEnum.WALL;

            mMap[10, 36].State = NavigateNode.StateEnum.WALL;
            mMap[9, 36].State = NavigateNode.StateEnum.WALL;
            mMap[8, 36].State = NavigateNode.StateEnum.WALL;
            mMap[7, 36].State = NavigateNode.StateEnum.WALL;
            mMap[6, 36].State = NavigateNode.StateEnum.WALL;
            mMap[5, 36].State = NavigateNode.StateEnum.WALL;
            mMap[4, 36].State = NavigateNode.StateEnum.WALL;
            mMap[3, 36].State = NavigateNode.StateEnum.WALL;

            mMap[3, 35].State = NavigateNode.StateEnum.WALL;
            mMap[3, 34].State = NavigateNode.StateEnum.WALL;
            mMap[3, 33].State = NavigateNode.StateEnum.WALL;
            mMap[3, 32].State = NavigateNode.StateEnum.WALL;
            mMap[3, 31].State = NavigateNode.StateEnum.WALL;
            mMap[3, 30].State = NavigateNode.StateEnum.WALL;
            mMap[3, 29].State = NavigateNode.StateEnum.WALL;
            mMap[3, 28].State = NavigateNode.StateEnum.WALL;

            mMap[4, 28].State = NavigateNode.StateEnum.WALL;
            mMap[5, 28].State = NavigateNode.StateEnum.WALL;
            mMap[6, 28].State = NavigateNode.StateEnum.WALL;
            mMap[7, 28].State = NavigateNode.StateEnum.WALL;
            mMap[8, 28].State = NavigateNode.StateEnum.WALL;
            mMap[9, 28].State = NavigateNode.StateEnum.WALL;
            mMap[10, 28].State = NavigateNode.StateEnum.WALL;
            mMap[11, 28].State = NavigateNode.StateEnum.WALL;
            mMap[12, 28].State = NavigateNode.StateEnum.WALL;
            mMap[13, 28].State = NavigateNode.StateEnum.WALL;
            mMap[14, 28].State = NavigateNode.StateEnum.WALL;
            mMap[15, 28].State = NavigateNode.StateEnum.WALL;

            mMap[15, 29].State = NavigateNode.StateEnum.WALL;
            mMap[15, 30].State = NavigateNode.StateEnum.WALL;
            mMap[15, 31].State = NavigateNode.StateEnum.WALL;
            mMap[15, 32].State = NavigateNode.StateEnum.WALL;


            mMap[14, 32].State = NavigateNode.StateEnum.WALL;
            mMap[13, 32].State = NavigateNode.StateEnum.WALL;
            mMap[12, 32].State = NavigateNode.StateEnum.WALL;
            mMap[11, 32].State = NavigateNode.StateEnum.WALL;
            mMap[10, 32].State = NavigateNode.StateEnum.WALL;
            mMap[9, 32].State = NavigateNode.StateEnum.WALL;
            mMap[8, 32].State = NavigateNode.StateEnum.WALL;
            mMap[7, 32].State = NavigateNode.StateEnum.WALL;
        }

        public void Draw() {
            for (int x = 0; x < mMap.GetLength(0); ++x) {
                for (int y = 0; y < mMap.GetLength(1); ++y) {
                    if (mMap[x, y].State == NavigateNode.StateEnum.NAVIGABLE) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("-");
                    }
                    else if (mMap[x, y].State == NavigateNode.StateEnum.PATH) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                    }
                    else if (mMap[x, y].State == NavigateNode.StateEnum.GOAL) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("g");
                    }
                    else if (mMap[x, y].State == NavigateNode.StateEnum.START) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("s");
                    }
                    else if (mMap[x, y].State == NavigateNode.StateEnum.WALL) {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("w");
                    }
                    else {
                        // should not go here
                    }
                }
                Console.WriteLine();
            }
        }

        private bool IsInRange(int x, int y) {
            return (x >= 0 && x < mRow && y >= 0 && y < mColumn);
        }

        private List<NavigateNode> GetNeighbors(NavigateNode n) {
            int x = n.X;
            int y = n.Y;
            List<NavigateNode> neighbors = new List<NavigateNode>();
            if (IsInRange(x - 1, y)) {
                if (mMap[x - 1, y].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x - 1, y]);
            }

            if (IsInRange(x + 1, y)) {
                if (mMap[x + 1, y].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x + 1, y]);
            }

            if (IsInRange(x, y - 1)) {
                if (mMap[x, y - 1].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x, y - 1]);
            }

            if (IsInRange(x, y + 1)) {
                if (mMap[x, y + 1].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x, y + 1]);
            }

            if (IsInRange(x - 1, y - 1)) {
                if (mMap[x - 1, y - 1].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x - 1, y - 1]);
            }
            
            if (IsInRange(x + 1, y - 1)) {
                if (mMap[x + 1, y - 1].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x + 1, y - 1]);
            }

            if (IsInRange(x - 1, y + 1)) {
                if (mMap[x - 1, y + 1].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x - 1, y + 1]);
            }

            if (IsInRange(x + 1, y + 1)) {
                if (mMap[x + 1, y + 1].State != NavigateNode.StateEnum.WALL)
                    neighbors.Add(mMap[x + 1, y + 1]);
            }

            return neighbors;
        }

        private double GetDirectCost(NavigateNode n, NavigateNode m) {
            int temp = Math.Abs(n.X - m.X) + Math.Abs(n.Y - m.Y);
            if (temp == 2)
                return 14.0;
            else
                return 10.0;
        }

        private double GetHeuristicCost(NavigateNode n, NavigateNode goal) {
            return 10.0 * (Math.Abs(n.X - goal.X) + Math.Abs(n.Y - goal.Y));
        }

        public void AstarRun() {
            Console.WriteLine("A* starts!");
            NavigateNode start = new NavigateNode(2, 2, NavigateNode.StateEnum.NAVIGABLE);
            NavigateNode end = new NavigateNode(goalX, goalY, NavigateNode.StateEnum.NAVIGABLE);

            PriorityQueue<NavigateNode> openSet = new PriorityQueue<NavigateNode>();
            PriorityQueue<NavigateNode> closeSet = new PriorityQueue<NavigateNode>();

            openSet.Add(start);

            while (!openSet.Empty) {
                // get from open set
                NavigateNode current = openSet.Pop();

                // add to close set
                closeSet.Add(current);

                // goal found
                if (current.IsSameLocation(end)) {
                    while (current.Parent != null) {
                        mMap[current.X, current.Y].State = NavigateNode.StateEnum.PATH;
                        current = current.Parent;
                    }
                    return;
                }
                else {
                    List<NavigateNode> neighbors = GetNeighbors(current);

                    foreach (NavigateNode n in neighbors) {
                        if (closeSet.IsMember(n)) {
                            continue;
                        }
                        else {
                            if (!openSet.IsMember(n)) {
                                n.Parent = current;
                                n.DirectCost = current.DirectCost + GetDirectCost(current, n);
                                n.HeuristicCost = GetHeuristicCost(n, end);
                                n.TotalCost = n.DirectCost + n.HeuristicCost;

                                // add to open set
                                openSet.Add(n);
                            }
                            else {
                                double costFromThisPathToM = current.DirectCost + GetDirectCost(current, n);
                                // we found a better path
                                if (costFromThisPathToM < n.DirectCost) {
                                    n.Parent = current;                                   // change parent to n
                                    n.DirectCost = costFromThisPathToM;             // recalculate direct cost
                                    n.TotalCost = n.HeuristicCost + n.DirectCost;   // recalculate total cost
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("end here?");
        }
    }
}
