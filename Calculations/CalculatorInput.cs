using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class CalculatorInput
    {
        Calculator cal = new Calculator();
        public void Start()
        {
            MainMenu();
        }

        //Menu that handles choice of mathematical method to use
        private void MainMenu()
        {
            bool choice = true;
           

            while (choice)
            {
                Console.Clear();
                int calculatorChoice = menu();

                switch (calculatorChoice)
                {
                    case 1:
                        {
                            Console.WriteLine(" Add numbers as follows and end on a number: 1+ 2+3....8 or -1+-10");
                            double result = InputArray('+');
                            Console.WriteLine("The sum is: " + result);
                            Console.WriteLine("Press a key to continue!");
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine(" Subtract numbers as follows and end on a number: 1-2,0-3....8,1 ");
                            double result = InputArray('-');
                            Console.WriteLine("The sum is: " + result);
                            Console.WriteLine("Press a key to continue!" );
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {

                            Console.WriteLine("The result of the multiplication: " + Multi());
                            Console.WriteLine("Press a key to continue!");
                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {

                            Console.WriteLine("The result of the division: " + Div());
                            Console.WriteLine("Press a key to continue!");
                            Console.ReadKey();
                            break;
                        }

                    case 9:
                        {
                            choice = false;
                            break;
                        }
                }

            }
        }
        //Menu options
        static int menu()
        {
            string count = "0";
            bool choice = true;
            Console.WriteLine("Choice what mathematical operation you want to preform:");
            Console.WriteLine("1. Addition.");
            Console.WriteLine("2. Subtraction.");
            Console.WriteLine("3. Multiplcation.");
            Console.WriteLine("4. Divide.");
            Console.WriteLine("9. Exit");
            do
            {
                count = Console.ReadLine();
                choice = ControlInteger(count);
            } while (choice);
            return Convert.ToInt32(count);

        }
        //Method that gets input from InputNumbers and call method Multi in th class Calculator and returns the result.
        public double Multi()
        {
            double numberOne = InputNumber("First");
            double numberTwo = InputNumber("Second");

            return cal.Multi(numberOne, numberTwo);
        }
        //Method that gets input from InputNumbers and call method Div in th class Calculator and returns the result.
        // It handles exeptions that can be thrown in the Calculator class.
        public double Div()
        {
            double numberOne = InputNumber("First");
            double numberTwo = InputNumber("Second");
            double result = 0;
            
            try
            {
                result = cal.Div(numberOne, numberTwo);
            }catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        //A text string is converted to a double and returned. ControllDouble is called and return a boolean that determines if the string contains a double.
        // It returns a double value
        public double InputNumber(string textSequence)
        {
            string textNumber;
            double number = 0;
            Console.WriteLine(textSequence + " number: ");
            textNumber = Console.ReadLine();
            if (!ControlDouble(textNumber))
            {
                number = Convert.ToDouble(textNumber);
            }
            return number;
        }

        //Control if string contains a integer and returns a boolean. Use try catch to catch execptions.
        public static bool ControlInteger(string number)
        {
            bool notInt = true;
            
                try
                {
                    int.Parse(number);
                    notInt = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Your input was not a integer. Please input a integer, example 1 or 2.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you inputed is to big.");
                }
            
            return notInt;
        }
        //Control if string contains a double and returns a boolean. Use try catch to catch execptions.
        public bool ControlDouble(string number)
        {
            bool notInt = true;
            
                try
                {
                    double temp = double.Parse(number);
                    notInt = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Your input was not a number. Please input a number, example 1, 1,0 or -2,1.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you inputed is to big.");
                }
            
            return notInt;
        }
        // Method that reads in a text string and calls ToDouble with sends in the text string and the token it gets from the calling method.
        // It gets a array and calls the Calcorlator class method decide by the token. And it returns a double with the result of the operation.
        public double InputArray(char token)
        {
            double result=0;
            string numbers = Console.ReadLine();
            double[] values = ToDoubleArray(numbers, token);
            if(token == '+')
            {
                if (values.Length == 2)
                {
                    result =cal.Add(values[0], values[1]);
                }
                else if(values.Length > 2)
                {
                    result = cal.Add(values);
                }
                else
                {
                    result = 0;
                }
            }else
            {
                if (values.Length == 2)
                {
                    result = cal.Sub(values[0], values[1]);
                }
                else if (values.Length > 2)
                {
                    result = cal.Sub(values);
                }
                else
                {
                    result = 0;
                }

            }
            return result;
        }

        // Method that decides how many number there is in the textstring and return a int
        public int LengthOfNumbersArray(string numbers, char token)
        {
            int index = 0;
            if (!ControlDouble(char.ToString(numbers[numbers.Length - 1])))
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == token)
                    {
                        index++;
                    }
                }
            }                
            return index;
        }

        // Method that creates arrays of doubles and returns a array of doubles. It extract the numbers from the text string and store them in a array.
        // Error handling is done by try catch.
        public double[] ToDoubleArray(string numbers, char token)
        {
            int countIndex = LengthOfNumbersArray(numbers, token);
               
            double[] result = new double[countIndex + 1];
            
            countIndex = 0;
            StringBuilder stb = new StringBuilder();
            for (int i= 0; i < numbers.Length; i++)
            {
                
                if (numbers[i] != token)
                {
                    stb.Append(numbers[i]);
                }
                else if(i == 0 && numbers[0] == '-')
                {
                    stb.Append(numbers[i]);
                }
// Special case where the input is a negativ number. ned to single out the negativ number in the input.  2-2- -2 = 2 in input.Input don't use () to single out negsativ numbers
                {
                else if(i>0 && numbers[i-1] == '-' && numbers[i] == '-')
                    stb.Append(numbers[i]); 
                }
                else if(numbers[i] == token)
                {
                    try { 
                            result[countIndex] = Convert.ToDouble(stb.ToString());
                            stb.Clear();
                            countIndex++;
                    }catch (IndexOutOfRangeException)
                    {
                        break;
                        //Console.WriteLine("Index out of range exception : " );
                    }
                    catch (FormatException)
                    {
                        break;
                        //Console.WriteLine("Your input was not a number : " );
                    }
                }
            }
            try
            {

                result[countIndex] = Convert.ToDouble(stb.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("Your input was not a number : " );
                result = new double[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range exception : The last input was not a number" );
            }

            return result;  
            
        }
    }
}


