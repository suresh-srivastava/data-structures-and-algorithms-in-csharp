//RedBlackTree.cs : Program for Red Black Tree.

using System;

namespace RedBlackTreeDemo
{
    class Node
    {
        public enum Color { BLACK, RED } ;
        public Color color;
        public int info;
        public Node lchild;
        public Node rchild;
        public Node parent;

        public Node(int key)
        {
            info = key;
            lchild = null;
            rchild = null;
            parent = null;
        }
    }//End of class Node

    class RedBlackTree
    {
        private Node root;
        private Node sentinel;	//will be parent of root and replace null

        public RedBlackTree()
        {
            sentinel = new Node(-1);
            sentinel.color = Node.Color.BLACK;
            root = sentinel;
        }//End of RedBlackTree()	

        public void Insert(int key)
	    {
		    Node parent = sentinel;
		    Node p = root;

		    while(p != sentinel)
		    {
			    parent = p;
			    if(key < p.info)
				    p = p.lchild;
			    else if(key > p.info)
				    p = p.rchild;
			    else
			    {
				    Console.WriteLine(key + " is already there");
				    return;
			    }
		    }

		    Node temp = new Node(key);
		    temp.lchild = sentinel;
		    temp.rchild = sentinel;
		    temp.color = Node.Color.RED;
		    temp.parent = parent;

		    if(parent == sentinel)
			    root = temp;
		    else if(temp.info < parent.info)
			    parent.lchild = temp;
		    else
			    parent.rchild = temp;

		    InsertionBalance(temp);

	    }//End of Insert()	

        private void InsertionBalance(Node n)
        {
            Node uncle, parent, grandParent;

            while (n.parent.color == Node.Color.RED)
            {
                parent = n.parent;
                grandParent = parent.parent;

                if (parent == grandParent.lchild)
                {
                    uncle = grandParent.rchild;
                    if (uncle.color == Node.Color.RED)	//Case L_1
                    {
                        parent.color = Node.Color.BLACK;
                        uncle.color = Node.Color.BLACK;
                        grandParent.color = Node.Color.RED;
                        n = grandParent;
                    }
                    else	//uncle is black
                    {
                        if (n == parent.rchild)		//Case L_2a
                        {
                            RotateLeft(parent);
                            n = parent;
                            parent = n.parent;
                        }
                        parent.color = Node.Color.BLACK;	//Case L_2b
                        grandParent.color = Node.Color.RED;
                        RotateRight(grandParent);
                    }
                }//End of if
                else
                {
                    if (parent == grandParent.rchild)
                    {
                        uncle = grandParent.lchild;
                        if (uncle.color == Node.Color.RED)	//Case R_1
                        {
                            parent.color = Node.Color.BLACK;
                            uncle.color = Node.Color.BLACK;
                            grandParent.color = Node.Color.RED;
                            n = grandParent;
                        }
                        else	//uncle is black
                        {
                            if (n == parent.lchild)	//Case R_2a
                            {
                                RotateRight(parent);
                                n = parent;
                                parent = n.parent;
                            }
                            parent.color = Node.Color.BLACK;	//Case R_2b
                            grandParent.color = Node.Color.RED;
                            RotateLeft(grandParent);
                        }

                    }//End of if

                }//End of else

            }//End of while

            root.color = Node.Color.BLACK;

        }//End of InsertionBalance()	

        private Node GetSuccessor(Node location)
        {
            Node p = location.rchild;
            while (p.lchild != sentinel)
                p = p.lchild;

            return p;
        }//End of GetSuccessor()	

        Node Find(int key)
        {
            Node location;
            Node p;

            if (root == sentinel)	//Tree is empty
            {
                location = sentinel;
                return null;
            }

            if (key == root.info)	//key is at root
            {
                location = root;
                return location;
            }

            //Initialize p
            if (key < root.info)
                p = root.lchild;
            else
                p = root.rchild;

            while (p != sentinel)
            {
                if (key == p.info)
                {
                    location = p;
                    return location;
                }

                if (key < p.info)
                    p = p.lchild;
                else
                    p = p.rchild;
            }//End of while

            location = sentinel;	//key not found
            return null;
        }//End of Find()		

        public void Del(int key)
	    {	
		    Node p = Find(key);

		    if(p==null)
		    {
			    Console.WriteLine("Key not present");
			    return;
		    }
	
		    if(p.lchild!=sentinel && p.rchild!=sentinel)
		    {
			    Node succ = GetSuccessor(p);
			    p.info = succ.info;
			    p = succ;
		    }

		    Node child;

		    if(p.lchild != sentinel)
			    child = p.lchild;
		    else
			    child = p.rchild;

		    child.parent = p.parent;

		    if(p.parent == sentinel)
			    root = child;
		    else if(p == p.parent.lchild)
			    p.parent.lchild = child;
		    else
			    p.parent.rchild = child;

		    if(child == root)
			    child.color = Node.Color.BLACK;
		    else if(p.color == Node.Color.BLACK)	//black node
		    {
			    if(child != sentinel)	//one child which is red
				    child.color = Node.Color.BLACK;
			    else	//no child
				    DeletionBalance(child);
		    }

	    }//End of Del()

