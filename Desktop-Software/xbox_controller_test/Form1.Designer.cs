namespace Supervisorio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.controller_check = new System.Windows.Forms.Button();
            this.left_trig_label = new System.Windows.Forms.Label();
            this.left_trig_value = new System.Windows.Forms.TextBox();
            this.right_trig_label = new System.Windows.Forms.Label();
            this.right_trig_value = new System.Windows.Forms.TextBox();
            this.left_stick_x_value = new System.Windows.Forms.TextBox();
            this.left_stick_x_label = new System.Windows.Forms.Label();
            this.left_stick_y_label = new System.Windows.Forms.Label();
            this.left_stick_y_value = new System.Windows.Forms.TextBox();
            this.right_stick_x_value = new System.Windows.Forms.TextBox();
            this.right_stick_y_value = new System.Windows.Forms.TextBox();
            this.right_stick_x_label = new System.Windows.Forms.Label();
            this.right_stick_y_label = new System.Windows.Forms.Label();
            this.variable_check = new System.Windows.Forms.TextBox();
            this.serial_output_label = new System.Windows.Forms.Label();
            this.serial_input_label = new System.Windows.Forms.Label();
            this.serial_inputT_textbox = new System.Windows.Forms.TextBox();
            this.serial_inputG_textbox = new System.Windows.Forms.TextBox();
            this.connect_serial_button = new System.Windows.Forms.Button();
            this.serial_status_textbox = new System.Windows.Forms.TextBox();
            this.camera_image = new System.Windows.Forms.PictureBox();
            this.camera_video_button = new System.Windows.Forms.Button();
            this.stop_video_button = new System.Windows.Forms.Button();
            this.camera_ip_label = new System.Windows.Forms.Label();
            this.ip_address_textbox = new System.Windows.Forms.TextBox();
            this.debug_label = new System.Windows.Forms.Label();
            this.debug_textbox = new System.Windows.Forms.TextBox();
            this.vert_offset_label = new System.Windows.Forms.Label();
            this.horiz_offset_label = new System.Windows.Forms.Label();
            this.vert_offset_value = new System.Windows.Forms.TextBox();
            this.horiz_offset_value = new System.Windows.Forms.TextBox();
            this.left_shoulder_label = new System.Windows.Forms.Label();
            this.left_shoulder_status = new System.Windows.Forms.TextBox();
            this.dpad_label = new System.Windows.Forms.Label();
            this.dpad_up_status = new System.Windows.Forms.TextBox();
            this.dpad_left_status = new System.Windows.Forms.TextBox();
            this.dpad_right_status = new System.Windows.Forms.TextBox();
            this.dpad_down_status = new System.Windows.Forms.TextBox();
            this.right_shoulder_label = new System.Windows.Forms.Label();
            this.right_shoulder_status = new System.Windows.Forms.TextBox();
            this.digital_buttons_label = new System.Windows.Forms.Label();
            this.Y_button_status = new System.Windows.Forms.TextBox();
            this.A_button_status = new System.Windows.Forms.TextBox();
            this.X_button_status = new System.Windows.Forms.TextBox();
            this.B_button_status = new System.Windows.Forms.TextBox();
            this.xbox_debug_label = new System.Windows.Forms.Label();
            this.COMPort_label = new System.Windows.Forms.Label();
            this.comport_textbox = new System.Windows.Forms.TextBox();
            this.serial_status_label = new System.Windows.Forms.Label();
            this.steering_combobox = new System.Windows.Forms.ComboBox();
            this.throttle_combobox = new System.Windows.Forms.ComboBox();
            this.steering_processing_label = new System.Windows.Forms.Label();
            this.throttle_processing_label = new System.Windows.Forms.Label();
            this.camera_position_label = new System.Windows.Forms.Label();
            this.camera_position_combobox = new System.Windows.Forms.ComboBox();
            this.xbox_360c_groupBox = new System.Windows.Forms.GroupBox();
            this.rumble_label = new System.Windows.Forms.Label();
            this.rumble_status_textbox = new System.Windows.Forms.TextBox();
            this.sequence_status = new System.Windows.Forms.TextBox();
            this.sequence_label = new System.Windows.Forms.Label();
            this.brightness_status = new System.Windows.Forms.TextBox();
            this.brightness_label = new System.Windows.Forms.Label();
            this.headlights_status = new System.Windows.Forms.TextBox();
            this.headlights_label = new System.Windows.Forms.Label();
            this.slowmode_status = new System.Windows.Forms.TextBox();
            this.slowmode_label = new System.Windows.Forms.Label();
            this.micro_groupBox = new System.Windows.Forms.GroupBox();
            this.camera_groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.camera_image)).BeginInit();
            this.xbox_360c_groupBox.SuspendLayout();
            this.micro_groupBox.SuspendLayout();
            this.camera_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // controller_check
            // 
            this.controller_check.Location = new System.Drawing.Point(21, 37);
            this.controller_check.Name = "controller_check";
            this.controller_check.Size = new System.Drawing.Size(144, 23);
            this.controller_check.TabIndex = 1;
            this.controller_check.Text = "Verificar Conexão Controle";
            this.controller_check.UseVisualStyleBackColor = true;
            this.controller_check.Click += new System.EventHandler(this.button1_Click);
            // 
            // left_trig_label
            // 
            this.left_trig_label.AutoSize = true;
            this.left_trig_label.Location = new System.Drawing.Point(126, 69);
            this.left_trig_label.Name = "left_trig_label";
            this.left_trig_label.Size = new System.Drawing.Size(86, 13);
            this.left_trig_label.TabIndex = 2;
            this.left_trig_label.Text = "Motor Esq F (LT)";
            // 
            // left_trig_value
            // 
            this.left_trig_value.BackColor = System.Drawing.Color.LightBlue;
            this.left_trig_value.Location = new System.Drawing.Point(20, 66);
            this.left_trig_value.Name = "left_trig_value";
            this.left_trig_value.Size = new System.Drawing.Size(100, 20);
            this.left_trig_value.TabIndex = 3;
            // 
            // right_trig_label
            // 
            this.right_trig_label.AutoSize = true;
            this.right_trig_label.Location = new System.Drawing.Point(234, 69);
            this.right_trig_label.Name = "right_trig_label";
            this.right_trig_label.Size = new System.Drawing.Size(83, 13);
            this.right_trig_label.TabIndex = 4;
            this.right_trig_label.Text = "Motor Dir F (RT)";
            // 
            // right_trig_value
            // 
            this.right_trig_value.BackColor = System.Drawing.Color.LightBlue;
            this.right_trig_value.Location = new System.Drawing.Point(323, 66);
            this.right_trig_value.Name = "right_trig_value";
            this.right_trig_value.Size = new System.Drawing.Size(100, 20);
            this.right_trig_value.TabIndex = 5;
            // 
            // left_stick_x_value
            // 
            this.left_stick_x_value.BackColor = System.Drawing.Color.LightBlue;
            this.left_stick_x_value.Location = new System.Drawing.Point(21, 140);
            this.left_stick_x_value.Name = "left_stick_x_value";
            this.left_stick_x_value.Size = new System.Drawing.Size(100, 20);
            this.left_stick_x_value.TabIndex = 6;
            // 
            // left_stick_x_label
            // 
            this.left_stick_x_label.AutoSize = true;
            this.left_stick_x_label.Location = new System.Drawing.Point(20, 124);
            this.left_stick_x_label.Name = "left_stick_x_label";
            this.left_stick_x_label.Size = new System.Drawing.Size(96, 13);
            this.left_stick_x_label.TabIndex = 7;
            this.left_stick_x_label.Text = "Servo Cot. (An.L x)";
            // 
            // left_stick_y_label
            // 
            this.left_stick_y_label.AutoSize = true;
            this.left_stick_y_label.Location = new System.Drawing.Point(23, 164);
            this.left_stick_y_label.Name = "left_stick_y_label";
            this.left_stick_y_label.Size = new System.Drawing.Size(101, 13);
            this.left_stick_y_label.TabIndex = 8;
            this.left_stick_y_label.Text = "Servo Base (An.L y)";
            // 
            // left_stick_y_value
            // 
            this.left_stick_y_value.BackColor = System.Drawing.Color.LightBlue;
            this.left_stick_y_value.Location = new System.Drawing.Point(20, 180);
            this.left_stick_y_value.Name = "left_stick_y_value";
            this.left_stick_y_value.Size = new System.Drawing.Size(100, 20);
            this.left_stick_y_value.TabIndex = 9;
            // 
            // right_stick_x_value
            // 
            this.right_stick_x_value.BackColor = System.Drawing.Color.LightBlue;
            this.right_stick_x_value.Location = new System.Drawing.Point(323, 140);
            this.right_stick_x_value.Name = "right_stick_x_value";
            this.right_stick_x_value.Size = new System.Drawing.Size(100, 20);
            this.right_stick_x_value.TabIndex = 10;
            // 
            // right_stick_y_value
            // 
            this.right_stick_y_value.BackColor = System.Drawing.Color.LightBlue;
            this.right_stick_y_value.Location = new System.Drawing.Point(323, 180);
            this.right_stick_y_value.Name = "right_stick_y_value";
            this.right_stick_y_value.Size = new System.Drawing.Size(100, 20);
            this.right_stick_y_value.TabIndex = 11;
            // 
            // right_stick_x_label
            // 
            this.right_stick_x_label.AutoSize = true;
            this.right_stick_x_label.Location = new System.Drawing.Point(327, 124);
            this.right_stick_x_label.Name = "right_stick_x_label";
            this.right_stick_x_label.Size = new System.Drawing.Size(96, 13);
            this.right_stick_x_label.TabIndex = 12;
            this.right_stick_x_label.Text = "Mão Horiz.(An.R x)";
            // 
            // right_stick_y_label
            // 
            this.right_stick_y_label.AutoSize = true;
            this.right_stick_y_label.Location = new System.Drawing.Point(327, 164);
            this.right_stick_y_label.Name = "right_stick_y_label";
            this.right_stick_y_label.Size = new System.Drawing.Size(91, 13);
            this.right_stick_y_label.TabIndex = 13;
            this.right_stick_y_label.Text = "Mão Vert.(An.R y)";
            // 
            // variable_check
            // 
            this.variable_check.Location = new System.Drawing.Point(380, 40);
            this.variable_check.Name = "variable_check";
            this.variable_check.Size = new System.Drawing.Size(55, 20);
            this.variable_check.TabIndex = 14;
            // 
            // serial_output_label
            // 
            this.serial_output_label.AutoSize = true;
            this.serial_output_label.Location = new System.Drawing.Point(62, 93);
            this.serial_output_label.Name = "serial_output_label";
            this.serial_output_label.Size = new System.Drawing.Size(87, 13);
            this.serial_output_label.TabIndex = 15;
            this.serial_output_label.Text = "Temperatura (°C)";
            // 
            // serial_input_label
            // 
            this.serial_input_label.AutoSize = true;
            this.serial_input_label.Location = new System.Drawing.Point(72, 576);
            this.serial_input_label.Name = "serial_input_label";
            this.serial_input_label.Size = new System.Drawing.Size(125, 13);
            this.serial_input_label.TabIndex = 16;
            this.serial_input_label.Text = "Concentração Gás (ppm)";
            // 
            // serial_inputT_textbox
            // 
            this.serial_inputT_textbox.Location = new System.Drawing.Point(166, 541);
            this.serial_inputT_textbox.Name = "serial_inputT_textbox";
            this.serial_inputT_textbox.Size = new System.Drawing.Size(236, 20);
            this.serial_inputT_textbox.TabIndex = 17;
            // 
            // serial_inputG_textbox
            // 
            this.serial_inputG_textbox.Location = new System.Drawing.Point(203, 573);
            this.serial_inputG_textbox.Name = "serial_inputG_textbox";
            this.serial_inputG_textbox.Size = new System.Drawing.Size(199, 20);
            this.serial_inputG_textbox.TabIndex = 18;
            // 
            // connect_serial_button
            // 
            this.connect_serial_button.Location = new System.Drawing.Point(304, 477);
            this.connect_serial_button.Name = "connect_serial_button";
            this.connect_serial_button.Size = new System.Drawing.Size(98, 49);
            this.connect_serial_button.TabIndex = 19;
            this.connect_serial_button.Text = "Conectar Serial";
            this.connect_serial_button.UseVisualStyleBackColor = true;
            this.connect_serial_button.Click += new System.EventHandler(this.connect_serial_button_Click);
            // 
            // serial_status_textbox
            // 
            this.serial_status_textbox.Location = new System.Drawing.Point(142, 506);
            this.serial_status_textbox.Name = "serial_status_textbox";
            this.serial_status_textbox.Size = new System.Drawing.Size(133, 20);
            this.serial_status_textbox.TabIndex = 20;
            // 
            // camera_image
            // 
            this.camera_image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camera_image.BackColor = System.Drawing.Color.Black;
            this.camera_image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("camera_image.BackgroundImage")));
            this.camera_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.camera_image.InitialImage = ((System.Drawing.Image)(resources.GetObject("camera_image.InitialImage")));
            this.camera_image.Location = new System.Drawing.Point(482, 32);
            this.camera_image.Name = "camera_image";
            this.camera_image.Size = new System.Drawing.Size(640, 480);
            this.camera_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.camera_image.TabIndex = 21;
            this.camera_image.TabStop = false;
            // 
            // camera_video_button
            // 
            this.camera_video_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.camera_video_button.Location = new System.Drawing.Point(26, 543);
            this.camera_video_button.Name = "camera_video_button";
            this.camera_video_button.Size = new System.Drawing.Size(91, 40);
            this.camera_video_button.TabIndex = 23;
            this.camera_video_button.Text = "Conectar Câmera";
            this.camera_video_button.UseVisualStyleBackColor = true;
            this.camera_video_button.Click += new System.EventHandler(this.camera_video_button_Click);
            // 
            // stop_video_button
            // 
            this.stop_video_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stop_video_button.Location = new System.Drawing.Point(156, 543);
            this.stop_video_button.Name = "stop_video_button";
            this.stop_video_button.Size = new System.Drawing.Size(91, 40);
            this.stop_video_button.TabIndex = 24;
            this.stop_video_button.Text = "Desconectar Câmera";
            this.stop_video_button.UseVisualStyleBackColor = true;
            this.stop_video_button.Click += new System.EventHandler(this.stop_video_button_Click);
            // 
            // camera_ip_label
            // 
            this.camera_ip_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.camera_ip_label.AutoSize = true;
            this.camera_ip_label.Location = new System.Drawing.Point(37, 512);
            this.camera_ip_label.Name = "camera_ip_label";
            this.camera_ip_label.Size = new System.Drawing.Size(80, 13);
            this.camera_ip_label.TabIndex = 25;
            this.camera_ip_label.Text = "Raspberry Pi IP";
            // 
            // ip_address_textbox
            // 
            this.ip_address_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ip_address_textbox.Location = new System.Drawing.Point(156, 509);
            this.ip_address_textbox.Name = "ip_address_textbox";
            this.ip_address_textbox.Size = new System.Drawing.Size(126, 20);
            this.ip_address_textbox.TabIndex = 26;
            this.ip_address_textbox.Text = "192.168.2.100";
            // 
            // debug_label
            // 
            this.debug_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.debug_label.AutoSize = true;
            this.debug_label.Location = new System.Drawing.Point(344, 512);
            this.debug_label.Name = "debug_label";
            this.debug_label.Size = new System.Drawing.Size(65, 13);
            this.debug_label.TabIndex = 27;
            this.debug_label.Text = "Debug Data";
            // 
            // debug_textbox
            // 
            this.debug_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.debug_textbox.Location = new System.Drawing.Point(895, 524);
            this.debug_textbox.Name = "debug_textbox";
            this.debug_textbox.Size = new System.Drawing.Size(220, 20);
            this.debug_textbox.TabIndex = 28;
            // 
            // vert_offset_label
            // 
            this.vert_offset_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vert_offset_label.AutoSize = true;
            this.vert_offset_label.Location = new System.Drawing.Point(816, 563);
            this.vert_offset_label.Name = "vert_offset_label";
            this.vert_offset_label.Size = new System.Drawing.Size(73, 13);
            this.vert_offset_label.TabIndex = 29;
            this.vert_offset_label.Text = "Vertical Offset";
            // 
            // horiz_offset_label
            // 
            this.horiz_offset_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.horiz_offset_label.AutoSize = true;
            this.horiz_offset_label.Location = new System.Drawing.Point(967, 563);
            this.horiz_offset_label.Name = "horiz_offset_label";
            this.horiz_offset_label.Size = new System.Drawing.Size(85, 13);
            this.horiz_offset_label.TabIndex = 30;
            this.horiz_offset_label.Text = "Horizontal Offset";
            // 
            // vert_offset_value
            // 
            this.vert_offset_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vert_offset_value.Location = new System.Drawing.Point(895, 560);
            this.vert_offset_value.Name = "vert_offset_value";
            this.vert_offset_value.Size = new System.Drawing.Size(57, 20);
            this.vert_offset_value.TabIndex = 31;
            this.vert_offset_value.Text = "0";
            // 
            // horiz_offset_value
            // 
            this.horiz_offset_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.horiz_offset_value.Location = new System.Drawing.Point(1058, 560);
            this.horiz_offset_value.Name = "horiz_offset_value";
            this.horiz_offset_value.Size = new System.Drawing.Size(57, 20);
            this.horiz_offset_value.TabIndex = 32;
            this.horiz_offset_value.Text = "0";
            // 
            // left_shoulder_label
            // 
            this.left_shoulder_label.AutoSize = true;
            this.left_shoulder_label.Location = new System.Drawing.Point(125, 95);
            this.left_shoulder_label.Name = "left_shoulder_label";
            this.left_shoulder_label.Size = new System.Drawing.Size(87, 13);
            this.left_shoulder_label.TabIndex = 33;
            this.left_shoulder_label.Text = "Motor Esq T (LB)";
            // 
            // left_shoulder_status
            // 
            this.left_shoulder_status.BackColor = System.Drawing.Color.LightBlue;
            this.left_shoulder_status.Location = new System.Drawing.Point(21, 92);
            this.left_shoulder_status.Name = "left_shoulder_status";
            this.left_shoulder_status.Size = new System.Drawing.Size(100, 20);
            this.left_shoulder_status.TabIndex = 34;
            // 
            // dpad_label
            // 
            this.dpad_label.AutoSize = true;
            this.dpad_label.Location = new System.Drawing.Point(22, 244);
            this.dpad_label.Name = "dpad_label";
            this.dpad_label.Size = new System.Drawing.Size(87, 13);
            this.dpad_label.TabIndex = 35;
            this.dpad_label.Text = "Rotação Câmera";
            // 
            // dpad_up_status
            // 
            this.dpad_up_status.BackColor = System.Drawing.Color.LightBlue;
            this.dpad_up_status.Location = new System.Drawing.Point(140, 244);
            this.dpad_up_status.Name = "dpad_up_status";
            this.dpad_up_status.Size = new System.Drawing.Size(55, 20);
            this.dpad_up_status.TabIndex = 36;
            this.dpad_up_status.Text = "Subir";
            this.dpad_up_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dpad_left_status
            // 
            this.dpad_left_status.BackColor = System.Drawing.Color.LightBlue;
            this.dpad_left_status.Location = new System.Drawing.Point(74, 255);
            this.dpad_left_status.Name = "dpad_left_status";
            this.dpad_left_status.Size = new System.Drawing.Size(67, 20);
            this.dpad_left_status.TabIndex = 37;
            this.dpad_left_status.Text = "Esquerda <";
            this.dpad_left_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dpad_right_status
            // 
            this.dpad_right_status.BackColor = System.Drawing.Color.LightBlue;
            this.dpad_right_status.Location = new System.Drawing.Point(169, 255);
            this.dpad_right_status.Name = "dpad_right_status";
            this.dpad_right_status.Size = new System.Drawing.Size(63, 20);
            this.dpad_right_status.TabIndex = 38;
            this.dpad_right_status.Text = "> Direita";
            this.dpad_right_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dpad_down_status
            // 
            this.dpad_down_status.BackColor = System.Drawing.Color.LightBlue;
            this.dpad_down_status.Location = new System.Drawing.Point(130, 282);
            this.dpad_down_status.Name = "dpad_down_status";
            this.dpad_down_status.Size = new System.Drawing.Size(53, 20);
            this.dpad_down_status.TabIndex = 39;
            this.dpad_down_status.Text = "Descer";
            this.dpad_down_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // right_shoulder_label
            // 
            this.right_shoulder_label.AutoSize = true;
            this.right_shoulder_label.Location = new System.Drawing.Point(233, 95);
            this.right_shoulder_label.Name = "right_shoulder_label";
            this.right_shoulder_label.Size = new System.Drawing.Size(84, 13);
            this.right_shoulder_label.TabIndex = 40;
            this.right_shoulder_label.Text = "Motor Dir T (RB)";
            // 
            // right_shoulder_status
            // 
            this.right_shoulder_status.BackColor = System.Drawing.Color.LightBlue;
            this.right_shoulder_status.Location = new System.Drawing.Point(323, 92);
            this.right_shoulder_status.Name = "right_shoulder_status";
            this.right_shoulder_status.Size = new System.Drawing.Size(100, 20);
            this.right_shoulder_status.TabIndex = 41;
            // 
            // digital_buttons_label
            // 
            this.digital_buttons_label.AutoSize = true;
            this.digital_buttons_label.Location = new System.Drawing.Point(246, 244);
            this.digital_buttons_label.Name = "digital_buttons_label";
            this.digital_buttons_label.Size = new System.Drawing.Size(75, 13);
            this.digital_buttons_label.TabIndex = 42;
            this.digital_buttons_label.Text = "Controle Garra";
            // 
            // Y_button_status
            // 
            this.Y_button_status.BackColor = System.Drawing.Color.LightBlue;
            this.Y_button_status.Location = new System.Drawing.Point(344, 229);
            this.Y_button_status.Name = "Y_button_status";
            this.Y_button_status.Size = new System.Drawing.Size(46, 20);
            this.Y_button_status.TabIndex = 43;
            this.Y_button_status.Text = "Y";
            this.Y_button_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // A_button_status
            // 
            this.A_button_status.BackColor = System.Drawing.Color.LightBlue;
            this.A_button_status.Location = new System.Drawing.Point(332, 282);
            this.A_button_status.Name = "A_button_status";
            this.A_button_status.Size = new System.Drawing.Size(67, 20);
            this.A_button_status.TabIndex = 44;
            this.A_button_status.Text = "Fechar (A)";
            this.A_button_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // X_button_status
            // 
            this.X_button_status.BackColor = System.Drawing.Color.LightBlue;
            this.X_button_status.Location = new System.Drawing.Point(307, 255);
            this.X_button_status.Name = "X_button_status";
            this.X_button_status.Size = new System.Drawing.Size(45, 20);
            this.X_button_status.TabIndex = 45;
            this.X_button_status.Text = "X";
            this.X_button_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // B_button_status
            // 
            this.B_button_status.BackColor = System.Drawing.Color.LightBlue;
            this.B_button_status.Location = new System.Drawing.Point(373, 255);
            this.B_button_status.Name = "B_button_status";
            this.B_button_status.Size = new System.Drawing.Size(50, 20);
            this.B_button_status.TabIndex = 46;
            this.B_button_status.Text = "Abrir (B)";
            this.B_button_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xbox_debug_label
            // 
            this.xbox_debug_label.AutoSize = true;
            this.xbox_debug_label.Location = new System.Drawing.Point(332, 43);
            this.xbox_debug_label.Name = "xbox_debug_label";
            this.xbox_debug_label.Size = new System.Drawing.Size(39, 13);
            this.xbox_debug_label.TabIndex = 47;
            this.xbox_debug_label.Text = "Debug";
            // 
            // COMPort_label
            // 
            this.COMPort_label.AutoSize = true;
            this.COMPort_label.Location = new System.Drawing.Point(71, 31);
            this.COMPort_label.Name = "COMPort_label";
            this.COMPort_label.Size = new System.Drawing.Size(59, 13);
            this.COMPort_label.TabIndex = 49;
            this.COMPort_label.Text = "Porta COM";
            // 
            // comport_textbox
            // 
            this.comport_textbox.Location = new System.Drawing.Point(166, 479);
            this.comport_textbox.Name = "comport_textbox";
            this.comport_textbox.Size = new System.Drawing.Size(109, 20);
            this.comport_textbox.TabIndex = 50;
            this.comport_textbox.Text = "COM8";
            // 
            // serial_status_label
            // 
            this.serial_status_label.AutoSize = true;
            this.serial_status_label.Location = new System.Drawing.Point(50, 58);
            this.serial_status_label.Name = "serial_status_label";
            this.serial_status_label.Size = new System.Drawing.Size(66, 13);
            this.serial_status_label.TabIndex = 51;
            this.serial_status_label.Text = "Status Serial";
            // 
            // steering_combobox
            // 
            this.steering_combobox.FormattingEnabled = true;
            this.steering_combobox.Items.AddRange(new object[] {
            "Linear",
            "Squared",
            "Cubed"});
            this.steering_combobox.Location = new System.Drawing.Point(130, 312);
            this.steering_combobox.Name = "steering_combobox";
            this.steering_combobox.Size = new System.Drawing.Size(93, 21);
            this.steering_combobox.TabIndex = 52;
            this.steering_combobox.SelectedIndexChanged += new System.EventHandler(this.steering_combobox_SelectedIndexChanged);
            // 
            // throttle_combobox
            // 
            this.throttle_combobox.FormattingEnabled = true;
            this.throttle_combobox.Items.AddRange(new object[] {
            "Linear",
            "Squared",
            "Cubed"});
            this.throttle_combobox.Location = new System.Drawing.Point(130, 340);
            this.throttle_combobox.Name = "throttle_combobox";
            this.throttle_combobox.Size = new System.Drawing.Size(93, 21);
            this.throttle_combobox.TabIndex = 53;
            this.throttle_combobox.SelectedIndexChanged += new System.EventHandler(this.throttle_combobox_SelectedIndexChanged);
            // 
            // steering_processing_label
            // 
            this.steering_processing_label.AutoSize = true;
            this.steering_processing_label.Location = new System.Drawing.Point(30, 315);
            this.steering_processing_label.Name = "steering_processing_label";
            this.steering_processing_label.Size = new System.Drawing.Size(89, 13);
            this.steering_processing_label.TabIndex = 54;
            this.steering_processing_label.Text = "Modo de Direção";
            // 
            // throttle_processing_label
            // 
            this.throttle_processing_label.AutoSize = true;
            this.throttle_processing_label.Location = new System.Drawing.Point(13, 343);
            this.throttle_processing_label.Name = "throttle_processing_label";
            this.throttle_processing_label.Size = new System.Drawing.Size(106, 13);
            this.throttle_processing_label.TabIndex = 55;
            this.throttle_processing_label.Text = "Modo de Aceleração";
            // 
            // camera_position_label
            // 
            this.camera_position_label.AutoSize = true;
            this.camera_position_label.Location = new System.Drawing.Point(10, 372);
            this.camera_position_label.Name = "camera_position_label";
            this.camera_position_label.Size = new System.Drawing.Size(109, 13);
            this.camera_position_label.TabIndex = 56;
            this.camera_position_label.Text = "Controle Pos. Câmera";
            // 
            // camera_position_combobox
            // 
            this.camera_position_combobox.FormattingEnabled = true;
            this.camera_position_combobox.Items.AddRange(new object[] {
            "Disabled",
            "Enabled"});
            this.camera_position_combobox.Location = new System.Drawing.Point(130, 369);
            this.camera_position_combobox.Name = "camera_position_combobox";
            this.camera_position_combobox.Size = new System.Drawing.Size(93, 21);
            this.camera_position_combobox.TabIndex = 57;
            this.camera_position_combobox.SelectedIndexChanged += new System.EventHandler(this.camera_position_combobox_SelectedIndexChanged);
            // 
            // xbox_360c_groupBox
            // 
            this.xbox_360c_groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.xbox_360c_groupBox.Controls.Add(this.rumble_label);
            this.xbox_360c_groupBox.Controls.Add(this.rumble_status_textbox);
            this.xbox_360c_groupBox.Controls.Add(this.sequence_status);
            this.xbox_360c_groupBox.Controls.Add(this.right_shoulder_status);
            this.xbox_360c_groupBox.Controls.Add(this.Y_button_status);
            this.xbox_360c_groupBox.Controls.Add(this.B_button_status);
            this.xbox_360c_groupBox.Controls.Add(this.right_shoulder_label);
            this.xbox_360c_groupBox.Controls.Add(this.left_shoulder_status);
            this.xbox_360c_groupBox.Controls.Add(this.sequence_label);
            this.xbox_360c_groupBox.Controls.Add(this.X_button_status);
            this.xbox_360c_groupBox.Controls.Add(this.brightness_status);
            this.xbox_360c_groupBox.Controls.Add(this.A_button_status);
            this.xbox_360c_groupBox.Controls.Add(this.left_shoulder_label);
            this.xbox_360c_groupBox.Controls.Add(this.brightness_label);
            this.xbox_360c_groupBox.Controls.Add(this.headlights_status);
            this.xbox_360c_groupBox.Controls.Add(this.headlights_label);
            this.xbox_360c_groupBox.Controls.Add(this.slowmode_status);
            this.xbox_360c_groupBox.Controls.Add(this.slowmode_label);
            this.xbox_360c_groupBox.Controls.Add(this.dpad_right_status);
            this.xbox_360c_groupBox.Controls.Add(this.right_stick_y_value);
            this.xbox_360c_groupBox.Controls.Add(this.dpad_down_status);
            this.xbox_360c_groupBox.Controls.Add(this.right_stick_x_value);
            this.xbox_360c_groupBox.Controls.Add(this.dpad_left_status);
            this.xbox_360c_groupBox.Controls.Add(this.right_trig_value);
            this.xbox_360c_groupBox.Controls.Add(this.camera_position_combobox);
            this.xbox_360c_groupBox.Controls.Add(this.steering_processing_label);
            this.xbox_360c_groupBox.Controls.Add(this.left_stick_x_value);
            this.xbox_360c_groupBox.Controls.Add(this.camera_position_label);
            this.xbox_360c_groupBox.Controls.Add(this.steering_combobox);
            this.xbox_360c_groupBox.Controls.Add(this.left_trig_value);
            this.xbox_360c_groupBox.Controls.Add(this.throttle_processing_label);
            this.xbox_360c_groupBox.Controls.Add(this.throttle_combobox);
            this.xbox_360c_groupBox.Controls.Add(this.left_stick_y_value);
            this.xbox_360c_groupBox.Controls.Add(this.right_stick_y_label);
            this.xbox_360c_groupBox.Controls.Add(this.right_stick_x_label);
            this.xbox_360c_groupBox.Controls.Add(this.left_stick_x_label);
            this.xbox_360c_groupBox.Controls.Add(this.left_trig_label);
            this.xbox_360c_groupBox.Controls.Add(this.right_trig_label);
            this.xbox_360c_groupBox.Controls.Add(this.left_stick_y_label);
            this.xbox_360c_groupBox.Location = new System.Drawing.Point(12, 15);
            this.xbox_360c_groupBox.Name = "xbox_360c_groupBox";
            this.xbox_360c_groupBox.Size = new System.Drawing.Size(446, 430);
            this.xbox_360c_groupBox.TabIndex = 58;
            this.xbox_360c_groupBox.TabStop = false;
            this.xbox_360c_groupBox.Text = "Controle Xbox ";
            // 
            // rumble_label
            // 
            this.rumble_label.AutoSize = true;
            this.rumble_label.Location = new System.Drawing.Point(17, 401);
            this.rumble_label.Name = "rumble_label";
            this.rumble_label.Size = new System.Drawing.Size(102, 13);
            this.rumble_label.TabIndex = 67;
            this.rumble_label.Text = "Status Acelerômetro";
            // 
            // rumble_status_textbox
            // 
            this.rumble_status_textbox.BackColor = System.Drawing.SystemColors.Window;
            this.rumble_status_textbox.Location = new System.Drawing.Point(130, 398);
            this.rumble_status_textbox.Name = "rumble_status_textbox";
            this.rumble_status_textbox.Size = new System.Drawing.Size(93, 20);
            this.rumble_status_textbox.TabIndex = 66;
            // 
            // sequence_status
            // 
            this.sequence_status.Location = new System.Drawing.Point(332, 398);
            this.sequence_status.Name = "sequence_status";
            this.sequence_status.Size = new System.Drawing.Size(42, 20);
            this.sequence_status.TabIndex = 65;
            // 
            // sequence_label
            // 
            this.sequence_label.AutoSize = true;
            this.sequence_label.Location = new System.Drawing.Point(254, 401);
            this.sequence_label.Name = "sequence_label";
            this.sequence_label.Size = new System.Drawing.Size(58, 13);
            this.sequence_label.TabIndex = 64;
            this.sequence_label.Text = "Sequência";
            // 
            // brightness_status
            // 
            this.brightness_status.Location = new System.Drawing.Point(332, 369);
            this.brightness_status.Name = "brightness_status";
            this.brightness_status.Size = new System.Drawing.Size(42, 20);
            this.brightness_status.TabIndex = 63;
            // 
            // brightness_label
            // 
            this.brightness_label.AutoSize = true;
            this.brightness_label.Location = new System.Drawing.Point(254, 372);
            this.brightness_label.Name = "brightness_label";
            this.brightness_label.Size = new System.Drawing.Size(72, 13);
            this.brightness_label.TabIndex = 62;
            this.brightness_label.Text = "Luminosidade";
            // 
            // headlights_status
            // 
            this.headlights_status.Location = new System.Drawing.Point(332, 340);
            this.headlights_status.Name = "headlights_status";
            this.headlights_status.Size = new System.Drawing.Size(42, 20);
            this.headlights_status.TabIndex = 61;
            this.headlights_status.Text = "OFF";
            // 
            // headlights_label
            // 
            this.headlights_label.AutoSize = true;
            this.headlights_label.Location = new System.Drawing.Point(254, 343);
            this.headlights_label.Name = "headlights_label";
            this.headlights_label.Size = new System.Drawing.Size(35, 13);
            this.headlights_label.TabIndex = 60;
            this.headlights_label.Text = "Luzes";
            // 
            // slowmode_status
            // 
            this.slowmode_status.Location = new System.Drawing.Point(332, 311);
            this.slowmode_status.Name = "slowmode_status";
            this.slowmode_status.Size = new System.Drawing.Size(42, 20);
            this.slowmode_status.TabIndex = 59;
            this.slowmode_status.Text = "OFF";
            // 
            // slowmode_label
            // 
            this.slowmode_label.AutoSize = true;
            this.slowmode_label.Location = new System.Drawing.Point(254, 314);
            this.slowmode_label.Name = "slowmode_label";
            this.slowmode_label.Size = new System.Drawing.Size(60, 13);
            this.slowmode_label.TabIndex = 58;
            this.slowmode_label.Text = "Modo lento";
            // 
            // micro_groupBox
            // 
            this.micro_groupBox.Controls.Add(this.serial_status_label);
            this.micro_groupBox.Controls.Add(this.COMPort_label);
            this.micro_groupBox.Controls.Add(this.serial_output_label);
            this.micro_groupBox.Location = new System.Drawing.Point(12, 451);
            this.micro_groupBox.Name = "micro_groupBox";
            this.micro_groupBox.Size = new System.Drawing.Size(446, 157);
            this.micro_groupBox.TabIndex = 59;
            this.micro_groupBox.TabStop = false;
            this.micro_groupBox.Text = "Conexão Placa Microcontrolada";
            // 
            // camera_groupBox
            // 
            this.camera_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camera_groupBox.Controls.Add(this.stop_video_button);
            this.camera_groupBox.Controls.Add(this.camera_video_button);
            this.camera_groupBox.Controls.Add(this.ip_address_textbox);
            this.camera_groupBox.Controls.Add(this.camera_ip_label);
            this.camera_groupBox.Controls.Add(this.debug_label);
            this.camera_groupBox.Location = new System.Drawing.Point(472, 15);
            this.camera_groupBox.Name = "camera_groupBox";
            this.camera_groupBox.Size = new System.Drawing.Size(662, 593);
            this.camera_groupBox.TabIndex = 60;
            this.camera_groupBox.TabStop = false;
            this.camera_groupBox.Text = "Raspberry Pi Câmera";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 623);
            this.Controls.Add(this.comport_textbox);
            this.Controls.Add(this.xbox_debug_label);
            this.Controls.Add(this.digital_buttons_label);
            this.Controls.Add(this.dpad_up_status);
            this.Controls.Add(this.dpad_label);
            this.Controls.Add(this.horiz_offset_value);
            this.Controls.Add(this.vert_offset_value);
            this.Controls.Add(this.horiz_offset_label);
            this.Controls.Add(this.vert_offset_label);
            this.Controls.Add(this.debug_textbox);
            this.Controls.Add(this.camera_image);
            this.Controls.Add(this.serial_status_textbox);
            this.Controls.Add(this.connect_serial_button);
            this.Controls.Add(this.serial_inputG_textbox);
            this.Controls.Add(this.serial_inputT_textbox);
            this.Controls.Add(this.serial_input_label);
            this.Controls.Add(this.variable_check);
            this.Controls.Add(this.controller_check);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.xbox_360c_groupBox);
            this.Controls.Add(this.micro_groupBox);
            this.Controls.Add(this.camera_groupBox);
            this.Name = "Form1";
            this.Text = "Supervisório";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camera_image)).EndInit();
            this.xbox_360c_groupBox.ResumeLayout(false);
            this.xbox_360c_groupBox.PerformLayout();
            this.micro_groupBox.ResumeLayout(false);
            this.micro_groupBox.PerformLayout();
            this.camera_groupBox.ResumeLayout(false);
            this.camera_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button controller_check;
        private System.Windows.Forms.Label left_trig_label;
        private System.Windows.Forms.TextBox left_trig_value;
        private System.Windows.Forms.Label right_trig_label;
        private System.Windows.Forms.TextBox right_trig_value;
        private System.Windows.Forms.TextBox left_stick_x_value;
        private System.Windows.Forms.Label left_stick_x_label;
        private System.Windows.Forms.Label left_stick_y_label;
        private System.Windows.Forms.TextBox left_stick_y_value;
        private System.Windows.Forms.TextBox right_stick_x_value;
        private System.Windows.Forms.TextBox right_stick_y_value;
        private System.Windows.Forms.Label right_stick_x_label;
        private System.Windows.Forms.Label right_stick_y_label;
        private System.Windows.Forms.TextBox variable_check;
        private System.Windows.Forms.Label serial_output_label;
        private System.Windows.Forms.Label serial_input_label;
        private System.Windows.Forms.TextBox serial_inputT_textbox;
        private System.Windows.Forms.TextBox serial_inputG_textbox;
        private System.Windows.Forms.Button connect_serial_button;
        private System.Windows.Forms.TextBox serial_status_textbox;
        private System.Windows.Forms.PictureBox camera_image;
        private System.Windows.Forms.Button camera_video_button;
        private System.Windows.Forms.Button stop_video_button;
        private System.Windows.Forms.Label camera_ip_label;
        private System.Windows.Forms.TextBox ip_address_textbox;
        private System.Windows.Forms.Label debug_label;
        private System.Windows.Forms.TextBox debug_textbox;
        private System.Windows.Forms.Label vert_offset_label;
        private System.Windows.Forms.Label horiz_offset_label;
        private System.Windows.Forms.TextBox vert_offset_value;
        private System.Windows.Forms.TextBox horiz_offset_value;
        private System.Windows.Forms.Label left_shoulder_label;
        private System.Windows.Forms.TextBox left_shoulder_status;
        private System.Windows.Forms.Label dpad_label;
        private System.Windows.Forms.TextBox dpad_up_status;
        private System.Windows.Forms.TextBox dpad_left_status;
        private System.Windows.Forms.TextBox dpad_right_status;
        private System.Windows.Forms.TextBox dpad_down_status;
        private System.Windows.Forms.Label right_shoulder_label;
        private System.Windows.Forms.TextBox right_shoulder_status;
        private System.Windows.Forms.Label digital_buttons_label;
        private System.Windows.Forms.TextBox Y_button_status;
        private System.Windows.Forms.TextBox A_button_status;
        private System.Windows.Forms.TextBox X_button_status;
        private System.Windows.Forms.TextBox B_button_status;
        private System.Windows.Forms.Label xbox_debug_label;
        private System.Windows.Forms.Label COMPort_label;
        private System.Windows.Forms.TextBox comport_textbox;
        private System.Windows.Forms.Label serial_status_label;
        private System.Windows.Forms.ComboBox steering_combobox;
        private System.Windows.Forms.ComboBox throttle_combobox;
        private System.Windows.Forms.Label steering_processing_label;
        private System.Windows.Forms.Label throttle_processing_label;
        private System.Windows.Forms.Label camera_position_label;
        private System.Windows.Forms.ComboBox camera_position_combobox;
        private System.Windows.Forms.GroupBox xbox_360c_groupBox;
        private System.Windows.Forms.GroupBox micro_groupBox;
        private System.Windows.Forms.GroupBox camera_groupBox;
        private System.Windows.Forms.TextBox slowmode_status;
        private System.Windows.Forms.Label slowmode_label;
        private System.Windows.Forms.TextBox headlights_status;
        private System.Windows.Forms.Label headlights_label;
        private System.Windows.Forms.Label sequence_label;
        private System.Windows.Forms.TextBox brightness_status;
        private System.Windows.Forms.Label brightness_label;
        private System.Windows.Forms.TextBox sequence_status;
        private System.Windows.Forms.Label rumble_label;
        private System.Windows.Forms.TextBox rumble_status_textbox;
    }
}

