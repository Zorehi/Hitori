using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitori.Models
{
    class Graph
    {
        private Node[,] _nodes;

        public Graph(Box[,] matrix)
        {
            int x = matrix.GetLength(0);
            List<Node> list = new List<Node>();
            _nodes = new Node[x, x];
            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < x; j++)
                {
                    _nodes[i, j] = new Node(i, j, matrix[i, j]);
                }
            }
            for(int k = 0; k < x; k++)
            {
                for(int l = 0; l < x; l++)
                {
                    // Coin haut-gauche
                    if ( k == 0 && l == 0)
                    {
                        list.Add(_nodes[k + 1,l]);
                        list.Add(_nodes[k, l + 1]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    }
                    // Coin haut-droit
                    else if(k == 0 && l == x - 1)
                    {
                        list.Add(_nodes[k, l - 1]);
                        list.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    }
                    // Coin bas-gauche
                    else if(k == x-1 && l == 0)
                    {
                        list.Add(_nodes[k, l + 1]);
                        list.Add(_nodes[k-1, l]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    }
                    // Coin bas-groit
                    else if (k == x-1 && l == x-1)
                    {
                        list.Add(_nodes[k - 1, l]);
                        list.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    }
                    // Ligne du haut
                    else if( k == 0)
                    {
                        list.Add(_nodes[k + 1, l]);
                        list.Add(_nodes[k, l-1]);
                        list.Add(_nodes[k, l+1]);
                        _nodes[0, l].AdjaList = list;
                        list.Clear();
                    
                    }
                    // Ligne du bas
                    else if(k == x - 1)
                    {
                        list.Add(_nodes[k - 1, l]);
                        list.Add(_nodes[k, l - 1]);
                        list.Add(_nodes[k, l + 1]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    }
                    //Colonne de gauche
                    else if(l == 0)
                    {
                        list.Add(_nodes[k - 1, l]);
                        list.Add(_nodes[k - 1, l]);
                        list.Add(_nodes[k + 1, l]);
                        list.Add(_nodes[k, l + 1]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    }
                    // Colonne de droite
                    else if(l == x - 1)
                    {
                        list.Add(_nodes[k - 1, l]);
                        list.Add(_nodes[k + 1, l]);
                        list.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    } 
                    else
                    {
                        list.Add(_nodes[k - 1, l]);
                        list.Add(_nodes[k + 1, l]);
                        list.Add(_nodes[k, l - 1]);
                        list.Add(_nodes[k, l + 1]);
                        _nodes[k, l].AdjaList = list;
                        list.Clear();
                    }
                }
            }
        }

        public Node[,] Nodes { get => _nodes; set => _nodes = value; }

    }
}
