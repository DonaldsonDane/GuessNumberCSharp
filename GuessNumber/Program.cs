namespace GuessNumber
{

    class Program
    {
        private static int _correctNumber;
        private static String? _playerName;
        private static int _attemptsRemaining;


        private enum Difficulties
        {
            Easy,
            Medium,
            Hard
        }

        private static Difficulties _difficulties;
        
        
        
        
        static void Main()
        {
            
            Console.WriteLine("Welcome to my game.");
            Console.WriteLine("===============================");
            Console.WriteLine("Before we begin, please tell me your name:");
            
            RetrieveName(false);
            
            BeginGame();
            
            
        }
        
        
        private static void RetrieveName(Boolean nameRetrieved)
        {
            if(!nameRetrieved)
            {
                string? name = Console.ReadLine();
                _playerName = name;

            }else{
                Console.WriteLine("Oops, it looks like I already have your name saved\nLet me find it...");
             
            }
        }
        
        
        private static void BeginGame() {

            Console.WriteLine($"Hello {_playerName}! I hope your enjoy your experience.");
            
            Console.WriteLine("This game has 3 difficulties. Easy (1), Medium (2) & Hard (3).");
            Console.WriteLine("Please type the difficulty of the number you want.");

            GrabUserDifficulty();
            _correctNumber = GenerateRandomNumber();
            GrabUserGuess(_correctNumber);
        }
        
        private static int GenerateRandomNumber(){

            Random rand = new Random();
            

            return _difficulties switch
            {
                Difficulties.Easy => _correctNumber = rand.Next(1, 10),
                Difficulties.Medium => _correctNumber = rand.Next(1, 20),
                Difficulties.Hard => _correctNumber = rand.Next(1, 50),
                _ => throw new ArgumentException("Invalid argument")
            };



        }
        
        private static void GrabUserGuess(int correctNumber)
        {

            var userGuess = Convert.ToInt32(Console.ReadLine());
            CheckUserGuess(correctNumber, userGuess);

        }
        
        private static void CheckUserGuess(int correctAnswer, int userGuess){
            Result(userGuess == correctAnswer);
        }
        
        private static void Result(bool complete){
            if (complete) {
                Console.WriteLine($"You did it! The correct answer was {_correctNumber}");
            } else {

                _attemptsRemaining--;
                if(_attemptsRemaining >= 1){
                    Console.WriteLine("Try Again ...");
                    GrabUserGuess(_correctNumber);
                }else{
                    Console.WriteLine("GAME OVER! You ran out of lives.");
                    Console.WriteLine("Press 'Enter' to try again...");
                    
                 
                }



            }
        }
        
        private static void GrabUserDifficulty()
        {

            var userDifficulty = Convert.ToInt32(Console.ReadLine());
            //Make sure the chosen difficulty is within the correct bounds.
            if(userDifficulty >= 1 && userDifficulty <= 3)
            {
                switch (userDifficulty){
                    case 1:
                        _difficulties = Difficulties.Easy;
                        _attemptsRemaining = 5;
                        Console.WriteLine("You've chosen Easy ... Hah!");
                        Console.WriteLine("You must guess a number between 1 - 10. You get 5 attempts.");
                        break;
                    case 2:
                        _difficulties = Difficulties.Medium;
                        _attemptsRemaining = 5;
                        Console.WriteLine("You've chosen Medium ... Interesting!");
                        Console.WriteLine("You must guess a number between 1 - 20. You get 5 attempts.");
                        break;
                    case 3:
                        _difficulties = Difficulties.Hard;
                        _attemptsRemaining = 10;
                        Console.WriteLine("You've chosen Hard ... Gamer!");
                        Console.WriteLine("You must guess a number between 1 - 50. You get 10 attempts.");
                        break;
                }
            }
            else{

                Console.WriteLine("That's not a valid difficulty buster!");
                Console.WriteLine("This game has 3 difficulties. Easy (1), Medium (2) & Hard (3).");
                Console.WriteLine("Please type the difficulty number you want (1-3), then press 'Enter'.");

            }



        }



   
    }
}