        private void DeletionBalance(Node n)
        {
            Node sib;

            while (n != root)
            {
                if (n == n.parent.lchild)
                {
                    sib = n.parent.rchild;

                    if (sib.color == Node.Color.RED)		//Case L_1
                    {
                        sib.color = Node.Color.BLACK;
                        n.parent.color = Node.Color.RED;
                        RotateLeft(n.parent);
                        sib = n.parent.rchild;	//new sibling
                    }

                    if (sib.lchild.color == Node.Color.BLACK && sib.rchild.color == Node.Color.BLACK)
                    {
                        sib.color = Node.Color.RED;
                        if (n.parent.color == Node.Color.RED)	//Case L_2a
                        {
                            n.parent.color = Node.Color.BLACK;
                            return;
                        }
                        else
                            n = n.parent;	//Case L_2b
                    }
                    else
                    {
                        if (sib.rchild.color == Node.Color.BLACK)	//Case L_3a
                        {
                            sib.lchild.color = Node.Color.BLACK;
                            sib.color = Node.Color.RED;
                            RotateRight(sib);
                            sib = n.parent.rchild;
                        }
                        sib.color = n.parent.color;	//Case L_3b
                        n.parent.color = Node.Color.BLACK;
                        sib.rchild.color = Node.Color.BLACK;
                        RotateLeft(n.parent);
                        return;
                    }

                }//End of if
                else
                {
                    sib = n.parent.lchild;
                    if (sib.color == Node.Color.RED)		//Case R_1
                    {
                        sib.color = Node.Color.BLACK;
                        n.parent.color = Node.Color.RED;
                        RotateRight(n.parent);
                        sib = n.parent.lchild;
                    }

                    if (sib.rchild.color == Node.Color.BLACK && sib.lchild.color == Node.Color.BLACK)
                    {
                        sib.color = Node.Color.RED;
                        if (n.parent.color == Node.Color.RED)	//Case R_2a
                        {
                            n.parent.color = Node.Color.BLACK;
                            return;
                        }
                        else
                            n = n.parent;	//Case R_2b
                    }
                    else
                    {
                        if (sib.lchild.color == Node.Color.BLACK)	//Case R_3a
                        {
                            sib.rchild.color = Node.Color.BLACK;
                            sib.color = Node.Color.RED;
                            RotateLeft(sib);
                            sib = n.parent.lchild;
                        }

                        sib.color = n.parent.color;	//Case R_3b
                        n.parent.color = Node.Color.BLACK;
                        sib.lchild.color = Node.Color.BLACK;
                        RotateRight(n.parent);
                        return;
                    }

                }//End of else

            }//End of while

        }//End of DeletionBalance()	

        private void RotateRight(Node p)
        {
            Node a;

            a = p.lchild;			//A is left child of P
            p.lchild = a.rchild;	//Right child of A becomes left child of P

            if (a.rchild != sentinel)
                a.rchild.parent = p;
            a.parent = p.parent;

            if (p.parent == sentinel)
                root = a;
            else if (p == p.parent.rchild)
                p.parent.rchild = a;
            else
                p.parent.lchild = a;

            a.rchild = p;			//P becomes right child of A
            p.parent = a;
        }//End of RotateRight()

        private void RotateLeft(Node p)
        {
            Node a;

            a = p.rchild;			//A is right child of P
            p.rchild = a.lchild;	//Left child of A becomes right child of P

            if (a.lchild != sentinel)
                a.lchild.parent = p;
            a.parent = p.parent;

            if (p.parent == sentinel)
                root = a;
            else if (p == p.parent.lchild)
                p.parent.lchild = a;
            else
                p.parent.rchild = a;

            a.lchild = p;			//P becomes left child of A
            p.parent = a;

        }//End of RotateLeft()

        private void Inorder(Node p)
	    {
		    if(p != sentinel)
		    {
			    Inorder(p.lchild);
                Console.WriteLine(p.info);
			    Inorder(p.rchild);
		    }
	    }//End of Inorder()

        public void Inorder()
        {
            Inorder(root);
        }//End of Inorder()

        private void Display(Node p, int level)
	    {
		    if(p != sentinel)
		    {
			    Display(p.rchild, level+1);
			    Console.WriteLine();
			
			    for(int i=0; i<level; i++)
				    Console.Write("    ");
			    Console.Write(p.info);
			    if(p.color == Node.Color.RED)
				    Console.Write("^");
			    else
                    Console.Write("*");
			
			    Display(p.lchild, level+1);
		    }
	    }//End of Display()

        public void Display()
        {
            Display(root, 1);
        }//End of Display()

    }//End of class RedBlackTree

    class RedBlackTreeDemo
    {
        static void Main(string[] args)
        {
		    RedBlackTree rbTree = new RedBlackTree();

            Console.WriteLine("Tree after inserting 50");
		    rbTree.Insert(50);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 60");
		    rbTree.Insert(60);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 70");
		    rbTree.Insert(70);
		    rbTree.Display();
		    Console.WriteLine();

		    rbTree.Insert(40);
		    Console.WriteLine("Tree after inserting 40");
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 55");
		    rbTree.Insert(55);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 75");
		    rbTree.Insert(75);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 53");
		    rbTree.Insert(53);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 54");
		    rbTree.Insert(54);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 30");
		    rbTree.Insert(30);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 45");
		    rbTree.Insert(45);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 35");
		    rbTree.Insert(35);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after inserting 51");
		    rbTree.Insert(51);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after deleting 55");
		    rbTree.Del(55);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after deleting 50");
		    rbTree.Del(50);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after deleting 75");
		    rbTree.Del(75);
		    rbTree.Display();
		    Console.WriteLine();

		    Console.WriteLine("Tree after deleting 45");
		    rbTree.Del(45);
		    rbTree.Display();
		    Console.WriteLine();
        }//End of Main()
    }//End of class RedBlackTreeDemo
}//End of namespace RedBlackTreeDemo
