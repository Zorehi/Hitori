using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class TreeNode<T>
    {
        private T _value;
        private TreeNode<T> _leftChild;
        private TreeNode<T> _rightChild;

        public TreeNode(T value)
        {
            this.Value = value;
        } 

        public T Value { get => _value; set => _value = value; }
        public TreeNode<T> LeftChild { get => _leftChild; set => _leftChild = value; }
        public TreeNode<T> RightChild { get => _rightChild; set => _rightChild = value; }
    }
}
