using Hitori.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace Hitori
{
    /**
     * Classe représentant la page principale de l'application
     */
    public sealed partial class MainPage : Page
    {
        private Models.Hitori hitori;
        private int gridLenght = 10;

        /**
         * Constructeur par défaut
         */
        public MainPage()
        {
            this.InitializeComponent();

            this.Background = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));

            this.hitori = new Models.Hitori(Models.Matrix.ReadMatrixInFile(this.gridLenght));

            this.CreateDynamicGrid();
        }

        /**
         * Méthode appelée lorsque la taille de la fenêtre change
         *
         * @param sender l'objet appelant
         * @param e les arguments de l'événement
         */
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            for (int row = 0; row < this.gridLenght; row++)
            {
                for (int col = 0; col < this.gridLenght; col++)
                {
                    this.hitori.Nodes[row, col].Box.FontSize = this.hitori.Nodes[row, col].Box.ActualHeight / 3;
                }
            }
        }

        /**
         * Méthode pour créer la grille dynamiquement
         */
        private void CreateDynamicGrid()
        {
            for (int i = 0; i < this.gridLenght; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.MinHeight = (Window.Current.Bounds.Height * 0.85) / this.gridLenght;
                DynamicGrid.RowDefinitions.Add(rowDefinition);

                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.MinWidth = (Window.Current.Bounds.Height * 0.85) / this.gridLenght;
                DynamicGrid.ColumnDefinitions.Add(columnDefinition);
            }

            for (int row = 0; row < this.gridLenght; row++)
            {
                for (int col = 0; col < this.gridLenght; col++)
                {
                    Box box = this.hitori.Nodes[row, col].Box;
					box.Style = ButtonWithoutHover;

                    Grid.SetRow(box, row);
                    Grid.SetColumn(box, col);

                    DynamicGrid.Children.Add(box);
                }
            }
        }

        /**
         * Méthode appelée lorsque l'utilisateur clique sur le bouton "Vérifier"
         *
         * @param sender l'objet appelant
         * @param e les arguments de l'événement
         */
        private void Verify(object sender, RoutedEventArgs e)
        {
			Button button = sender as Button;
            if (this.hitori.Verify())
            {
                button.Foreground = new SolidColorBrush(Colors.Green);
            } else
            {
                button.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        /**
         * Méthode appelée lorsque l'utilisateur clique sur le bouton "Résoudre"
         *
         * @param sender l'objet appelant
         * @param e les arguments de l'événement
         */
        private void Resolve(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            this.hitori.Resolve();
        }

        /**
         * Méthode appelée lorsque l'utilisateur clique sur une nouvelle grille
         * 
         * @param sender l'objet appelant
         * @param e les arguments de l'événement
         */
		private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
		{
			if (args.SelectedItem != null)
			{
				var selectedItem = args.SelectedItem as NavigationViewItem;
				if (selectedItem != null)
				{
					gridLenght = int.Parse(selectedItem.Tag?.ToString());

					DynamicGrid.ColumnDefinitions.Clear();
                    DynamicGrid.RowDefinitions.Clear();
                    DynamicGrid.Children.Clear();

                    this.hitori = new Models.Hitori(Models.Matrix.ReadMatrixInFile(gridLenght));

                    this.CreateDynamicGrid();

                    this.InvalidateMeasure();
				}
			}
		}
	}
}
