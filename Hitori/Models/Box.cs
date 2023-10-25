using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;

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
        public void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this._state)
            {
                case State.Black:
                    this._button.Background = new SolidColorBrush(Color.FromArgb(255, 90, 90, 90));
                    this._state = State.Gray;
                    break;
                case State.White:
                    this._button.Background = new SolidColorBrush(Colors.Black);
                    this._button.Foreground = new SolidColorBrush(Colors.White);
                    this._state = State.Black;
                    break;
                case State.Gray:
                    this._button.Background = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
                    this._button.Foreground = new SolidColorBrush(Colors.Black);
                    this._state = State.White;
                    break;
            }
        }
    }
}
