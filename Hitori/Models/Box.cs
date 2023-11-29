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
    class Box : Button
    {
        private State _state;
        private int _value;
        private bool _isLock;

        public Box(Box box)
        {
            this._value = box.Value;
            this.State = box.State;
            this._isLock = box.IsLock;
            this.Content = $"{this._value}";
            this.Click += this.ChangeColorButton_Click;
        }

        public Box(int value, State state) : base()
        {
            this._value = value;
            this.State = state;
            this._isLock = false;
			this.Content = $"{this._value}";
			this.Click += this.ChangeColorButton_Click;
		}

        public int Value { get => _value; set => _value = value; }
        public State State { 
            get => _state; 
            set {
                /*if (_state != value && _isLock)
                {
                    throw new Exception("Une erreur est survenue dans la résolution");
                }*/

                _state = value;
                switch (value)
                {
                    case State.Gray:
                        this.Background = new SolidColorBrush(Color.FromArgb(255, 90, 90, 90));
                        this.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case State.Black:
                        this.Background = new SolidColorBrush(Colors.Black);
                        this.Foreground = new SolidColorBrush(Colors.White);
                        break;
                    case State.White:
                        this.Background = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
                        this.Foreground = new SolidColorBrush(Colors.Black);
                        break;
                }
            }
        }
        public bool IsLock { get => _isLock; set => _isLock = value; }
        public void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this._state)
            {
                case State.Black:
                    this.State = State.Gray;
                    break;
                case State.White:
                    this.State = State.Black;
                    break;
                case State.Gray:
                    this.State = State.White;
                    break;
            }
        }

        public bool IsBlackLock()
        {
            return this.State == State.Black && this.IsLock;
        }
    }
}
