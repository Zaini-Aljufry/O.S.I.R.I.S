#ifndef __COMMON_DOT_H__
#define __COMMON_DOT_H__


#include "tm4c123gh6pm.h"

#define SystemClock 80000000 //80Mhz
typedef unsigned short BOOL;
#define TRUE 1
#define FALSE 0

/* Direction*/
#define INPUT 0
#define OUTPUT 1

/* Edge set*/
#define RISING 0
#define FALLING 1
#define BOTHEDGE 2

/*GPIOF_LED Colour */
#define OFF_F 0x0
#define RED_F 0x2
#define BLUE_F 0x4
#define PINK_F 0x6
#define GREEN_F 0x8
#define YELLOW_F 0xA
#define TUR_F 0xC
#define WHITE_F 0xE
	
/* */

void PLL_Init(void);
void portFInit(void);
void timerInit(unsigned long nTimer, unsigned long Hertz, BOOL irqEn );
void SysTick_Init(unsigned int hertz);
void extiInit(char nGPIO, int nPin, int edge);
void pwmInit(unsigned long Hertz, unsigned long dutyCycle);
void OnBoardLED(short mode);
void Tick_Wait(unsigned long delay);
void OnboardSwitchInit(void);
void Tick_Wait10ms(unsigned long delay);
void DigitInOut(char nGPIO, int nPin, char dir);
void PWMUpdate(void);
void PWMOff(void);
#endif
