//ExpressionTree.cs : Program for Expression Tree.

using System;
using System.Collections.Generic;

namespace ExpressionTreeDemo
{
    class Node
    {
        public char info;
        public Node lchild;
        public Node rchild;

        public Node(char ch)
        {
            info = ch;
            lchild = null;
            rchild = null;
        }
    }//End of class Node

    class ExpressionTree
    {
        private Node root;

        public ExpressionTree()
        {
            root = null;
        }//End of ExpressionTree()

        private bool IsOperator(char c)
        {
            if(c == '+' || c == '-' || c == '*' || c == '/')
                return true;
            return false;
        }//End of IsOperator();	

        public void BuildTree(String postfix)
        {
            Stack<Node> treeStack = new Stack<Node>();
            Node t;

            for (int i = 0; i < postfix.Length; i++)
            {
                if(IsOperator(postfix[i]))
                {
                    t = new Node(postfix[i]);
                    t.rchild = treeStack.Pop();
                    t.lchild = treeStack.Pop();
                    treeStack.Push(t);
                }
                else	//operand
                {
                    t = new Node(postfix[i]);
                    treeStack.Push(t);
                }
            }

            root = treeStack.Pop();

        }//End of BuildTree()	

        private void Preorder(Node p)
	    {
		    if(p == null)	//Base case
			    return;

		    Console.Write(p.info);
		    Preorder(p.lchild);
		    Preorder(p.rchild);
	    }//End of Preorder()

        public void Prefix()
	    {
		    Preorder(root);
		    Console.WriteLine();
	    }//End of Prefix()

        private void Postorder(Node p)
	    {
		    if(p == null)	//Base case
			    return;

		    Postorder(p.lchild);
		    Postorder(p.rchild);
		    Console.Write(p.info);
	    }//End of postorder()

        public void Postfix()
	    {
		    Postorder(root);
		    Console.WriteLine();
	    }//End of Postfix()

        private void Inorder(Node p)
	    {
		    if(p == null)	//Base case
			    return;

		    if(IsOperator(p.info))
			    Console.Write("(");

		    Inorder(p.lchild);
		    Console.Write(p.info);
		    Inorder(p.rchild);

		    if(IsOperator(p.info))
                Console.Write(")");

	    }//End of Inorder()

        public void ParenthesizedInfix()
	    {
		    Inorder(root);
		    Console.WriteLine();
	    }//End of ParenthesizedInfix()

        private void Display(Node p, int level)
	    {
		    if(p == null)
			    return;

		    Display(p.rchild, level+1);
		    Console.WriteLine();

		    for(int i=0; i<level; i++)
			    Console.Write("    ");
		    Console.Write(p.info);

		    Display(p.lchild, level+1);

	    }//End of Display()

        public void Display()
	    {
		    Display(root, 0);
		    Console.WriteLine();
	    }//End of Display()	

        private int Evaluate(Node p)
        {
            int value = 0;

            if(!IsOperator(p.info))
                return p.info - 48;

            int leftValue = Evaluate(p.lchild);
            int rightValue = Evaluate(p.rchild);

            if(p.info == '+')
                value = leftValue + rightValue;
            else if(p.info == '-')
                value = leftValue - rightValue;
            else if(p.info == '*')
                value = leftValue * rightValue;
            else if(p.info == '/')
                value = leftValue / rightValue;

            return value;
        }//End of Evaluate()

        public int Evaluate()
        {
            if (root == null)
                return 0;

            return Evaluate(root);
        }//End of evaluate()

    }//End of class ExpressionTree

    class ExpressionTreeDemo
    {
        static void Main(string[] args)
        {
		    ExpressionTree expTree = new ExpressionTree();

		    String postfix = "54+12*3*-";

		    expTree.BuildTree(postfix);
		    expTree.Display();

            Console.WriteLine("Prefix : ");
		    expTree.Prefix();

		    Console.WriteLine("Postfix : ");
		    expTree.Postfix();

		    Console.WriteLine("Infix : ");
		    expTree.ParenthesizedInfix();

		    Console.WriteLine("Evaluated Value : " + expTree.Evaluate());
        }//End of Main()
    }//End of class ExpressionTreeDemo
}//End of namespace ExpressionTreeDemo
