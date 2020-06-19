#include "common.h"

void timerInit(unsigned long nTimer, unsigned long Hertz, BOOL irqEn ){
	TIMER0_Type * Timer;
	switch(nTimer){
		case 0: 
			Timer = TIMER0;
			SYSCTL->RCGCTIMER |= 0x01;
			break;
		case 1: 
			Timer = TIMER1;
			SYSCTL->RCGCTIMER |= 0x02;
			break;
		case 2: 
			Timer = TIMER2;
			SYSCTL->RCGCTIMER |= 0x04;
			break;
		case 3: 
			Timer = TIMER3;
			SYSCTL->RCGCTIMER |= 0x08;
			break;
		case 4: 
			Timer = TIMER4;
			SYSCTL->RCGCTIMER |= 0x10;
			break;
		case 5: 
			Timer = TIMER5;
			SYSCTL->RCGCTIMER |= 0x020;
			break;
	}
	
/*1. Ensure the timer is disabled, TnEN GPTMCTL */
	Timer->CTL &= ~ 0x01; 
/*2. write GPTM cofiguration register (GPTMCFG) with 0x00000000 */
	Timer->CFG = 0x00000000;
/*3. Configue the TnMr field in the GPTM timer n Mode Register GOTMTnMR */
/*3a or b 0x1 for One-Shot mode or 0x02 for Periodic mode */
	Timer->TAMR |= 0x2;
/*4. Optionally... long comment here. im lazy  */
	Timer->TAMR |= (1<<4); //down counter 
/*5. Load the start value into the GPTM Timer n Interval load register (GPTMTnILR) */
	Timer->TAILR = (SystemClock  / Hertz); //count value 
/*6. If interrupts are required, set the appropriate bits in the GPTM interrupt mark register GPTMIMR */
	if(irqEn)
		Timer->IMR |= 0x01;
	else
		Timer->IMR &= ~0x01;
/*7. set TnEN bit in the GPTMCTL register to enable the timer and start counting */
	
/*8. Poll the GPTMRIS register or wait for the interrupt to generated(if enabled). In 
     both cases, the status flags are cleared by writing a 1 to the appropriate bit of the GPTM Interrupt clear Register GPTMICR*/
	
	if(irqEn) //irqEn 
		switch(nTimer){
			case 0: 
				__NVIC_EnableIRQ(TIMER0A_IRQn);
				break;
			case 1: 
				__NVIC_EnableIRQ(TIMER1A_IRQn);
				break;
			case 2: 
				__NVIC_EnableIRQ(TIMER2A_IRQn);
				break;
			case 3: 
				__NVIC_EnableIRQ(TIMER3A_IRQn);
				break;
			case 4: 
				__NVIC_EnableIRQ(TIMER4A_IRQn);
				break;
			case 5: 
				__NVIC_EnableIRQ(TIMER5A_IRQn);
				break;
		}
		Timer->CTL |= 0x01;
}



