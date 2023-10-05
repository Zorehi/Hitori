using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hitori.Models;

namespace Hitori.Models
{
    class Matrix
    {
        public static Box[,] GenerateMatrix5x5()
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
        }
    }
}
