using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Hitori
    {
        public static bool Verify(Graph graph)
        {
            return Hitori.CheckAdja(graph) && Hitori.CheckConnex(graph) && Hitori.CheckRowCol(graph);
        }

        public static bool CheckRowCol(Graph graph)
        {
            bool check = true;
            int graphSize = graph.Nodes.GetLength(0);
            for (int row = 0; row < graphSize; row++)
            {
                HashSet<int> rowSet = new HashSet<int>();
                HashSet<int> colSet = new HashSet<int>();
                for (int col = 0; col < graphSize; col++)
                {
                    Box boxRC = graph.Nodes[row, col].Box;
                    Box boxCR = graph.Nodes[col, row].Box;
                    if (boxRC.State == State.Black || boxRC.State == State.Gray)
                    {
                        if (!rowSet.Add(boxRC.Value))
                        {
                            // Le numéro a déjà été rencontré dans cette ligne
                            check = false;
                        }
                    }
                    if (boxCR.State == State.Black || boxCR.State == State.Gray)
                    {
                        if (!colSet.Add(boxCR.Value))
                        {
                            // Le numéro a déjà été rencontré dans cette colonne
                            check = false;
                        }
                    }
                }
            }
            return check;
        }

        public static bool CheckAdja(Graph graph)
        {
            bool check = true;
            int graphSize = graph.Nodes.GetLength(0);
            for (int row = 0; row < graphSize; row++)
            {
                for (int col = 0; col < graphSize; col++)
                {
                    Node node = graph.Nodes[row, col];
                    if (node.Box.State == State.White)
                    {
                        int sizeAdjaList = node.AdjaList.Count;
                        for (int x = 0; x < sizeAdjaList; x++)
                        {
                            if (node.AdjaList[x].Box.State == State.White)
                            {
                                check = false;
                            }
                        }
                    }
                }
            }
            return check;
        }

        public static bool CheckConnex(Graph graph)
        {
            int x = 0; int y = 0;
            if (graph.Nodes[x, y].Box.State == State.White)
            {
                x = 1;
            }

            return ConnectedGraph.IsConnected(graph, graph.Nodes[x, y]);
        }
    }
}
