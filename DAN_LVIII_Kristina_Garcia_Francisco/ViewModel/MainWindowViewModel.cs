using DAN_LVIII_Kristina_Garcia_Francisco.Command;
using DAN_LVIII_Kristina_Garcia_Francisco.Model;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_LVIII_Kristina_Garcia_Francisco.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Variables
        /// <summary>
        /// Main Window
        /// </summary>
        MainWindow main;
        /// <summary>
        /// Array of results
        /// </summary>
        private char[] currentResults = new char[9];
        /// <summary>
        /// Checks if player is playing
        /// </summary>
        private bool IsPlayerTurn = true;
        /// <summary>
        /// Checks who starts first
        /// </summary>
        private bool FirstPlayer = true;
        /// <summary>
        /// Game order
        /// </summary>
        int orderNumber = 0;
        /// <summary>
        /// Get the model
        /// </summary>
        TicTacToe ticTacToe = new TicTacToe();
        #endregion

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
            int number = 0;
            Button btn = null;
            string nextPlayer = "";

            // Checks who is currently playing
            if (IsPlayerTurn == true)
            {
                // Get the selected cell number
                number = int.Parse(sender.ToString().Substring((sender.ToString().Length - 1)));
                // Get the button
                btn = GetButton(sender.ToString());
                IsPlayerTurn = false;
            }
            else
            {
                // Get the computer selected number
                Task<int> computerTurn = Task.Run(() => ticTacToe.ComputerSelectField(currentResults));
                number = computerTurn.Result;
                // Get the button with that name
                btn = GetButton("Button" + number);
                IsPlayerTurn = true;
            }

            // Check result
            int result = 0;
            // Current game order
            orderNumber++;
            // Even numbers are saved as 'O', while odds are saved as 'X', the button content gets updated with that value and disabled.
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

            // Check if there was a winner
            result = ticTacToe.CheckWin(currentResults);
            string currentMark = orderNumber % 2 == 0 ? "O" : "X";

            // There is a winner
            if (result == 1)
            {
                // Select who starts next the match
                if (FirstPlayer == true)
                {
                    nextPlayer = "Computer";
                    IsPlayerTurn = false;
                    FirstPlayer = false;
                }
                else
                {
                    nextPlayer = "Player";
                    IsPlayerTurn = true;
                    FirstPlayer = true;
                }

                Xceed.Wpf.Toolkit.MessageBox.Show($"The winner is: {currentMark}!\n{nextPlayer} starts first.", "Close", MessageBoxButton.OK, MessageBoxImage.Warning);
                RestartBoard();
                
            }
            // No winnder
            else if (result == -1)
            {
                // Select who starts next the match
                if (FirstPlayer == true)
                {
                    nextPlayer = "Computer";
                    IsPlayerTurn = false;
                    FirstPlayer = false;
                }
                else
                {
                    nextPlayer = "Player";
                    IsPlayerTurn = true;
                    FirstPlayer = true;
                }
                Xceed.Wpf.Toolkit.MessageBox.Show($"There is no winner!\n{nextPlayer} starts first.", "Close", MessageBoxButton.OK, MessageBoxImage.Warning);
                RestartBoard();
            }

            // If its not players turn, let the computer play
            if (IsPlayerTurn == false)
            {                
                GameExecute(sender);
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
