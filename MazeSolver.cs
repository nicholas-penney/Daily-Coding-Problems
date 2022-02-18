using System;



public class MazeSolver
{

	// Variables used in functions
	static int[][] map = new int[][] 
	{
		new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 2, 0, 0, 0, 0 },
		new int[]{ 0, 2, 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 0, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0 },
		new int[]{ 0, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 },
		new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
	};
	
	static int targetY;
	static int targetX;
	static int startY;
	static int startX;


	public static void Main()
	{

		// Map that we input
		int[][] mapOrig = new int[][] 
		{
    		new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 0, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 2, 0, 0, 0, 0 },
    		new int[]{ 0, 2, 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 0, 2, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 0, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 0, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 2, 2, 2, 0 },
    		new int[]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    	};

		
		// Set target
		targetY = 3;
		targetX = 14;

		// Set Start
		startY = 18;
		startX = 1;

		// Set grid space of target to 3
		mapOrig[targetY][targetX] = 3;

		// Map that we will modify with crumbs
		for (int i = 0; i < 20; i++)
		{
			for (int j = 0; j < 20; j++)
			{
				map[i][j] = mapOrig[i][j];
			}
		}
		
		
				
		
		// Start recursive function with Starting point (row, column)
		if (solver(startY, startX))
		{

			// Solution found. Fill origMap with crumbs dropped
			for (int i=0; i<20; i++)
			{
				for (int j=0; j<20; j++)
				{
					if (map[i][j] == 1){
						mapOrig[i][j] = 1;
					}
				}
			}

			// Print map and solution to screen
			for(int i = 0;i<20;i++)
			{
				for (int j=0; j<20; j++)
				{
					if (mapOrig[i][j] == 2)
					{
						Console.Write(" ");
						
					} else if (mapOrig[i][j] == 3)
					{
						Console.Write("T");
						
					} else if (i == startY && j == startX)
					{
						Console.Write("S");

					} else if (mapOrig[i][j] == 1 )
					{
						Console.Write(".");
					
					} else
					{
						Console.Write(mapOrig[i][j]);
					}
				}
				Console.Write("\n");
			}

		} else
		{
			Console.WriteLine("No solution found.");
		}

	} // End of main


	// - - - - - - - - - - - - - - - - - - - -

	
	// Main recursive fucntion
	public static bool solver(int cY, int cX)
	{

		// Have we reached the target?
		if ( map[cY][cX] == 3 )
		{
			return true;
		}

		// Get direction priority e.g {N, E, W, S}
		char[] compass = getCompass(cY, cX);

		// Is current position empty?
		if (map[cY][cX] > 1)
		{

			// Set current position as wall
			map[cY][cX] = 0;
	
			// Try 1st trial direction
			int[] trial = getTrial(cY, cX, compass[0]);
			if (solver(trial[0], trial[1]) == true)
			{
				map[cY][cX] = 1;
				return true;
			}

			// 2nd trial
			trial = getTrial(cY, cX, compass[1]);
			if (solver(trial[0], trial[1]) == true)
			{
				map[cY][cX] = 1;
				return true;
			}

			// 3rd trial
			trial = getTrial(cY, cX, compass[2]);
			if (solver(trial[0], trial[1]) == true)
			{
				map[cY][cX] = 1;
				return true;
			}

			// 4th trial
			trial = getTrial(cY, cX, compass[3]);
			if (solver(trial[0], trial[1]) == true)
			{
				map[cY][cX] = 1;
				return true;
			}
			
		} // end of if

		// All 4 trial directions from current position lead to non-empty squares
		return false;

	} // End of solver class


	// - - - - - - - - - - - - - - - - - - - -


	public static char[] getCompass(int cY, int cX)
	{

		// Initiate compass with temporary values
		char[] compass = {'x', 'x', 'x', 'x'};

		// Work out which plane is furthest away
		int manhattanV = Math.Abs(cY - targetY);
		int manhattanH = Math.Abs(cX - targetX);
		
		// Should we try vertical or horizontal first?
		if (manhattanV >= manhattanH)
		{

			// Vertical
			if (targetY <= cY)
			{
				compass[0] = 'N';
				compass[3] = 'S';
			} else
			{
				compass[0] = 'S';
				compass[3] = 'N';
			}

			if (targetX >= cX)
			{
				compass[1] = 'E';
				compass[2] = 'W';
			} else
			{
				compass[1] = 'W';
				compass[2] = 'E';
			}


		} else
		{

			// Horizontal
			if (targetX >= cX)
			{
				compass[0] = 'E';
				compass[3] = 'W';
			} else
			{
				compass[0] = 'W';
				compass[3] = 'E';
			}

			if (targetY <= cY){
				compass[1] = 'N';
				compass[2] = 'S';
			} else
			{
				compass[1] = 'S';
				compass[2] = 'N';
			}
		}

		return compass;
	} // End of getCompass method


	// - - - - - - - - - - - - - - - - - - - -


	public static int[] getTrial(int cY, int cX, char c)
	{

		int[] trial = {cY, cX};

		switch(c)
		{
			case 'N': trial[0] = cY-1; break;
			case 'S': trial[0] = cY+1; break;
			case 'E': trial[1] = cX+1; break;
			case 'W': trial[1] = cX-1; break;
		}

		// Returns a trial coordinate based on compass direction
		return trial;
	} // End of tryTile method


} // End of MapSolver namespace


