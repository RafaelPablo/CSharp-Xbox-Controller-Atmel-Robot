using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInputDotNetPure;

namespace Supervisorio
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
            Application.Run(new Form1());
            //Application.Run(new camera_viewer_only());
        }
    }

    public class xboxc
    {
        //functions for xbox controller

        public int checkcontroller()
        {
            GamePadState concheck;

            // Simply get the state of the controller from XInput.
            concheck = GamePad.GetState(PlayerIndex.One);

            if (concheck.IsConnected)
            {
                 // Controller is connected
                return 1;
            }
            else
            {
                // Controller is not connected 
                return 0;
            }
        }
     
    }
}
