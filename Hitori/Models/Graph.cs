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
        // constructeur de recopie
        public Graph(Graph graph)
        {
            int x = graph.Nodes.Length;
            this._nodes = new Node[x, x];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    _nodes[i, j] = new Node(graph.Nodes[i, j]);
                }
            }
            for (int k = 0; k < x; k++)
            {
                for (int l = 0; l < x; l++)
                {
                    _nodes[k, l].AdjaList = new List<Node>();
                    // Coin haut-gauche
                    if (k == 0 && l == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);
                    }
                    // Coin haut-droit
                    else if (k == 0 && l == x - 1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                    }
                    // Coin bas-gauche
                    else if (k == x - 1 && l == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);

                    }
                    // Coin bas-groit
                    else if (k == x - 1 && l == x - 1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);

                    }
                    // Ligne du haut
                    else if (k == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);


                    }
                    // Ligne du bas
                    else if (k == x - 1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);

                    }
                    //Colonne de gauche
                    else if (l == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);

                    }
                    // Colonne de droite
                    else if (l == x - 1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                    }
                    else
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);

                    }
                }
            }
        }

        public Graph(Box[,] matrix)
        {
            int x = matrix.GetLength(0);
           
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
                    _nodes[k, l].AdjaList = new List<Node>();
                    // Coin haut-gauche
                    if ( k == 0 && l == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1,l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);
                    }
                    // Coin haut-droit
                    else if(k == 0 && l == x - 1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                    }
                    // Coin bas-gauche
                    else if(k == x-1 && l == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k-1, l]);

                    }
                    // Coin bas-groit
                    else if (k == x-1 && l == x-1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);

                    }
                    // Ligne du haut
                    else if( k == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l-1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l+1]);

                    
                    }
                    // Ligne du bas
                    else if(k == x - 1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);

                    }
                    //Colonne de gauche
                    else if(l == 0)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);

                    }
                    // Colonne de droite
                    else if(l == x - 1)
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                    } 
                    else
                    {
                        _nodes[k, l].AdjaList.Add(_nodes[k - 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k + 1, l]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l - 1]);
                        _nodes[k, l].AdjaList.Add(_nodes[k, l + 1]);

                    }
                }
            }
        }

        public Node[,] Nodes { get => _nodes; set => _nodes = value; }

    }
}
