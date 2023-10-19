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
            this._box.Value = box.Value;
            this._box.State= box.State;
        }
        public Box Box { get => _box ; set => _box = value; }
        public int Xpos { get => _xpos; set => _xpos = value; }
        public int Ypos { get => _ypos; set => _ypos = value; }
        public List<Node> AdjaList { get => adjaList; set => AdjaList = value; }
    }
}
