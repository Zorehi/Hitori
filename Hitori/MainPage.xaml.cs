using Hitori.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hitori
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Box[,] hitoriMatrix;
        private int gridLenght = 5;

        public MainPage()
        {
            this.InitializeComponent();
            this.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 30, 30 ,30));

            this.hitoriMatrix = Hitori.Models.Matrix.GenerateMatrix5x5();

            this.CreateDynamicGrid();
        }

        private void CreateDynamicGrid()
        {
            Grid dynamicGrid = new Grid();

            for (int i = 0; i < this.gridLenght; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = GridLength.Auto; // Vous pouvez ajuster la hauteur selon vos besoins
                dynamicGrid.RowDefinitions.Add(rowDefinition);

                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = GridLength.Auto; // Vous pouvez ajuster la largeur selon vos besoins
                dynamicGrid.ColumnDefinitions.Add(columnDefinition);
            }

            for (int row = 0; row < this.gridLenght; row++)
            {
                for (int col = 0; col < this.gridLenght; col++)
                {
                    Button button = new Button();
                    button.Content = $"{this.hitoriMatrix[row, col].Value}"; // Texte de chaque bouton

                    button.Click += ChangeColorButton_Click;
                    button.DataContext = this.hitoriMatrix[row, col];
                    button.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                    button.Height = (Window.Current.Bounds.Height * 0.85) / this.gridLenght;
                    button.Width = button.Height;
                    button.FontSize = button.Height / 3;
                    button.Margin = new Thickness(1);

                    this.hitoriMatrix[row, col].Button = button;
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);

                    dynamicGrid.Children.Add(button);
                }
            }

            DynamicGrid.Children.Add(dynamicGrid);
        }

        private void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Box box = button.DataContext as Box;

            Console.WriteLine(box.State);

            switch (box.State)
            {
                case State.Black:
                    button.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 90, 90, 90));
                    box.State = State.Gray;
                    break;
                case State.White:
                    button.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                    button.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                    box.State = State.Black;
                    break;
                case State.Gray:
                    button.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 170, 170, 170));
                    button.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
                    box.State = State.White;
                    break;
            }
        }
    }
}
