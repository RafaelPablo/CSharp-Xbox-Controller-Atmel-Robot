// Includes
#include <Servo.h>
#include <OneWire.h>
#include <DallasTemperature.h>

// Defines
#define ONE_WIRE_BUS 47     // Porta do pino de sinal do DS18B20
#define r1 41 //Azul e Branco
#define r2 38
#define l1 12 //Roxo e Cinza
#define l2 13

// Define uma instancia do oneWire para comunicacao com o sensor
OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature sensors(&oneWire);
DeviceAddress sensor1;

// Variables
int count = 0;
int analogic_mq135 = 0;
char sensorGasString[5]={'\0','\0','\0','\0'};
char SensorTmpString[5]={'\0','\0','\0','\0'};

//Servo declarations
Servo camera_H;
Servo camera_V;
Servo b_base;
Servo b_cotovelo;
Servo b_maoV;
Servo b_maoH;
Servo b_garra;

//***********************************************************************************************************
//Initialisation Function
//***********************************************************************************************************

void setup()
{
  // set the digital pin as output and initialize LOW:
  pinMode(r1, OUTPUT);
  pinMode(r2, OUTPUT);
  pinMode(l1, OUTPUT);
  pinMode(l2, OUTPUT);

  digitalWrite(r1, HIGH);
  digitalWrite(r2, HIGH);
  digitalWrite(l1, HIGH);
  digitalWrite(l2, HIGH);

  pinMode(25, OUTPUT); // ponte h AUX
  digitalWrite(25, HIGH);
  pinMode(27, OUTPUT); // ponte h AUX
  digitalWrite(27, HIGH);

  // Turn the Serial Protocol ON
  Serial.begin(57600);  //First hardware serial is used for debugging only
  Serial1.begin(57600); //Arduino Mega 2560 is used, so hardware serial 1 is used

  // Inicia a leitura de sensores de temperatura
  sensors.begin();
  sensors.getAddress(sensor1, 0);
  
  //Configure camera servos and initial angle
  camera_H.attach(46);
  camera_V.attach(10);
  camera_H.write(125);
  camera_V.write(100);

  //Configure arm servos and initial angle
  b_base.attach(5);
  b_cotovelo.attach(3);
  b_maoV.attach(7);
  b_maoH.attach(6);
  b_garra.attach(8);

  b_maoH.write(120);
  delay(15);
  b_maoV.write(0);
  delay(15);
  b_cotovelo.write(120);
  delay(15);
  b_base.write(180);

  //Configure motors pins initial value
}

//************************************************************************************************************
//Main loop
//************************************************************************************************************

void loop()
{
  getstring();
  delay(50);
  // Would have preferred to update at 25Hz or higher (delay (40)) but reliability was reduced 
}

//**************************************************************************************
//Other Functions
//**************************************************************************************

// void getstring ()
// This function sends an output to the C# program periodically, containing a final character "A"
// This function also receives strings sent via serial
// It stops receiving serial input when the "Z" character is detected

// Using comma locations in the saved char array, it saves the input throttle and steering
// values into separate char arrays. It also extracts other information (eg lights)
// It then writes to the throttle and steering variables (using the atoi function)

