#include "common.h"
#define PWMDIV 2
#define PWMCLOCK SystemClock/2/PWMDIV //seems to have a step down of 2 before pwmdiv
#define PWMMODULE 0
/* 
M0
	0- PB6 (PCTL 4),1- PB7 (PCTL 4),2- PB4 (PCTL 4), 3-PB5 (PCTL 4)
	4- PE4 5-PE5 6-PC4 or PD 7- 
M1
	0- PD0(5) 1-PD1(5) 2- 3-
M2
	0- 1- 2- 3-
M3
	0- 1- 2- 3-
*/
unsigned long DCycle;
void PWMOff(void)
{
	PWM0->ENABLE &= ~(0x00000002|0x00000001);
	DCycle =0;
}
void PWMUpdate(void)
{
	unsigned long loadval = PWM0->_0_LOAD +1;
	unsigned long cmpval;// =  loadval * dutyCycle;
	if(DCycle<90)
		DCycle+= 10;
	else DCycle = 0;
	
	cmpval = loadval * DCycle;
	cmpval /=100;
	cmpval = loadval - cmpval;//countdown
	//disable for awhile 
	PWM0->ENABLE &= ~(0x00000002|0x00000001);
	//update the compare value
	PWM0->_0_CMPA = cmpval-1;
	//re-enable 
	PWM0->ENABLE |= (0x00000002|0x00000001);
}

void pwmInit(unsigned long Hertz, unsigned long dutyCycle){
	
	long loadval = PWMCLOCK/Hertz;
	long cmpval =  loadval * dutyCycle;
	cmpval /=100;
	cmpval = loadval - cmpval;//countdown
	DCycle = dutyCycle;
	
#if PWMMODULE == 0 //use PB6 & PB7 as PWM pin
	SYSCTL->RCGCPWM |= 0x01;             // 1) activate PWM0
	SYSCTL->RCGCGPIO |= 0x02;            // 2) activate port B
	while((SYSCTL->PRGPIO & 0x02)==0){};            // allow time to finish activating
	GPIOB->AFSEL |= 0xC0;           // enable alt funct on PB7-6
	GPIOB->PCTL &= ~0xFF000000;     // configure PB7-6 as PWM0
	GPIOB->PCTL |= 0x44000000;
	GPIOB->AMSEL &= ~0xC0;          // disable analog functionality on PB7-6
	GPIOB->DEN |= 0xC0;             // enable digital I/O on PB7-6
	GPIOB->DR8R |= 0xC0;	//increase drive strength 
#else //use module 1, PD0 and PD1 as PWM pin
	SYSCTL->RCGCPWM |= 0x02;             // 1) activate PWM1
	SYSCTL->RCGCGPIO |= 0x08;            // 2) activate port D
	while((SYSCTL->PRGPIO & 0x08)==0){};            // allow time to finish activating
	GPIOD->AFSEL |= 0x3;           // enable alt funct on PD0, PD1
	GPIOD->PCTL &= ~0xFF;     // configure PD0 PD1 as PWM1
	GPIOD->PCTL |= 0x55;	
	GPIOD->AMSEL &= ~0x3;          // disable analog functionality on PD0, PD1
	GPIOD->DEN |= 0x3;             // enable digital I/O on PD0, PD1
	GPIOD->DR8R |= 0x3;	//increase drive strength 
#endif		

	/*Set divider, note that PWM clock already half of PLL clock  before further division*/
	SYSCTL->RCC |= 0x00100000; // 3) use PWM divider
	SYSCTL->RCC &= ~0x000E0000; //    clear PWM divider field
#if PWMDIV == 4  //<<17configure for divider, 0 is 2, 1 is 4, 2 is 8, 3 is 16, 4 is 32
	SYSCTL->RCC |= (1<<17)
#elseif PWMDIV == 8
	SYSCTL->RCC |= (2<<17)
#elseif PWMDIV == 16
	SYSCTL->RCC |= (3<<17)
#elseif PWMDIV == 32
	SYSCTL->RCC |= (4<<17)
#elseif PWMDIV == 64
	SYSCTL->RCC |= (5<<17)
#endif 
		
#if PWMMODULE == 0 //use PB6 & PB7 as PWM pin
	PWM0->_0_CTL = 0;                     // 4) disable PWM while initializing
	//PWM0, Generator A (PWM0/PB6) goes to 0 when count==reload and 1 when count==0
	//PWM0->_0_GENA = (0x00000008|0x00000003);
	PWM0->_0_GENA |= 0xB0;
	//PWM0, Generator B (PWM1/PB7) goes to 0 when count==CMPA counting down and 1 when count==CMPA counting up
	PWM0->_0_GENB = 0xB0;
	PWM0->_0_LOAD = loadval -1;       // 5) count from zero to this number and back to zero in (period - 1) cycles
	PWM0->_0_CMPA = cmpval-1;       // 6) count value when PWM1/PB7 toggles
	// 7) start PWM0 in Count Up/Down mode
	PWM0->_0_CTL |= (0x00000002|0x00000001);
	// enable PWM1-0
	PWM0->ENABLE |= (0x00000002|0x00000001);
#else //use PD0 & PD1 as PWM pin
	 PWM1->_0_CTL = 0;                     // 4) disable PWM while initializing
	//PWM0, Generator A (PWM0/PB6) goes to 0 when count==reload and 1 when count==0
	//PWM0->_0_GENA = (PWM_0_GENA_ACTLOAD_ZERO|PWM_0_GENA_ACTZERO_ONE);
	PWM1->_0_GENA &= ~0xFFF;
	PWM1->_0_GENA |= 0xB0;
	PWM1->_0_GENB = 0xB0;
	PWM1->_0_LOAD = loadval -1;       
	PWM1->_0_CMPA = cmpval-1;      
	PWM1->_0_CTL |= (0x00000002|0x00000001);
	PWM1->ENABLE |= (0x4|0x8);
#endif 
}