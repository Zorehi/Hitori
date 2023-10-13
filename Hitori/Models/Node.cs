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
        private Button _button;
        private State _state;
        private int _value;
        private int _xpos,_ypos;
        private List<Node> adjaList;

        public Node(int x, int y, int value, State state)
        {
            this._xpos = x;
            this._ypos = y;
            this._value = value;
            this._state = state;
        }
        public Button Button { get => _button; set => _button = value; }
        public int Value { get => _value; set => _value = value; }
        internal State State { get => _state; set => _state = value; }
        public int Xpos { get => _xpos; set => _xpos = value; }
        public int Ypos { get => _ypos; set => _ypos = value; }
        public List<Node> AdjaList { get => adjaList; set => AdjaList = value; }
    }
}
