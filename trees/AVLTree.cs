//AVLTree.cs : Program for AVL Tree.

using System;

namespace AVLTreeDemo
{
    class Node
    {
        public int info;
        public int balance;
        public Node lchild;
        public Node rchild;

        public Node(int key)
        {
            info = key;
            balance = 0;
            lchild = null;
            rchild = null;
        }
    }//End of class Node

    class AVLTree
    {
        private Node root;
        private bool taller;
        private bool shorter;

        public AVLTree()
        {
            root = null;
        }//End of AVLTree()

        public bool IsEmpty()
        {
            return root == null;
        }//End of IsEmpty()

        public void Display()
	    {
		    Display(root, 0);
            Console.WriteLine();
	    }//End of Display()

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

        private void Inorder(Node p)
	    {
		    if(p == null)	//Base Case
			    return;

		    Inorder(p.lchild);
		    Console.Write(p.info + " ");
		    Inorder(p.rchild);
	    }//End of Inorder()

        public void Inorder()
	    {
		    Inorder(root);
		    Console.WriteLine();
	    }//End of Inorder()	

        public void Insert(int key)
        {
            root = Insert(root, key);
        }//End of Insert()

        private Node Insert(Node p, int key)
	    {
		    if(p == null)		//Base case
		    {
			    p = new Node(key);
			    taller = true;
		    }
		    else if(key < p.info)		//Insertion in left subtree
		    {
			    p.lchild = Insert(p.lchild, key);
			    if(taller == true)
				    p = InsertionLeftSubtreeCheck(p);
		    }
		    else if(key > p.info)		//Insertion in right subtree
		    {
			    p.rchild = Insert(p.rchild, key);
			    if(taller == true)
				    p = InsertionRightSubtreeCheck(p);
		    }
		    else	//Base case
		    {
                Console.WriteLine(key + " is already there");
			    taller = false;
		    }

		    return p;
	    }//End of Insert()

        private Node InsertionLeftSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0:		//Case L_A : was balanced
                    p.balance = 1;	//now left heavy
                    break;
                case -1:	//Case L_B : was right heavy
                    p.balance = 0;	//now balanced
                    taller = false;
                    break;
                case 1:		//Case L_C : was left heavy
                    p = InsertionLeftBalance(p);	//left balancing
                    taller = false;
                    break;
            }

