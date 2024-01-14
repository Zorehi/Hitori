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
    /**
     * Classe représentant une case du jeu
     */
    class Box : Button
    {
        private State _state;
        private int _value;
        private bool _isLock;

        /**
         * Constructeur par recopie
         * 
         * @param box la case à recopier
         * @return la case recopiée
         */
        public Box(Box box)
        {
            this._value = box.Value;
            this.State = box.State;
            this._isLock = box.IsLock;
            this.Content = $"{this._value}";
            this.Click += this.ChangeColorButton_Click;
        }

        /**
         * Constructeur par défaut
         * 
         * @param value la valeur de la case
         * @param state la couleur de la case
         * @return la case
         */
        public Box(int value, State state) : base()
        {
            this._value = value;
            this.State = state;
            this._isLock = false;
			this.Content = $"{this._value}";
			this.Click += this.ChangeColorButton_Click;
		}

        /**
         * Getter et setter de la valeur de la case
         */
        public int Value { get => _value; set => _value = value; }

		/**
         * Getter et setter de la couleur de la case
         */
		public State State { 
            get => _state; 
            set {
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

        /**
         * Getter et setter du verrouillage de la case
         */
        public bool IsLock { get => _isLock; set => _isLock = value; }

        /**
         * Méthode permettant de changer la couleur de la case lors du clic de la souris
         * 
         * @param sender l'objet qui a envoyé l'évènement
         * @param e les arguments de l'évènement
         */
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

        /**
         * Getter permettant de savoir si la case est noire et verrouillée
         */
        public bool IsBlackLock { get => this.State == State.Black && this.IsLock; }
    }
}
