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
            Button button = sender as Button;
            Box box = button.DataContext as Box;

            switch (box.State)
            {
                case State.Black:
                    button.Background = new SolidColorBrush(Color.FromArgb(255, 90, 90, 90));
                    box.State = State.Gray;
                    break;
                case State.White:
                    button.Background = new SolidColorBrush(Colors.Black);
                    button.Foreground = new SolidColorBrush(Colors.White);
                    box.State = State.Black;
                    break;
                case State.Gray:
                    button.Background = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
                    button.Foreground = new SolidColorBrush(Colors.Black);
                    box.State = State.White;
                    break;
            }
        }
    }
}
