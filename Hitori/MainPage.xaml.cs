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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hitori
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int[,] hitoriMatrix;
        private int gridLenght = 5;

        public MainPage()
        {
            this.InitializeComponent();

            this.CreateHitoriMatrix();

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
                    button.Content = $"{this.hitoriMatrix[row, col]}"; // Texte de chaque bouton
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    dynamicGrid.Children.Add(button);
                }
            }

            DynamicGrid.Children.Add(dynamicGrid);
        }

        private void CreateHitoriMatrix()
        {
            this.hitoriMatrix = new int[this.gridLenght, this.gridLenght];

            this.hitoriMatrix[0, 0] = 4;
            this.hitoriMatrix[0, 1] = 2;
            this.hitoriMatrix[0, 2] = 1;
            this.hitoriMatrix[0, 3] = 5;
            this.hitoriMatrix[0, 4] = 3;

            this.hitoriMatrix[1, 0] = 1;
            this.hitoriMatrix[1, 1] = 4;
            this.hitoriMatrix[1, 2] = 3;
            this.hitoriMatrix[1, 3] = 2;
            this.hitoriMatrix[1, 4] = 2;

            this.hitoriMatrix[2, 0] = 3;
            this.hitoriMatrix[2, 1] = 5;
            this.hitoriMatrix[2, 2] = 4;
            this.hitoriMatrix[2, 3] = 2;
            this.hitoriMatrix[2, 4] = 2;

            this.hitoriMatrix[3, 0] = 1;
            this.hitoriMatrix[3, 1] = 5;
            this.hitoriMatrix[3, 2] = 2;
            this.hitoriMatrix[3, 3] = 5;
            this.hitoriMatrix[3, 4] = 5;

            this.hitoriMatrix[4, 0] = 1;
            this.hitoriMatrix[4, 1] = 1;
            this.hitoriMatrix[4, 2] = 5;
            this.hitoriMatrix[4, 3] = 3;
            this.hitoriMatrix[4, 4] = 4;
        }
    }
}
