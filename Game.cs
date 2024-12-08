using System.Runtime.InteropServices;

class Game{

    static DateTime startTime = DateTime.Now;

    public static string name = "";
    public static int turno = 1;
    public static void Main(string[] args)
    {
        int option = 0;
        string texto = @"




                _____ ______   _______   ________  ________  ___               ________  ________      ________  ________  ___ _ __________         
                |\   _ \  _   \|\  ___ \ |\   ___ \|\   __  \|\  \             |\   __  \|\  _____\    |\   __  \|\   __  \|\  \|\   ___  \        
                \ \  \\\__\ \  \ \   __/|\ \  \_|\ \ \  \|\  \ \  \            \ \  \|\  \ \  \__/     \ \  \|\  \ \  \|\  \ \  \ \  \\ \  \       
                \ \  \\|__| \  \ \  \_|/_\ \  \ \\ \ \   __  \ \  \            \ \  \\\  \ \   __\     \ \   ____\ \   __  \ \  \ \  \\ \  \      
                \ \  \    \ \  \ \  \_|\ \ \  \_\\ \ \  \ \  \ \  \____        \ \  \\\  \ \  \_|      \ \  \___|\ \  \ \  \ \  \ \  \\ \  \     
                \ \__\    \ \__\ \_______\ \_______\ \__\ \__\ \_______\       \ \_______\ \__\        \ \__\    \ \__\ \__\ \__\ \__\\ \__\    
                \|__|     \|__|\|_______|\|_______|\|__|\|__|\|_______|        \|_______|\|__|         \|__|     \|__|\|__|\|__|\|__| \|__|   


            

        ";



        try
        {
            MostrarTextoConEfecto("Por favor ingrese un nombre:", 4);
            name = Console.ReadLine()!;
            if (name == "" || name == null){throw new ArgumentException("El nombre no puede estar vacío.");}
            else {
                Player player = new Player (name, 10,10,0);
                string e = $@"
                    ____________________________________________________________________________
                    |                                                                           |
                                                Bienvenido  {name}                                
                    |                                                                           |
                    | 1. Iniciar juego                                                          |
                    | 2. Salir                                                                  |
                    |___________________________________________________________________________|
                    ";
                VibrarConColores(texto);
                MostrarTextoConEfecto(e,5);
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        Console.WriteLine($"GOOD BAY");
                        
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }


                
            }
            
        }

