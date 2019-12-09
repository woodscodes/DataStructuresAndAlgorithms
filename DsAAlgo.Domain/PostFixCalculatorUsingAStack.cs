using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsAAlgo.Domain
{
    public class PostFixCalculatorUsingAStack
    {
        private Stack<int> _values = new Stack<int>();

        public void GetPostfixedAnswer(string[] args)
        {
            foreach (var token in args)
            {
                int value;
                if(int.TryParse(token, out value))
                {
                    _values.Push(value);
                }
                else
                {
                    int rhs = _values.Pop();
                    int lhs = _values.Pop();

                    switch (token)
                    {
                        case "+":
                            _values.Push(lhs + rhs);
                            break;
                        case "-":
                            _values.Push(lhs - rhs);
                            break;
                        case "*":
                            _values.Push(lhs * rhs);
                            break;
                        case "/":
                            _values.Push(lhs / rhs);
                            break;
                        case "%":
                            _values.Push(lhs % rhs);
                            break;
                        default:
                            throw new NotImplementedException(string.Format("Unrecognized token {0}", token));                            
                    }
                }
            }

            Console.WriteLine("Answer is {0}", _values.Pop());
        }

    }
}