void getstring ()
{
  char inputstring[19];
  String testeEntrada;
  String outputstring;
  int bytesreceived = 0;
  int index = 0;
  int posindex = 0;
  char motorLVal = '5';
  char motorRVal = '5';
  char braco = ' ';
  char bracostring[4]={'\0','\0','\0'};
  char panstring[4]={'\0','\0','\0'};
  char tiltstring[4]={'\0','\0','\0'};
//  char slowmode;
//  int throttle_comma = 0;
  int motorL_comma = 1;
  int motorR_comma = 3;
  int braco_comma = 5;
  int braco_comma_val = 9;
  int pan_comma = 13;
  int tilt_comma = 17;
  int motorR = 5;
  int motorL = 5;
  int braco_val = 0;
  int braco_base = 180;
  int braco_cotovelo = 90;
  int braco_horizontal = 90;
  int braco_vertical = 90;
  int braco_garra = 160;
  int cam_pan = 125;
  int cam_tilt = 100;
  int data_valid = 0;
//  int counter = 0;

//receive and save serial input characters until a new line character is detected, or the char array is full.
//if received message is greater than 14 characters if (Serial.available() > 18)
  if (Serial.available()> 17)
  {
    //counter = Serial.available();
    //testeEntrada = Serial.readStringUntil ('Y');
    testeEntrada = Serial.readString();
    //Serial.print(testeEntrada);
    //read bytes until it finds a 'Z' (90), or 19 characters are reached, save into inputstring
    //inputstring[testeEntrada.length()] = 0;  //make last character 0
    //Serial.print(testeEntrada.length());

    if(testeEntrada.lastIndexOf('Y') == 18)
    {
      testeEntrada.toCharArray(inputstring, 18);
    }

//    for(int i=0; i < testeEntrada.length();i++)
//    {
//      Serial.print(inputstring[i]);
//    }
    
    if (inputstring[3]==',') //if (testeEntrada.length() > 18 && inputstring[3]==',' && inputstring[19]=='Y')
    {
      data_valid = 1;
      //Serial.println("OK");
    }
  }

  // Comma locations, based on the following input string structure:
  // L,R,B,BRA,PAM,TIL,Y
  // where L = motorL, R = motorR, B = archer, BRA = arm value, PAM = camera pan, TIL = camera vertical tilt, Y = check character
  
//  motorR_comma = 3;
//  motorL_comma = 7;
//  slowmode_comma = 9;
//  pan_comma = 13;
//  tilt_comma = 17;
  
  if (data_valid == 1)
  {
    motorLVal = inputstring[motorL_comma-1];
//    Serial.print(motorLString);
//    Serial.print('\n');
//    motorL = atoi(&motorLVal);
//    if (motorL < 4 || motorL >  6)
//    {
//      motorL = 5;
//    }
    if(motorLVal == '4')
      motorL = 4;
    if(motorLVal == '5')
      motorL = 5;
    if(motorLVal == '6')
      motorL = 6;

   motorRVal = inputstring[motorR_comma-1];
    if(motorRVal == '4')
      motorR = 4;
    if(motorRVal == '5')
      motorR = 5;
    if(motorRVal == '6')
      motorR = 6;
  }
  else
  {
    //stop the car if invalid input data is detected
    motorL = 5;
    motorR = 5;
  }
  
  //Save the arm character
  if (data_valid ==1)
  {
    braco = inputstring[braco_comma-1];
  }
  else
  {
    braco = 'B';
  }
  
  //Write the arm data to a separate character array
  posindex = 0;
  for (index=braco_comma+1; (index<pan_comma && posindex < 4); index++)
  {
    bracostring[posindex] = inputstring[index];
    posindex++;
  }

  if (data_valid == 1)
  {
    braco_val = atoi(bracostring);
  }
  else 
  {
//     if (braco == 'B')
//    {
//      braco_base = 180;
//    }
//    if (braco == 'C')
//    {
//      braco_cotovelo = 90;
//    }
//    if (braco == 'H')
//    {
//      braco_horizontal = 90;
//    }
//    if (braco == 'V')
//    {
//      braco_vertical = 90;
//    }
//    if (braco == 'G')
//    {
//      braco_garra = 160;
//    }
  }


  
  //Write the camera pan data to a separate character array
  posindex = 0;
  for (index=braco_comma_val+1; (index<pan_comma && posindex < 4); index++)
  {
    panstring[posindex] = inputstring[index];
    posindex++;
  }
  if (data_valid == 1)
  {
    cam_pan = atoi(panstring);
    camera_H.write(cam_pan);
  }


  //Write the camera tilt data to a separate character array
  posindex = 0;
  for (index=pan_comma+1; (index<tilt_comma && posindex < 4); index++)
  {
    tiltstring[posindex] = inputstring[index];
    posindex++;
  }
  if (data_valid == 1)
  {
    cam_tilt = atoi(tiltstring);
    camera_H.write(cam_tilt);
  }

  process_motorR(motorR);
  process_motorL(motorL);
//  process_braco(braco_val, braco);
  process_cam_pan(cam_pan);
  process_cam_tilt(cam_tilt);
//  Serial.println(motorR);
//  Serial.println(motorR);
//  Serial.println(braco_val);
//  Serial.println(braco);
//  Serial.println(cam_pan);
//  Serial.println(cam_tilt);
  ler_sensor_gases();
  ler_sensor_temperatura();
//  
//  //write the output back to C# program
//  //A and Z are frame markers, to indicate the start and end of the message
//  outputstring = "A," + String(throttlestring) + ',' + String(steerstring) + ',' + String(slowmode) + ',' + String(sensorGas) + ',' + String(SensorTmp) + ',' + rumble + ",Z" + '\n';
// 
  outputstring = "A," + String(sensorGasString) + ',' + String(SensorTmpString) + ",Z" + '\n';
// outputstring = "A," + String(600) + ',' + String(600) + ",s," + String(600) + ',' + String(600) + ",Z" + '\n';

//  debug code - output various things through Hardware serial (i.e. Arduino USB cable)
//  Serial.print (inputstring);
//  Serial.print ('\n');
//  Serial.print (bytesreceived);
//  Serial.print ('\n');
//  Serial.print (data_valid);
//  Serial.print ('\n');
//  Serial.print ('\n');
//  Serial.print ("  ");
//  Serial.print (counter);
//  Serial.print ('\n');
//  Serial.print (outputstring);
//  Serial.print ('\n');
//  Serial.print ('\n');
//  
   Serial.print (outputstring);
//
  data_valid = 0;
  //delay (75);
}
//
//void process_steering (int steervalue)
//{
//  //C# program sends a value between 400 (full left) to 600 (full right)
//  //The steering servo expects an angle between 120 (full left) and 60 (full right)
//  //133 was used due to my car's wonky axles. 133 is full left, and 60 is full right
//  float steer_angle = map (steervalue, 400, 600, 133, 60);
//  steer_servo.write(steer_angle);
//}

