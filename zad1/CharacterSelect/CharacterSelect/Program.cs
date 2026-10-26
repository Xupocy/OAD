using CharacterSelect.Application.Factory;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect
{
    public static class Program
    {
        public static void Main()
        {
            Console.Title = "Character Select";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== WYBÓR POSTACI ===");
                Console.WriteLine("1) Wojownik");
                Console.WriteLine("2) Mag");
                Console.WriteLine("3) Łotrzyk");
                Console.WriteLine("4) Paladyn");
                Console.WriteLine("5) Nekromanta");
                Console.WriteLine("6) Łucznik");
                Console.WriteLine("0) Wyjście");
                Console.Write("Wybierz klasę [0-6]: ");

                var input = Console.ReadLine();
                if (input == "0") break;

                // Zmieniono warunek z 3 na 6, aby akceptował nowe postacie
                if (!int.TryParse(input, out var choice) || choice < 1 || choice > 6)
                {
                    Pause("Niepoprawny wybór. Naciśnij Enter…");
                    continue;
                }

                // W C# w enumach wartości są numerowane od 0, więc odejmujemy 1
                var cls = (CharacterClass)(choice - 1);

                Console.Write("Podaj imię postaci (Enter = domyślne): ");
                var name = Console.ReadLine();

                var character = CharacterFactory.Create(cls, name);

                Console.Clear();
                Console.WriteLine(">>> Utworzono postać!");
                character.Describe();

                // --- MENU AKCJI (OCENA 5) ---
                Console.WriteLine("\nWybierz akcję:");
                Console.WriteLine("1. Atak");
                Console.WriteLine("2. Umiejętność specjalna");
                Console.Write("Wybierz opcję [1-2]: ");
                var akcja = Console.ReadLine();

                if (akcja == "1")
                {
                    int obrazenia = character.Sila * 3;
                    Console.WriteLine($"\n{character.Name} wykonuje atak!");
                    Console.WriteLine($"Zadane obrażenia: {obrazenia}");
                }
                else if (akcja == "2")
                {
                    Console.WriteLine($"\n{character.Name} używa umiejętności specjalnej!");
                    Console.WriteLine("Przeciwnik zostaje potężnie trafiony!");
                }
                else
                {
                    Console.WriteLine("\nNie wybrano poprawnej akcji, pomijamy turę.");
                }
                // -----------------------------

                Console.WriteLine("\nChcesz utworzyć kolejną postać? (t/n): ");
                var again = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                if (again != "t" && again != "tak") break;
            }

            Console.WriteLine("\nDzięki za grę! Do zobaczenia 👋");
        }

        private static void Pause(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}