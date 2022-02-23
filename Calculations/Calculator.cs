using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class Calculator
    {

        public double Add(double numberOne, double numberTwo) { return numberOne + numberTwo; }
        public double Add(double[] number)
        {
            double sum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                sum = sum + number[i];
            }
            return sum;
        }

        public double Sub(double numberOne, double numberTwo) { return numberOne - numberTwo; }

        public double Sub(double[] number)
        {
            double sum = number[0];
            for (int i = 1; i < number.Length; i++)
            {
                sum = sum - number[i];
            }
            return sum;
        }

        public double Multi(double numberOne, double numberTwo) { return numberOne * numberTwo; }

        public double Div(double numberOne, double numberTwo) {
            if(numberTwo == 0)
            {
                throw new DivideByZeroException("Division by zero is not possible." );
            }
            return numberOne / numberTwo; }
    }
}
