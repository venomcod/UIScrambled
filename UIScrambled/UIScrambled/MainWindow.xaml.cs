using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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

namespace UIScrambled
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        static int currentDif = 0;

        enum Dificalti
        {
            Easy = 10,
            Medium = 16,
            Hard = 22

        }
        static string CreateScramble(int movesLenght)
        {
            var varMovesPlus = new List<string>() { "R", "L", "B", "U", "F", "D" };
            var varMovesMinus = new List<string>() { "R'", "L'", "B'", "U'", "F'", "D'" };
            var varMovesDoubLe = new List<string>() { "2R", "2L", "2B", "2U", "2F", "2D" };
            var suDo = 0;
            var resualt = "";
            var response = 0;
            var lastResponse = 0;
            var varResponse = 0;
            while (suDo != movesLenght)
            {
                response = rnd.Next(5);
                varResponse = rnd.Next(3);
                while (response != lastResponse)
                {
                    if (varResponse == 0)
                    {
                        resualt = resualt + " " + varMovesPlus[response];
                        suDo++;
                    }
                    else if (varResponse == 1)
                    {
                        resualt = resualt + " " + varMovesMinus[response];
                        suDo++;
                    }
                    else
                    {
                        resualt = resualt + " " + varMovesDoubLe[response];
                        suDo++;
                    }
                    lastResponse = response;
                }
            }
            return resualt;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Easy_Button_Click(object sender, RoutedEventArgs e)
        {

            currentDif = (int)Dificalti.Easy;
            Text_Dif.Text = "Лёгкая";

        }

        private void Medium_Button_Click(object sender, RoutedEventArgs e)
        {
            currentDif = (int)Dificalti.Medium;
            Text_Dif.Text = "Средняя";
        }

        private void Hard_Button_Click(object sender, RoutedEventArgs e)
        {
            currentDif = (int)Dificalti.Hard;
            Text_Dif.Text = "Сложная";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text_Dif.Text = "Своя";
            currentDif = 0;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            string col = TextBox.Text;
            if (col != "")
            {
                int icol = int.Parse(col);
                Resualt.Text = CreateScramble(icol);
            }
            else if (currentDif == 0)
            {
            }
            else if (currentDif > 0)
            {
                Resualt.Text = CreateScramble(currentDif);
            }
        }
    }
}
