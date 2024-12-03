namespace CalculatorCet
{
    public partial class MainPage : ContentPage
    {



        public MainPage()
        {
            InitializeComponent();
        }


        double FirstNumber;
        bool isFirstNumberAfterOperator = true;
        Operator PreviousOperator = Operator.None;
        double MemoryValue;


        private void SubtractButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Subtract;

        }

        private void MultiplyButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Multiply;
        }

        private void DivideButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Divide;

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

            DoCalculation();
            PreviousOperator = Operator.Add;

        }

        void DoCalculation()
        {

            switch (PreviousOperator)
            {
                case Operator.None:
                    FirstNumber = Double.Parse(Display.Text);
                    break;
                case Operator.Add:
                    FirstNumber = FirstNumber + Double.Parse(Display.Text);
                    break;
                case Operator.Subtract:
                    FirstNumber = FirstNumber - Double.Parse(Display.Text);

                    break;
                case Operator.Multiply:
                    FirstNumber = FirstNumber * Double.Parse(Display.Text);

                    break;
                case Operator.Divide:
                    FirstNumber = FirstNumber / Double.Parse(Display.Text);

                    break;

            }
            isFirstNumberAfterOperator = true;
            Display.Text = FirstNumber.ToString();
        }

        private void Digit_Clicked(object sender, EventArgs e)
        {
            Button digitButton = sender as Button;
            if (isFirstNumberAfterOperator)
            {
                Display.Text = digitButton.Text;
                isFirstNumberAfterOperator = false;

            }
            else
            {
                Display.Text += digitButton.Text;
            }

        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.None;

        }

        private void CEButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            isFirstNumberAfterOperator = true;
        }

        private void CButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            FirstNumber = 0;
            PreviousOperator = Operator.None;
            isFirstNumberAfterOperator = true;
        }

        private void decimalbutton_Clicked(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(","))
            {
                if (isFirstNumberAfterOperator)
                {
                    Display.Text = "0,";
                    isFirstNumberAfterOperator = false;
                }
                else
                {
                    Display.Text += ",";
                }
            }
        }

        private void MSbtn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Display.Text))
            {
                MemoryValue = double.Parse(Display.Text);
            }
        }

        private void MRbtn_Clicked(object sender, EventArgs e)
        {
            Display.Text = MemoryValue.ToString();
        }
    }

}