        catch (FormatException){Console.WriteLine("Error: Ingresa un número válido.");}
        catch (System.Exception einass){Console.WriteLine($"An error occurred: {einass.Message}");}

        
        



    }




    public static void StartGame(){
        Console.WriteLine("El juego iniciará");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("Comenzamos el juego...");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("El juego ha iniciado");
        Console.Clear();
        Console.WriteLine($"Elige los siguientes personajes \n");
        Console.WriteLine(@"
                ____________________________________________________________________________
                |                                                                           |
                |                              Medal of Pain                                |
                |                                                                           |
                | 1. Magico                                                                 |
                | 2. Guerrero                                                               |
                | 3. Arquero                                                                |
                |___________________________________________________________________________|

        ");
        

        try
        {
            
            int optionPlayer = Convert.ToInt32(Console.ReadLine());
            switch (optionPlayer){
                case 1:
                    Magic playerMagic = new Magic(name,8,10,0,0);
                    Console.WriteLine($"_Has elegido al mago {playerMagic.name}");
                    GameInit(playerMagic);
                    break;
                case 2:
                    Warrior playerWarrior = new Warrior(name,12,10,0,0);
                    Console.WriteLine($"_Has elegido al Guerrero {playerWarrior.name}");
                    GameInit(playerWarrior);
                    break;
                case 3:
                    Arquer arquer = new Arquer(name,12,10,0,0);
                    Console.WriteLine($"_Has elegido al Arquero {arquer.name}");
                    GameInit(arquer);
                    break;
            }
        }

        catch (FormatException){Console.WriteLine("Error: Ingresa un número válido.");}
        catch (OverflowException){Console.WriteLine("Error: El número ingresado es muy largo jefe");}
        catch(System.Exception einass){Console.WriteLine($"An error occurred: {einass.Message}");}
        
        
        


    } 


    public static void GameInit(Player player){
    bool gameOver = false;

    try
    {
        while (!gameOver)
        {
            Console.Clear();

            // Mostrar información del jugador y el turno
            Console.WriteLine($"________________________________________________________________________________");
            Console.WriteLine($@"
            Turno: {turno} | {player.name} - Vida: {player.health} - Nivel: {player.level} - Habilidad: {player.hability}");
            Console.WriteLine($"________________________________________________________________________________");

            // Generar un enemigo o el jefe final según el turno
            Enemy enemy;
            if (turno % 5 == 0)
            {
                TriggerRandomEvent(player);
                Console.WriteLine("\n¡Enfrentarás al jefe final!");
                enemy = new BossFinal("Jefe Final", 15, 20, 5); // Crear jefe final
            }
            else
            {
                enemy = GenerateEnemy(); // Generar un enemigo aleatorio
            }

            // Mostrar información del enemigo
            Console.WriteLine($"Enemigo: {enemy.name} - Vida: {enemy.health} - Nivel: {enemy.level}");

            // Confirmar inicio de combate
            Console.WriteLine("\nPulsa cualquier tecla para iniciar el combate...");
            Console.ReadKey();

            // Iniciar combate
            bool isDefeated = combatEnemy(player, enemy);

            if (isDefeated)
            {
                Console.WriteLine("\nHas sido derrotado. Fin del juego.");
                gameOver = true;
            }
            else
            {
                // Mostrar resultados después de la batalla
                turno++;
                Console.WriteLine($"\nBatalla terminada. Vida actual: {player.health}");
                Console.WriteLine($"Turno actual: {turno}");
                
                if (enemy is BossFinal)
                {
                    Console.WriteLine("\n¡Felicitaciones! Has derrotado al jefe final. ¡Has ganado la partida!");
                    gameOver = true;
                }

                else
                {
                    LevelUp(player); // Subir nivel si derrotaste a un enemigo normal
                }

                // Pausar antes de continuar
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }

            Console.Clear();
            ShowElapsedTime();
            Console.Clear();
            ShowTurnSummary(player,turno);
        }
    }
    catch (Exception ex){Console.WriteLine($"Hubo un error: {ex.Message}");}
}



    public static Enemy GenerateEnemy()
    {
        Random random = new Random();
        if (random.Next(0, 2) == 0)
        {
            return new EnemySpecial("Enemigo Especial",new Random().Next(5, 13), new Random().Next(0, 16) ,new Random().Next(0, 5));
        }
        else
        {
            return new Enemy("Enemigo Básico",new Random().Next(5, 13), new Random().Next(0, 16));
        }
    }

    public static bool combatEnemy(Player player, Enemy enemy)
    {
        while (player.health > 0 && enemy.health > 0)
        {
            Console.Clear();
            Console.WriteLine($"{player.name} VS {enemy.name}");
            Console.WriteLine($"Tu vida: {player.health} - Enemigo vida: {enemy.health}");
            Console.WriteLine("\n¿Qué deseas hacer?");
            Console.WriteLine("1. Atacar");
            Console.WriteLine("2. Defender");
            Console.WriteLine("3. Escapar");

            int option = Convert.ToInt32( Console.ReadLine());

            switch (option)
            {
                case 1: // Atacar
                    int attack = player.Attack();
                    enemy.health -= attack;
                    Console.WriteLine($"\n{player.name} lanza un feroz ataque causando {attack} de daño a {enemy.name}.");
                    if (enemy.health <= 0)
                    {
                        Console.WriteLine($"\n¡{enemy.name} ha sido derrotado!");
                        break;
                    }
                    break;

                case 2: // Defender
                    Console.WriteLine("\nTe preparas para defender, reduciendo el daño recibido.");
                    int reducedDamage = Math.Max(1, enemy.Attack() - 2);
                    player.health -= reducedDamage;
                    Console.WriteLine($"\n{enemy.name} intenta atacarte, pero solo logra causar {reducedDamage} de daño.");
                    break;

                case 3: // Escapar
                    Console.WriteLine("\nIntentas escapar...");
                    Random random = new Random();
                    if (random.Next(0, 2) == 0)
                    {
                        Console.WriteLine("\n¡Escapaste exitosamente!");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"\nNo logras escapar. {enemy.name} te ataca mientras intentas huir.");
                    }
                    break;

                default:
                    Console.WriteLine("\nOpción inválida. ¡Pierdes tu turno!");
                    break;
            }

            if (enemy.health > 0)
            {
                int attackEnemy = enemy.Attack();
                player.health -= attackEnemy;
                Console.WriteLine($"\n{enemy.name} contraataca con {attackEnemy} de daño.");
            }
        }

        if (player.health > 0)
        {
            Console.WriteLine($"\n{player.name} sobrevive con {player.health} puntos de vida.");
            return false;
        }
        else
        {
            Console.WriteLine("\nHas sido derrotado.");
            return true;
        }

        

    }


    public static void ShowTurnSummary(Player player, int turno)
    {
        Console.WriteLine($"\n--- Resumen del Turno {turno} ---");
        Console.WriteLine($"Jugador: {player.name}");
        Console.WriteLine($"Vida: {player.health}");
        Console.WriteLine($"Nivel: {player.level}");
        Console.WriteLine($"Habilidad: {player.hability}");
        Console.WriteLine("----------------------------------");
        Console.ReadKey();
    }




    public static  void LevelUp(Player player)
    {
        player.level++;
        player.hability += 1; 
        Console.WriteLine($"¡Subiste al nivel {player.level}! Puntos de habilidad: {player.hability}");
    }




    public static void ShowElapsedTime()
    {
        TimeSpan elapsedTime = DateTime.Now - startTime;
        Console.WriteLine($"\nTiempo transcurrido: {elapsedTime.Hours:00}:{elapsedTime.Minutes:00}:{elapsedTime.Seconds:00}");
    }


    public static void TriggerRandomEvent(Player player)
    {
        Random random = new Random();
        int eventChance = random.Next(0, 100);

        if (eventChance < 50)
        {
            Console.WriteLine("\n¡Encontraste un cofre! Recuperas 5 puntos de vida.");
            player.health += 5;
        }
        else if (eventChance < 60) 
        {
            Console.WriteLine("\n¡Caíste en una trampa! Pierdes 5 puntos de vida.");
            player.health = Math.Max(0, player.health - 5);
        }
        else
        {
            Console.WriteLine("\nNo ocurre nada especial en este turno.");
        }

        Console.ReadKey();
    }


































// SECCION ESTETICA MARC
    static void VibrarConColores(string texto)
    {
        Console.CursorVisible = false;
        Random random = new Random();

        for (int i = 0; i < 30; i++) 
        {
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 16);

            Console.Clear();
            Console.WriteLine(texto);

            if (i % 2 == 0)
            {
                Thread.Sleep(100); 
            }
            else
            {
                Console.Clear(); 
                Thread.Sleep(100);
            }
        }

        Console.ResetColor(); 
        Console.CursorVisible = true;
    }

    static void MostrarTextoConEfecto(string texto, int delay)
    {
        foreach (char c in texto) // Recorre cada carácter en el texto
        {
            Console.Write(c); // Muestra el carácter
            Thread.Sleep(delay); // Pausa antes de mostrar el siguiente
        }
        Console.WriteLine(); // Salto de línea al terminar
    }

    static void BorrarTextoConEfecto(string texto, int delay)
    {
        foreach (char c in texto) // Recorre cada carácter en el texto
        {
            Console.Write("\b \b"); // Borra el carácter anterior
            Thread.Sleep(delay); // Pausa antes de borrar el siguiente
        }
    }
    
}
