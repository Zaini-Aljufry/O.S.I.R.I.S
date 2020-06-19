#include "common.h"

#define PF0	     (*((volatile unsigned long *)0x40025004))	//access only PF0 - Left Switch (SW2)
#define PF4      (*((volatile unsigned long *)0x40025040))  //access only PF4 - Right Switch (SW1)
/*
	Sw1(left) -PF0
	Sw2(right) - PF4
*/
int main(void){
	PLL_Init();//set PLL 80mhz 
	portFInit(); //on-board LED lights
	//OnBoardLED(YELLOW_F);//yellow light to signify initializing pheripherals 
	OnboardSwitchInit(); //SW1&SW2 
	pwmInit(24000,0); //desired hertz, duty cycle(will convert since down counter)
	//OnBoardLED(GREEN_F); //green light to signify system good to go
	while(1)
	{
	}
}



void HardFault_Handler (void)
{
	GPIOF->DATA &= ~0xF;
	GPIOF->DATA |= 0x02; //on red onboard LED if hardfault
	while(1);
}

void GPIOF_Handler(void)
{
	unsigned long echo = GPIOF->DATA & 0x011;
	GPIOF->ICR |= 0x011;		//clear GPIO exti handler, PF0&4
	OnBoardLED(OFF_F);
	if(echo == 0x11) //off both
	{
		PWMOff();
		OnBoardLED(OFF_F);
	}
	else
	{
		if(echo & 0x1) //
		{
			PWMOff();OnBoardLED(YELLOW_F);
		}
		if(echo & 0x10) // Right Switch
		{
			PWMUpdate(); OnBoardLED(GREEN_F);
		}
			
	}
}