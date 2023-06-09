using Lab1;
using System;

namespace Lab1
{
    public abstract class DoubleNumber_Abstract
    {
        protected double number;

        public abstract double Number { get; set; }

        public abstract override string ToString();
    }
    public class RealPart : DoubleNumber_Abstract
    {
        public RealPart()
        {
            number = 0;
        }
        public RealPart(double a)
        {
            number = a;
        }
        public override double Number
        {
            get { return number; }
            set { number = value; }
        }
        public override string ToString()   //ToString() override
        {
            return number.ToString();   //ex. 5
        }
    }
    public class ImaginaryPart : DoubleNumber_Abstract
    {
        public ImaginaryPart()
        {
            number = 0;
        }
        public ImaginaryPart(double b)
        {
            number = b;
        }
        public override double Number
        {
            get { return number; }
            set { number = value; }
        }
        public override string ToString()   //ToString() override
        {
            if (number > 0)
            {
                return "+" + number.ToString() + "i";   //ex. +3i
            }
            return number.ToString() + "i"; //ex. -3i
        }
    }
    public class Complex
    {
        private RealPart rpart = new RealPart();
        private ImaginaryPart impart = new ImaginaryPart();
        public Complex()
        {  
        }
        public Complex(double a, double b)
        {

            rpart.Number = a;  //real part
            impart.Number = b;  //imaginary part
        }
        public Complex(double[] a)  //constructor using array of 2
        {
            if (a.Length != 2)
            {
                throw new ArgumentException("array must be double[2]");
            }
            rpart.Number = a[0];   //real part
            impart.Number = a[1];   //imaginary part
        }
        public Complex(RealPart a, ImaginaryPart b)
        {

            rpart.Number = a.Number;  //real part
            impart.Number = b.Number;  //imaginary part
        }
        //Below different variations of real, imaginary and double as input for constructor
        public Complex(RealPart a, double b)
        {

            rpart.Number = a.Number;  //real part
            impart.Number = b;  //imaginary part
        }
        public Complex(double a, ImaginaryPart b)
        {

            rpart.Number = a;  //real part
            impart.Number = b.Number;  //imaginary part
        }
        public double[] GetComplex()  //return complex number as an array of doubles
                                      //without link to other classes. Main porpose for calculation outside Complex
                                      //class and for some static methods
        {
            double[] output = new double[2];
            output[0] = rpart.Number;
            output[1] = impart.Number;
            return output;
        }
        public override string ToString()   //ToString() override
        {
            return rpart.ToString() + impart.ToString(); //ex. 5+3i
        }
        
        public static Complex Add(Complex a, Complex b)//Complex number addition
        {
            Complex result = new Complex(a.GetComplex());
            result.rpart.Number += b.rpart.Number;
            result.impart.Number += b.impart.Number;
            return result;
        }
        public static Complex Sub(Complex a, Complex b)//Complex number substraction
        {
            Complex result = new Complex(a.GetComplex());
            result.rpart.Number -= b.rpart.Number;
            result.impart.Number -= b.impart.Number;
            return result;
        }
        public static Complex Mul(Complex a, Complex b)//Complex number multiplication
        {
            Complex result = new Complex();
            result.rpart.Number = a.rpart.Number * b.rpart.Number - a.impart.Number * b.impart.Number;
            result.impart.Number = a.rpart.Number * b.impart.Number + a.impart.Number * b.rpart.Number;
            return result;
        }
        public static Complex Div(Complex a, Complex b)//Complex number division
        {
            Complex result = new Complex();
            result.rpart.Number = (a.rpart.Number * b.rpart.Number + a.impart.Number * b.impart.Number) / (b.rpart.Number * b.rpart.Number + b.impart.Number * b.impart.Number);
            result.impart.Number = (a.impart.Number * b.rpart.Number + a.rpart.Number * b.impart.Number) / (b.rpart.Number * b.rpart.Number + b.impart.Number * b.impart.Number);
            return result;
        }
        public static bool Equ(Complex a, Complex b)//Complex number comparing
        {
            return (a.rpart.Number == b.rpart.Number) && (a.impart.Number == b.impart.Number);
        }
        public static Complex Conj(Complex a)//Complex number conjugation
        {
            Complex result = new Complex(a.GetComplex());
            result.impart.Number = -a.impart.Number;
            return result;
        }
        public static Complex Sqrt(Complex a)//Complex number square root
        {
            Complex result = new Complex(a.GetComplex());
            double realpart;
            double imgpart;
            realpart = Math.Sqrt((Math.Sqrt(result.rpart.Number * result.rpart.Number + result.impart.Number * result.impart.Number) + result.rpart.Number) / 2);
            imgpart = Math.Sqrt((Math.Sqrt(result.rpart.Number * result.rpart.Number + result.impart.Number * result.impart.Number) - result.rpart.Number) / 2);
            result.rpart.Number = realpart;
            result.impart.Number = imgpart;  
            return result;  // both + and -
        }
    }

    
}


public class ComplexDemo
    {
    static void Main(string[] args)
    {
        Complex a = new Complex(1.25, 5.901);
        double[] temp = { -0.13, 42 };
        Complex b = new Complex(temp);
        Console.WriteLine("First complex number: " + a);
        Console.WriteLine("Second complex number: " + b);
        Console.WriteLine("Addition: " + a + " " + b + " = " + Complex.Add(a, b));
        Console.WriteLine("Subtraction: " + a + " - " + b + " = " + Complex.Sub(a, b));
        Console.WriteLine("Multiplication: " + a + " * " + b + " = " + Complex.Mul(a, b));
        Console.WriteLine("Division: " + a + " / " + b + " = " + Complex.Div(a, b));
        Console.WriteLine("Comparison: " + a + " == " + b + " is " + Complex.Equ(a, b));
        Console.WriteLine("First number Conjugation: " + a + " = " + Complex.Conj(a));
        Console.WriteLine("Second number Conjugation: " + b + " = " + Complex.Conj(b));
        Console.WriteLine("First number positive Square Root: " + a + " = " + Complex.Sqrt(a));
        Console.WriteLine("Second number positive Square Root: " + b + " = " + Complex.Sqrt(b));

        Console.WriteLine("Press Enter...");
        Console.ReadLine();
    }
}
