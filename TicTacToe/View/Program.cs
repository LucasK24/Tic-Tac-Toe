/*
 * Contains the Main method at its helpers for the application.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (January 2021) - 
 * Version 1.1 (August 2021) -
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Starts the tic-tac-toe application. Event listeners are
    /// used in order to set the mode and difficulty level within
    /// this class.
    /// </summary>
    static class Program
    {

        private static string mode = "";
        private static string difficulty = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HomeScreen hs = new HomeScreen();
            hs.ModeSelected += GetMode;

            Application.Run(hs);
            
            // After home screen is exited, loop until event tells us what was clicked.
            while (true)
            {
                if (mode != "")
                    break;
            }

            // Open new window based on which option was fired to event handler (terminate for "Exit")
            if (mode == "Multiplayer")
            {
                Application.Run(new BoardGUI());
            }
            else if (mode == "Single")
            {
                SelectDifficulty sd = new SelectDifficulty();
                sd.DifficultySelected += GetDifficulty;

                Application.Run(sd);
                while (true)
                {
                    if (difficulty != "")
                        break;
                }

                // Choose board with AI difficulty based on the event that was fired and stored in difficulty.
                if (difficulty == "Easy")
                    Application.Run(new SinglePlayerBoardGUI("Easy"));
                else if (difficulty == "Hard")
                    Application.Run(new SinglePlayerBoardGUI("Hard"));
                else if(difficulty == "Impossible")
                    Application.Run(new SinglePlayerBoardGUI("Impossible"));
            }

        }

        /// <summary>
        /// Sets the mode that was selected by the user.
        /// </summary>
        /// <param name="clickedMode"></param>
        private static void GetMode(string clickedMode)
        {
            mode = clickedMode;
        }

        /// <summary>
        /// Sets the difficulty that was selected by the user.
        /// </summary>
        /// <param name="clickedMode"></param>
        private static void GetDifficulty(string clickedDifficulty)
        {
            difficulty = clickedDifficulty;
        }
    }
}
