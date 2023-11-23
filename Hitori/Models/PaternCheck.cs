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
            // Cas où le somment est un coin : on ne fait rien 
            if ((node.Xpos == 0 && node.Ypos == 0) || (node.Xpos == len - 1 && node.Ypos == 0) || (node.Xpos == len - 1 && node.Ypos == len - 1) || (node.Xpos == len - 1 && node.Ypos == len - 1))
            {

            }
            // Cas où le sommet est en haut ou en bas de la grille 
            else if (node.Xpos == 0 || node.Xpos == len - 1)
            {
                valueA = hitori.Nodes[node.Xpos, node.Ypos - 1].Box.Value;
                valueB = hitori.Nodes[node.Xpos, node.Ypos + 1].Box.Value;
                if (valueA == valueB)
                {
                    node.Box.State = State.Black;
                    node.Box.IsLock = true;
                }
            }
            // Cas où le sommet est à gauche ou à droite de la grille
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
                    node.Box.State = State.Black;
                    node.Box.IsLock = true;
                }
            }
         
        }
        // Doublet = Si deux cases adja ont la même valeur, alors tous les cases dans la même ligne ou colonne ayant la même valeur sont blanche
        // Triplet = Si trois cases adja ont la même valeur, alors celle du milieu est forcément noire et les deux extrémités sont blancs,
        // et toutes les cases dans la même ligne ou colonne ayant la même valeur que le triplet et blanche
        static public void Doublet(Hitori hitori, Node node)
        {
            int len = hitori.Nodes.GetLength(0);
            int count = node.AdjaList.Count();
            int cntX = 0;
            int cntY = 0;
            List<int> lxPos = new List<int>();
            List<int> lyPos = new List<int>();
            // On vérifie si les voisins su sommets ont la même valeur que lui 
            if ((node.Xpos == 0 && node.Ypos == 0) || (node.Xpos == len - 1 && node.Ypos == 0) || (node.Xpos == len - 1 && node.Ypos == len - 1) || (node.Xpos == len - 1 && node.Ypos == len - 1))
            {

            }
            else
            {


                for (int i = 0; i < count; i++)
                {
                    if (node.AdjaList[i].Box.Value == node.Box.Value)
                    {
                        if (node.AdjaList[i].Xpos == node.Xpos)
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
                // S'il n'y a qu'un doublet sur sa ligne 
                if (cntX == 1)
                {
                    for (int j = 0; j < len; j++)
                    {
                        if (j != node.Ypos && j != lxPos[0])
                        {
                            if (hitori.Nodes[node.Xpos, j].Box.Value == node.Box.Value)
                            {
                                hitori.Nodes[node.Xpos, j].SetWhiteForResolve();
                            }
                        }
                    }
                }
                // Si c'est un triplet sur sa ligne  
                else if (cntX == 2)
                {
                    node.Box.IsLock = true;
                    for (int k = 0; k < len; k++)
                    {
                        if (k != node.Ypos)
                        {
                            if (hitori.Nodes[node.Xpos, k].Box.Value == node.Box.Value)
                            {
                                hitori.Nodes[node.Xpos, k].SetWhiteForResolve();
                            }
                        }
                    }
                }
                // S'il n'y a qu'un doublet sur sa colonne 
                else if (cntY == 1)
                {
                    for (int j = 0; j < len; j++)
                    {
                        if (j != node.Xpos && j != lyPos[0])
                        {
                            if (hitori.Nodes[j, node.Ypos].Box.Value == node.Box.Value)
                            {
                                hitori.Nodes[j, node.Ypos].SetWhiteForResolve();
                            }
                        }

                    }
                }
                // Si c'est un triplet sur sa colonne 
                else if (cntY == 2)
                {
                    node.Box.IsLock = true;
                    for (int k = 0; k < len; k++)
                    {
                        if (k != node.Xpos)
                        {
                            if (hitori.Nodes[k, node.Ypos].Box.Value == node.Box.Value)
                            {
                                hitori.Nodes[k, node.Ypos].SetWhiteForResolve();
                            }
                        }
                    }

                }
            }
        }
        static public void Croix(Hitori hitori, Node node)
        {
            int len = hitori.Nodes.GetLength(0);
            for (int i = 0; i < node.AdjaList.Count; i++)
            {
                if (node.Xpos == node.AdjaList[i].Xpos) // Voisin sur la même ligne 
                {
                    for (int j = 1; j < len - 1; j++)
                    {
                        if (hitori.Nodes[j, node.Ypos].Box.Value == node.Box.Value && j != node.Xpos && j != node.Xpos + 1 && j != node.Xpos - 1) // S'il existe une autre case avec la même valeur que la case initial 
                        {
                            if (node.AdjaList[i].Box.Value == hitori.Nodes[j - 1, node.AdjaList[i].Ypos].Box.Value)
                            {
                                hitori.Nodes[j - 1, node.Ypos].Box.State = State.Black;
                                hitori.Nodes[j - 1, node.Ypos].Box.IsLock = true;
                                hitori.Nodes[j, node.AdjaList[i].Ypos].Box.State = State.Black;
                                hitori.Nodes[j, node.AdjaList[i].Ypos].Box.IsLock = true;

                            }
                            else if (node.AdjaList[i].Box.Value == hitori.Nodes[j + 1, node.AdjaList[i].Ypos].Box.Value)
                            {
                                hitori.Nodes[j + 1, node.Ypos].Box.State = State.Black;
                                hitori.Nodes[j + 1, node.Ypos].Box.IsLock = true;
                                hitori.Nodes[j, node.AdjaList[i].Ypos].Box.State = State.Black;
                                hitori.Nodes[j, node.AdjaList[i].Ypos].Box.IsLock = true;
                            }


                        }
                    }
                }
                if (node.Ypos == node.AdjaList[i].Ypos)
                {
                    for (int k = 1; k < len - 1; k++)
                    {
                        if (hitori.Nodes[node.Xpos, k].Box.Value == node.Box.Value && k != node.Ypos && k != node.Ypos + 1 && k != node.Ypos - 1)
                        {
                            if (node.AdjaList[i].Box.Value == hitori.Nodes[node.AdjaList[i].Xpos, k - 1].Box.Value)
                            {
                                hitori.Nodes[node.Xpos, k - 1].Box.State = State.Black;
                                hitori.Nodes[node.Xpos, k - 1].Box.IsLock = true;
                                hitori.Nodes[node.AdjaList[i].Xpos, k].Box.IsLock = true;
                                hitori.Nodes[node.AdjaList[i].Xpos, k].Box.State = State.Black;

                            }
                            else if (node.AdjaList[i].Box.Value == hitori.Nodes[node.AdjaList[i].Xpos, k + 1].Box.Value)
                            {
                                hitori.Nodes[node.Xpos, k + 1].Box.State = State.Black;
                                hitori.Nodes[node.Xpos, k + 1].Box.IsLock = true;
                                hitori.Nodes[node.AdjaList[i].Xpos, k].Box.IsLock = true;
                                hitori.Nodes[node.AdjaList[i].Xpos, k].Box.State = State.Black;
                            }
                        }
                    }
                }
            }
        }

    }




}
    

