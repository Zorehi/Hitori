using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Tree
    {
        private TreeNode<Hitori> _rootNode;

        public Tree(Hitori rootValue)
        {
            this.RootNode = new TreeNode<Hitori>(rootValue);
        }

        public TreeNode<Hitori> RootNode { get => _rootNode; set => _rootNode = value; }


    }
}
