#include "common.h"

volatile unsigned long delay;

void OnBoardLED(short mode)
{
	GPIOF->DATA &= ~0xE;
	switch(mode){
		case RED_F: 
			GPIOF->DATA |=RED_F;
			break;
		case BLUE_F: 
			GPIOF->DATA |=BLUE_F;
			break;
		case PINK_F: 
			GPIOF->DATA |=PINK_F;
			break;
		case GREEN_F: 
			GPIOF->DATA |= GREEN_F;
			break;
		case YELLOW_F: 
			GPIOF->DATA |=YELLOW_F;
			break;
		case TUR_F: 
			GPIOF->DATA |=TUR_F;
			break;
		case WHITE_F: 
			GPIOF->DATA |= WHITE_F;
			break;
		default: GPIOF->DATA &= ~0xE;
			break;
	}

}

void LED_standby(void)
{
	GPIOF->DATA &= ~0xE;
	GPIOF->DATA |= YELLOW_F; 


}

void LED_done(void)
{
	GPIOF->DATA &= ~0xE;
	GPIOF->DATA |= GREEN_F;
}


void portFInit(void)
{
	SYSCTL->RCGCGPIO |= 0x20;
	delay = SYSCTL->RCGCGPIO ;
	GPIOF->LOCK = 0x4C4F434B;
	GPIOF->CR |= 0xE;
	GPIOF->AMSEL &= ~0xE;
	GPIOF->PCTL &= ~0xFFF0;
	GPIOF->DIR |= 0xE;
	GPIOF->AFSEL &= ~0xE;
	GPIOF->DEN |= 0xE; 
	GPIOF->DATA &= ~0xE;
	
}

void OnboardSwitchInit(void)
{
	/*Set pin as Digital Input*/
	//DigitInOut('f', 0, INPUT);
	
	SYSCTL->RCGCGPIO |= 0x20;
	delay = SYSCTL->RCGCGPIO ;
	GPIOF->LOCK = 0x4C4F434B;
	GPIOF->CR |= 0x11;
	GPIOF->AMSEL &= ~0x11;
	GPIOF->PCTL &= ~0xF000F;
	GPIOF->PUR   |= 0x11;  //switchs
	GPIOF->DEN |= 0x11; //pf0 need unlock 
	//QEI part 21 
	extiInit('f', 0, FALLING);
	extiInit('f', 4, FALLING);
	__NVIC_EnableIRQ(GPIOF_IRQn);
}

void DigitInOut(char nGPIO, int nPin, char dir)
{
	GPIOA_Type* GPIO;
	
	switch(nGPIO){
		case 'a':
			GPIO = GPIOA;
			SYSCTL->RCGCGPIO |= 0x01;
			break;
		case 'b':
			GPIO = GPIOB;
			SYSCTL->RCGCGPIO |= 0x02;
			break;
		case 'c':
			GPIO = GPIOC;
			SYSCTL->RCGCGPIO |= 0x04;
			break;
		case 'd':
			GPIO = GPIOD;
			SYSCTL->RCGCGPIO |= 0x08;
			break;
		case 'e':
			GPIO = GPIOE;
			SYSCTL->RCGCGPIO |= 0x10;
			break;
		case 'f':
			GPIO = GPIOF;
			SYSCTL->RCGCGPIO |= 0x20;
			break;
	}
	
	/*1. Enable the clock in switch case */
	delay = SYSCTL->RCGCGPIO; 
	/*2. GPIO direction */
	if(dir == INPUT)
		GPIO->DIR &= ~(1<<nPin); //as input
	else
		GPIO->DIR |= (1<<nPin); //as output
	
	/*3. GPIO alternal function selection */
	GPIO->AFSEL &= ~(1<<nPin);
	GPIO->PCTL &= ~(0xf<<nPin);
	/*4. Set Drive strength, the amp of the pins  */
	GPIO->DR8R |= (1<<nPin); // set to 2m-A
	
	/*5. GPIOPUR, GPIOPDR, GPIOODR */
	GPIO->PDR |= (1<<nPin);
	/*6. To enable GPIO is digital I/Os & GPIOAMSEL  */
	GPIO->DEN |= (1<<nPin);
	GPIO->AMSEL &= ~(1<<nPin);
}

void extiInit(char nGPIO, int nPin, int edge){
	GPIOA_Type* GPIO;
	
	switch(nGPIO){
		case 'a':
			GPIO = GPIOA;
			SYSCTL->RCGCGPIO |= 0x01;
			break;
		case 'b':
			GPIO = GPIOB;
			SYSCTL->RCGCGPIO |= 0x02;
			break;
		case 'c':
			GPIO = GPIOC;
			SYSCTL->RCGCGPIO |= 0x04;
			break;
		case 'd':
			GPIO = GPIOD;
			SYSCTL->RCGCGPIO |= 0x08;
			break;
		case 'e':
			GPIO = GPIOE;
			SYSCTL->RCGCGPIO |= 0x10;
			break;
		case 'f':
			GPIO = GPIOF;
			SYSCTL->RCGCGPIO |= 0x20;
			break;
	}
	
	/*Set pin as Digital Input*/
	//DigitInOut(nGPIO, nPin, INPUT);
	
	/******** set interrupt mask ********/
	/*7. Program GPIOIS, GPIOIBE, GPIOEV, and GPIOIM */
	/*7a. Mask the correspoding port by clearning the IME field GPIOIM, pg 667 */
	GPIO->IM &= ~(1<<nPin);
	/*7b. Configure the IS field in the GPIOIS register and the IBE field in the GPIOIBE register */
	GPIO->IS &= ~(1<<nPin); //to detect edges
	
	if(edge == RISING)
		GPIO->IEV |= (1<<nPin);
	else if(edge == FALLING)
		GPIO->IEV &= ~(1<<nPin);
	else if(edge == BOTHEDGE)
		GPIO->IBE |= (1<<nPin); //both edge trigger
	
	/*7c. Clear the GPIORIS */
	GPIO->RIS &= ~(1<<nPin);
	/*7d. Unmask the port by setting the IME field in the GPIOIM register*/
	GPIO->IM |= (1<<nPin);

}
