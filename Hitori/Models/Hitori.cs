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

        public void Resolve()
        {

            int len = this.Nodes.GetLength(0);
            for (int i = 0; i < len-1; i++)
            {
                for(int j = 0; j < len-1; j++)
                {
                    PaternCheck.Tenaille(this, this.Nodes[i, j]);
                    //PaternCheck.Doublet(this, this.Nodes[i, j]);
                    //PaternCheck.Croix(this, this.Nodes[i, j]);
                }
            }
            //Tree<Hitori> tree = new Tree<Hitori>(this);
            List<DuplicateNode> list = new List<DuplicateNode>();
            HashSet<int> listRowSet = new HashSet<int>();
            HashSet<int> listColSet = new HashSet<int>();

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
                            if (listRowSet.Add(boxRC.Value))
                            {
                                list.Add(new DuplicateNode(this, this.Nodes[row, col], false));
                            }
                        }
                    }
                    if (boxCR.State == State.Black || boxCR.State == State.Gray)
                    {
                        if (!colSet.Add(boxCR.Value))
                        {
                            if (listColSet.Add(boxRC.Value))
                            {
                                list.Add(new DuplicateNode(this, this.Nodes[row, col], true));
                            }
                        }
                    }
                }
            }*/

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].NodesRow.Any(Node.IsBlackLock))
                {
                    for (int j = 0; j < list[j].NodesRow.Count; j++)
                    {
                        if (!list[i].NodesRow[j].IsBlackLock())
                        {
                            list[i].NodesRow[j].SetWhiteForResolve();
                        }
                    }
                }
                if (list[i].NodesCol.Any(Node.IsBlackLock))
                {
                    for (int j = 0; j < list[j].NodesCol.Count; j++)
                    {
                        if (!list[i].NodesCol[j].IsBlackLock())
                        {
                            list[i].NodesCol[j].SetWhiteForResolve();
                        }
                    }
                }
            }
        }
    }
}