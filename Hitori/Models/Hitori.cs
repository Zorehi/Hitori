using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    /**
     * Classe représentant le jeu Hitori
     */
    class Hitori : Graph
    {
        /**
         * Constructeur par défaut
         * 
         * @param matrix la matrice de jeu
         * @return le jeu
         */
        public Hitori(Box[,] matrix) : base(matrix)
        {
        }

        /**
         * Constructeur par recopie
         * 
         * @param hitori le jeu à recopier
         * @return le jeu recopié
         */
        public Hitori(Hitori hitori) : base(hitori)
        {
        }

        /**
         * Vérifie si le jeu est résolu
         * 
         * @return true si le jeu est résolu, false sinon
         */
        public bool Verify()
        {
            return this.CheckAdja() && this.CheckConnex() && this.CheckRowCol();
        }

		/**
         * Vérifie si les lignes et les colonnes n'ont pas de doublons
         *
         * @return true si les lignes et les colonnes n'ont pas de doublons, false sinon
         */
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
                    if (boxRC.State != State.White)
                    {
                        if (!rowSet.Add(boxRC.Value))
                        {
                            // Le numéro a déjà été rencontré dans cette ligne
                            return false;
                        }
                    }
                    if (boxCR.State != State.White)
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

        /**
         * Vérifie si les cases adjacentes d'une case blanche ne sont pas de la même couleur
         *
         * @return true si les cases adjacentes d'une case blanche ne sont pas de la même couleur, false sinon
         */
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

        /**
         * Vérifie si le graphe est connexe
         *
         * @return true si le graphe est connexe, false sinon
         */
        public bool CheckConnex()
        {
            int row = 0; int col = 0;
            if (this.Nodes[row, col].Box.State == State.White)
            {
                col = 1;
            }

            return ConnectedGraph.IsConnected(this, this.Nodes[row, col]);
        }

        /**
         * Résout le jeu
         */
        public void Resolve()
        {

            int len = this.Nodes.GetLength(0);
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1; j++)
                {
                    PaternCheck.Tenaille(this, this.Nodes[i, j]);
                    PaternCheck.Doublet(this, this.Nodes[i, j]);
                    PaternCheck.Croix(this, this.Nodes[i, j]);
                }
            }
            bool isChanged = true;
            while (isChanged)
            {
                isChanged = false;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        if (PaternCheck.Connected(this, this.Nodes[i, j]))
                        {
                            isChanged = true;
                        }
                    }
                }
            }

            if (Tree.finalResolve(new TreeNode<Hitori>(this)))
            {
                Tree.ShowFinalResult(this);
            }
        }
    }
}