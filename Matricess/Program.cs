using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricess
{
    class Program
    {
        static void Main(string[] args)
        {
            //decimal[,] Matrix ={
            //                      { 5, -2, 2, 7},
            //                      { 1, 0, 0, 3},
            //                      { -3, 1, 5, 0},
            //                      { 3, -1, -9, 4}
            //      };
           // decimal[,] matrix = { { 2, 3 }, { 4, 5 } };
            //double[,] matrix = { { 1, 4, 2, 3, 5 }, { 0, 1, 4, 4, 4 }, { -1, 0, 1, 0, 3 }, { 2, 0, 4, 1, 2 }, { 1, 2, 3, 4, 5 } };
           decimal [,] matrix = { { 1,4,2},{ 0,4,1},{ -1,0,1} } ;
            MatrixManipulation.DisplayDeterminant(MatrixManipulation.Inverse(matrix, 3));
          //  MatrixManipulation.DisplayDeterminant(MatrixManipulation.Adjoint(matrix, 3));
            double t = 5;
            double z = 45;
            Console.WriteLine(t / z);
            Console.ReadKey();
        }
    }
}
