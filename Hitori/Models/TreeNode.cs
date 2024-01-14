using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    /**
     * Classe représentant un noeud d'un arbre
     */
    class TreeNode<T>
    {
        private T _value;
        private TreeNode<T> _leftChild;
        private TreeNode<T> _rightChild;

        /**
         * Constructeur par défaut
         * 
         * @param value la valeur du noeud
         * @return le noeud
         */
        public TreeNode(T value)
        {
            this.Value = value;
        }

        /**
         * Getter et setter de la valeur du noeud
         */
        public T Value { get => _value; set => _value = value; }

        /**
         * Getter et setter de l'enfant gauche du noeud
         */
        public TreeNode<T> LeftChild { get => _leftChild; set => _leftChild = value; }

        /**
         * Getter et setter de l'enfant droit du noeud
         */
        public TreeNode<T> RightChild { get => _rightChild; set => _rightChild = value; }


    }
}
