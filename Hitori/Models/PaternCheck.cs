using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class PaternCheck
    {
		/**
		 * Méthode qui permet de vérifier le patern de la tenaille
		 * Si une case est entre deux cases de valeurs identique, alors cette case est forcément noir
		 * 
		 * @param hitori le jeu
		 * @param node le noeud à vérifier
		 */
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
					SetBlackForResolve(hitori, node);
				}
			}
			// Cas où le sommet est à gauche ou à droite de la grille
			else if (node.Ypos == 0 || node.Ypos == len - 1)
			{
				valueA = hitori.Nodes[node.Xpos - 1, node.Ypos].Box.Value;
				valueB = hitori.Nodes[node.Xpos + 1, node.Ypos].Box.Value;
				if (valueA == valueB)
				{
					SetBlackForResolve(hitori, node);
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
					SetBlackForResolve(hitori, node);
				}
			}
 
		}

		/**
		 * Méthode qui permet de vérifier le patern du doublet et du triplet
		 * 
		 * Doublet = Si deux cases adja ont la même valeur, alors tous les cases dans la même ligne ou colonne ayant la même valeur sont blanche
		 * Triplet = Si trois cases adja ont la même valeur, alors celle du milieu est forcément noire et les deux extrémités sont blancs,
		 * et toutes les cases dans la même ligne ou colonne ayant la même valeur que le triplet et blanche
		 *
		 * @param hitori le jeu
		 * @param node le noeud à vérifier
		 */
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
								SetWhiteForResolve(hitori, hitori.Nodes[node.Xpos, j]);
							}
						}
					}
				}
				// Si c'est un triplet sur sa ligne  
				else if (cntX == 2)
				{
					for (int k = 0; k < len; k++)
					{
						if (k != node.Ypos)
						{
							if (hitori.Nodes[node.Xpos, k].Box.Value == node.Box.Value)
							{
								SetWhiteForResolve(hitori, hitori.Nodes[node.Xpos, k]);
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
								SetWhiteForResolve(hitori, hitori.Nodes[j, node.Ypos]);
							}
						}

					}
				}
				// Si c'est un triplet sur sa colonne 
				else if (cntY == 2)
				{
					for (int k = 0; k < len; k++)
					{
						if (k != node.Xpos)
						{
							if (hitori.Nodes[k, node.Ypos].Box.Value == node.Box.Value)
							{
								SetWhiteForResolve(hitori, hitori.Nodes[k, node.Ypos]);
							}
						}
					}

				}
			}
		}

		/**
		 * Méthode qui permet de vérifier le patern de la croix
		 *
		 * @param hitori le jeu
		 * @param node le noeud à vérifier
		 */
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
								SetBlackForResolve(hitori, hitori.Nodes[j - 1, node.Ypos]);
								SetBlackForResolve(hitori, hitori.Nodes[j, node.AdjaList[i].Ypos]);
							}
							else if (node.AdjaList[i].Box.Value == hitori.Nodes[j + 1, node.AdjaList[i].Ypos].Box.Value)
							{
								SetBlackForResolve(hitori, hitori.Nodes[j + 1, node.Ypos]);
								SetBlackForResolve(hitori, hitori.Nodes[j, node.AdjaList[i].Ypos]);
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
								SetBlackForResolve(hitori, hitori.Nodes[node.Xpos, k - 1]);
								SetBlackForResolve(hitori, hitori.Nodes[node.AdjaList[i].Xpos, k]);
							}
							else if (node.AdjaList[i].Box.Value == hitori.Nodes[node.AdjaList[i].Xpos, k + 1].Box.Value)
							{
								SetBlackForResolve(hitori, hitori.Nodes[node.Xpos, k + 1]);
								SetBlackForResolve(hitori, hitori.Nodes[node.AdjaList[i].Xpos, k]);
							}
						}
					}
				}
			}
		}

		/**
		 * Méthode qui permet de passer une case en blanc et de mettre en noir toutes les cases adjacentes
		 * 
		 * @param hitori le jeu
		 * @param node le noeud à vérifier
		 */
		static public void SetWhiteForResolve(Hitori hitori, Node node)
		{
			if (node.Box.IsBlackLock)
			{
				throw new Exception("Case lock on black");
			}

			node.Box.State = State.White;
			node.Box.IsLock = true;

			for (int i = 0; i < node.AdjaList.Count; i++)
			{
				SetBlackForResolve(hitori, node.AdjaList[i]);
			}
	
		}

		/**
		 * Méthode qui permet de passer une case en noir et de mettre en blanc toutes les cases portant la même valeur dans la même ligne ou colonne
		 *
		 * @param hitori le jeu
		 * @param node le noeud à vérifier
		 */
		static public void SetBlackForResolve(Hitori hitori, Node node)
		{
			if (node.Box.IsLock)
			{
				if (node.Box.State == State.White)
				{
					throw new Exception("Case lock on white");
				}

				return;
			}

			node.Box.State = State.Gray;
			node.Box.IsLock = true;

			int graphsize = hitori.Nodes.GetLength(0);
			for (int i = 0; i < graphsize; i++)
			{
				Node colNode = hitori.Nodes[node.Xpos, i];
				Node rowNode = hitori.Nodes[i, node.Ypos];
				if (colNode.Box.Value == node.Box.Value && i != node.Ypos)
				{
					SetWhiteForResolve(hitori, colNode);
				}
				if (rowNode.Box.Value == node.Box.Value && i != node.Xpos)
				{
					SetWhiteForResolve(hitori, rowNode);
				}
			}
		}

		/**
		 * Méthode qui permet de vérifier si un sommet est connecté à un seul sommet noir
		 * Si oui alors on met le sommet en noir
		 *
		 * @param hitori le jeu
		 * @param node le noeud à vérifier
		 * @return true si le sommet est connecté à un seul sommet noir, false sinon
		 */
		static public bool Connected(Hitori hitori, Node node)
		{
			int cntW = 0;
			int mem = 0;
			for(int i = 0; i < node.AdjaList.Count(); i++)
			{
				if (node.AdjaList[i].Box.State != State.White )
				{
					cntW++;
					mem = i;
				}

			}
			if (cntW == 1)
			{
				if (node.AdjaList[mem].Box.IsLock == false)
				{
					SetBlackForResolve(hitori, node.AdjaList[mem]);
					return true;
				}
			}
			return false;
		}
	}
}


