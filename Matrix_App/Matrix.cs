using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_App
{
    //The purpose of writing this class is to simulate a matrix
    internal class Matrix
    {
        private List<double> Matrix_Elements = new();
        public int NRow, NCol;
        /*public Matrix()
        {

        }*/
        public Matrix(int Row,int Col)
        {
            NRow = Row;
            NCol = Col;
            Matrix_Elements.Clear();
            Matrix_Elements.Capacity = Row * Col + 1;
            for (int i = 0; i < Row * Col; i++)
            {
                Matrix_Elements.Add(0);
            }
        }
        //this method clear object and make it with new row and col size 
        public bool Init(int Row, int Col)
        {
            NRow = Row;
            NCol = Col;
            Matrix_Elements.Clear();
            Matrix_Elements.Capacity = Row * Col + 1;
            for (int i = 0; i < Row * Col; i++)
            {
                Matrix_Elements.Add(0);
            }
            return true;
        }
        // this method make input matrix diagonal
        public void Diagonal_Maker()
        {
            for (int i = 0; i < NRow; i++)
            {
                Matrix_Elements[AC(i, i)] = 1;
            }
        }
        //Adress converter method to convert adress to on one dimimensional for list 
        private int AC(int Row, int Col)
        {

            return ((NCol * Row) + Col);
        }
        //counts zero elements
        public int Zero_count()
        {
            int zero_counter = 0;
            for (int i = 0; i < Matrix_Elements.Count; i++)
            {
                if (Matrix_Elements[i] == 0)
                {
                    zero_counter++;
                }
            }
            return zero_counter;
        }
        //counts elements
        public int Element_Count()
        {
            return Matrix_Elements.Count;
        }
        //swap rows of matrix
        public bool Swap_Rows(int A, int B)
        {
            double Temp = 0;
            for (int i = 0; i < NCol; i++)
            {
                Temp = Matrix_Elements[AC(A, i)];
                Matrix_Elements[AC(A, i)] = Matrix_Elements[AC(B, i)];
                Matrix_Elements[AC(B, i)] = Temp;
            }
            return true;
        }
        //swaps columns of matrix
        public bool Swap_Cols(int A, int B)
        {
            double Temp = 0;
            for (int i = 0; i < NRow; i++)
            {
                Temp = Matrix_Elements[AC(i, A)];
                Matrix_Elements[AC(i, A)] = Matrix_Elements[AC(i, B)];
                Matrix_Elements[AC(i, B)] = Temp;
            }
            return true;

        }
        //check if matrix is squre
        public bool Square()
        {
            if (NRow == NCol)
            {
                return true;
            }
            return false;
        }
        //check if matrix is up triangle
        public bool Up_Triangle()
        {
            if (Square() != true)
            {
                return false;
            }
            for (int i = 1; i < NRow; i++)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (Matrix_Elements[AC(i, j)] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //check matrix if down triangle
        public bool Down_Triangle()
        {
            if (Square() != true)
            {
                return false;
            }
            for (int i = NRow - 1; i >= 0; i--)
            {
                for (int j = NRow - 1; j >= i; j--)
                {
                    if (Matrix_Elements[AC(i, j)] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // count linearly dependent rows
        public int Zero_Rows()
        {
            int Temp = 0;
            for (int i = 0; i < NRow; i++)
            {
                for (int j = 0; j < NCol; j++)
                {
                    if (Matrix_Elements[AC(i, j)] != 0)
                    {
                        break;
                    }
                    if (j == NCol - 1)
                    {
                        Temp++;
                    }
                }
            }

            return Temp;
        }
        //returns a specified row
        public void Select_Row(int Row, List<double> Output)
        {
            for (int i = 0; i < NRow; i++)
            {
                Output.Add(Matrix_Elements[AC(Row, i)]);
            }

        }
        //returns a specified row
        public void Select_Col(int Col, List<double> Output)
        {
            for (int i = 0; i < NRow; i++)
            {
                Output.Add(Matrix_Elements[AC(i, Col)]);
            }

        }
        //adding a multiple of one row to another row
        public void Row_Sum(int Row, double Value, int S_Row)
        {
            for (int i = 0; i < NCol; i++)
            {
                Matrix_Elements[AC(Row, i)] = Matrix_Elements[AC(Row, i)] - (Value * Matrix_Elements[AC(S_Row, i)]);
            }
        }
        //multiplying an row by a non-zero constant
        public void Row_Multiplier(int Row, double Value)
        {
            for (int i = 0; i < NRow; i++)
            {
                Matrix_Elements[AC(Row, i)] = Value * (Matrix_Elements[AC(Row, i)]);
            }
        }
        //copies input matrix to this class
        public bool Copy(Matrix input)
        {
            if (input.Element_Count() != this.Element_Count())
            {
                return false;
            }
            for (int i = 0; i < NRow; i++)
            {
                for (int j = 0; j < NCol; j++)
                {
                    Matrix_Elements[AC(i, j)] = input[i, j];
                }
            }
            return true;

        }
        // check if element exists or not 
        public bool Element_Exist(int row, int col)
        {
            if (row > NRow || col > NCol)
            {
                return false;
            }
            return true;
        }
        //remove a row 
        public void Row_Remove(int Row)
        {
            for (int i = 0; i < NCol; i++)
            {
                Matrix_Elements.RemoveAt(AC(Row, i));
                Matrix_Elements.Insert(AC(Row, i), 0);
            }
            for (int i = 0; i < NCol; i++)
            {
                Matrix_Elements.Remove(0);
            }
            NRow--;
        }
        //removes a col 
        public void Col_Remove(int Col)
        {
            for (int i = 0; i < NRow; i++)
            {
                Matrix_Elements.RemoveAt(AC(i, Col));
                Matrix_Elements.Insert(AC(i, Col), 0);
            }
            for (int i = 0; i < NRow; i++)
            {
                Matrix_Elements.Remove(0);
            }
            NCol--;
        }
        //multiplying matrix by number given 
        public void Scaler_multipy(double Input)
        {
            for (int i = 0; i < NRow; i++)
            {
                for (int j = 0; j < NCol; j++)
                {
                    Matrix_Elements[AC(i, j)] = Matrix_Elements[AC(i, j)] * Input;
                }
            }
        }
        // check if 2 matrix is equal or not 
        public bool Equal(Matrix Input)
        {
            for (int i = 0; i < NRow * NCol; i++)
            {
                if (Matrix_Elements[i] != Input.Matrix_Elements[i])
                {
                    return false;
                }
            }
            return true;
        }
        public double this[int row, int col]
        {
            // get accessor
            get
            {
                return Matrix_Elements[(NCol * row) + col];
            }

            // set accessor
            set
            {
                Matrix_Elements[((NCol * row) + col)] = value;
            }
        }

    }

}
