using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Tree<T>
    {
        private TreeNode<T> _rootNode;

        public Tree(T rootValue)
        {
            this.RootNode = new TreeNode<T>(rootValue);
        }

        public TreeNode<T> RootNode { get => _rootNode; set => _rootNode = value; }
    }
}
