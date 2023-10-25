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
        private Graph hitoriGraph;
        private int gridLenght = 5;

        public MainPage()
        {
            this.InitializeComponent();

            this.Background = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));

            this.hitoriMatrix = Models.Matrix.GenerateMatrix(this.gridLenght);
            this.hitoriGraph = new Graph(this.hitoriMatrix);

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

                    button.Click += this.hitoriMatrix[row, col].ChangeColorButton_Click;
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

        private void Check(object sender, RoutedEventArgs e)
        {
            bool checkRowCol = true;
            bool checkAdja = true;
            bool checkConnex = true;
            // Vérification des lignes
            for (int row = 0; row < this.gridLenght; row++)
            {
                HashSet<int> rowSet = new HashSet<int>();
                for (int col = 0; col < this.gridLenght; col++)
                {
                    if (this.hitoriMatrix[row, col].State == State.White)
                    {
                        if (!rowSet.Add(this.hitoriMatrix[row, col].Value))
                        {
                            // Le numéro a déjà été rencontré dans cette colonne
                            checkRowCol = false;
                        }

                        int sizeAdjaList = this.hitoriGraph.Nodes[row, col].AdjaList.Count;
                        for (int x = 0; x < sizeAdjaList; x++)
                        {
                            if (this.hitoriMatrix[row, col].State == State.White)
                            {
                                checkAdja = false;
                            }
                        }
                    }
                }
            }

            // Vérification des colonnes
            for (int row = 0; row < this.gridLenght; row++)
            {
                HashSet<int> colSet = new HashSet<int>();
                for (int col = 0; col < this.gridLenght; col++)
                {
                    if (this.hitoriMatrix[row, col].State == State.White)
                    {
                        if (!colSet.Add(this.hitoriMatrix[row, col].Value))
                        {
                            // Le numéro a déjà été rencontré dans cette colonne
                            checkRowCol = false;
                        }
                    }
                }
            }

            checkConnex = ConnectedGraph.IsConnected(this.hitoriGraph);

            Button button = sender as Button;
            if (checkConnex && checkAdja && checkRowCol)
            {
                button.Foreground = new SolidColorBrush(Colors.Green);
            } else
            {
                button.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
