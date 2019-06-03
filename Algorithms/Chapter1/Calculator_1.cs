using System;
using System.Collections.Generic;

namespace Algorithms.Chapter1
{
    class Calculator_1
    {
        static void Calculate()
        {
            Stack<string> ops = new Stack<string>();
            Stack<double> vals = new Stack<double>();
            string s = Console.ReadLine();
            while (!string.IsNullOrEmpty(s))
            {
                switch (s)
                {
                    case "(": break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "sqrt":
                        ops.Push(s);
                        break;
                    case ")":
                        string op = ops.Pop();
                        double v = vals.Pop();
                        switch (op)
                        {
                            case "+":
                                v = vals.Pop() + v;
                                break;
                            case "-": v = vals.Pop() - v; break;
                            case "*":
                                v = vals.Pop() * v;
                                break;
                            case "/":
                                v = vals.Pop() / v;
                                break;
                            case "sqrt":
                                v = Math.Sqrt(v);
                                break;
                        }

                        vals.Push(v);
                        break;
                    default:
                        vals.Push(double.Parse(s));
                        break;
                }
                s = Console.ReadLine();
            }
            Console.WriteLine(vals.Pop());
        }
    }
}
