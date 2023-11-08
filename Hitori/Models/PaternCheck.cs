using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class PaternCheck
    {
        // Tenaille = Si une case est entre deux cases de valeurs identique, alors cette case est forcément noir
        static public void Tenaille(Hitori hitori, Node node)
        {
            int len = hitori.Nodes.GetLength(0);
            int valueA, valueB, valueC, valueD;

            if ((node.Xpos == 0 && node.Ypos == 0) || (node.Xpos == len - 1 && node.Ypos == 0) || (node.Xpos == len - 1 && node.Ypos == len - 1) || (node.Xpos == len - 1 && node.Ypos == len - 1))
            {

            }
            else if (node.Xpos == 0 || node.Xpos == len - 1)
            {
                valueA = hitori.Nodes[node.Xpos, node.Ypos - 1].Box.Value;
                valueB = hitori.Nodes[node.Xpos, node.Ypos + 1].Box.Value;
                if (valueA == valueB)
                {
                    node.Box.IsLock = true;
                }
            }
            else if (node.Ypos == 0 || node.Ypos == len - 1)
            {
                valueA = hitori.Nodes[node.Xpos - 1, node.Ypos].Box.Value;
                valueB = hitori.Nodes[node.Xpos + 1, node.Ypos].Box.Value;
                if (valueA == valueB)
                {
                    node.Box.IsLock = true;
                }
            }
            else
            {
                valueA = hitori.Nodes[node.Xpos - 1, node.Ypos].Box.Value;
                valueB = hitori.Nodes[node.Xpos + 1, node.Ypos].Box.Value;
                valueC = hitori.Nodes[node.Xpos, node.Ypos - 1].Box.Value;
                valueD = hitori.Nodes[node.Xpos, node.Ypos + 1].Box.Value;
                if (valueA == valueB || valueC == valueD)
                {
                    node.Box.IsLock = true;
                }

            }
        }

        static public void Doublet(Hitori hitori, Node node)
        {
            int len = hitori.Nodes.GetLength(0);
            int count = node.AdjaList.Count();
            int cntX = 0;
            int cntY = 0;
            List<int> lxPos = new List<int>();
            List<int> lyPos = new List<int>();

            for (int i = 0; i<count; i++)
            {
                if(node.AdjaList[i].Box.Value == node.Box.Value)
                {
                    if(node.AdjaList[i].Xpos == node.Xpos)
                    {
                        lxPos.Add(node.AdjaList[i].Ypos);
                        cntX++;
                    }
                    else if (node.AdjaList[i].Ypos == node.Ypos)
                    {
                        lyPos.Add(node.AdjaList[i].Xpos);
                        cntY++;
                    }
                }
            }
            if (cntX == 1)
            {
                for (int j = 0; j < len; j++)
                {
                    if (j != node.Ypos && j != lxPos[0])
                    {
                        if (hitori.Nodes[node.Xpos, j].Box.Value == node.Box.Value)
                        {
                            hitori.Nodes[node.Xpos, j].Box.State = State.White;
                            hitori.Nodes[node.Xpos, j].Box.IsLock = true;
                        }
                    }
                }
            }
            else if (cntX == 2)
            {
                node.Box.IsLock = true;
                for (int k = 0; k < len; k++)
                {
                    if (k != node.Ypos)
                    {
                        if (hitori.Nodes[node.Xpos, k].Box.Value == node.Box.Value)
                        {
                            hitori.Nodes[node.Xpos, k].Box.State = State.White;
                            hitori.Nodes[node.Xpos, k].Box.IsLock = true;
                        }
                    }
                }
            }
            else if (cntY == 1)
            {
                for (int j = 0; j < len; j++)
                {
                    if (j != node.Xpos && j != lxPos[0])
                    {
                        if (hitori.Nodes[j, node.Ypos].Box.Value == node.Box.Value)
                        {
                            hitori.Nodes[j, node.Ypos].Box.State = State.White;
                            hitori.Nodes[j, node.Ypos].Box.IsLock = true;
                        }
                    }

                }
            }
            else if (cntY == 2)
            {
                node.Box.IsLock = true;
                for (int k = 0; k < len; k++)
                {
                    if (k != node.Ypos)
                    {
                        if (hitori.Nodes[k, node.Ypos].Box.Value == node.Box.Value)
                        {
                            hitori.Nodes[k, node.Ypos].Box.State = State.White;
                            hitori.Nodes[k, node.Ypos].Box.IsLock = true;
                        }
                    }
                }

            }
        }
    }
}
