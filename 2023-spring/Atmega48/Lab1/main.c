#define F_CPU 8000000UL //definition of the clock frequency of the microcontroller
#include <avr/io.h>  // Including I/O library
#include <util/delay.h> //Including a Library with delay functions

#define LED_RED    PB2
#define LED_YELLOW PB1
#define LED_GREEN  PB0
#define BUTTON_7   PD7

void traffic_light_init(void)
{
	DDRB |= (1 << LED_RED) | (1 << LED_YELLOW) | (1 << LED_GREEN); // Set LED pins as outputs
	PORTB = 0xFF; // Initialize PORTB to 1 to turn off all LEDs initially
	PORTB = ~(1 << LED_RED); // Turn on red LED
	DDRD &= ~(1 << BUTTON_7); // Set button pin as input
	PORTD = 1 << 7; // Connecting a pull-up resistor to PD7 pin
}

void traffic_light_cycle(void)
{
	PORTB = 0xFF; // Turn off red LED
	PORTB = ~(1 << LED_YELLOW); // Turn on yellow LED
	_delay_ms(3000);
	PORTB = 0xFF; // Turn off yellow LED
	PORTB = ~(1 << LED_GREEN); // Turn on green LED
	_delay_ms(3000);
	PORTB = 0xFF; // Turn off green LED
	PORTB = ~(1 << LED_YELLOW); // Turn on yellow LED
	_delay_ms(3000);
	PORTB = 0xFF; // Turn off yellow LED
	PORTB = ~(1 << LED_RED); // Turn on red LED
}

int main(void)
{
	traffic_light_init();

	while (1) {
		if (!(PIND & (1 << BUTTON_7))) { // Button pressed
			_delay_ms(5000);
			traffic_light_cycle(); // Switch colors
		}
	}

	return 0;
}