#define F_CPU 8000000UL	// the clock frequency of the ATMega48 microcontroller is 8 MHz
#include <avr/io.h>	// Including I/O library
#include <avr/interrupt.h>	// Including interrupt library
#include <util/delay.h>	// Including a library with delay functions

#define LED_PORT PORTD // Port D controls the LEDs
#define LED_DDR DDRD   // Data Direction Register for Port D

#define INTERRUPT_PORT PORTB    // Port B controls the interrupt
#define INTERRUPT_DDR DDRB    // Data Direction Register for Port B
#define INTERRUPT_MASK 0x10  // Mask for interrupt pin

#define REPETITIONS_BEFORE_INTERRUPT 5 // After every 5 repetitions of running lights, an interrupt is triggered

volatile uint8_t repetitions = 0; // Global variable to count the number of repetitions

void setup() {
	LED_DDR = 0xFF; // Set up the LED pins as outputs
	LED_PORT = 0xFF; //Turn off all LED
	
	INTERRUPT_DDR = INTERRUPT_MASK;	// set desired pins on Port B as input
	INTERRUPT_PORT = 0x00;   // initialize all pins on Port B to low

	PCICR |= (1 << PCIE0);	  // enable PCINT0 interrupt
	PCMSK0 |= (1 << PCINT4);  // enable interrupt for PCINT4 (input) pin
	
	sei();	// Enable global interrupts
}

void running_lights() {
	for (uint8_t i = 0; i < 8; i++) {
		LED_PORT = ~(1 << i); // Turn on LED at i-th position
		_delay_ms(100); // Delay 100 ms
	}
}

void display_repetitions() {
	LED_PORT = ~repetitions; // Display the number of repetitions
	_delay_ms(6000); // Delay 6 second
	LED_PORT = 0xFF; //Turn off all LED
}

ISR(PCINT0_vect) {		   // PCINT0 interrupt
	if (INTERRUPT_PORT == INTERRUPT_MASK) {   // check if PORTB is 0x10
		display_repetitions();
		INTERRUPT_PORT = 0x00;      // Clear Port B
	}
}


int main() {
	setup();
	while (1) {
		running_lights();
		repetitions++;
		if (repetitions % REPETITIONS_BEFORE_INTERRUPT == 0) {
			INTERRUPT_PORT = INTERRUPT_MASK;  // Trigger interrupt by setting PinB to mask
		}
	}
	return 0;
}