#include "common.h" //contain TypeDef Value


	
void SysTick_Init(unsigned int hertz)
{
	
	//disable SysTick
	SysTick->CTRL &= ~0x01;   //disable SysTick
	SysTick->LOAD = (SystemClock/hertz) - 1; //set reload value
	SysTick->VAL = 0;     //reset value 
	SysTick->CTRL |= 0x04;    // set clock selection 
	SysTick->CTRL |= 0x02;    // set interrupt enable
	//NVIC_SYS_PRI3_R &= ~0xFFFFFF;
	//NVIC_SYS_PRI3_R |= 0x40000000; //toggle priority 3 for systick handler
	SysTick->CTRL |= 0x1;      //enable systick 
	
}


void Tick_Wait(unsigned long delay){
	while(delay--);
}

void Tick_Wait10ms(unsigned long delay)
{
	unsigned long i;
	for(i=0; i< delay; ++i)
		Tick_Wait(800000); //10ms
}