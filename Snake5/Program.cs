using Snake5;
using System;
using System.IO;
using System.Threading;
using System.Media;
using NAudio.Wave;

namespace Snake3
{
    class program:figure        
    {        
        static void Main(string[] args)
        {
            Sound gameOverSound = new Sound(@"C:\Users\admin\source\repos\C-sharp_Snake\Snake5\Snake5\Gameover.mp3");
            Sound Bgmusic = new Sound(@"C:\Users\admin\source\repos\C-sharp_Snake\Snake5\Snake5\Snake.mp3");
            Bgmusic.Play();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            while (name.Length < 3)
            {
                Console.WriteLine("Name must be at least 3 letters long. Please try again.");
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
            }
            Player player = new Player { Name = name, Score = 0 };

            Console.Clear();

            Console.SetWindowSize(79, 25);
            Console.SetBufferSize(79, 25);
            player.Draw(2, 1);
            //Любой класс может состоять не только из данных но и из функций
            Walls walls = new Walls(79, 25);
            walls.Draw();
            
            //point это класс используется для создания экземпляров этого класса
            //После создания конструктора можно сразу задавать, координаты точек
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();
            snake.Move();
            //вызываем класс ответственный за появление точек еда
            FoodCreator foodCreator = new FoodCreator(79, 25, '$');
            Point food = foodCreator.CreatFood();
            food.Draw();

            int foodEaten = 0;
            Obstacles obstacle = new Obstacles(0,0);
            Obstacles1 obstacle1 = new Obstacles1(0, 0);
            Obstacle2 obstacle2 = new Obstacle2(0, 0);
                                                         
            while (true)
            {
                //bool проверка, связь с Walls,Snake,Figure method IsHit(figure),snake.IsHitTail())
                if (walls.IsHit(snake) || obstacle2.IsHit(snake) || obstacle1.IsHit(snake) || obstacle.IsHit(snake) || snake.IsHitTail())
                {
                    gameOverSound.Play();
                    Bgmusic.Stop();
                    //Ð±Ð°Ð»Ð»Ñ‹ Ð·Ð°Ð¿Ð¸ÑÑ‹Ð²Ð°ÑŽÑ‚ÑÑ Ð² ÐºÐ¾Ð¿Ð¸ÑŽ Ð»Ð¸ÑÑ‚Ð° PlayerResult, Ñ€Ð°Ð±Ð¾Ñ‚Ð°ÐµÑ‚ Ñ‚Ð¾Ð»ÑŒÐºÐ¾ Ñ ÑƒÐºÐ°Ð·Ð°Ð½Ð¸ÐµÐ¼ Ð¿Ð¾Ð»Ð½Ð¾Ð³Ð¾ Ð¿ÑƒÑ‚Ð¸
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\admin\source\repos\C-sharp_Snake\Snake5\Snake5\PlayResult", true))
                    {
                        writer.WriteLine("Player name: " + player.Name);
                        writer.WriteLine("Score: " + player.Score);
                    }
                    break;
                }
                //Ð¡Ð¾Ð·Ð´Ð°ÐµÐ¼ Ð¿Ñ€ÐµÐ¿ÑÑ‚ÑÑ‚Ð²Ð¸Ñ, Ð·Ð°Ð´Ð°ÐµÑ‚ÑÑ ÑÑ‡ÐµÑ‚Ñ‡Ð¸Ðº foodEaten ÐºÐ¾Ð³Ð´Ð° ÑÑ‡ÐµÑ‚Ñ‡Ð¸Ðº ÑÑ€Ð°Ð±Ð°Ñ‚Ñ‹Ð²Ð°ÐµÑ‚
                //Ñ€Ð¸ÑÑƒÐµÑ‚ÑÑ Ð¿Ñ€ÐµÐ¿ÑÑ‚ÑÑ‚Ð²Ð¸Ñ Ð²Ñ‹Ð·Ñ‹Ð²Ð°Ñ Ð¼ÐµÑ‚Ð¾Ð´ Draw Ð¸Ð· ÐºÐ»Ð°ÑÑÐ° figure Ð° Ð½Ðµ Ð¸Ð· 
                // Obstacles Ð¿Ð¾Ñ‚Ð¾Ð¼Ñƒ Ñ‡Ñ‚Ð¾ Ð¾Ð½ Ð¾Ð¿Ñ€ÐµÐ´ÐµÐ»ÐµÐ½ Ð² ÐºÐ»Ð°ÑÑÐµ Ð¾Ñ‚ ÐºÐ¾Ñ‚Ð¾Ñ€Ð¾Ð³Ð¾ Ð½Ð°ÑÐ»ÐµÐ´ÑƒÑŽÑ‚ÑÑ                             
                if (true)
                {
                    snake.Move();
                }
                Thread.Sleep(100);
                //проверка бы ла ли нажата какая либо клавиша связь с классом snake 
                //public void HandleKey(ConsoleKey key)
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    //вызвали функцию из класса
                    snake.HandleKey(key.Key);
                }
                //бинарное значение будет ли на этом ходу змейка кушать или нет
                if (snake.Eat(food))
                {
                    foodEaten++;

                    food = foodCreator.CreatFood();

                    food.Draw();

                    player.Score++;

                    player.Draw(2, 1);
                    Sound eatSound = new Sound(@"C:\Users\admin\source\repos\C-sharp_Snake\Snake5\Snake5\aple.mp3");
                    eatSound.Play();
                    if (foodEaten == 1)
                    {
                        obstacle = new Obstacles(20, 40);
                        obstacle.Draw();

                    }
                 

                }
                if (foodEaten == 2)
                {
                    obstacle1 = new Obstacles1(20, 25);
                    obstacle1.Draw();

                }
                if (foodEaten==3)
                {
                    obstacle2 = new Obstacle2(20, 20);
                    obstacle2.Draw();

                }
            }
            WriteGameOver();
            Console.ReadLine();
        }


        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("Never Back Down", xOffset + 1, yOffset++);
            yOffset += 2;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("Leaderboard:", xOffset, yOffset++);
            yOffset++;

            // Read the data from the file and display the top 3 results on the console
            string fileName = "C:\\Users\\admin\\source\\repos\\C-sharp_Snake\\Snake5\\Snake5\\PlayResult";
            if (File.Exists(fileName))
            {
                //Ð’Ñ‹Ð²Ð¾Ð´Ð¸Ð¼ Ð½Ð° Ð­ÐºÑ€Ð°Ð½ Ñ‚Ð¾Ð»ÑŒÐºÐ¾ Ñ‚Ð¾ ÐºÐ¾Ð»Ð¸Ñ‡Ð¸ÑÑ‚Ð²Ð¾ ÑÑ‚Ñ€Ð¾Ðº ÐºÐ¾Ñ‚Ð¾Ñ€Ð¾Ðµ Ð½Ðµ Ð½Ð°Ñ€ÑƒÑˆÐ°ÐµÑ‚ Ñ€Ð°Ð±Ð¾Ñ‚Ñƒ SetCursorPoition
                string[] lines = File.ReadAllLines(fileName);
                int count = 0;
                foreach (string line in lines)
                {
                    if (count < 7) // display only the first 3 results
                    {
                        WriteText(line, xOffset, yOffset++);
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                WriteText("No results found!", xOffset, yOffset++);
            }

        }
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
   

        
}

       
