using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;


namespace Matrix_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MessageBox.Show("The purpose of writing this program is to implement mathematical algorithms in academic textbooks, " +
    "and in some places may not be optimal in terms of time complexity and memory."
    + "\nMore detailed descriptions of code implementation are written in the project files." +
     "\n\n\nMade by Sina Ghasemzadeh Farde Bidgoli under MIT license (2022)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Please enter the data in csv format." +
                "Separate the new row in the new row and the new column with the mark", "Warning"
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
       
        private Matrix StringToMatrix(string input)
        {
            string[] str = Input_1.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] _str = _str = str[0].Split(",", StringSplitOptions.RemoveEmptyEntries);
            Matrix matrix=new(str.Length,_str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < _str.Length; j++)
                {
                    try
                    {
                        _str = str[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                        matrix[i, j] = double.Parse(_str[j]);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Input matrix was not in corret format");
                        Application.Restart();
                    }
                }
            }
            return matrix;
        }
        private void PrintResult(Matrix matrix)
        {

            Ouput.Clear();
            for (int i = 0; i < matrix.NRow; i++)
            {
                for (int j = 0; j < matrix.NCol; j++)
                {
                    Ouput.Text += Math.Round(matrix[i, j], 3).ToString()+',';
                }
                Ouput.Text += Environment.NewLine;
            }
        }
        private void PrintResult(string Input)
        {
          Ouput.Clear();
          Ouput.Text = Input;
        }
        private void PrintResult(Matrix Input1 , Matrix Input2)
        {
            Input_2.Clear();
            Ouput.Clear();
            for (int i = 0; i < Input2.NRow; i++)
            {
                for (int j = 0; j < Input2.NCol; j++)
                {
                    Input_2.Text += Math.Round(Input2[i, j],3).ToString() + ',';
                }
                Input_2.Text += Environment.NewLine;
            }
            for (int i = 0; i < Input1.NRow; i++)
            {
                for (int j = 0; j < Input1.NCol; j++)
                {
                    Ouput.Text += Math.Round(Input1[i, j],3).ToString() + ',';
                }
                Ouput.Text += Environment.NewLine;
            }
        }
        private void Input_1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Input_1.Text))
            {
                string[] str = Input_1.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string[] _str = _str = str[0].Split(",", StringSplitOptions.RemoveEmptyEntries);
                Row1_tb.Text = str.Length.ToString();
                Col1_tb.Text = _str.Length.ToString();
                if (!Input_1.Text.Any(char.IsLetter))
                {
                    Input1Check.Text = "Valid";
                    Input1Check.ForeColor = Color.Green;
                    Caculate_btn.Enabled = true;
                }
                else
                {
                    Input1Check.Text = "Error";
                    Input1Check.ForeColor = Color.Red;
                    Caculate_btn.Enabled = false;
                }
            }


        }
        private void Caculate_btn_Click_1(object sender, EventArgs e)
        {
            Function function = new Function();
            if (Modes.SelectedIndex>2)
            {
                if(!StringToMatrix(Input_1.Text).Square())
                {
                    MessageBox.Show("Input matrix is not squre please edit matrix");
                    Application.Restart();
                }
            }
            int _row1, _col1,_row2,_col2 = 0;
            try
            {
                _row1 = int.Parse(Row1_tb.Text);
                _col1 = int.Parse(Col1_tb.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Input matrix was not in corret format");
                Application.Restart();
            }
            _row1 = int.Parse(Row1_tb.Text);
            _col1 = int.Parse(Col1_tb.Text);
            if (Modes.SelectedIndex<3)
            {
                _row2 = int.Parse(Row2_tb.Text);
                _col2 = int.Parse(Col2_tb.Text);
            }
            string _str=Input_1.Text;
            var _matrix = new Matrix(_row1, _col1);
            var _temp = new Matrix(_row1, _col1);
            if (!string.IsNullOrEmpty(_str) )
            {
                switch (Modes.SelectedIndex)
                {
                    case 0:

                        function.Subtraction(StringToMatrix(Input_1.Text), StringToMatrix(Input_2.Text), _matrix);
                        PrintResult(_matrix);
                        break;
                    case 1:
                        function.Addition(StringToMatrix(Input_1.Text), StringToMatrix(Input_2.Text), _matrix);
                        PrintResult(_matrix);
                        break;
                    case 2:
                        _matrix.Init(_row1,_col2);
                        function.Multipy(StringToMatrix(Input_1.Text), StringToMatrix(Input_2.Text), _matrix);
                        PrintResult(_matrix);
                        break;
                    case 3:
                       PrintResult(function.Determinant(StringToMatrix(Input_1.Text)).ToString());
                        break;
                    case 4:
                        _matrix.Init(_row1, _col1);
                        function.invers(StringToMatrix(Input_1.Text),_matrix);
                        PrintResult(_matrix);
                        break;
                    case 5:
                        _matrix.Init(_col1, _row1);   
                        function.Transpose(StringToMatrix(Input_1.Text), _matrix);
                        PrintResult(_matrix);
                        break;
                    case 6:
                        function.Eigenvalue(StringToMatrix(Input_1.Text),_matrix); 
                        PrintResult(_matrix);
                        break;
                    case 7:
                        PrintResult(function.Trace(StringToMatrix(Input_1.Text)).ToString());
                        break;
                    case 8:
                        //baresi shavad 
                        _matrix.Init(_row1, _col1);
                        function.LU_Factor(StringToMatrix(Input_1.Text), _matrix, _temp);
                        PrintResult(_matrix,_temp);
                        break;
                    case 9:
                        function.QR_Factor(StringToMatrix(Input_1.Text), _matrix, _temp);
                        PrintResult(_matrix, _temp);
                        break;
                    case 10:
                        PrintResult(function.Rank(StringToMatrix(Input_1.Text)).ToString());
                        break;
                    case 11:
                        PrintResult(function.SM(StringToMatrix(Input_1.Text)).ToString());
                        break;
                    default:
                        MessageBox.Show("Something went wrong with select method please try agian");
                        Application.Restart();
                        break;
                }
            }
        }

        private void Input_2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Input_2.Text))
            {
                string[] str = Input_2.Text.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string[] _str = _str = str[0].Split(",", StringSplitOptions.RemoveEmptyEntries);
                Row2_tb.Text = str.Length.ToString();
                Col2_tb.Text = _str.Length.ToString();
                if (!Input_2.Text.Any(char.IsLetter))
                {
                    Input2Check.Text = "Valid";
                    Input2Check.ForeColor = Color.Green;
                    Caculate_btn.Enabled = true;
                }
                else
                {
                    Input2Check.Text = "Error";
                    Input2Check.ForeColor = Color.Red;
                    Caculate_btn.Enabled = false;
                }
            }

        }

        private void Modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modes.SelectedIndex>2)
            {
                Input_2.Enabled = false;
                Row2_tb.Enabled = false;
                Col2_tb.Enabled = false;
                Input_2.Clear();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Ouput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
