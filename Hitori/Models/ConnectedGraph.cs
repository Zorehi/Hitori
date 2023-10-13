using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class ConnectedGraph
    {
        public static bool IsConnected(Graph graph)
        {
            Stack<Node> stack = new Stack<Node>();
            int length = graph.Nodes.GetLength(0);
            bool[,] InStack = new bool[length, length];
            int count = 0;

            int x = 0; int y = 0;
            if (graph.Nodes[x, y].State == State.White)
            {
                x = 1;
            }
            stack.Push(graph.Nodes[x, y]);

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                foreach (Node adj in node.AdjaList)
                {
                    if (!InStack[adj.Xpos, adj.Ypos] && adj.State == State.Black)
                    {
                        stack.Push(adj);
                        InStack[adj.Xpos, adj.Ypos] = true;
                        count++;
                    }
                }
            }

            int countBlack = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (graph.Nodes[i, j].State == State.Black) countBlack++;
                }
            }

            return count == countBlack;
        }
    }
}
