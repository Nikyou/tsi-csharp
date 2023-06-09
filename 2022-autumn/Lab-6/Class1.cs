using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; // !
namespace WindowsFormsApp13
{
    public class RealPart
    {
        private double number;
        public RealPart()
        {
            number = 0;
        }
        public RealPart(double a)
        {
            number = a;
        }
        public double Number
        {
            get { return number; }
            set { number = value; }
        }
        public override string ToString()   //ToString() override
        {
            return number.ToString();   //ex. 5
        }
    }
    public class ImaginaryPart
    {
        private double number;
        public ImaginaryPart()
        {
            number = 0;
        }
        public ImaginaryPart(double b)
        {
            number = b;
        }
        public double Number
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
        private string starttime = DateTime.Now.ToString("HH:mm:ss");
        private string author = "Nikita Goloviznins";
        public Complex()
        {
        }
        public Complex(double a, double b)
        {

            rpart.Number = a;  //real part
            impart.Number = b;  //imaginary part
            starttime = DateTime.Now.ToString("HH:mm:ss");
        }
        public Complex(double[] a)  //constructor using array of 2
        {
            if (a.Length != 2)
            {
                throw new ArgumentException("array must be double[2]");
            }
            rpart.Number = a[0];   //real part
            impart.Number = a[1];   //imaginary part
            starttime = DateTime.Now.ToString("HH:mm:ss");
        }
        public Complex(RealPart a, ImaginaryPart b)
        {

            rpart.Number = a.Number;  //real part
            impart.Number = b.Number;  //imaginary part
            starttime = DateTime.Now.ToString("HH:mm:ss");
        }
        //Below different variations of real, imaginary and double as input for constructor
        public Complex(RealPart a, double b)
        {

            rpart.Number = a.Number;  //real part
            impart.Number = b;  //imaginary part
            starttime = DateTime.Now.ToString("HH:mm:ss");
        }
        public Complex(double a, ImaginaryPart b)
        {

            rpart.Number = a;  //real part
            impart.Number = b.Number;  //imaginary part
            starttime = DateTime.Now.ToString("HH:mm:ss");
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
        public void Author()
        {
            { Console.WriteLine(author + " " + starttime); }
        }
    }
    public class ComplexList : ArrayList, ITypedList
    {
        // We announce that Person properties will be used. public
        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[]
        listAccessors)
        {
            return TypeDescriptor.GetProperties(typeof(Complex));
        }

        // Use the same name (this method is required for ITypedList) public
        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return "ComplexList";
        }
    }
}
