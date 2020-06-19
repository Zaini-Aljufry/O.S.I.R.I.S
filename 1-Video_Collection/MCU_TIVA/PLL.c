#include "common.h"

void PLL_Init(void) // 80Mhz
{ 
  /* Step 0: RCC2 */
  SYSCTL->RCC2 |=0x80000000; //usercc2
  /* Step 1: Bypass PLL to init */
  SYSCTL->RCC2 |=0x800;      //BYPASS2
  /* Step 2: Bypass PLL to init */
  SYSCTL->RCC &= ~0x7C0;    //clear XTAL bit
  SYSCTL->RCC |= 0x540;     //configure to 16MHz 
  SYSCTL->RCC2 &= ~0x70;      //main oscillator 
  /* Step 3:  Activate PLL */
  SYSCTL->RCC2 &= ~0x2000;   // clear PWRDN
  /* Step 4: Set the desired system divider */
  //SYSCTL_RCC2_R &= ~0x7C00000;
	
  SYSCTL->RCC2 |= 0x40000000;    //set to use sysdiv2 ( own dvider), divide from 400mhz
  SYSCTL->RCC2 &= ~0x1FC00000;   //clear sysdiv2, from 400Mhz total to step down
  SYSCTL->RCC2 |= 0x1000000;// (4<<22), divide by (4+1)
  /* Step 5: Wait for PLL to lock and stabilize*/
  while(!(SYSCTL->RIS & 0x40)){}
  /* Step 6: Enable PPL by clearing BYPASS*/
  SYSCTL->RCC2 &= ~0x800;
}



