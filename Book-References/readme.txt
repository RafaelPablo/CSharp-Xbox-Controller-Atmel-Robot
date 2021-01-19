Base project:
https://www.instructables.com/Arduino-RC-Car-with-FPV-Camera/
Some improvments/changes on this code (Form1.cs):

683 :         private void display_input_T(string temperatura)
        {
            serial_inputT_textbox.Text = temperatura;
        }

687 :         private void display_input_G(string gas)
        {
            serial_inputG_textbox.Text = gas;
        }

1056 : string video_URL = "http://" + ip_address_textbox.Text + ":8080/RPi_CAm/cam_pic_new.php?";


Book with detailed construction and programming:
https://www.amazon.com/Desenvolvimento-explora%C3%A7%C3%A3o-ambientes-perigosos-microcontroladora/dp/613970443X