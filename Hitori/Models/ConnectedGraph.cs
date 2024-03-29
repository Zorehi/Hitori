﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    /**
     * Classe permettant de tester si un graphe est connexe
     */
    class ConnectedGraph
    {
        /**
         * Test si le graphe est connexe en retirant les noeuds blancs
         * 
         * @param graph le graphe à tester
         * @param start le noeud de départ
         * @return true si le graphe est connexe, false sinon
         */
        public static bool IsConnected(Graph graph, Node start)
        {
            Stack<Node> stack = new Stack<Node>();
            int length = graph.Nodes.GetLength(0);
            bool[,] InStack = new bool[length, length];
            int count = 0;
            stack.Push(start);

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                foreach (Node adj in node.AdjaList)
                {
                    if (!InStack[adj.Xpos, adj.Ypos] && adj.Box.State != State.White)
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
                    if (graph.Nodes[i, j].Box.State != State.White) countBlack++;
                }
            }

            return count == countBlack;
        }
    }
}
