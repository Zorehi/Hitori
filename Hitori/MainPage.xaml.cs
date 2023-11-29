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
        private Models.Hitori hitori;
        private int gridLenght = 9;

        public MainPage()
        {
            this.InitializeComponent();

            this.Background = new SolidColorBrush(Color.FromArgb(255, 30, 30, 30));

            this.hitori = new Models.Hitori(Models.Matrix.ReadMatrixInFile(this.gridLenght));

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
                    this.hitori.Nodes[row, col].Box.FontSize = this.hitori.Nodes[row, col].Box.ActualHeight / 3;
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
                    Box box = this.hitori.Nodes[row, col].Box;
					box.Style = ButtonWithoutHover;

                    Grid.SetRow(box, row);
                    Grid.SetColumn(box, col);

                    DynamicGrid.Children.Add(box);
                }
            }
        }

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
        private void Resolve(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            this.hitori.Resolve();
        }
    }
}
