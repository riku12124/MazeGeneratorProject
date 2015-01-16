using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeConsoleExample
{
	 class BoardSystem
	 {
		  //This object will keep track of where everything is, and how far back the board needs to reset.
		  //this object will also have methods to get a new direction for the board, and also translate the information
		  //into an output form.
		  private int[,] board;
		  private int mHeight, mWidth;

		  //Reference to the XNA version.
		  /*const int blockSize = 10;
		  const int blockBuffer = blockSize + 2;
		  const int edgeBuffer = 5;
		  const int screenHeight = blockBuffer * mWidth + edgeBuffer * 2;
		  const int screenWidth = blockBuffer * mHeight + edgeBuffer * 2;*/

		  public BoardSystem(int sizeOfBoardW, int sizeOfBoardH) //There currently is no default.
		  {
				//Set board.
				board = new int[sizeOfBoardW, sizeOfBoardH];
				mHeight = sizeOfBoardH;//Set the maze height
				mWidth = sizeOfBoardW;//Set the maze width
				initBoard();//set initial board.
				board[1, 1] = 0;//Set the starting point of the board.
				
		  }

		  public string updateBoard()
		  {
				string translatedBoard = "";
				//Function to change all integers to a single character.
				Console.Clear();
				for(int y = 0; y < mHeight; y++)
				{
					 for(int x = 0; x < mWidth; x++)
					 {
						  if(board[x, y] == 0)
								translatedBoard +="@ ";//Starting position.
						  else if(board[x, y] == 1)
								translatedBoard +="X ";//Wall or unburrowed
						  else if(board[x, y] == 2)
								translatedBoard +="O ";//Burrowed area
						  else if(board[x, y] == 3)
								translatedBoard +="H ";//Current area being checked
						  else if(board[x, y] == 4)
								translatedBoard +="= ";//unchecked burrowed area
					 }
					 translatedBoard += "\n";
				}
				return translatedBoard;
		  }

		  public bool complete()
		  {

				return false;
		  }

		  public int getDirection()
		  {
				Random rng = new Random();
				return rng.Next(1, 5);
		  }

		  private void initBoard()
		  {
				for(int x = 0; x < mWidth; x++)
				{
					 for(int y = 0; y < mHeight; y++)
					 {
						  board[x, y] = 1;
					 }
				}
		  }



		  private int w, h, reset;//Variables to work generateBoardPart, and resetHolder

		  public void generateBoardPart()
		  {
				
				int direction = 0;
				bool trueForH;

				direction = getDirection();
				//1 is north
				//2 is east
				//3 is south
				//4 is west
				switch(direction)
				{
					 case 1:
						  trueForH = true;
						  reset = reset + 1;
						  board[w, h] = 3;
						  updateBoard();
						  if(h == 0 || h == mHeight)
								h = h + reset;
						  else
						  {
								h = h - 1;
								reset = reset + 1;
								if(h == 0 || h == mHeight)
								{
									 h = h + 1;
									 reset = reset + 1;
								}
						  }
						  break; //End Case 1.
					 case 2:
						  break;
				}
		  }

		  private void resetHolder(bool checkVar, int adjustment)
		  {
				if(checkVar)
					 h = h + adjustment;
				else
					 w = w + adjustment;
				reset = reset + adjustment;
		  }
	 }
}
