using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Node
    {
        private int xpos,ypos;
        private List<Node> AdjaList;

        public Node(int x, int y,  List<Node> list)
        {
            xpos = x;
            ypos = y;
            for (int i = 0; i <= list.Count; i++)
            {
                AdjaList.Add(list[i]);
            }
        }

    }
}