            return p;
        }//End of InsertionLeftSubtreeCheck()

        private Node InsertionLeftBalance(Node p)
        {
            Node a, b;

            a = p.lchild;
            if (a.balance == 1)	//Case L_C1 : Insertion in AL
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateRight(p);
            }
            else	//Case L_C2 : Insertion in AR
            {
                b = a.rchild;
                switch (b.balance)
                {
                    case -1:	//Case L_C2a : Insertion in BR
                        p.balance = 0;
                        a.balance = 1;
                        break;
                    case 1:		//Case L_C2b : Insertion in BL
                        p.balance = -1;
                        a.balance = 0;
                        break;
                    case 0:		//Case L_C2c : B is the newly inserted node
                        p.balance = 0;
                        a.balance = 0;
                        break;
                }

                b.balance = 0;
                p.lchild = RotateLeft(a);
                p = RotateRight(p);
            }

            return p;
        }//End of InsertionLeftBalance()	

        private Node InsertionRightSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0:		//Case R_A : was balanced
                    p.balance = -1;	//now right heavy
                    break;
                case 1:		//Case R_B : was left heavy
                    p.balance = 0;		//now balanced
                    taller = false;
                    break;
                case -1:	//Case R_C : was right heavy
                    p = InsertionRightBalance(p);	//right balancing
                    taller = false;
                    break;
            }

            return p;
        }//End of InsertionRightSubtreeCheck()	

        private Node InsertionRightBalance(Node p)
        {
            Node a, b;

            a = p.rchild;
            if (a.balance == -1)	//Case R_C1 : Insertion in AR
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateLeft(p);
            }
            else	//Case R_C2 : Insertion in AL
            {
                b = a.lchild;
                switch (b.balance)
                {
                    case -1:	//Case R_C2a : Insertion in BR
                        p.balance = 1;
                        a.balance = 0;
                        break;
                    case 1:		//Case R_C2b : Insertion in BL
                        p.balance = 0;
                        a.balance = -1;
                        break;
                    case 0:		//Case R_C2c : B is the newly inserted node
                        p.balance = 0;
                        a.balance = 0;
                        break;
                }
                b.balance = 0;
                p.rchild = RotateRight(a);
                p = RotateLeft(p);
            }

            return p;
        }//End of InsertionRightBalance()	

        private Node RotateRight(Node p)
        {
            Node a;

            a = p.lchild;			//A is left child of P
            p.lchild = a.rchild;	//Right child of A becomes left child of P	
            a.rchild = p;			//P becomes right child of A
            return a;				//A is the new root of the subtree initially rooted at P
        }//End of RotateRight()

        private Node RotateLeft(Node p)
        {
            Node a;

            a = p.rchild;			//A is right child of P
            p.rchild = a.lchild;	//Left child of A becomes right child of P
            a.lchild = p;			//P becomes left child of A
            return a;				//A is the new root of the subtree initially rooted at P
        }//End of RotateLeft()

        public void Del(int key)
        {
            root = Del(root, key);
        }//End of Del()	

        private Node Del(Node p, int key)
	    {
		    Node succ;

		    if(p == null)		//Base case
		    {
                Console.WriteLine(key + " not found");
			    shorter = false;
			    return p;
		    }

		    if(key < p.info)	//Delete from left subtree
		    {
			    p.lchild = Del(p.lchild, key);
			    if(shorter == true)
				    p = DeletionLeftSubtreeCheck(p);
		    }
		    else if(key > p.info)	//Delete from right subtree
		    {
			    p.rchild = Del(p.rchild, key);
			    if(shorter == true)
				    p = DeletionRightSubtreeCheck(p);
		    }
		    else	//key to be deleted is found, Base case
		    {
			
			    if(p.lchild!=null && p.rchild!=null)	//2 children
			    {
				    succ = p.rchild;
				    while(succ.lchild != null)
					    succ = succ.lchild;
				    p.info = succ.info;
				    p.rchild = Del(p.rchild, succ.info);
				    if(shorter == true)
					    p = DeletionRightSubtreeCheck(p);
			    }
			    else	//1 child or no child
			    {
				    if(p.lchild != null)	//Only left child
					    p = p.lchild;
				    else	//Only right child or no child
					    p = p.rchild;
				    shorter = true;
			    }
		    }

		    return p;
	    }//End of Del()	

        private Node DeletionLeftSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0:		//Case L_A : was balanced
                    p.balance = -1;	//now right heavy
                    shorter = false;
                    break;
                case 1:		//Case L_B : was left heavy
                    p.balance = 0;		//now balanced
                    break;
                case -1:	//Case L_C : was right heavy
                    p = DeletionRightBalance(p);	//right balancing
                    break;
            }

            return p;
        }//End of DeletionLeftSubtreeCheck()

        private Node DeletionRightBalance(Node p)
        {
            Node a, b;

            a = p.rchild;
            if (a.balance == 0)		//Case L_C1
            {
                a.balance = 1;
                shorter = false;
                p = RotateLeft(p);
            }
            else if (a.balance == -1)	//Case L_C2
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateLeft(p);
            }
            else	//Case L_C3
            {
                b = a.lchild;
                switch (b.balance)
                {
                    case 0:		//Case L_C3a
                        p.balance = 0;
                        a.balance = 0;
                        break;
                    case 1:		//Case L_C3b
                        p.balance = 0;
                        a.balance = -1;
                        break;
                    case -1:	//Case L_C3c
                        p.balance = 1;
                        a.balance = 0;
                        break;
                }
                b.balance = 0;
                p.rchild = RotateRight(a);
                p = RotateLeft(p);
            }

            return p;
        }//End of DeletionRightBalance()	

        private Node DeletionRightSubtreeCheck(Node p)
        {
            switch (p.balance)
            {
                case 0:		//Case R_A : was balanced
                    p.balance = 1;		//now left heavy
                    shorter = false;
                    break;
                case -1:	//Case R_B : was right heavy
                    p.balance = 0;		//now balanced
                    break;
                case 1:		//Case R_C : was left heavy
                    p = DeletionLeftBalance(p);		//left balancing
                    break;
            }

            return p;
        }//End of DeletionRightSubtreeCheck()	

        private Node DeletionLeftBalance(Node p)
        {
            Node a, b;

            a = p.lchild;
            if (a.balance == 0)		//Case R_C1
            {
                a.balance = -1;
                shorter = false;
                p = RotateRight(p);
            }
            else if (a.balance == 1)	//Case R_C2
            {
                p.balance = 0;
                a.balance = 0;
                p = RotateRight(p);
            }
            else	//Case R_C3
            {
                b = a.rchild;
                switch (b.balance)
                {
                    case 0:		//Case R_C3a
                        p.balance = 0;
                        a.balance = 0;
                        break;
                    case 1:		//Case R_C3b
                        p.balance = -1;
                        a.balance = 0;
                        break;
                    case -1:	//Case R_C3c
                        p.balance = 0;
                        a.balance = 1;
                        break;
                }
                b.balance = 0;
                p.lchild = RotateLeft(a);
                p = RotateRight(p);
            }

            return p;
        }//End of DeletionLeftBalance()	

    }//End of class AVLTree

    class AVLTreeDemo
    {
        static void Main(string[] args)
        {
		    AVLTree avlTree = new AVLTree();

		    avlTree.Insert(50);
            Console.WriteLine("Tree after inserting 50");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(40);
		    Console.WriteLine("Tree after inserting 40");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(35);
		    Console.WriteLine("Tree after insertiing 35");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(58);
		    Console.WriteLine("Tree after inserting 58");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(48);
		    Console.WriteLine("Tree after inserting 48");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(42);
		    Console.WriteLine("Tree after inserting 42");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(60);
		    Console.WriteLine("Tree after inserting 60");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(30);
		    Console.WriteLine("Tree after inserting 30");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(33);
		    Console.WriteLine("Tree after inserting 33");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Insert(25);
		    Console.WriteLine("Tree after inserting 25");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Del(60);
		    Console.WriteLine("Tree after deleting 60");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Del(48);
		    Console.WriteLine("Tree after deleting 48");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Del(25);
		    Console.WriteLine("Tree after deleting 25");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Del(30);
		    Console.WriteLine("Tree after deleting 30");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Del(35);
		    Console.WriteLine("Tree after deleting 35");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Del(33);
		    Console.WriteLine("Tree after deleting 33");
		    avlTree.Display();
		    Console.WriteLine();

		    avlTree.Del(58);
		    Console.WriteLine("Tree after deleting 58");
		    avlTree.Display();
		    Console.WriteLine();
        }//End of Main()
    }//End of class AVLTreeDemo
}//End of namespace AVLTreeDemo
