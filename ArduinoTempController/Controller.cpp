
using std;

#include "DallasTemperature.h"
#include "OneWire.h"
//#include 

#define ONE_WIRE_BUS 2 

OneWire oneWire(ONE_WIRE_BUS);

DallasTemperature sensors(&oneWire);

#define BUFFSIZE 20

float temps[BUFFSIZE];

uint8_t addresses[BUFFSIZE];

uint8_t numSensors = 0;

volatile char buffer[40];

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

void setupOneWire()
{


	sensors.begin();
}

void loop()
{

	sensors.requestTemperatures();

	numSensors = sensors.getDS18Count();

	for (int i = 0; i < numSensors; i++)
	{
		if (i == BUFFSIZE)
			break;

		uint8_t* address;

		sensors.getAddress(address, i);

		addresses[i] = *address;
		temps[i] = sensors.getTempF(address);
	}



}

void requestEvent()
{

}

void receiveEvent(int howMany)
{
	data = "";

	Wire.

	while (Wire.available())
	{
		data += (char)Wire.read();
	}

	


	while (1 < Wire.available())
	{
		Wire.
	}
}
