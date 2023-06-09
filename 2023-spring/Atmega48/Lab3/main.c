#include <avr/io.h>
#include <avr/interrupt.h>

#define BUTTON PD4

ISR(TIMER1_COMPA_vect){
	 PORTB = ~TCNT0;
	 TCNT0 = 0;
}

int main(void)
{
	DDRB = 0xFF;
	PORTB = 0xFF;
	DDRD &= ~(1 << BUTTON); // Set button pin as input
	PORTD = 1 << 4; // Connecting a pull-up resistor to PD4 pin

	TCCR1B = (1<<CS12) | (1<<CS10) | (1<<WGM12); //clk/1024
	TIMSK1 = (1<<OCIE1A); //Enable Output compare A match interrupt
	
	TCCR0B = (1<<CS02) | (1<<CS01); //Config Timer T0 to External clock source
	OCR1A = 39062; //Set the Top value for Timer/Counter1 5 sec
	
	sei(); //Enable global interrupts
	while (1)
	{
	}
}
