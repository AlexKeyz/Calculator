using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using KeyzLibCalcul;

namespace SuperCalculatorKeyzerov
{
    public partial class MainWindow : Window
    {
        private static readonly Regex ValidExpressionPattern = new Regex(@"[^0-9\+\-\*\/\^\(\)\.\,\%\!]");
        Calcul cl = new Calcul();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text1 = textBox1.Text;
            string sanitizedInput = Regex.Replace(text1, ValidExpressionPattern.ToString(), "");
            textBox2.Text = cl.Calculate(sanitizedInput).ToString();
        }
    }
}
