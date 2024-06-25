using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace KeyzLibCalcul
{
    public class Calcul
    {
        public double Calculate(string expression)
        {
            expression = expression.Replace(',', '.');
            int i = 0;
            return Calculate(expression, ref i);
        }

        private double Calculate(string expression, ref int i)
        {
            Stack<double> resultStack = new Stack<double>();
            char op = '+';
            double num = 0;

            while (i < expression.Length)
            {
                char c = expression[i];

                if (c == '(')
                {
                    i++;
                    num = Calculate(expression, ref i);
                }
                else if (char.IsDigit(c) || c == '.' || (c == '-' && (i == 0 || expression[i - 1] == '(' || expression[i - 1] == '+' || expression[i - 1] == '-' || expression[i - 1] == '*' || expression[i - 1] == '/')))
                {
                    double decimalPlace = 1;
                    bool isFraction = false;
                    bool isNegative = false;
                    num = 0;

                    if (c == '-')
                    {
                        isNegative = true;
                        i++;
                    }

                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        if (expression[i] == '.')
                        {
                            isFraction = true;
                        }
                        else
                        {
                            int digit = expression[i] - '0';
                            if (isFraction)
                            {
                                decimalPlace /= 10;
                                num += digit * decimalPlace;
                            }
                            else
                            {
                                num = num * 10 + digit;
                            }
                        }
                        i++;
                    }
                    i--;

                    if (isNegative)
                    {
                        num = -num;
                    }
                }

                switch (op)
                {
                    case '+': resultStack.Push(num); break;
                    case '-': resultStack.Push(-num); break;
                    case '*': resultStack.Push(resultStack.Pop() * num); break;
                    case '/': resultStack.Push(resultStack.Pop() / num); break;
                    case '^': resultStack.Push(Math.Pow(resultStack.Pop(), num)); break;
                    case '%': resultStack.Push((int)resultStack.Pop() / (int)num); break;
                    case '!': resultStack.Push(Factorial((int)num)); break;
                }

                if (i < expression.Length)
                {
                    op = expression[i];
                    if (op == ')')
                    {
                        i++;
                        break;
                    }
                }

                i++;
            }

            double result = 0;
            while (resultStack.Count != 0)
            {
                result += resultStack.Pop();
            }

            return result;
        }

        private double Factorial(int num)
        {
            double fact = 1;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}