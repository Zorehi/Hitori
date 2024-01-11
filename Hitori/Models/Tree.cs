using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Tree
    {
        private static Hitori _end;

        public static bool finalResolve(TreeNode<Hitori> treeNode)
        {
            int len = treeNode.Value.Nodes.GetLength(0);
            bool isFullLock = true;
            bool firstLock = false;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (treeNode.Value.Nodes[i,j].Box.IsLock == false)
                    {
                        isFullLock = false;
                    }
                }
            }
            if (treeNode.Value.Verify())
            {
                _end = treeNode.Value;
                return true;
            }
            else if (isFullLock)
            {
                return false;
            }
            treeNode.LeftChild = new TreeNode<Hitori>(new Hitori(treeNode.Value));
            treeNode.RightChild = new TreeNode<Hitori>(new Hitori(treeNode.Value));
            int firstX = -1;
            int firstY = -1;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (treeNode.Value.Nodes[i, j].Box.IsLock == false && !firstLock)
                    {
                        firstX = i;
                        firstY = j;
                        firstLock = true;
                    }
                }
            }

            bool left = false;
            bool right = false;
            try
            {
                PaternCheck.SetWhiteForResolve(treeNode.LeftChild.Value, treeNode.LeftChild.Value.Nodes[firstX, firstY]);
                
                left = finalResolve(treeNode.LeftChild);
                if (left)
                {
                    treeNode.Value = treeNode.LeftChild.Value;
                }
            } 
            catch
            {

            }
            try
            {
                PaternCheck.SetBlackForResolve(treeNode.RightChild.Value, treeNode.RightChild.Value.Nodes[firstX, firstY]);
                right = finalResolve(treeNode.RightChild);
                if (right)
                {
                    treeNode.Value = treeNode.RightChild.Value;
                }
            }
            catch
            {

            }

            return left || right;
        }
        public static void ShowFinalResult(Hitori hitori)
        {
            int len = hitori.Nodes.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    hitori.Nodes[i, j].Box.State = _end.Nodes[i, j].Box.State;
                }
            }
        }
    }
}
