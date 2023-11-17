using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Hitori.Models
{
    class Node
    {
        private Box _box;
        private int _xpos,_ypos;
        private List<Node> adjaList;

        public Node(int x, int y, Box box)
        {
            this._xpos = x;
            this._ypos = y;
            this._box = box;
        }
        public Box Box { get => _box ; set => _box = value; }
        public int Xpos { get => _xpos; set => _xpos = value; }
        public int Ypos { get => _ypos; set => _ypos = value; }
        public List<Node> AdjaList { get => adjaList; set => adjaList = value; }
        public bool IsBlackLock()
        {
            return this.Box.IsBlackLock();
        }
        public static bool IsBlackLock(Node node)
        {
            return node.IsBlackLock();
        }
        public void SetWhiteForResolve()
        {
            this.Box.State = State.White;
            this.Box.IsLock = true;

            for (int i = 0; i < this.AdjaList.Count; i++)
            {
                this.AdjaList[i].Box.State = State.Black;
                this.AdjaList[i].Box.IsLock = true;
            }
        }
    }
}
