using SurvivorSimulation.Entities;
using SurvivorSimulation.Services;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Hayatta Kalma Simülasyonu ---");
            Console.WriteLine("Lütfen bir seçenek belirleyin:");
            Console.WriteLine("1. Örnek Girdi 1'i Çalıştır (Kahraman Kazanır)");
            Console.WriteLine("2. Örnek Girdi 2'yi Çalıştır (Kahraman Ölür)");
            Console.WriteLine("3. Kendi Senaryonu Oluştur");
            Console.WriteLine("4. Çıkış");
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();
            Console.WriteLine(); 

            switch (choice)
            {
                case "1":
                    SimulateExample1();
                    break;
                case "2":
                    SimulateExample2();
                    break;
                case "3":
                    SimulateFromUserInput();
                    break;
                case "4":
                    Console.WriteLine("Simülasyondan çıkılıyor...");
                    return; 
                default:
                    Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen 1-4 arasında bir sayı girin.");
                    break;
            }

            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey(); 
        }
    }

    private static void SimulateExample1()
    {
        Console.WriteLine("--- Örnek Girdi 1 Simülasyonu ---");
        var hero = new Hero(1000, 10);
        var enemies = new List<Enemy>
        {
            new Enemy("Böcek", 50, 2, 276),
            new Enemy("Böcek", 50, 2, 489),
            new Enemy("Aslan", 100, 15, 1527),
            new Enemy("Zombi", 308, 7, 1681),
            new Enemy("Aslan", 100, 15, 2865),
            new Enemy("Zombi", 308, 7, 3523)
        };
        var battleService = new BattleService();
        var simulationService = new SimulationService(battleService);
        simulationService.StartSimulation(hero, 5000, enemies);
    }

    private static void SimulateExample2()
    {
        Console.WriteLine("--- Örnek Girdi 2 Simülasyonu ---");
        var hero = new Hero(500, 9);
        var enemies = new List<Enemy>
        {
            new Enemy("Mutant", 480, 8, 274),
            new Enemy("Zombi Köpeği", 75, 10, 486),
            new Enemy("Zombi", 300, 7, 1687),
            new Enemy("Zombi Köpeği", 75, 10, 1897),
            new Enemy("Mutant", 480, 8, 5332)
        };
        var battleService = new BattleService();
        var simulationService = new SimulationService(battleService);
        simulationService.StartSimulation(hero, 7500, enemies);
    }

    private static void SimulateFromUserInput()
    {
        Console.WriteLine("--- Örnek Girdi 3 Simülasyonu (Kullanıcı Girişi) ---");

        Console.Write("Kaynaklara olan mesafeyi giriniz (metre cinsinden): ");
        int destination = int.Parse(Console.ReadLine());

        Console.Write("Kahramanın HP'sini giriniz: ");
        int heroHP = int.Parse(Console.ReadLine());

        Console.Write("Kahramanın saldırı gücünü giriniz: ");
        int heroAttack = int.Parse(Console.ReadLine());

        var hero = new Hero(heroHP, heroAttack);
        var enemies = new List<Enemy>();

        Console.Write("Düşman sayısını giriniz: ");
        int enemyCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < enemyCount; i++)
        {
            Console.WriteLine($"\nDüşman {i + 1}'in adını giriniz: ");
            string enemyName = Console.ReadLine();

            Console.WriteLine($"{enemyName}'in HP'sini giriniz: ");
            int enemyHP = int.Parse(Console.ReadLine());

            Console.WriteLine($"{enemyName}'in saldırı gücünü giriniz: ");
            int enemyAttack = int.Parse(Console.ReadLine());

            Console.WriteLine($"{enemyName}'in pozisyonunu (metre) giriniz: ");
            int enemyPosition = int.Parse(Console.ReadLine());

            enemies.Add(new Enemy(enemyName, enemyHP, enemyAttack, enemyPosition));
        }

        var battleService = new BattleService();
        var simulationService = new SimulationService(battleService);
        simulationService.StartSimulation(hero, destination, enemies);
    }
}