#include <Wire.h>

/*  
 *  How I2C Communication Protocol Works - Example01
 *  
 *   by Dejan Nedelkovski, www.HowToMechatronics.com 
 *   
 */
#include <Wire.h>
#include <OneWire.h> 
#include <DallasTemperature.h>

#define ONE_WIRE_BUS 2 

OneWire oneWire(ONE_WIRE_BUS); 

DallasTemperature sensors(&oneWire);

float[] temps;

uint8_t[] addresses;

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
  
  sensors.requestTemperatures();

  uint8_t numSensors = sensors.getDS18Count();

  

  
  
}

void requestEvent()
{
  
}

void receiveEvent(int howMany)
{
  
}