void process_motorL (int motorLvalue)
{
//C# program sends a value between 400 (full reverse) to 600 (full forwards)
//The speed controller expects a value between 0 (full reverse) and 180 (full forwards)
//  if (slowmode == 'F')
//  {
//    //max throttle is full speed
//    float throttle_mapped = map (throttlevalue, 400, 600, 0, 180);
//    throttle_ESC.write(throttle_mapped);
//  }
//  else if (slowmode == 'S')
//  {
//    //max throttle limited to half speed in slow mode
//    float throttle_mapped = map (throttlevalue, 400, 600, 45, 135);
//    throttle_ESC.write(throttle_mapped);
//  }

    //Serial.println(motorLvalue);
    if (motorLvalue == 4)
    {
      digitalWrite(27,HIGH);
      digitalWrite(l1,HIGH);
      digitalWrite(l2,LOW);
    }
    if (motorLvalue == 6)
    {
      digitalWrite(27,HIGH);
      digitalWrite(l1,LOW);
      digitalWrite(l2,HIGH);
    }
      if (motorLvalue == 5)
    {
      digitalWrite(27,LOW);
    }
}

void process_motorR (int motorRvalue)
{
    //Serial.println(motorRvalue);
    
    if (motorRvalue == 4)
    {
      digitalWrite(25,HIGH);
      digitalWrite(r1,HIGH);
      digitalWrite(r2,LOW);
    }
    if (motorRvalue == 6)
    {
      digitalWrite(25,HIGH);
      digitalWrite(r1,LOW);
      digitalWrite(r2,HIGH);
    }
      if (motorRvalue == 5)
    {
      digitalWrite(25,LOW);
    }
}

void process_braco (int braco_val, char braco)
{
  //C# program sends a value between 400 (full reverse) to 600 (full forwards)
  //The speed controller expects a value between 0 (full reverse) and 180 (full forwards)
  if (braco == 'B')
  {
    // movimentar base
    float base_mapped = map (braco_val, 400, 600, 90, 180);
    b_base.write(base_mapped);
  }
  if (braco == 'C')
  {
    //movimentar cotovelo
    float cotovelo_mapped = map (braco_val, 400, 600, 90, 150);
    b_cotovelo.write(cotovelo_mapped);
  }
  if (braco == 'H')
  {
    //movimentar mao horizontal
    float horizontal_mapped = map (braco_val, 400, 600, 0, 100);
    b_maoH.write(horizontal_mapped);
  }
  if (braco == 'V')
  {
    //movimentar mao vertical
    float vertical_mapped = map (braco_val, 400, 600, 60, 180);
    b_maoV.write(vertical_mapped);
  }
  if (braco == 'G')
  {
    //movimentar mao vertical
    float garra_mapped = map (braco_val, 400, 600,30, 160);
    b_garra.write(garra_mapped);
  }
}

void process_cam_pan (int panvalue)
{
  //C# program sends a value between 100 (full left) to 300 (full right)
  //servo range is limited to 20 degreees to 160 degrees (90 is centre)
  //left/right is reversed due to the way the servo is mounted
  //float pan_mapped = map (panvalue, 100, 300, 180, 0);
  camera_H.write(panvalue);
}

void process_cam_tilt (int tiltvalue)
{
  //C# program sends a value between 100 (full down) to 300 (full right)
  //servo range is limited to 75 degrees to 160 degrees, but want 90 degrees to be the centre
  //float tilt_mapped = map (200, 100, 300, 45, 140);

  camera_V.write(tiltvalue);
}

void ler_sensor_gases ()
{
  analogic_mq135 = analogRead(0);
  sprintf(sensorGasString, "%d", analogic_mq135);
  //Serial.println(analogic_mq135);
}

void ler_sensor_temperatura ()
{
  sensors.requestTemperatures();
  int tempC = sensors.getTempC(sensor1);
  sprintf(SensorTmpString, "%d", tempC);
  //Serial.println(tempC);
}

