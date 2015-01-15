using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeConsoleExample
{
	 class Program
	 {
		  private const int mWidth = 20;
		  private const int mHeight = 20;

		  //Graphic related constants
		  private const int blockSize = 10;
		  private const int blockBuffer = blockSize + 2;
		  private const int edgeBuffer = 5;
		  private const int screenHeight = blockBuffer * mWidth + edgeBuffer * 2;
		  private const int screenWidth = blockBuffer * mHeight + edgeBuffer * 2;

		  //basic variables
		  private static int[,] board = new int[mWidth, mHeight];

		  static void Main(string[] args)
		  {
				buildField();

				burrowField();
				Console.ReadKey();

				
		  }

		  static void buildField()
		  {
				//Build Playing field.
				for(int y = 0; y < mHeight; y++)
				{
					 for(int x = 0; x < mWidth; x++)
					 {
						  Console.Write("X ");
					 }
					 Console.WriteLine();
				}
		  }

		  //Currently isn't used.
		  static void burrowField()
		  {
				//First, mark all positions at 1 to create the grid.
				for(int x = 0; x < mWidth; x++)
				{
					 for(int y = 0; y < mHeight; y++)
					 {
						  board[x, y] = 1;
					 }
				}
				//The board should be filled with ones.
				Random rng = new Random();
				//Start at 1,1 (the maze should have a buffer surrounding it, like a frame), and lable the beginning as the start.
				int w, h;
				w = 1;//Width
				h = 1;//Height
				board[1, 1] = 0;//Starting point
				int direction = 0;


				//Algorithm begin.
				while(complete() != true)
				{
					 direction = getDirection();
					 //1 is north
					 //2 is east
					 //3 is south
					 //4 is west
					 if(direction == 1)
					 {
						  h = h - 1; //Set position of what is being checked.
						  board[w,h] = 3;
						  updateField();
						  if(h == 0 || h == mHeight)
								h = h + 1;
						  else
						  {
								h = h - 1;
								if(h == 0 || h == mHeight)
									 
						  }
					 }
				}

				updateField();



				updateField();
		  }

		  //Currently isn't used.
		  static void updateField()
		  {
				//Function to change all integers to a single character.
				Console.Clear();
				for(int y = 0; y < mHeight; y++)
				{
					 for(int x = 0; x < mWidth; x++)
					 {
						  if(board[x, y] == 0)
								Console.Write("@ ");//Starting position.
						  else if(board[x, y] == 1)
								Console.Write("X ");//Wall or unburrowed
						  else if(board[x, y] == 2)
								Console.Write("O ");//Burrowed area
						  else if(board[x, y] == 3)
								Console.Write("H ");//Current area being checked
						  else if(board[x, y] == 4)
								Console.Write("= ");//unchecked burrowed area
					 }
					 Console.WriteLine();
				}
		  }

		  static bool complete()
		  {

				return false;
		  }
	 }
}
