//CheckParentheses.cs : Program to check that parentheses in expression are valid or not.

using System;
using System.Collections.Generic;

namespace CheckParenthesesDemo
{
    class CheckParenthesesDemo
    {
        static bool MatchParentheses(char leftPar, char rightPar)
        {
            if (leftPar == '(' && rightPar == ')')
                return true;

            if (leftPar == '{' && rightPar == '}')
                return true;

            if (leftPar == '[' && rightPar == ']')
                return true;

            return false;
        }//End of MatchParentheses()

        static bool IsValid(String expr)
	    {
		    Stack<char> st = new Stack<char>();

		    for(int i=0; i<expr.Length; i++)
		    {
			    if(expr[i]=='(' || expr[i]=='{' || expr[i]=='[')
				    st.Push(expr[i]);

			    if(expr[i]==')' || expr[i]=='}' || expr[i]==']')
			    {
				    if(st.Count==0)
				    {
                        Console.WriteLine("Right parentheses are more than left parentheses");
					    return false;
				    }
				    else
				    {
					    char ch = st.Pop();
					    if(!MatchParentheses(ch, expr[i]))
					    {
						    Console.WriteLine("Parentheses are : ");
						    Console.WriteLine(ch + " and " + expr[i]);
						    return false;
					    }
				    }
			    }//End of if
		    }//End of for

		    if(st.Count==0)
		    {
			    Console.WriteLine("Balanced Parentheses");
			    return true;
		    }
		    else
		    {
			    Console.WriteLine("Left parantheses are more than right parantheses");
			    return false;
		    }
	    }//End of IsValid()

        static void Main(string[] args)
        {
		    String expression = "[A/(B-C)*D]";

            Console.WriteLine("Expression is : " + expression);

		    if(IsValid(expression))
			    Console.WriteLine("Valid expression");
		    else
			    Console.WriteLine("Invalid expression");
        }//End of Main()
    }//End of class CheckParenthesesDemo
}//End of namespace CheckParenthesesDemo
