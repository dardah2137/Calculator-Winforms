namespace WinFormsApp2
{
    public partial class Form1 : Form
    {

        String operation;

        
        const ushort _def_label_lower_location_x = 321;

        const ushort _def_label_upper_location_x = 334;


        public Form1()
        {
            InitializeComponent();
            operation = "";
        }

        private void changeOperation(String op)
        {
            label_operation.Text = op;
            numLabelsChangeText(label_upper_text, label_lower_text.Text);
            numLabelsChangeText(label_lower_text, "0");
        }

        private void numLabelsChangeText(Label? label, String? value, bool addAsNextLetter = false)
        {
            int new_x_calc = 0;

            if (label.Text != "0" && addAsNextLetter)
            {
                value = label.Text + value;

                if (value.Contains(".")) { new_x_calc = (value.Length - 2); }

                else { new_x_calc = (value.Length - 1); }
            }
            else { new_x_calc = (value.Length - 1); }

            switch (label.Name)
            {
                case "label_lower_text":
                    label.Location = new Point(_def_label_lower_location_x - (new_x_calc * 15), label.Location.Y);

                    break;

                case "label_upper_text":
                    label.Location = new Point(_def_label_upper_location_x - (new_x_calc * 9), label.Location.Y);

                    break;


            }
            label.Text = value;
        }


        private void button_dot_Click(object sender, EventArgs e)
        {
            if(!label_lower_text.Text.Contains("."))
            {
                label_lower_text.Text += ".";
            }
        }

        private void button_number_Click(object sender, EventArgs e)
        {
            var _button = (Button)sender;
            numLabelsChangeText(label_lower_text, _button.Text, true);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            numLabelsChangeText(label_lower_text, "0");
            numLabelsChangeText(label_upper_text, "");
            label_operation.Text = "";
        }

        private void button_operations_Click(object sender, EventArgs e)
        {
            var _button = (Button)sender;
            operation = _button.Text;
            if (operation == "=")
            {
                Double _upper = 0.0D;
                try
                {
                    _upper = Convert.ToDouble(label_upper_text.Text);
                }
                catch (Exception)
                {
                    return;
                }
                
                Double _lower = Convert.ToDouble(label_lower_text.Text);

                Double result = 0.0;

                switch (label_operation.Text)
                {
                    case "+":
                        result = _upper + _lower;
                        break;

                    case "-":
                        result = _upper - _lower;

                        break;

                    case "x":
                        result = _upper * _lower;

                        break;

                    case "/":
                        result = _upper / _lower;
                        break;

                }
                numLabelsChangeText(label_upper_text, _upper.ToString() + label_operation.Text + label_lower_text.Text);
                numLabelsChangeText(label_lower_text, result.ToString());
                Console.WriteLine(result.ToString());
                return;
            }

            changeOperation(operation);
        }

        private void label_lower_text_Click(object sender, EventArgs e)
        {

        }

        private void label_upper_text_Click(object sender, EventArgs e)
        {

        }

        private void label_operation_Click(object sender, EventArgs e)
        {

        }
    }
}