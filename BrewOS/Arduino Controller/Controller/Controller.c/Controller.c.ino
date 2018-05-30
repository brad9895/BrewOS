/*  
 *  How I2C Communication Protocol Works - Example01
 *  
 *   by Dejan Nedelkovski, www.HowToMechatronics.com 
 *   
 */
#include <Wire.h>
#include <OneWire.h> 
#include <DallasTemperature.h>

int ADXLAddress = 0x53; // Device address in which is also included the 8th bit for selecting the mode, read in this case.
#define X_Axis_Register_DATAX0 0x32 // Hexadecima address for the DATAX0 internal register.
#define X_Axis_Register_DATAX1 0x33 // Hexadecima address for the DATAX1 internal register.
#define Power_Register 0x2D         // Power Control Register

int X0,X1,X_out;

void setup()
{
  setupI2C();
  
  setupOneWire();
  
  Serial.begin(9600);
  
  delay(100);
}

void setupI2C()
{
  Wire.begin(2); // Initiate the Wire library

  Wire.onReceive(receiveEvent);
  Wire.onRequest(requestEvent);
}

void setupOneWire
{
  sensors.begin();
}

void loop()
{
  Wire.beginTransmission(ADXLAddress); // Begin transmission to the Sensor 
  //Ask the particular registers for data
  Wire.write(X_Axis_Register_DATAX0);
  Wire.write(X_Axis_Register_DATAX1);
  
  Wire.endTransmission(); // Ends the transmission and transmits the data from the two registers
  
  Wire.requestFrom(ADXLAddress,2); // Request the transmitted two bytes from the two registers
  
  if(Wire.available()<=2)
  {  // 
    X0 = Wire.read(); // Reads the data from the register
    X1 = Wire.read();   
  }
  
  Serial.print("X0= ");
  Serial.print(X0);
  Serial.print("   X1= ");
  Serial.println(X1);
}

void requestEvent()
{
  
}

void receiveEvent(int howMany)
{
  
}

