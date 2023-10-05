using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Hitori.Models
{
    class Box
    {
        private Button _button;
        private State _state;
        private int _value;


        public Box(int value, State state)
        {
            this._value = value;
            this._state = state;
        }

        public Button Button { get => _button; set => _button = value; }
        public int Value { get => _value; set => _value = value; }
        internal State State { get => _state; set => _state = value; }
    }
}
