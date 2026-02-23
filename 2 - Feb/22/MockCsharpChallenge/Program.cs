// Mocking CSharp Challenge

// this follow Simplify new expression (IDE0090)

using System;

//Random random = new();
Random random = new Random();
Console.CursorVisible = false;

int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// console position of the player
int playerX = 0;
int playerY = 0;

// console position of the food
int foodX = 0;
int foodY = 0;


// Available player and food strings 
// I did not account for the state change
string[] states = {"('-')", "(^-^)", "(X_X)"};
string[] foods = {"@@@@@", "$$$$$", "#####"};

// Current player string displayed in the Console
string player = states[0];

// index of the current food
int food = 0;

// running the app
InitializeGame();
while (!shouldExit)
{   
    if (TerminalResized())
    {
        Console.Clear();
        Console.Write("Console was resized. Program exiting.");
        shouldExit = true;    
    }
    else
    {
        // create PlayerIsFater
        if (PlayerIsFaster())
        {
            // why 1 again?
            Move(1, false);
        }
        else if (PlayerIsSick())
        {
            // we freeze the player   
            FreezePlayer();
        }
        else
        {
            Move(othersKeyExit: false);
        }

        // implement eating the food
        if (GotFood())
        {
            // Change player expression
            ChangePlayer();
            ShowFood();
        }
    }
}



void ShowFood()
{
    // using .Length function when foods is already initialized
    food = random.Next(0, foods.Length);

    // randomly positions the food
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Displays food based on foodX and foodY
    Console.SetCursorPosition(foodX, foodY);
    // select from the array of foods
    Console.Write(foods[food]);
}

bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

bool PlayerIsFaster()
{
    // what's player again?
    // player is a string that is initialized as state[0]
    return player.Equals(states[1]);
}

void Move(int speed = 1, bool othersKeyExit = false)
{
    // sets the cursor's new position
    int lastX = playerX;
    int lastY = playerY;

    // implement switch statement
    switch(Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            playerY--;
            break;
        case ConsoleKey.DownArrow:
            playerY++;
            break;
        case ConsoleKey.LeftArrow:
            playerX -= speed;
            break;
        case ConsoleKey.RightArrow:
            playerX += speed;
            break;
        case ConsoleKey.Escape:
            shouldExit = true;
            break;
        default:
            // when will the othersKeyExit is true?
            shouldExit = othersKeyExit;
            break;
    }

    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }
    
    // this ensures player position does not go out of terminal position
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width: playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height: playerY);

    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

bool PlayerIsSick()
{
    return player.Equals(states[2]);
}

void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

bool GotFood()
{
    // return playerY == foodY && playerY == foodX;
    // this was the bug. 
    return playerY == foodY && playerX == foodX;
}

void ChangePlayer()
{   
    // food is initialized as state[0]
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0,0);
    Console.Write(player);
}