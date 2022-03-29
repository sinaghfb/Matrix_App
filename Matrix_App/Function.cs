using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_App
{
    internal class Function
    {
        // pivot the matrix
        private int Pivot(Matrix Input)
        {
            int temp = 1;
            for (int i = 0; i < Input.NRow; i++)
            {
                if (Input[i, i] == 0)
                {
                    for (int j = i + 1; j < Input.NRow; j++)
                    {
                        if (Input[i, j] != 0)
                        {
                            Input.Swap_Rows(i, j);
                            temp = temp * -1;
                            break;

                        }
                    }
                }
            }
            return temp;
        }
        //gaus eleminition 
        private void Gaus(Matrix Input)
        {
            //temp row counter
            int TCC = 0;
            double TVS = 0;
            for (int i = 0; i < Input.NRow - 1; i++)
            {

                for (int j = 1 + i; j < Input.NRow; j++)
                {
                    TVS = Input[j, TCC] / Input[i, i];
                    if (Input[j, TCC] != 0)
                    {
                        Input.Row_Sum(j, TVS, i);
                    }
                }

                TCC++;
            }
        }
        //gaus jordan eleminition 
        private void Gaus_Jordan(Matrix Input)
        {
            Pivot(Input);
            Gaus(Input);
            for (int i = 0; i < Input.NRow; i++)
            {
                if (Input[i, i] != 0)
                {

                    Input.Row_Multiplier(i, 1 / Input[i, i]);
                }
            }
        }
        //caculates the rank of matrix 
        public int Rank(Matrix Input)
        {
            Matrix Temp = new Matrix(Input.NRow,Input.NCol);
            Temp.Copy(Input);
            Pivot(Temp);
            Gaus(Temp);
            return (Temp.NRow - Temp.Zero_Rows());
        }
        //caculates Determinant of matrix
        public double Determinant(Matrix Input)
        {
            if (!Input.Square())
            {
                return 0;
            }
            Matrix Temp = new Matrix(Input.NRow, Input.NCol); 
            Temp.Copy(Input);
            bool sign = false;
            if (Pivot(Temp) == 1)
            {
                sign = true;
            }
            double temp = 1;
            Pivot(Temp);
            Gaus(Temp);
            for (int i = 0; i < Temp.NRow; i++)
            {
                temp = temp * Temp[i, i];
            }
            if (sign)
            {
                return temp;
            }
            else
            {
                return temp * -1;
            }

        }
        //caculates transpose of matrix
        public void Transpose(Matrix Input, Matrix Output)
        {

            for (int i = 0; i < Input.NRow; i++)
            {
                for (int j = 0; j < Input.NCol; j++)
                {
                    Output[i, j] = Input[j, i];
                }
            }
        }
        // adds 2 matrix toghethar
        public bool Addition(Matrix A, Matrix B, Matrix Output)
        {
            if (A.NCol != B.NCol || A.NRow != B.NRow)
            {
                return false;
            }
            for (int i = 0; i < A.NRow; i++)
            {
                for (int j = 0; j < B.NCol; j++)
                {
                    Output[i, j] = A[i, j] + B[i, j];
                }
            }
            return true;
        }
        //Subtracts 2 matrix
        public bool Subtraction(Matrix A, Matrix B, Matrix Output)
        {
            if (A.NCol != B.NCol || A.NRow != B.NRow)
            {
                return false;
            }
            for (int i = 0; i < A.NRow; i++)
            {
                for (int j = 0; j < B.NCol; j++)
                {
                    Output[i, j] = A[i, j] - B[i, j];
                }
            }
            return true;
        }
        //Multipy 2 matrix 
        public bool Multipy(Matrix A, Matrix B, Matrix Output)
        {
            if (Output.NCol!=B.NCol || Output.NRow!=A.NRow)
            {
                return false;
            }
            double temp = 0;
            if (A.NCol != B.NRow)
            {
                return false;
            }
            for (int i = 0; i < A.NRow; i++)
            {
                for (int j = 0; j < B.NCol; j++)
                {
                    temp = 0;
                    Output[i, j] = 0;
                    for (int k = 0; k < A.NCol; k++)
                    {
                        temp += (A[i, k] * B[k, j]);
                    }
                    Output[i, j] = temp;

                }
            }
            return true;
        }
        private void Sub_Matrix(int Level, Matrix Input, Matrix Output)
        {
            for (int i = Level; i < Input.NRow; i++)
            {
                for (int j = Level; j < Input.NCol; j++)
                {
                    Output[i - Level, j - Level] = Input[i, j];
                }
            }
        }
        private double Vector_Size(List<double> Input)
        {
            double Temp = 0;
            for (int i = 0; i < Input.Count; i++)
            {
                Temp = Temp + Math.Pow(Input[i], 2);
            }
            return Temp;
        }
        private void Vector_Spanner(List<double> Input, Matrix Output)
        {
            for (int i = 0; i < Input.Count; i++)
            {
                for (int j = 0; j < Input.Count; j++)
                {
                    Output[i, j] = Input[i] * Input[j];
                }
            }
        }
        //qr factorization caculator
        public bool QR_Factor(Matrix Input, Matrix Q, Matrix R)
        {
            if (!Input.Square())
            {
                return false;
            }
            Q.Init(Input.NRow,Input.NCol);
            R.Init(Input.NRow, Input.NCol);
            Q.Diagonal_Maker();
            Matrix A = new Matrix(Input.NRow, Input.NCol);
            double a = 0;
            List<double> V = new();
            Matrix H = new Matrix(Input.NRow, Input.NCol); 
            A= new Matrix(Input.NRow, Input.NCol);
            A.Copy(Input);
            for (int i = 0; i < Input.NRow; i++)
            {
                H= new Matrix(Input.NRow, Input.NCol);
                H.Diagonal_Maker();
                V.Clear();
                if (i != 0)
                {
                    A.Col_Remove(0);
                    A.Row_Remove(0);
                }
                A.Select_Col(0, V);
                a = Math.Sqrt(Vector_Size(V));
                if (A[0, 0] < 0)
                {
                    a = a * -1;
                }
                V[0] = V[0] + a;
                a = (2 / Vector_Size(V));

                Vector_Spanner(V, H);
                H.Scaler_multipy(-a);
                for (int j = 0; j < Input.NRow - i; j++)
                {
                    H[j, j] = 1 + H[j, j];
                }
                R.Init(Input.NRow - i, Input.NCol - i);
                R.Copy(A);
                Multipy(H, R, A);
                R.Init(Input.NRow, Input.NCol);
                R.Diagonal_Maker();
                for (int j = 0; j < Input.NRow - i; j++)
                {
                    for (int k = 0; k < Input.NCol - i; k++)
                    {

                        R[j + i, k + i] = H[j, k];
                    }
                }
                H=new Matrix(Input.NRow, Input.NCol);
                H.Copy(R);
                Multipy(Q, H, R);
                Q.Copy(R);
            }
            Q.Scaler_multipy(-1);
            R.Init(Input.NRow, Input.NCol);
            A=new Matrix(Input.NRow, Input.NCol);
            Transpose(Q, A);
            Multipy(A, Input, R);
            return true;
        }
        //LU factorization caculator
        public bool LU_Factor(Matrix Input, Matrix L, Matrix U)
        {
            if (!Input.Square())
            {
                return false;
            }
            int TCC = 0;
            double TVS = 0;
            U.Init(Input.NRow, Input.NCol);
            U.Copy(Input);
            Pivot(U);
            L.Init(Input.NRow, Input.NCol);
            L.Diagonal_Maker();

            for (int i = 0; i < Input.NRow - 1; i++)
            {

                for (int j = 1 + i; j < Input.NRow; j++)
                {
                    TVS = U[j, TCC] / U[i, i];
                    if (Input[j, TCC] != 0)
                    {
                        U.Row_Sum(j, TVS, i);
                    }
                    L[j, TCC] = TVS;
                }

                TCC++;
            }
            return true;
        }
        //caculates invers of matrix 
        public bool invers(Matrix Input, Matrix Output)
        {
            if (Determinant(Input) == 0 || !Input.Square())
            {
                return false;
            }
            Matrix Co_Factor = new Matrix(Input.NRow, Input.NCol);
            for (int i = 0; i < Input.NRow; i++)
            {

                for (int j = 0; j < Input.NCol; j++)
                {
                    Co_Factor = new Matrix(Input.NRow, Input.NCol);
                    Co_Factor.Copy(Input);
                    Co_Factor.Col_Remove(j);
                    Co_Factor.Row_Remove(i);
                    Output[i, j] = Determinant(Co_Factor);
                    if ((i + j) % 2 != 0)
                    {
                        Output[i, j] = Output[i, j] * -1;
                    }
                }
            }
            Co_Factor=new Matrix(Input.NRow, Input.NCol);
            Transpose(Output, Co_Factor);
            Output.Copy(Co_Factor);
            Output.Scaler_multipy(1 / Determinant(Input));
            return true;
        }
        //caculates  Eigenvalue of matrix 
        public bool Eigenvalue(Matrix Input, Matrix Output)
        {
            if (!Input.Square())
            {
                return false;
            }
            Matrix temp = new(Input.NRow, Input.NCol);
            Matrix Q = new(Input.NRow, Input.NCol);
            Matrix R = new(Input.NRow, Input.NCol);
            Output.Copy(Input);
            for (int i = 0; i < 3000; i++)
            {
                QR_Factor(Output, Q, R);
                Multipy(R, Q, Output);
            }
            temp.Copy(Output);
            Output.Init(Input.NRow, 1);
            for (int i = 0; i < Input.NRow; i++)
            {
                Output[i, 0] = temp[i, i];
            }
            return true;
        }
        //caculates trace of matrix 
        public double Trace(Matrix Input)
        {
            double temp = 0;
            for (int i = 0; i < Input.NRow; i++)
            {
                temp += Input[i, i];
            }
            return temp;
        }
        //check if matrix is Symmetric Matrix or not
        public bool SM(Matrix Input)
        {
            Matrix Temp = new(Input.NRow, Input.NCol);
            
            if (Input.Square())
            {
                Transpose(Input, Temp);
                if (Input.Equal(Temp))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
