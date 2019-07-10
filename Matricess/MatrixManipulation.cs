using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricess
{
    class MatrixManipulation
    {
        public static decimal[,] GetMinors(decimal[,] Matrix, int MatrixRow, int MatrixCol, int Dimension)
        {
            decimal[,] minorHolding = new decimal[Dimension, Dimension];
            int minorRow = 0, minorCol = 0;
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    //checking for coffactors
                    if (i != MatrixRow && j != MatrixCol) // this controls the if statement  //eliminates rows and column
                    {
                        minorHolding[minorRow, minorCol++] = Matrix[i, j];   //let minorholding hold those elements not in same i/j. minorcol++ moves to the next column , same row
                        if (minorCol == Dimension - 1) // when the row gets filled up then fill the column
                        {
                            minorCol = 0;
                            minorRow++;

                        }
                    }
                }

            }
            return minorHolding;

        }
        public static decimal DeterminantOfMatrix(decimal[,] Matrix, int Dimention)
        {
            decimal Determinant = 0;// initializing this
            // checking if matrix contains single elements
            if (Dimention == 1)
            {
                return Matrix[0, 0];
            }
            int sign = 1; //holding the sign


            for (int i = 0; i < Dimention; i++)
            {
                //getting the coffactor
              //  for (int j = i; j < Dimention; j++)
              //  {
                    decimal[,] temp = GetMinors(Matrix, 0, i, Dimention); // 0 here we talking about first row of each minor returned.
                    Determinant += sign * Matrix[0, i] * DeterminantOfMatrix(temp, Dimention - 1);
                    sign = -sign;
                }
            //}
            return Determinant;
        }
        // function for the adjont 
        public static decimal[,]Adjoint(decimal[,] Matrix, int Dimension)
        {
            decimal[,] adjoint = new decimal[Dimension, Dimension];
              decimal[,] coFactor = new decimal[Dimension, Dimension];

              for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    // getting the matix minors
                    decimal[,] coMinor = GetMinors(Matrix, i, j, Dimension);
                    //checking for and switching signs
                   int  sign = (((i + j) % 2) == 0) ? 1 : -1;
                  //  getting the coffactors
                     coFactor[i, j] = sign * DeterminantOfMatrix(coMinor, Dimension - 1);
                    //   getting the adjoint.adjoint is transpose of coffactors that is i becomes j;
                    adjoint[j, i] = coFactor[i, j];
                   
                }
               
            }
            return adjoint;
        }
        // function for the inverse
        public static decimal[,] Inverse(decimal[,] Matrix, int Dimension)
        {
            //checking for singularity of matrix
            decimal det = DeterminantOfMatrix(Matrix, Dimension);
            if (det == 0)
            {
                Console.WriteLine("The matrix is singular hence there is no inverse");
            }
            decimal[,] adjoint = Adjoint(Matrix, Dimension);
            decimal[,] inverse = new decimal[Dimension, Dimension];
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    inverse[i, j] = adjoint[i, j] * (1 / det);
                }
            }
            return inverse;
        }
        public static void DisplayDeterminant(decimal[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(" " + Matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
