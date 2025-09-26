//Polynomial.cs : Program of Polynomial expression creation, addition and multiplication using linked list.

using System;

namespace PolynomialDemo
{
    class Node
    {
        public int coeff;
        public int expo;
        public Node link;

        public Node(int coefficient, int exponent)
        {
            coeff = coefficient;
            expo = exponent;
            link = null;
        }
    }//End of class Node

    class Polynomial
    {
        private Node start;

        public Polynomial()
        {
            start = null;
        }//End of Polynomial()

        public bool IsEmpty()
        {
            return (start == null);
        }//End of IsEmpty()

        public void Display()
	    {
		    Node p;

		    if(!IsEmpty())
		    {
			    p = start;
			    while(p != null)
			    {
				    Console.Write(p.coeff);
				    if(p.expo == 1)
					    Console.Write("x");
				    else if(p.expo > 1)
					    Console.Write("x^" + p.expo);
				    p = p.link;
				    if(p!=null)
					    Console.Write(" + ");
			    }
			    Console.WriteLine();
		    }
		    else
                Console.WriteLine("Zero polynomial");
	    }//End of Display()

        public void Insert(int coefficient, int exponent)
        {
            Node p, temp;

            temp = new Node(coefficient, exponent);
            //List empty or exponent greater than first one
            if (IsEmpty() || exponent > start.expo)
            {
                temp.link = start;
                start = temp;
            }
            else
            {
                p = start;
                while (p.link != null && p.link.expo >= exponent)
                    p = p.link;
                temp.link = p.link;
                p.link = temp;
            }
        }//End of Insert()	

        //Required for addition of polynomials
        public void InsertAtEnd(int coefficient, int exponent)
        {
            Node p, temp;

            temp = new Node(coefficient, exponent);

            if (IsEmpty())
                start = temp;
            else
            {
                p = start;
                while (p.link != null)
                    p = p.link;

                p.link = temp;
            }
        }//End of InsertAtEnd()

        public void Addition(Polynomial list, Polynomial resultList)
        {
            Node p1 = start;
            Node p2 = list.start;

            while (p1 != null && p2 != null)
            {
                if (p1.expo > p2.expo)
                {
                    resultList.Insert(p1.coeff, p1.expo);
                    p1 = p1.link;
                }
                else if (p2.expo > p1.expo)
                {
                    resultList.Insert(p2.coeff, p2.expo);
                    p2 = p2.link;
                }
                else if (p1.expo == p2.expo)
                {
                    resultList.Insert(p1.coeff + p2.coeff, p1.expo);
                    p1 = p1.link;
                    p2 = p2.link;
                }
            }
            //If poly2 is finished and elements left in poly1
            while (p1 != null)
            {
                resultList.Insert(p1.coeff, p1.expo);
                p1 = p1.link;
            }
            //If poly1 is finished and elements left in poly2
            while (p2 != null)
            {
                resultList.Insert(p2.coeff, p2.expo);
                p2 = p2.link;
            }

        }//End of Addition()	

        public void Multiplication(Polynomial list, Polynomial resultList)
	    {
		    Node p1 = start;
		    Node p2 = list.start;
		    Node p2Start = p2;

		    if(p1==null || p2==null)
			    Console.WriteLine("Multiplied polynomial is zero polynomial");
		    else
		    {
			    while(p1 != null)
			    {
				    p2 = p2Start;
				    while(p2 != null)
				    {
					    resultList.Insert(p1.coeff*p2.coeff, p1.expo+p2.expo);
					    p2 = p2.link;	
				    }
				    p1 = p1.link;
			    }
		    }

	    }//End of Multiplication()	

    }//End of class Polynomial

    class PolynomialDemo
    {
        static void Main(string[] args)
        {
    	    Polynomial list1 = new Polynomial();
    	    Polynomial list2 = new Polynomial();
    	    Polynomial list3 = new Polynomial();
    	    Polynomial list4 = new Polynomial();

    	    list1.Insert(4,3);
    	    list1.Insert(5,2);
    	    list1.Insert(-3,1);

    	    Console.WriteLine("Polynomial List1 :");
    	    list1.Display();

    	    list2.Insert(2,5);
    	    list2.Insert(6,4);
    	    list2.Insert(1,2);
    	    list2.Insert(8,0);

    	    Console.WriteLine("Polynomial List2 :");
    	    list2.Display();

    	    //Polynomial addition
    	    list1.Addition(list2, list3);

    	    Console.WriteLine("After addition of list1 and list2 :");
    	    list3.Display();

    	    //Polynomial multiplication
    	    list1.Multiplication(list2, list4);

            Console.WriteLine("After multiplication of list1 and list2 :");
    	    list4.Display();
        }//End of Main()
    }//End of class PolynomialDemo
}//End of namespace PolynomialDemo
