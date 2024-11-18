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

    }
}
