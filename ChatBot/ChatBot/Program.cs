using System;
using System.Media;
using System.Xml.Linq;

namespace ChatBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            welcomeGreeting("Media.wav");
            logoDisplay();

            

            //Prompt for name to personalise answers
            Console.WriteLine("Bot:  Hello What is your name user? ");
            Console.WriteLine("");

            //Colour Change
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("User: ");
            string name = Console.ReadLine();
            Console.WriteLine("");

            //Colour Changes back
            Console.ResetColor();


            //Prompt for question
            Console.WriteLine($"Bot: Greetings, {name}. Enter 'ASK' to view a list of questions I can assist you with.");
            Console.WriteLine("");

            //Colour Change
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"{name}: ");
            string userResponse = Console.ReadLine().ToLower();
            Console.WriteLine("");

            //Colour Changes back
            Console.ResetColor();

            UserQuery user = new UserQuery(name,userResponse);

            user.responses();

  
        Console.ReadKey();
        }
        public static void welcomeGreeting(string filepath)
        { 
           SoundPlayer player = new SoundPlayer();
            player.SoundLocation = filepath;
            player.Play();
         }

        public static void logoDisplay() 
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"
                              

        
█▀▀ █▄█ █▄▄ █▀▀ █▀█ ▄▄ █▀ █▀▀ █▀▀ █░█ █▀█ █ ▀█▀ █▄█   ▄▀█ █░█░█ ▄▀█ █▀█ █▀▀ █▄░█ █▀▀ █▀ █▀   █▀▀ █░█ ▄▀█ ▀█▀ █▄▄ █▀█ ▀▄▀
█▄▄ ░█░ █▄█ ██▄ █▀▄ ░░ ▄█ ██▄ █▄▄ █▄█ █▀▄ █ ░█░ ░█░   █▀█ ▀▄▀▄▀ █▀█ █▀▄ ██▄ █░▀█ ██▄ ▄█ ▄█   █▄▄ █▀█ █▀█ ░█░ █▄█ █▄█ █░█
                
                                  .-%#.....:#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%-.....:*%=.                     ..
                              .+%%#:.=++++++*%+.                           .+%*******=.:#%%*.                 ..
                             ..%=.*#.       -%-  .-=+++++++++++++++++++=-.  .%:       .+%.:%-.                ..
                         .:--..=###%+.......=%- .+%-:::::::::::::::::::-#%. .%-.......=%###=..--:.            ..
                        .+%=*%..  ..*#######%%- .*#      .........      +%. .%########*..   :%*=%*.           ..
                        .=%+#%.             -%- .*#     .+%#####%#.     +%. .%:             .%#+%*.           ..
                         ....#%*************#%- .*#     .%%.    +%.     +%. .%#*************%%:..             ..
                    .....    ...............=%- .*#   ...%%.    +%...   +%. .%-...............    .....       ..
                    :%%%#.                  -%- .*#   =%%%%%%%%%%%%%=.  +%. .%:                  .#%%%=.      ..
                   .*#.-%%%%%%%%%%%%%%%%%%%%%%- .*#  .%*.....-.....-%:  +%. .%%%%%%%%%%%%%%%%%%%%%%=.##.      ..
                    .-*+:.                  -%- .*#  .%*   .%%*.   -%:  +%. .%:                  ..+*-..      ..
                             :###############%- .*#  .%*   .-%..   -%:  +%. .%###############:.               ..
                         .*##%-.............=%- .*#  .%#.....:.....+%:  +%. .%-.............-%%#*..           ..
                        .##.-%:.   .........=%- .*#   :*###########*:.  +%. .%-........     :%=.*#.           ..
                        .:#%%+.....+%*******#%- .*#                     +%. .%********%*.....+%%#-.           ..
                          ... .##*%#.       -%-  -%%%%%%%%%%%%%%%%%%%%%%%-. .%:      ..*%*#%.....             ..
                              .%+-##........-%-                            .:%:........=%-=%:.                ..
                               .=+:.-%#######%%+:::::::::::::::::::::::::::=%%%#####%%=.:==.                  
   

");

            Console.ResetColor();
        }
                
    }
}
