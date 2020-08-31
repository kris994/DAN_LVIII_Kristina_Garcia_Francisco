using DAN_LVIII_Kristina_Garcia_Francisco.Command;
using DAN_LVIII_Kristina_Garcia_Francisco.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_LVIII_Kristina_Garcia_Francisco.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Main Window
        /// </summary>
        MainWindow main;
        /// <summary>
        /// Array of results
        /// </summary>
        private char[] currentResults = new char[9];
        /// <summary>
        /// Checks who starts first
        /// </summary>
        private bool playerFirst = false;
        /// <summary>
        /// Player order
        /// </summary>
        int orderNumber = 0;
        /// <summary>
        /// Get the model
        /// </summary>
        TicTacToe ticTacToe = new TicTacToe();
   
        #region Constructor
        /// <summary>
        /// Opens the main window
        /// </summary>
        /// <param name="mainOpen">MainWindow param</param>
        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }
        #endregion

        #region Commands
        /// <summary>
        /// TicTacToe Button
        /// </summary>
        private ICommand game;
        public ICommand Game
        {
            get
            {
                if (game == null)
                {
                    game = new RelayCommand(GameExecute, param => CanGameExecute());
                }
                return game;
            }
        }

        /// <summary>
        /// Executes a game move
        /// </summary>
        private void GameExecute(object sender)
        {
            // Get the selected cell number
            int number = int.Parse(sender.ToString().Substring((sender.ToString().Length - 1)));
            // Get the button
            Button btn = GetButton(sender.ToString());
            // Check result
            int result = 0;

            orderNumber++;
            if (orderNumber % 2 == 0)
            {
                currentResults[number] = 'O';
                btn.Content = "O";
                btn.IsEnabled = false;
            }
            else
            {
                currentResults[number] = 'X';
                btn.Content = "X";
                btn.IsEnabled = false;
            }

            result = ticTacToe.CheckWin(currentResults);
            string winnerMark = orderNumber % 2 == 0 ? "O" : "X";

            if (result == 1)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show($"The winner is: {winnerMark}", "Close", MessageBoxButton.OK, MessageBoxImage.Warning);
                RestartBoard();
            }
            else if (result == -1)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("There is no winner!", "Close", MessageBoxButton.OK, MessageBoxImage.Warning);
                RestartBoard();
            }
        }

        /// <summary>
        /// Checks if its possible to press the button
        /// </summary>
        /// <returns></returns>
        private bool CanGameExecute()
        {
            return true;
        }
        #endregion


        /// <summary>
        /// Gets the button that was pressed
        /// </summary>
        /// <param name="name">button name</param>
        /// <returns>The pressed button</returns>
        private Button GetButton(string name)
        {
            if (main.Button0.Name == name)
            {
                return main.Button0;
            }
            else if (main.Button1.Name == name)
            {
                return main.Button1;
            }
            else if (main.Button2.Name == name)
            {
                return main.Button2;
            }
            else if (main.Button3.Name == name)
            {
                return main.Button3;
            }
            else if (main.Button4.Name == name)
            {
                return main.Button4;
            }
            else if (main.Button5.Name == name)
            {
                return main.Button5;
            }
            else if (main.Button6.Name == name)
            {
                return main.Button6;
            }
            else if (main.Button7.Name == name)
            {
                return main.Button7;
            }
            else if (main.Button8.Name == name)
            {
                return main.Button8;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Resets the board, order number and current Results
        /// </summary>
        public void RestartBoard()
        {
            main.Button0.IsEnabled = true;
            main.Button0.Content = "";
            main.Button1.IsEnabled = true;
            main.Button1.Content = "";
            main.Button2.IsEnabled = true;
            main.Button2.Content = "";
            main.Button3.IsEnabled = true;
            main.Button3.Content = "";
            main.Button4.IsEnabled = true;
            main.Button4.Content = "";
            main.Button5.IsEnabled = true;
            main.Button5.Content = "";
            main.Button6.IsEnabled = true;
            main.Button6.Content = "";
            main.Button7.IsEnabled = true;
            main.Button7.Content = "";
            main.Button8.IsEnabled = true;
            main.Button8.Content = "";

            currentResults = new char[9];
            orderNumber = 0;
        }
    }
}
