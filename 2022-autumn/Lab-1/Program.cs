using System;

namespace Lab1
{
    public class Complex
    {
        private double[] number = new double[2];
        private string starttime;
        private string author = "Nikita Goloviznins";
        public Complex(double a, double b)
        {

            number[0] = a;  //real part
            number[1] = b;  //imaginary part
            starttime = DateTime.Now.ToString("HH:mm:ss");
        }
        public Complex(double[] a)
        {
            if (a.Length != 2)
            {
                throw new ArgumentException("array must be double[2]");
            }
            number[0] = a[0];   //real part
            number[1] = a[1];   //imaginary part
            starttime = DateTime.Now.ToString("HH:mm:ss");
        }
        public double[] Number
        {
            get { return number; }
            set { number = value; }

        }
        public void Author()
        {
            { Console.WriteLine(author + " " + starttime); }
        }
        public static double[] Add(double[] a, double[] b) //Complex number addition
        {
            double[] result = a;
            result[0] += b[0];
            result[1] += b[1];
            return result;
        }
        public static Complex Add(Complex a, Complex b)//Complex number addition
        {
            Complex result = new Complex(a.Number);
            result.number[0] += b.number[0];
            result.number[1] += b.number[1];
            return result;
        }

        public static double[] Sub(double[] a, double[] b)//Complex number substraction
        {
            double[] result = a;
            result[0] -= b[0];
            result[1] -= b[1];
            return result;
        }
        public static Complex Sub(Complex a, Complex b)//Complex number substraction
        {
            Complex result = new Complex(a.Number);
            result.number[0] -= b.number[0];
            result.number[1] -= b.number[1];
            return result;
        }

        public static double[] Mul(double[] a, double[] b)//Complex number multiplication
        {
            double[] result = new double[2];
            result[0] = a[0] * b[0] - a[1] * b[1];
            result[1] = a[0] * b[1] + a[1] * b[0];
            return result;
        }
        public static Complex Mul(Complex a, Complex b)//Complex number multiplication
        {
            Complex result = new Complex(a.Number);
            result.number[0] = a.number[0] * b.number[0] - a.number[1] * b.number[1];
            result.number[1] = a.number[0] * b.number[1] + a.number[1] * b.number[0];
            return result;
        }

        public static double[] Div(double[] a, double[] b)//Complex number division
        {
            double[] result = new double[2];
            result[0] = (a[0] * b[0] + a[1] * b[1]) / (b[0] * b[0] + b[1] * b[1]);
            result[1] = (a[1] * b[0] + a[0] * b[1]) / (b[0] * b[0] + b[1] * b[1]);
            return result;
        }
        public static Complex Div(Complex a, Complex b)//Complex number division
        {
            Complex result = new Complex(a.Number);
            result.number[0] = (a.number[0] * b.number[0] + a.number[1] * b.number[1]) / (b.number[0] * b.number[0] + b.number[1] * b.number[1]);
            result.number[1] = (a.number[1] * b.number[0] + a.number[0] * b.number[1]) / (b.number[0] * b.number[0] + b.number[1] * b.number[1]);
            return result;
        }

        public static bool Equ(double[] a, double[] b)//Complex number comparing
        {
            return a == b;
        }
        public static bool Equ(Complex a, Complex b)//Complex number comparing
        {
            return ((a.number[0] == b.number[0]) && (a.number[1] == b.number[1]));
        }

        public static double[] Conj(double[] a)//Complex number conjugation
        {
            double[] result = a;
            result[1] = -a[1];
            return result;
        }
        public static Complex Conj(Complex a)//Complex number conjugation
        {
            Complex result = new Complex(a.Number);
            result.number[1] = -a.number[1];
            return result;
        }
    }

    public class ComplexDemo
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(1.25, 5.901);
            double[] temp = { -0.13, 42 };
            Complex b = new Complex(temp);
            a.Author();
            Console.WriteLine("First complex number: (" + string.Join(" ", a.Number) + ")");
            Console.WriteLine("Second complex number: (" + string.Join(" ", b.Number) + ")");
            Console.WriteLine("Addition: (" + string.Join(" ", a.Number) + ") + (" + string.Join(" ", b.Number) + ") = (" + string.Join(" ", Complex.Add(a, b).Number) + ")");
            Console.WriteLine("Subtraction: (" + string.Join(" ", a.Number) + ") - (" + string.Join(" ", b.Number) + ") = (" + string.Join(" ", Complex.Sub(a, b).Number) + ")");
            Console.WriteLine("Multiplication: (" + string.Join(" ", a.Number) + ") * (" + string.Join(" ", b.Number) + ") = (" + string.Join(" ", Complex.Mul(a, b).Number) + ")");
            Console.WriteLine("Division: (" + string.Join(" ", a.Number) + ") / (" + string.Join(" ", b.Number) + ") = (" + string.Join(" ", Complex.Div(a, b).Number) + ")");
            Console.WriteLine("Comparison: (" + string.Join(" ", a.Number) + ") == (" + string.Join(" ", b.Number) + ") is " + Complex.Equ(a, b));
            Console.WriteLine("First number Conjugation: (" + string.Join(" ", a.Number) + ") = (" + string.Join(" ", Complex.Conj(a).Number) + ")");
            Console.WriteLine("Second number Conjugation: (" + string.Join(" ", b.Number) + ") = (" + string.Join(" ", Complex.Conj(b).Number) + ")");

            Console.WriteLine("Press Enter...");
            Console.ReadLine();
        }
    }
}
