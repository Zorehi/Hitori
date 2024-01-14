using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Hitori.Models
{
    /**
     * Classe représentant un noeud du graphe
     */
    class Node
    {
        private Box _box;
        private int _xpos,_ypos;
        private List<Node> adjaList;

        /**
         * Constructeur par recopie
         *
         * @param node le noeud à recopier
         * @return le noeud recopié
         */
        public Node(Node node)
        {
            this._xpos = node.Xpos;
            this._ypos = node.Ypos;
            this._box = new Box(node.Box);
        }

        /**
         * Constructeur par défaut
         * 
         * @param x la position en x du noeud
         * @param y la position en y du noeud
         * @param box la case du noeud
         * @return le noeud
         */
        public Node(int x, int y, Box box)
        {
            this._xpos = x;
            this._ypos = y;
            this._box = box;
        }

        /**
         * Getter et setter de la case du noeud
         */
        public Box Box { get => _box ; set => _box = value; }

        /**
         * Getter et setter de la position en x du noeud
         */
        public int Xpos { get => _xpos; set => _xpos = value; }

		/**
         * Getter et setter de la position en y du noeud
         */
		public int Ypos { get => _ypos; set => _ypos = value; }

		/**
         * Getter et setter de la liste d'adjacence du noeud
         */
		public List<Node> AdjaList { get => adjaList; set => adjaList = value; }

        /**
         * Méthode permettant de savoir si le noeud est noir et verrouillé
         * 
         * @return true si le noeud est noir et verrouillé, false sinon
         */
        public bool IsBlackLock()
        {
            return this.Box.IsBlackLock;
        }

		/**
         * Méthode static permettant de savoir si le noeud est noir et verrouillé
         * 
         * @param node le noeud à tester
         * @return true si le noeud est noir et verrouillé, false sinon
         */
		public static bool IsBlackLock(Node node)
        {
            return node.IsBlackLock();
        }
    }
}
