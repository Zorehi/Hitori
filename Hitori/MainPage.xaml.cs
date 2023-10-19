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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hitori
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Box[,] hitoriMatrix;
        private int gridLenght = 9;

        public MainPage()
        {
            this.InitializeComponent();

            this.Background = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));

            this.hitoriMatrix = Models.Matrix.GenerateMatrix(this.gridLenght);

            this.CreateDynamicGrid();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (var item in DynamicGrid.ColumnDefinitions)
            {
                item.MinWidth = (Window.Current.Bounds.Height * 0.85) / this.gridLenght;
            }
            foreach (var item in DynamicGrid.RowDefinitions)
            {
                item.MinHeight = (Window.Current.Bounds.Height * 0.85) / this.gridLenght;
            }

            for (int row = 0; row < this.gridLenght; row++)
            {
                for (int col = 0; col < this.gridLenght; col++)
                {
                    this.hitoriMatrix[row, col].Button.FontSize = this.hitoriMatrix[row, col].Button.ActualHeight / 3;
                }
            }
        }

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
                    Button button = new Button();
                    button.Content = $"{this.hitoriMatrix[row, col].Value}"; // Texte de chaque bouton

                    button.Style = ButtonWithoutHover;

                    button.Click += ChangeColorButton_Click;
                    button.DataContext = this.hitoriMatrix[row, col];
                    button.Background = new SolidColorBrush(Colors.Black);
                    button.Foreground = new SolidColorBrush(Colors.White);
                    //button.Height = (Window.Current.Bounds.Height * 0.85) / this.gridLenght;.
                    button.VerticalAlignment = VerticalAlignment.Stretch;
                    button.HorizontalAlignment = HorizontalAlignment.Stretch;
                    //button.Width = button.Height;
                    //button.FontSize = button.ActualHeight / 3;
                    button.Margin = new Thickness(1);

                    this.hitoriMatrix[row, col].Button = button;
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);

                    DynamicGrid.Children.Add(button);
                }
            }
        }

        private void ChangeColorButton_Click(object sender, RoutedEventArgs e)
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
