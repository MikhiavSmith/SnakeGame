using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeOnAFrame
{
	class Program
	{
		static void Main(string[] args)
		{
			bool displayMenu = true;
			while (displayMenu == true)
			{
				displayMenu = MainMenu();
			}
			MainMenu();

		}

		private static void PlaySnake()
		{
			#region Variables
			int[] xPosition = new int[50];
			xPosition[0] = 35;
			int[] yPosition = new int[50];
			yPosition[0] = 20;
			int appleXDim = 10;
			int appleYDim = 10;
			int applesEaten = 0;

			decimal gameSpeed = 150m;

			bool isGameOn = true;
			bool isWallHit = false;
			bool isAppleEaten = false;
			//bool isSnakeHit = false;

			Random random = new Random();

			Console.CursorVisible = false;
			#endregion

			#region Game Setup
			// Get the snake to appear on screen
			paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

			// Set apple on screen
			setApplePositionOnScreen(random, out appleXDim, out appleYDim);
			paintApple(appleXDim, appleYDim);

			// Build boundary
			buildWall();

			ConsoleKey command = Console.ReadKey().Key;

			#endregion

			do
			{
				#region Change Directions

				switch (command)
				{
					case ConsoleKey.LeftArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						xPosition[0]--;
						break;

					case ConsoleKey.UpArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						yPosition[0]--;
						break;

					case ConsoleKey.RightArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						xPosition[0]++;
						break;

					case ConsoleKey.DownArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						yPosition[0]++;
						break;
				}

				#endregion

				#region Playing Game

				// Paint the snake
				paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

				// Detect when snake hits boundary
				isWallHit = DidSnakeHitWall(xPosition[0], yPosition[0]);

				if (isWallHit)
				{
					isGameOn = false;
					Console.SetCursorPosition(28, 20);
					Console.WriteLine("The snake hit the wall and died.");

					Console.ForegroundColor = ConsoleColor.White;
					Console.SetCursorPosition(15, 21);
					Console.WriteLine("Your score is " + applesEaten * 100 + "!");
					Console.SetCursorPosition(15, 22);
					Console.WriteLine("Press Enter to Continue.");
					applesEaten = 0;
					Console.ReadLine();
					Console.Clear();
					MainMenu();
				}

				// Detect when apple was eaten
				isAppleEaten = determineIfAppleWasEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);

				// Place apple on board (random)
				if (isAppleEaten)
				{
					setApplePositionOnScreen(random, out appleXDim, out appleYDim);
					paintApple(appleXDim, appleYDim);
					// Keep track of eaten apples
					applesEaten++;
					// Make snake faster
					gameSpeed *= .925m;
				}

				// 

				if (Console.KeyAvailable) command = Console.ReadKey().Key;
				// Slow game down
				System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

				#endregion

			} while (isGameOn);
		} // end PlaySnake

		private static void PlayEasySnake()
		{
			#region Variables
			int[] xPosition = new int[50];
			xPosition[0] = 35;
			int[] yPosition = new int[50];
			yPosition[0] = 20;
			int appleXDim = 10;
			int appleYDim = 10;
			int applesEaten = 0;

			decimal gameSpeed = 300m;

			bool isGameOn = true;
			bool isWallHit = false;
			bool isAppleEaten = false;

			Random random = new Random();

			Console.CursorVisible = false;
			#endregion

			#region Game Setup
			// Get the snake to appear on screen
			paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

			// Set apple on screen
			setApplePositionOnScreen(random, out appleXDim, out appleYDim);
			paintApple(appleXDim, appleYDim);

			// Build boundary
			buildWall();

			ConsoleKey command = Console.ReadKey().Key;

			#endregion

			do
			{
				#region Change Directions

				switch (command)
				{
					case ConsoleKey.LeftArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						xPosition[0]--;
						break;

					case ConsoleKey.UpArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						yPosition[0]--;
						break;

					case ConsoleKey.RightArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						xPosition[0]++;
						break;

					case ConsoleKey.DownArrow:
						Console.SetCursorPosition(xPosition[0], yPosition[0]);
						Console.Write(" ");
						yPosition[0]++;
						break;
				}

				#endregion

				#region Playing Game

				// Paint the snake
				paintSnake(applesEaten, xPosition, yPosition, out xPosition, out yPosition);

				// Detect when snake hits boundary
				isWallHit = DidSnakeHitWall(xPosition[0], yPosition[0]);

				if (isWallHit)
				{
					isGameOn = false;
					Console.SetCursorPosition(28, 20);
					Console.WriteLine("The snake hit the wall and died.");

					Console.ForegroundColor = ConsoleColor.White;
					Console.SetCursorPosition(15, 21);
					Console.WriteLine("Your score is " + applesEaten * 100 + "!");
					Console.SetCursorPosition(15, 22);
					Console.WriteLine("Press Enter to Continue.");
					applesEaten = 0;
					Console.ReadLine();
					Console.Clear();
					MainMenu();
				}

				// Detect when apple was eaten
				isAppleEaten = determineIfAppleWasEaten(xPosition[0], yPosition[0], appleXDim, appleYDim);

				// Place apple on board (random)
				if (isAppleEaten)
				{
					setEasyApplePositionOnScreen(random, out appleXDim, out appleYDim);
					paintApple(appleXDim, appleYDim);
					// Keep track of eaten apples
					applesEaten++;
					// Make snake faster
					gameSpeed *= .925m;
				}

				// 

				if (Console.KeyAvailable) command = Console.ReadKey().Key;
				// Slow game down
				System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

				#endregion

			} while (isGameOn);
		} // end PlayEasySnake

		private static bool MainMenu()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(25, 8);
			Console.WriteLine("Choose an option:");
			Console.SetCursorPosition(25, 10);
			Console.WriteLine("1) Play Snake Game");
			Console.SetCursorPosition(25, 11);
			Console.WriteLine("2) Play Snake Game (Easy)");
			Console.SetCursorPosition(25, 12);
			Console.WriteLine("3) Read Diretions");
			Console.SetCursorPosition(25, 13);
			Console.WriteLine("4) Exit \n\n\n\n\n" + @"                    /^\/^\
                  _|__|  O|
         \/     /~     \_/ \
          \____|__________/  \
                 \_______      \
                         `\     \                 \
                           |     |                  \
                          /      /                    \
                         /     /                       \\
                       /      /                         \ \
                      /     /                            \  \
                    /     /             _----_            \   \
                   /     /           _-~      ~-_         |   |
                  (      (        _-~    _--_    ~-_     _/   |
                   \      ~-____-~    _-~    ~-_    ~-_-~    /
                     ~-_           _-~          ~-_       _-~   
                        ~--______-~                ~-___-~");
			buildWall();
			string result = Console.ReadLine();
			if (result == "1")
			{
				Console.Clear();
				PlaySnake();
				return false;
			}
			else if (result == "2")
			{
				Console.Clear();
				PlayEasySnake();
				return false;
			}
			else if (result == "3")
			{
				Console.Clear();
				DisplayDirections();
				return false;
			}
			else if (result == "4")
			{
				return false;
			}
			else
			{
				return true;
			}
		} // end MainMenu

		private static void DisplayDirections()
		{
			Console.Clear();
			buildWall();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.SetCursorPosition(5, 5);
			Console.WriteLine("1) Resize the console window so you can see all");
			Console.SetCursorPosition(5, 6);
			Console.WriteLine("   4 sides of playing field border.");
			Console.SetCursorPosition(5, 7);
			Console.WriteLine("2) Use arrow keys to move the snake around the field.");
			Console.SetCursorPosition(5, 8);
			Console.WriteLine("3) The snake will die if it runs into the wall.");
			Console.SetCursorPosition(5, 9);
			Console.WriteLine("4) You gain points by eating the apple.");
			Console.SetCursorPosition(5, 10);
			Console.WriteLine("   but your snake will go faster and get longer.");
			Console.SetCursorPosition(5, 12);
			Console.WriteLine("Press enter to return to the main menu.");
			Console.ReadKey();
			Console.Clear();
			MainMenu();
		} // end DisplayDirections 

		#region Snake Methods
		private static void paintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
		{
			// Paint the head
			Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine((char)214);

			// Paint the body
			for (int i = 1; i < applesEaten + 1; i++)
			{
				Console.SetCursorPosition(xPositionIn[i], yPositionIn[i]);
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("o");
			}

			// Erase last part of snake
			Console.SetCursorPosition(xPositionIn[applesEaten + 1], yPositionIn[applesEaten + 1]);
			Console.WriteLine(" ");

			// Record location of each body part
			for (int i = applesEaten + 1; i > 0; i--)
			{
				xPositionIn[i] = xPositionIn[i - 1];
				yPositionIn[i] = yPositionIn[i - 1];
			}

			// Return the new array
			xPositionOut = xPositionIn;
			yPositionOut = yPositionIn;
		} // end paintSnake

		private static bool DidSnakeHitWall(int xPosition, int yPosition)
		{
			if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; else return false;
		}

		//private static bool DidSnakeHitSnake(xPosition[applesEaten + 1], yPosition[applesEaten + 1])
		//{
		//	for (int i = 1; i < applesEaten + 1; i++)
		//	{
		//		if(xPosition[i-1] == xPositionIn[i], yPositionIn[i])
		//	}

		//}

		private static void buildWall()
		{
			for (int i = 1; i < 41; i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(1, i);
				Console.Write("#");
				Console.SetCursorPosition(70, i);
				Console.Write("#");
			}

			for (int i = 1; i < 71; i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.SetCursorPosition(i, 1);
				Console.Write("#");
				Console.SetCursorPosition(i, 40);
				Console.Write("#");
			}
		} // end buildWall
		private static void setApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
		{
			appleXDim = random.Next(0 + 2, 70 - 2);
			appleYDim = random.Next(0 + 2, 40 - 2);
		}

		private static void setEasyApplePositionOnScreen(Random random, out int appleXDim, out int appleYDim)
		{
			appleXDim = random.Next(0 + 4, 70 - 4);
			appleYDim = random.Next(0 + 4, 40 - 4);
		} // only used for Easy Snake

		private static void paintApple(int appleXDim, int appleYDim)
		{
			Console.SetCursorPosition(appleXDim, appleYDim);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write((char)64);
		}

		private static bool determineIfAppleWasEaten(int xPosition, int yPosition, int appleXDim, int appleYDim)
		{
			if (xPosition == appleXDim && yPosition == appleYDim) return true; return false;
		}
		#endregion
	}
}

