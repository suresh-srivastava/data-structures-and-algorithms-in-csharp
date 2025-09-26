//TowerOfHanoi.cs : Program to solve Tower of Hanoi problem using recursion.

using System;

namespace TowerOfHanoiDemo
{
    class TowerOfHanoiDemo
    {
	    static void Tofh(int ndisk, char source, char temp, char dest)
	    {
		    if(ndisk == 1)
		    {
                Console.WriteLine("Move Disk " + ndisk + " from " + source + "-->" + dest);
			    return;
		    }

		    Tofh(ndisk-1, source, dest, temp);
		    Console.WriteLine("Move Disk " + ndisk + " from " + source + "-->" + dest);
		    Tofh(ndisk-1, temp, source, dest);
	    }//End of Tofh()

        static void Main(string[] args)
        {
		    char source='A', temp='B', dest='C';
		    int ndisk = 3;

		    Console.WriteLine("Sequence is :");
		    Tofh(ndisk, source, temp, dest);

        }//End of Main()
    }//End of class TowerOfHanoiDemo
}//End of namespace TowerOfHanoiDemo

