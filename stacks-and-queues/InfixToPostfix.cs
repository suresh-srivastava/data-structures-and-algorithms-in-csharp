//InfixToPostfix.cs : Program to covert infix to postfix and evaluate the postfix 
//expression. It will evaluate only single digit numbers.

using System;
using System.Collections.Generic;

namespace InfixToPostfixDemo
{
    class InfixToPostfixDemo
    {
	    static int Power(int b, int a)
	    {
		    int result=1;

		    for(int i=1; i<=a; i++)
			    result *= b;

		    return result;
	    }//End of Power()

	    static int EvaluatePostfix(String postfix)
	    {
		    char symbol;
		    int a, b, temp=0;
		    Stack<int> st = new Stack<int>();

		    for(int i=0; i<postfix.Length; i++)
		    {
			    symbol = postfix[i];

			    if(symbol-'0' >= 0 && symbol-'0' <= 9)
			    {
				    st.Push(symbol-'0');
			    }
			    else
			    {
				    a = st.Pop();
				    b = st.Pop();

				    switch(symbol)
				    {
					    case '+':
						    temp = b+a; break;
					    case '-':
						    temp = b-a; break;
					    case '*':
						    temp = b*a; break;
					    case '/':
						    temp = b/a; break;
					    case '%':
						    temp = b%a; break;
					    case '^':
						    temp = Power(b, a); break;
				    }//End of switch

				    st.Push(temp);
			    }//End of else
		    }//End of for

		    return st.Pop();
	    }//End of EvaluatePostfix()	

	    static int Precedence(char symbol)
	    {
		    switch(symbol)
		    {
			    case '(':
				    return 0;
			    case '+':
			    case '-':
				    return 1;
			    case '*':
			    case '/':
			    case '%':
				    return 2;
			    case '^':
				    return 3;
			    default:
				    return 0;
		    }
	    }//End of Precedence()

	    static String InfixToPostfix(String infix)
	    {
		    String postfix = "";
		    char symbol;
		    Stack<char> st = new Stack<char>();

		    for(int i=0; i<infix.Length; i++)
		    {
			    symbol = infix[i];

			    switch(symbol)
			    {
				    case '(':
					    st.Push(symbol);
					    break;
				    case ')':
					    while(st.Peek() != '(')
					    {
						    postfix += st.Pop();
					    }
					    st.Pop();
					    break;
				    case '+':
				    case '-':
				    case '*':
				    case '/':
				    case '%':
				    case '^':
					    while(st.Count!=0 && ( Precedence(st.Peek()) >= Precedence(symbol) ) )
					    {
						    postfix += st.Pop();
					    }
					    st.Push(symbol);
					    break;
				    default:
					    postfix += symbol;
					    break;
			    }//End of switch
		    }//End of for

		    while(st.Count!=0)
		    {
			    postfix += st.Pop();
		    }
		
		    return postfix;
	    }//End of InfixToPostfix()

        static void Main(string[] args)
        {
		    String infix = "7+5*3^2/(9-2^2)+6*4";
		    String postfix;

            Console.WriteLine("Infix expression is : " + infix);

		    postfix = InfixToPostfix(infix);

		    Console.WriteLine("Postfix expression is :");
		    Console.WriteLine(postfix);

		    Console.WriteLine("Value of expression is :");
		    Console.WriteLine(EvaluatePostfix(postfix));
        }//End of Main()
    }//End of class InfixToPostfixDemo
}//End of namespace InfixToPostfixDemo
