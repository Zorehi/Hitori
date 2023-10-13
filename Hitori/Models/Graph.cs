using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Graph
    {
        private Node[,] graph;

        public Graph(Box[,] matrix)
        {
            int x= matrix.Length;
            int y = x; 

            for(int i =0; i<x; i++)
            {
                for(int j=0; j < y; j++)
                {

                }
            }
        }
    }
}
