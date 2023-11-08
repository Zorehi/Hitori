using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Hitori : Graph
    {
        public Hitori(Box[,] matrix) : base(matrix)
        {
		}

        public bool Verify()
        {
            return this.CheckAdja() && this.CheckConnex() && this.CheckRowCol();
        }

        public bool CheckRowCol()
        {
            int graphSize = this.Nodes.GetLength(0);
            for (int row = 0; row < graphSize; row++)
            {
                HashSet<int> rowSet = new HashSet<int>();
                HashSet<int> colSet = new HashSet<int>();
                for (int col = 0; col < graphSize; col++)
                {
                    Box boxRC = this.Nodes[row, col].Box;
                    Box boxCR = this.Nodes[col, row].Box;
                    if (boxRC.State == State.Black || boxRC.State == State.Gray)
                    {
                        if (!rowSet.Add(boxRC.Value))
                        {
                            // Le numéro a déjà été rencontré dans cette ligne
                            return false;
                        }
                    }
                    if (boxCR.State == State.Black || boxCR.State == State.Gray)
                    {
                        if (!colSet.Add(boxCR.Value))
                        {
                            // Le numéro a déjà été rencontré dans cette colonne
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public bool CheckAdja()
        {
            int graphSize = this.Nodes.GetLength(0);
            for (int row = 0; row < graphSize; row++)
            {
                for (int col = 0; col < graphSize; col++)
                {
                    Node node = this.Nodes[row, col];
                    if (node.Box.State == State.White)
                    {
                        int sizeAdjaList = node.AdjaList.Count;
                        for (int x = 0; x < sizeAdjaList; x++)
                        {
                            if (node.AdjaList[x].Box.State == State.White)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public bool CheckConnex()
        {
            int row = 0; int col = 0;
            if (this.Nodes[row, col].Box.State == State.White)
            {
				col = 1;
            }

            return ConnectedGraph.IsConnected(this, this.Nodes[row, col]);
        }

        public bool CheckDuplicateValue(Node node)
        {
            int graphSize = this.Nodes.GetLength(0);
            for (int i = 0; i < graphSize; i++)
            {
                Box boxRC = this.Nodes[node.Xpos, i].Box;
                Box boxCR = this.Nodes[i, node.Ypos].Box;
                if (boxRC.State == State.Black || boxRC.State == State.Gray)
                {
                    if (boxRC.Value == node.Box.Value && node.Ypos != i)
                    {
                        return true;
                    }
                }
                if (boxCR.State == State.Black || boxCR.State == State.Gray)
                {
                    if (boxCR.Value == node.Box.Value && node.Xpos != i)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Resolve()
        {
            //Tree<Hitori> tree = new Tree<Hitori>(this);
            int graphSize = this.Nodes.GetLength(0);
            for (int row = 0; row < graphSize; row++)
            {
                for (int col = 0; col < graphSize; col++)
                {

                }
            }
        }
    }
}
