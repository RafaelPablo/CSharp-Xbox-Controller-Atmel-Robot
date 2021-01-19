using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInputDotNetPure;
using System.IO.Ports;
using System.IO;
using System.Net;

namespace Supervisorio
{
    public partial class Form1 : Form
    {

        //The following variables are used across several threads
        float shared_left_trig = 0;
        float shared_left_stick_x = 0;
        float shared_left_stick_y = 0;
        float shared_right_trig = 0;
        float shared_right_stick_x = 0;
        float shared_right_stick_y = 0;

        int shared_A = 0;
        int shared_B = 0;
        int shared_X = 0;
        int shared_Y = 0;

        int shared_dpad_up = 0;
        int shared_dpad_down = 0;
        int shared_dpad_left = 0;
        int shared_dpad_right = 0;

        int shared_left_shoulder = 0;
        int shared_right_shoulder = 0;

        int shared_bracoB_valor = 180;
        int shared_bracoC_valor = 90;
        int shared_bracoV_valor = 0;
        int shared_bracoH_valor = 76;
        int shared_bracoG_valor = 80;

        int rumble = 0;

        string motorR;
        string motorL;
        string throttle;
        float shared_steer = 500;
        string steer;

        int steering_mode = 0;
        int throttle_mode = 0;
        int camera_position_flag = 1;

        float shared_cam_pan = 125;
        string cam_pan;
        float shared_cam_tilt = 100;
        string cam_tilt;

        string dataout;

        int headlights = 0;
        int light_brightness = 5;
        int light_sequence = 0;
        int slowmode = 0;
        string braco_string;
        string braco_valor;

        //counters used for managing the toggling of car functions
        //eg headlights or slow mode. These counters are used to stop repeated toggling on/off
        //if the xbox controller button is held down too long
        int samplecount = 0;
        int oldsamplecount1 = 0;
        int rumblecount = 0;

        SerialPort portaSerial = new SerialPort();

        public Form1()
        {
            InitializeComponent();
        }

        //function for controller check button
        private void button1_Click(object sender, EventArgs e)
        {
            int check = 0;
            //The xboxc class is included in Program.cs
            xboxc controlcheck = new xboxc();

            check = controlcheck.checkcontroller();
            if (check == 1)
            {
                textBox1.Text = "Conectado";
                variable_check.Text = String.Format("{0:0.000}", shared_left_stick_x);
            }
            else
            {
                textBox1.Text = "Desconectado";
            }  
        }

        //This event is triggered when the GUI loads
        //Multiple threads are started with this event, and are configured to run in the background
        private void Form1_Load(object sender, EventArgs e)
        {
            //Thread for handling Xbox 360 controller
            Thread updatecontroller = new Thread(new ThreadStart(UpdateState));
            updatecontroller.IsBackground = true;
            updatecontroller.Start();

            //Thread for handling serial communications
            Thread updateIO = new Thread(new ThreadStart(UpdateSerial));
            updateIO.IsBackground = true;
            updateIO.Start();


            //Set default values in comboboxes
            //Index 0 is the first value
            steering_combobox.SelectedIndex = 0;
            throttle_combobox.SelectedIndex = 0;
            camera_position_combobox.SelectedIndex = 0;

            //camera_viewer_only camera_viewer;
            //camera_viewer = new camera_viewer_only();
            //camera_viewer.Show();
        }


        //Auto-generated functions
        private void steering_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            steering_mode = steering_combobox.SelectedIndex;
        }

