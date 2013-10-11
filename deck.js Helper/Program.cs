/* Deck.js Helper
 * Copyright (c) 2013 Benjamin Röjder Delnavaz
 * Licensed under the MIT license. */

using System;
using System.Windows.Forms;

namespace DeckjsHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
