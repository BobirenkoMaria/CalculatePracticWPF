using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement element in MainGrid.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            if (str == "C")
                {
                    TextLabel.Text = "";
                }
            else if (str == "=")
                {
                    string value = new DataTable().Compute(TextLabel.Text, null).ToString();
                    TextLabel.Text = value;
                }
            else if (TextLabel.Text.Length < 20)
            {
                if (TextLabel.Text.Length != 0 && (str == "%" || str == "+" || str == "-" ||
                    str == "*" || str == "/" || str == "√" || str == ","))
                {
                    string LastCharOfTextLabel = TextLabel.Text[TextLabel.Text.Length - 1].ToString();

                    if (LastCharOfTextLabel == "%" || LastCharOfTextLabel == "+"
                        || LastCharOfTextLabel == "-" || LastCharOfTextLabel == "*"
                        || LastCharOfTextLabel == "/" || LastCharOfTextLabel == "√"
                        || LastCharOfTextLabel == ",")
                    {
                        //Do nothing
                        str = "";
                    }

                    else
                    {
                        TextLabel.Text += str;
                    }

                }
                else if (str == "%" || str == "+" || str == "-" ||
                    str == "*" || str == "/" || str == "√" || str == ",")
                {
                    if (TextLabel.Text == "")
                    {
                        str = "";
                    }
                    else
                    {
                        TextLabel.Text += str;
                    }
                }
                else
                {
                    TextLabel.Text += str;
                }

                //Регулирование размера текста
                if (TextLabel.Text.Length >= 7 && TextLabel.Text.Length < 10) TextLabel.FontSize = 48;
                else if (TextLabel.Text.Length >= 10 && TextLabel.Text.Length < 14) TextLabel.FontSize = 36;
                else if (TextLabel.Text.Length >= 14) TextLabel.FontSize = 24;
                else TextLabel.FontSize = 72;
            }
            else str = "";
        }
    }
}
