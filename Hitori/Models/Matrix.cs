using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hitori.Models;

namespace Hitori.Models
{
    class Matrix
    {
        public static Box[,] GenerateMatrix(int length)
        {
            switch (length)
            {
                case 5:
                    return Matrix.GenerateMatrix5x5();
                case 7:
                    return Matrix.GenerateMatrix7x7();
                case 9:
                    return Matrix.GenerateMatrix9x9();
                default:
                    throw new Exception("Impossiblle de générer une matrice "+ length + "x" + length);
            }
        }

        private static Box[,] GenerateMatrix5x5()
        {
            string filename = "Assets/Matrix/Matrix5x5.txt";
            int length = 5;
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

        private static Box[,] GenerateMatrix7x7()
        {
            string filename = "Assets/Matrix/Matrix7x7.txt";
            int length = 7;
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

        private static Box[,] GenerateMatrix9x9()
        {
            string filename = "Assets/Matrix/Matrix9x9.txt";
            int length = 9;
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
        /*private static Box[,] GenerateMatrix5x5()
        {
            Box[,] matrix = new Box[5, 5];

            matrix[0, 0] = new Box(4, State.Black);
            matrix[0, 1] = new Box(2, State.Black);
            matrix[0, 2] = new Box(1, State.Black);
            matrix[0, 3] = new Box(5, State.Black);
            matrix[0, 4] = new Box(3, State.Black);

            matrix[1, 0] = new Box(1, State.Black);
            matrix[1, 1] = new Box(4, State.Black);
            matrix[1, 2] = new Box(3, State.Black);
            matrix[1, 3] = new Box(2, State.Black);
            matrix[1, 4] = new Box(2, State.Black);

            matrix[2, 0] = new Box(3, State.Black);
            matrix[2, 1] = new Box(5, State.Black);
            matrix[2, 2] = new Box(4, State.Black);
            matrix[2, 3] = new Box(2, State.Black);
            matrix[2, 4] = new Box(2, State.Black);

            matrix[3, 0] = new Box(1, State.Black);
            matrix[3, 1] = new Box(5, State.Black);
            matrix[3, 2] = new Box(2, State.Black);
            matrix[3, 3] = new Box(5, State.Black);
            matrix[3, 4] = new Box(5, State.Black);

            matrix[4, 0] = new Box(1, State.Black);
            matrix[4, 1] = new Box(1, State.Black);
            matrix[4, 2] = new Box(5, State.Black);
            matrix[4, 3] = new Box(3, State.Black);
            matrix[4, 4] = new Box(4, State.Black);

            return matrix;
        }*/
    }
}