        private void throttle_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            throttle_mode = throttle_combobox.SelectedIndex;
        }

        private void camera_position_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            camera_position_flag = camera_position_combobox.SelectedIndex;
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for handling the Xbox360 controller
        //---------------------------------------------------------------------------------------------------------

        //Delegates are required so that the background thread can update data in the GUI thread
        //See tutorials on C# cross thread operations for more details
        private delegate void left_trig_delegate(float i);
        private delegate void left_stick_x_delegate(float i);
        private delegate void left_stick_y_delegate(float i);

        private delegate void right_trig_delegate(float i);
        private delegate void right_stick_x_delegate(float i);
        private delegate void right_stick_y_delegate(float i);

        private delegate void left_shoulder_delegate(int status);
        private delegate void right_shoulder_delegate(int status);

        private delegate void dpad_up_delegate(int status);
        private delegate void dpad_down_delegate(int status);
        private delegate void dpad_left_delegate(int status);
        private delegate void dpad_right_delegate(int status);

        private delegate void button_A_delegate(int status);
        private delegate void button_B_delegate(int status);
        private delegate void button_X_delegate(int status);
        private delegate void button_Y_delegate(int status);

        private delegate void slowmode_delegate(int status);
        private delegate void headlights_delegate(int status);
        private delegate void brightness_delegate(int status);
        private delegate void sequence_delegate(int status);
        private delegate void rumble_delegate(int status);

        private void UpdateState()
        {
            while (true)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                //Read analog control values and save into shared variables
                //Left/right triggers and left thumbstick (x-axis only) also have a process function to change
                //the behaviour of the controls between linear/squared/cubed modes.
                //Squared and cubed gives more control for low speed / small steering angles

                shared_left_trig = state.Triggers.Left;
                shared_left_trig = process_raw_throttle_data(shared_left_trig);
                left_trig_value.Invoke(new left_trig_delegate(display_left_trig), shared_left_trig);
                shared_left_stick_x = state.ThumbSticks.Left.X;
                shared_left_stick_x = process_raw_steer_data(shared_left_stick_x);
                left_stick_x_value.Invoke(new left_stick_x_delegate(display_left_stick_x), shared_left_stick_x);
                shared_left_stick_y = state.ThumbSticks.Left.Y;
                left_stick_y_value.Invoke(new left_stick_y_delegate(display_left_stick_y), shared_left_stick_y);

                shared_right_trig = state.Triggers.Right;
                shared_right_trig = process_raw_throttle_data(shared_right_trig);
                right_trig_value.Invoke(new right_trig_delegate(display_right_trig), shared_right_trig);
                shared_right_stick_x = state.ThumbSticks.Right.X;
                right_stick_x_value.Invoke(new right_stick_x_delegate(display_right_stick_x), shared_right_stick_x);
                shared_right_stick_y = state.ThumbSticks.Right.Y;
                right_stick_y_value.Invoke(new right_stick_y_delegate(display_right_stick_y), shared_right_stick_y);
                
                //Update digital button values
                //The xinputdotnetpure wrapper returns the text "Pressed" or "Released" for button state
                //The following if statements read this status for the various buttons, and update the shared status variables
                
                if (state.Buttons.LeftShoulder.ToString().Equals("Pressed"))
                {
                    shared_left_shoulder = 1;
                }
                else if (state.Buttons.LeftShoulder.ToString().Equals("Released"))
                {
                    shared_left_shoulder = 0;
                }
                if (state.Buttons.RightShoulder.ToString().Equals("Pressed"))
                {
                    shared_right_shoulder = 1;
                }
                else if (state.Buttons.RightShoulder.ToString().Equals("Released"))
                {
                    shared_right_shoulder = 0;
                }

                if (state.DPad.Up.ToString().Equals("Pressed"))
                {
                    shared_dpad_up = 1;
                }
                else if (state.DPad.Up.ToString().Equals("Released"))
                {
                    shared_dpad_up = 0;
                }

                if (state.DPad.Down.ToString().Equals("Pressed"))
                {
                     shared_dpad_down = 1;
                }
                else if (state.DPad.Down.ToString().Equals("Released"))
                {
                    shared_dpad_down = 0;
                }

                if (state.DPad.Left.ToString().Equals("Pressed"))
                {
                    shared_dpad_left = 1;
                }
                else if (state.DPad.Left.ToString().Equals("Released"))
                {
                    shared_dpad_left = 0;
                }

                if (state.DPad.Right.ToString().Equals("Pressed"))
                {
                    shared_dpad_right = 1;
                }
                else if (state.DPad.Right.ToString().Equals("Released"))
                {
                    shared_dpad_right = 0;
                }

                if (state.Buttons.A.ToString().Equals("Pressed"))
                {
                    shared_A = 1;
                    //GamePad.SetVibration(PlayerIndex.One, 0.5f,0.0f);     //test code - left motor vibrates when A is pressed
                }   
                else if (state.Buttons.A.ToString().Equals("Released"))
                {
                    shared_A = 0;
                    //GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);    //test code - vibration is off when A is released
                }
                if (state.Buttons.B.ToString().Equals("Pressed"))
                {
                    shared_B = 1;
                }
                else if (state.Buttons.B.ToString().Equals("Released"))
                {
                    shared_B = 0;
                }
                if (state.Buttons.X.ToString().Equals("Pressed"))
                {
                    shared_X = 1;
                    //simple check to stop function toggling on/off when button is held too long
                    if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                    {
                        shared_B = 1;
                        if (slowmode == 0)
                        {
                            slowmode = 1;
                        }
                        else
                        {
                            slowmode = 0;
                        }
                    }
                    oldsamplecount1 = samplecount;
                }
                else if (state.Buttons.X.ToString().Equals("Released"))
                {
                    shared_X = 0;
                }
                if (state.Buttons.Y.ToString().Equals("Pressed"))
                {
                    //simple check to stop function toggling on/off when button is held too long
                    if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                    {
                        shared_Y = 1;
                        if (headlights == 0)
                        {
                            headlights = 1;
                        }
                        else
                        {
                            headlights = 0;
                        }
                    }
                    oldsamplecount1 = samplecount;
                }
                else if (state.Buttons.Y.ToString().Equals("Released"))
                {
                    shared_Y = 0;
                }

                //The following 'invokes' update the GUI with the various button statuses
                left_shoulder_status.Invoke(new left_shoulder_delegate(display_left_shoulder), shared_left_shoulder);
                right_shoulder_status.Invoke(new right_shoulder_delegate(display_right_shoulder), shared_right_shoulder);
                dpad_up_status.Invoke(new dpad_up_delegate(display_dpad_up), shared_dpad_up);
                dpad_down_status.Invoke(new dpad_down_delegate(display_dpad_down), shared_dpad_down);
                dpad_left_status.Invoke(new dpad_left_delegate(display_dpad_left), shared_dpad_left);
                dpad_right_status.Invoke(new dpad_right_delegate(display_dpad_right), shared_dpad_right);
                A_button_status.Invoke(new button_A_delegate(display_button_A), shared_A);
                B_button_status.Invoke(new button_B_delegate(display_button_B), shared_B);
                X_button_status.Invoke(new button_X_delegate(display_button_X), shared_X);
                Y_button_status.Invoke(new button_Y_delegate(display_button_Y), shared_Y);

                //Update other GUI statuses
                slowmode_status.Invoke(new slowmode_delegate(display_slowmode), slowmode);
                //headlights_status.Invoke(new headlights_delegate(display_headlights), headlights);
                brightness_status.Invoke(new brightness_delegate(display_brightness), light_brightness);
                sequence_status.Invoke(new sequence_delegate(display_sequence), light_sequence);
                rumble_status_textbox.Invoke(new rumble_delegate(display_rumble), rumblecount);


                //Put a limit on how frequently this updates
                Thread.Sleep(20);

                //Frame counter for managing repeated on/off toggling of car functions
                //For example, this counter is used for the headlight on/off toggle, to stop it
                //turning on/off continuously when the button is held down.
                samplecount++;
                //manually reset counter if it gets large
                if (samplecount > 2000000000)
                {
                    samplecount = 0;
                }

                //Countdown rumblecount
                //Rumblecount is required so that rumble occurs for a minimum number of controller frames
                if (rumblecount > 0)
                {
                    GamePad.SetVibration(PlayerIndex.One, 0.8f, 0.5f);
                    rumblecount--;
                }
                else if (rumblecount == 0)
                {
                    GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
                }

            }
        }

        //Functions for processing raw analog control data
        private float process_raw_steer_data(float raw_data)
        {
            float modified_data = 0;
            if (steering_mode == 0)
            {
                modified_data = raw_data;
            }
            else if (steering_mode == 1)
            {
                modified_data = raw_data * raw_data;
                if (raw_data < 0)
                {
                    modified_data = -modified_data;
                }
            }
            else if (steering_mode == 2)
            {
                modified_data = raw_data * raw_data * raw_data;
            }
            return modified_data;
        }

        private float process_raw_throttle_data(float raw_data)
        {
            float modified_data = 0;
            if (throttle_mode == 0)
            {
                modified_data = raw_data;
            }
            else if (throttle_mode == 1)
            {
                modified_data = raw_data * raw_data;
                if (raw_data < 0)
                {
                    modified_data = -modified_data;
                }
            }
            else if (throttle_mode == 2)
            {
                modified_data = raw_data * raw_data * raw_data;
            }
            return modified_data;
        }

        //Functions for use with the delegates
        private void display_left_trig(float i)
        {
            //left_trig_value.Text = String.Format("{0:0.000}", i);
            left_trig_value.Text = Convert.ToString(i);
            if (i == 0)
            {
                left_trig_value.BackColor = Color.LightBlue;
            }
            else
            {
                left_trig_value.BackColor = Color.Orange;
            }
        }
        private void display_right_trig(float i)
        {
            right_trig_value.Text = Convert.ToString(i);
            if (i == 0)
            {
                right_trig_value.BackColor = Color.LightBlue;
            }
            else
            {
                right_trig_value.BackColor = Color.Orange;
            }
        }

        private void display_left_stick_x(float i)
        {
            left_stick_x_value.Text = Convert.ToString(i);
            if (i == 0)
            {
                left_stick_x_value.BackColor = Color.LightBlue;
            }
            else
            {
                left_stick_x_value.BackColor = Color.Orange;
            }
        }
        private void display_left_stick_y(float i)
        {
            left_stick_y_value.Text = Convert.ToString(i);
            if (i == 0)
            {
                left_stick_y_value.BackColor = Color.LightBlue;
            }
            else
            {
                left_stick_y_value.BackColor = Color.Orange;
            }
        }


        private void display_right_stick_x(float i)
        {
            right_stick_x_value.Text = Convert.ToString(i);
            if (i == 0)
            {
                right_stick_x_value.BackColor = Color.LightBlue;
            }
            else
            {
                right_stick_x_value.BackColor = Color.Orange;
            }
        }
        private void display_right_stick_y(float i)
        {
            right_stick_y_value.Text = Convert.ToString(i);
            if (i == 0)
            {
                right_stick_y_value.BackColor = Color.LightBlue;
            }
            else
            {
                right_stick_y_value.BackColor = Color.Orange;
            }
        }

        private void display_left_shoulder(int status)
        {
            if (status == 1)
            {
                left_shoulder_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                left_shoulder_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }
        private void display_right_shoulder(int status)
        {
            if (status == 1)
            {
                right_shoulder_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                right_shoulder_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        private void display_dpad_up(int status)
        {
            if (status == 1)
            {
                dpad_up_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                dpad_up_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }
        private void display_dpad_down(int status)
        {
            if (status == 1)
            {
                dpad_down_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                dpad_down_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }
        private void display_dpad_left(int status)
        {
            if (status == 1)
            {
                dpad_left_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                dpad_left_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }
        private void display_dpad_right(int status)
        {
            if (status == 1)
            {
                dpad_right_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                dpad_right_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        private void display_button_A(int status)
        {
            if (status == 1)
            {
                A_button_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                A_button_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }
        private void display_button_B(int status)
        {
            if (status == 1)
            {
                B_button_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                B_button_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }
        private void display_button_X(int status)
        {
            if (status == 1)
            {
                X_button_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                X_button_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }
        private void display_button_Y(int status)
        {
            if (status == 1)
            {
                Y_button_status.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                Y_button_status.BackColor = System.Drawing.Color.LightBlue;
            }
        }

        private void display_slowmode(int status)
        {
            if (status == 1)
            {
                slowmode_status.BackColor = System.Drawing.Color.Orange;
                slowmode_status.Text = "ON";
            }
            else
            {
                slowmode_status.BackColor = System.Drawing.SystemColors.Window;
                slowmode_status.Text = "OFF";
            }
        }

        //private void display_headlights(int status)
        //{
        //    if (status == 1)
        //    {
        //        headlights_status.BackColor = System.Drawing.Color.Orange;
        //        headlights_status.Text = "ON";
        //    }
        //    else
        //    {
        //        headlights_status.BackColor = System.Drawing.SystemColors.Window;
        //        headlights_status.Text = "OFF";
        //    }
        //}

        private void display_brightness(int level)
        {
            brightness_status.Text = level.ToString();
        }
        private void display_sequence(int preset)
        {
            sequence_status.Text = preset.ToString();
        }
        private void display_rumble(int rumblecounter)
        {
            if (rumblecounter > 0)
            {
                rumble_status_textbox.BackColor = System.Drawing.Color.Orange;
                rumble_status_textbox.Text = "RUMBLE";
            }
            else
            {
                rumble_status_textbox.BackColor = System.Drawing.SystemColors.Window;
                rumble_status_textbox.Text = "";
            }
        }

        //End of Xbox 360 controller section
        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for serial operations
        //---------------------------------------------------------------------------------------------------------

        private delegate void output_delegate(string output);
        private delegate void input_delegate(string input);

        //Functions for updating the serial output/input boxes on the GUI

        //private void display_output(string output)
        //{
        //    serial_inputT_textbox.Text = output;
        //}

        private void display_output(string output)
        {
            serial_status_textbox.Text = output;
        }
        private void display_input_T(string temperatura)
        {
            serial_inputT_textbox.Text = temperatura;
        }
        private void display_input_G(string gas)
        {
            serial_inputG_textbox.Text = gas;
        }
        
        private void UpdateSerial()
        {
            //serial operations
            //polling function
            while (true)
            {
                //If serial is connected
                if (portaSerial.IsOpen == true)
                {
                    //save the input from the Microcontroller
                    string received = portaSerial.ReadLine();
                    //Basic error checking - input to the PC should contain the start/end characters "A" and "Z"
                    //If it meets this requirement, send out instructions to Microcontroller via serial
                    if (received.Contains("A") && received.Contains("Z"))
                    {
                        if (received.Contains("R"))
                        {
                            rumblecount = 3;
                            //this counter is used to make the controller rumble for the specified number of frames
                        }

                        string[] serial_array = received.Split(',');

                        serial_inputG_textbox.Invoke(new input_delegate(display_input_G), serial_array[1]);
                        serial_inputT_textbox.Invoke(new input_delegate(display_input_T), serial_array[2]);
                        calculateMotorL();
                        calculateMotorR();
                        calculate_ARM();
                        calculate_cam_pan();
                        calculate_cam_tilt();
                        //dataout = throttle + "," + steer + "," + slowmode_string + "," + headlights_string + ",Y";
                        dataout = motorL + "," + motorR + "," + braco_string + "," + braco_valor + "," + cam_tilt + "," + cam_pan + ",Y";
                        portaSerial.DiscardOutBuffer();
                        portaSerial.WriteLine(dataout);
                        serial_inputT_textbox.Invoke(new output_delegate(display_output), dataout);
                        received = "\n";
                    }
                    //Set poll frequency to 100Hz
                    Thread.Sleep(10);
                }
                else
                {
                    //serial_inputT_textbox.Invoke(new output_delegate(display_output), "Sem conexão");
                }
                if (portaSerial.IsOpen == false)
                {
                    Thread.Sleep(20);
                }
            }
        }

        //private void calculatethrottle()
        //{
        //    //calculate throttle value, centred around a neutral value of 500
        //    //400 is full reverse, 600 is full forwards
        //    if (shared_right_trig >= shared_left_trig)
        //    {
        //        shared_throttle = (shared_right_trig * 100) + 500;
        //    }
        //    else
        //    {
        //        shared_throttle = -(shared_left_trig * 100) + 500;
        //    }
        //    throttle = String.Format("{0:000}", shared_throttle);
        //}

        private void calculateMotorL()
        {
            if (slowmode == 0)
            {
                if (shared_left_trig > 0 && shared_left_shoulder == 0)
                {
                    motorL = "6";
                }
                if (shared_left_shoulder == 1 && shared_left_trig == 0)
                {
                    motorL = "4";
                }
            }
            if (slowmode == 1)
            {
                if (shared_left_trig > 0 && shared_left_shoulder == 0)
                {
                    motorL = "7";
                }
                if (shared_left_shoulder == 1 && shared_left_trig == 0)
                {
                    motorL = "3";
                }
            }
            if (shared_left_shoulder == 0 && shared_left_trig == 0)
            {
                motorL = "5";
            }

            motorL = String.Format("{0:0}", motorL);
        }

        private void calculateMotorR()
        {
            if (slowmode == 0)
            {
                if (shared_right_trig > 0 && shared_right_shoulder == 0)
                {
                    motorR = "6";
                }
                if (shared_right_shoulder == 1 && shared_right_trig == 0)
                {
                    motorR = "4";
                }
            }
            if (slowmode == 1)
            {
                if (shared_right_trig > 0 && shared_right_shoulder == 0)
                {
                    motorR = "7";
                }
                if (shared_right_shoulder == 1 && shared_right_trig == 0)
                {
                    motorR = "3";
                }
            }

            if (shared_right_shoulder == 0 && shared_right_trig == 0)
            {
                motorR = "5";
            }

            motorR = String.Format("{0:0}", motorR);
        }

        private void calculate_ARM()
        {
            //calculate camera pan value, centred around a neutral value of 200
            //100 is full left, 300 is full right

            if(shared_left_stick_x == 0 && shared_left_stick_y != 0 && shared_right_stick_x == 0 && shared_right_stick_y == 0)
            {
                braco_string = "B";

                if (shared_left_stick_y < 0 && shared_bracoB_valor > 70)
                {
                    shared_bracoB_valor = shared_bracoB_valor - 10;
                    braco_valor = String.Format("{0:000}", shared_bracoB_valor);
                }

                if (shared_left_stick_y > 0 && shared_bracoB_valor < 180)
                {
                    shared_bracoB_valor = shared_bracoB_valor + 10;
                    braco_valor = String.Format("{0:000}", shared_bracoB_valor);
                }

                //shared_bracoB_valor = (shared_left_stick_x * 100);
                //braco_valor = String.Format("{0:000}", shared_bracoB_valor);
            }

            if (shared_left_stick_x != 0 && shared_left_stick_y == 0 && shared_right_stick_x == 0 && shared_right_stick_y == 0)
            { 
                braco_string = "C";

                if (shared_left_stick_x < 0 && shared_bracoC_valor > 80)
                {
                    shared_bracoC_valor = shared_bracoC_valor - 1;
                    braco_valor = String.Format("{0:000}", shared_bracoC_valor);
                }

                if (shared_left_stick_x > 0 && shared_bracoC_valor < 110)
                {
                    shared_bracoC_valor = shared_bracoC_valor + 1;
                    braco_valor = String.Format("{0:000}", shared_bracoC_valor);
                }
            }

            if (shared_left_stick_x == 0 && shared_left_stick_y == 0 && shared_right_stick_x != 0 && shared_right_stick_y == 0)
            {
                braco_string = "H";

                if (shared_right_stick_x < 0 && shared_bracoH_valor > 80)
                {
                    shared_bracoH_valor = shared_bracoH_valor - 10;
                    braco_valor = String.Format("{0:000}", shared_bracoH_valor);
                }

                if (shared_right_stick_x > 0 && shared_bracoH_valor < 150)
                {
                    shared_bracoH_valor = shared_bracoH_valor + 10;
                    braco_valor = String.Format("{0:000}", shared_bracoH_valor);
                }
            }

            if (shared_left_stick_x == 0 && shared_left_stick_y == 0 && shared_right_stick_x == 0 && shared_right_stick_y != 0)
            {
                braco_string = "V";

                if (shared_right_stick_y < 0 && shared_bracoV_valor > 0)
                {
                    shared_bracoV_valor = shared_bracoV_valor - 10;
                    braco_valor = String.Format("{0:000}", shared_bracoV_valor);
                }

                if (shared_right_stick_y > 0 && shared_bracoV_valor < 100)
                {
                    shared_bracoV_valor = shared_bracoV_valor + 10;
                    braco_valor = String.Format("{0:000}", shared_bracoV_valor);
                }

            }

            if (shared_left_stick_x == 0 && shared_left_stick_y == 0 && shared_right_stick_x == 0 && shared_right_stick_y == 0)
            {
                braco_string = "G";
                if (shared_A == 1 && shared_B == 0 && shared_bracoG_valor < 140)
                {
                    shared_bracoG_valor = shared_bracoG_valor + 10;
                }

                if (shared_B == 1 && shared_A == 0 && shared_bracoG_valor > 70)
                {
                    shared_bracoG_valor = shared_bracoG_valor - 10;
                }

                braco_valor = String.Format("{0:000}", shared_bracoG_valor);
            }
        }

        private void calculate_cam_pan()
        {
            //calculate camera pan value, centred around a neutral value of 200
            //100 is full left, 300 is full right
            if (shared_dpad_right == 1 && shared_dpad_left == 0 && shared_cam_pan > 0)
            {
                shared_cam_pan = shared_cam_pan - 10;
            }

            if (shared_dpad_left == 1 && shared_dpad_right == 0 && shared_cam_pan < 140)
            {
                shared_cam_pan = shared_cam_pan + 10;
            }

            cam_pan = String.Format("{0:000}", shared_cam_pan);
        }

        private void calculate_cam_tilt()
        {
            //calculate camera tilt value, centred around a neutral value of 200
            //100 is full down, 300 is full up
            if (shared_dpad_up == 1 && shared_dpad_down == 0 && shared_cam_tilt < 140)
            {
                shared_cam_tilt = shared_cam_tilt + 10;
            }

            if (shared_dpad_down == 1 && shared_dpad_up == 0 && shared_cam_tilt > 50)
            {
                shared_cam_tilt = shared_cam_tilt - 10;
            }

            cam_tilt = String.Format("{0:000}", shared_cam_tilt);
        }

        private void InitialiseSerial()
        {
            //open serial port, if not already opened
            if (portaSerial.IsOpen == false)
            {
                //portaSerial.PortName = "COM8";
                //Default portname is set by the textbox "comport_textbox"
                portaSerial.PortName = comport_textbox.Text;
                portaSerial.BaudRate = 57600;
                portaSerial.DataBits = 8;
                portaSerial.StopBits = StopBits.One;
                portaSerial.Parity = Parity.None;
                portaSerial.Open();
            }
        }

        private void CloseSerial()
        {
            //close connection to serial port
            //This often crashes the program - disabling serial after it has started is not recommended
            portaSerial.Close();
        }

        private void connect_serial_button_Click(object sender, EventArgs e)
        {
            //Button click event toggles serial connection
            if (portaSerial.IsOpen == false)
            {
                InitialiseSerial();
                //serial_status_textbox.Text = "Conectado";
                serial_status_textbox.Text = dataout;
            }
            else
            {
                CloseSerial();
                serial_status_textbox.Text = "Desconectado";
                //This often crashes the program - see above
            }
        }
        //End of serial section

        
        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for the Raspberry Pi camera
        //---------------------------------------------------------------------------------------------------------
    
        private void camera_video_button_Click(object sender, EventArgs e)
        {
            Thread get_video_stream = new Thread(new ThreadStart(receive_video_stream));
            get_video_stream.IsBackground = true;
            get_video_stream.Start();
        }  
  

        private void stop_video_button_Click(object sender, EventArgs e)
        {
            videorun = 0;
            camera_image.Image = Image.FromFile("default_camera.png");
        }        

        //Common variables
        int videorun = 1;
        int upcommand = 0;
        int downcommand = 2;
        int leftcommand = 6;
        int rightcommand = 4;
        int horiz_offset = 0;
        int vert_offset = 0;

        //Delegates for use for cross thread operations
        private delegate void image_delegate(Bitmap image);
        private delegate void debug_text_delegate(string debug_data);
        private delegate void vert_offset_delegate(string vert);
        private delegate void horiz_offset_delegate(string horiz);

        //Functions for use with delegates
        private void display_image(Bitmap image)
        {
            camera_image.Image = image;
        }
        private void display_debug(string debug_data)
        {
            debug_textbox.Text = debug_data;
        }
        private void display_vert(string vert)
        {
            vert_offset_value.Text = vert;
        }
        private void display_horiz(string horiz)
        {
            horiz_offset_value.Text = horiz;
        }


        //MJPEG Video
        //This function is for displaying a live MJPEG video stream from the Raspberry Pi camera (using UV4L driver)
        //It works by connecting to the RPi http server and processing the received continuous stream
        //The function picks out the individual JPEG frames by searching for the JPEG header and JPEG footer
        //When a JPEG header is found, it starts saving the data into a byte array called imagebuffer. It keeps
        //saving until the JPEG footer is detected. Once this happens, the JPEG image is created from the byte
        //array, and displayed. The imagebuffer byte array is cleared, and the process starts again.


        private void receive_video_stream()
        {
            string video_URL = "http://" + ip_address_textbox.Text + ":8080/RPi_CAm/cam_pic_new.php?";
            // string video_URL = "http://" + ip_address_textbox.Text + ":8080/stream/video.mjpeg";
            // string video_URL = "http://" + ip_address_textbox.Text + ":8080/RPi_CAm/cam_pic_new.php?";
            // create HTTP request
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(video_URL);
            // get response

            req.Proxy = null;

            WebResponse resp = req.GetResponse();

            Stream imagestream = resp.GetResponseStream();

            const int BufferSize = 5000000;
            byte[] imagebuffer = new byte[BufferSize];
            int a = 2;
            int framecounter = 0;
            int framecounter2 = 0;
            int startreading = 0;
            byte[] start_checker = new byte[2];
            byte[] end_checker = new byte[2];

            //reset videorun flag
            videorun = 1;

            while (videorun == 1)
            {
                start_checker[1] = (byte)imagestream.ReadByte();
                end_checker[1] = start_checker[1];

                //This if statement searches for the JPEG header, and performs the relevant operations
                if (start_checker[0] == 0xff && start_checker[1] == 0xd8)// && Reset ==0)
                {
                    Array.Clear(imagebuffer, 0, imagebuffer.Length);
                    //Rebuild jpeg header into imagebuffer
                    imagebuffer[0] = 0xff;
                    imagebuffer[1] = 0xd8;
                    a = 2;
                    framecounter++;
                    startreading = 1;
                }

                //This if statement searches for the JPEG footer, and performs the relevant operations
                if (end_checker[0] == 0xff && end_checker[1] == 0xd9)
                {
                    framecounter2++;
                    startreading = 0;
                    //Write final part of JPEG header into imagebuffer
                    imagebuffer[a] = start_checker[1];
                    MemoryStream jpegstream = new MemoryStream(imagebuffer);
                    Bitmap bmp = (Bitmap)Bitmap.FromStream(jpegstream);
                    camera_image.Invoke(new image_delegate(display_image), bmp);
                    debug_textbox.Invoke(new debug_text_delegate(display_debug), framecounter.ToString() + ", " + framecounter2.ToString());
                    //camera_viewer.
                }

                //This if statement fills the imagebuffer, if the relevant flags are set
                if (startreading == 1 && a < BufferSize)
                {
                    imagebuffer[a] = start_checker[1];
                    a++;
                }

                //Catches error condition where a = buffer size - this should not happen in normal operation
                if (a == BufferSize)
                {
                    a = 2;
                    startreading = 0;
                }

                start_checker[0] = start_checker[1];
                end_checker[0] = end_checker[1];

            }
            
            resp.Close();
        }
    }
}
