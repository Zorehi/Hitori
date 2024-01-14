using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hitori.Models;

namespace Hitori.Models
{
    /**
     * Classe permettant de lire une matrice dans un fichier
     */
    class Matrix
    {
        /**
         * Lit une matrice dans un fichier
         *
         * @param length la taille de la matrice
         * @return la matrice
         */
        public static Box[,] ReadMatrixInFile(int length)
        {
            if (length != 5 && length != 7 && length != 9 && length != 8 && length != 10 && length != 20)
            {
                throw new Exception($"Impossible de lire ce type de matrice matrice {length}x{length}");
            }

            string filename = $"Assets/Matrix/Matrix{length}x{length}.txt";
            Box[,] matrix = new Box[length, length];

            using (var reader = new StreamReader(filename))
            {
                for (int i = 0; i < length; i++)
                {
                    string line = reader.ReadLine();
                    string[] separateLine = line.Split(' ');
                    for (int j = 0; j < length; j++)
                    {
                        matrix[i, j] = new Box(int.Parse(separateLine[j]), State.Black);
                    }
                }
            }

            return matrix;
        }
    }
}
