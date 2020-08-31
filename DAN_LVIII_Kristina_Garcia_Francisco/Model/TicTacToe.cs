using System;
using System.Linq;
using System.Threading;

namespace DAN_LVIII_Kristina_Garcia_Francisco.Model
{
    /// <summary>
    /// The Tic tac Toe Game
    /// </summary>
    class TicTacToe
    {
        /// <summary>
        /// Checking winner conditions
        /// </summary>
        /// <param name="arr">current array</param>
        /// <returns>Current state</returns>
        public int CheckWin(char[] arr)
        {
            #region Horzontal Winning Condtion
            //Winning Condition For First Row 
            if (arr[0] == arr[1] && arr[1] == arr[2] && arr[0]+ arr[1]+ arr[2] != 0)
            {
                return 1;
            }

            //Winning Condition For Second Row   
            else if (arr[3] == arr[4] && arr[4] == arr[5] && arr[3] + arr[4] + arr[5] != 0)
            {
                return 1;
            }

            //Winning Condition For Third Row   
            else if (arr[6] == arr[7] && arr[7] == arr[8] && arr[6] + arr[7] + arr[8] != 0)
            {
                return 1;
            }
            #endregion

            #region vertical Winning Condtion
            //Winning Condition For First Column       
            else if (arr[0] == arr[3] && arr[3] == arr[6] && arr[0] + arr[3] + arr[6] != 0)
            {
                return 1;
            }

            //Winning Condition For Second Column  
            else if (arr[1] == arr[4] && arr[4] == arr[7] && arr[1] + arr[4] + arr[7] != 0)
            {
                return 1;
            }

            //Winning Condition For Third Column  
            else if (arr[2] == arr[5] && arr[5] == arr[8] && arr[2] + arr[5] + arr[8] != 0)
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            else if (arr[0] == arr[4] && arr[4] == arr[8] && arr[0] + arr[4] + arr[8] != 0)
            {
                return 1;
            }

            else if (arr[2] == arr[4] && arr[4] == arr[6] && arr[2] + arr[4] + arr[6] != 0)
            {
                return 1;
            }
            #endregion

            #region Checking For Draw

            // If all the cells or values filled with X or O then any player has won the match  
            else if (arr[0] != '\0' && arr[1] != '\0' && arr[2] != '\0' && arr[3] != '\0' && arr[4] != '\0' && arr[5] != '\0' && arr[6] != '\0' && arr[7] != '\0' && arr[8] != '\0')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }
        }

        /// <summary>
        /// The computer selects one of the available fields
        /// </summary>
        /// <param name="arr">The array list of fields</param>
        /// <returns>The selected field</returns>
        public int ComputerSelectField(char[] arr)
        {
            Random rng = new Random();
            bool isAvailable = false;
            int selectedField = 0;

            do
            {
                selectedField = rng.Next(0, 9);
                if (arr[selectedField] == '\0')
                {
                    isAvailable = true;
                }
            } while (isAvailable == false);

            return selectedField;
        }
    }
}
