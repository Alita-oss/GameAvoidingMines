namespace _2_projekt_hledani_min
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dodělat UkazatelMin() a pak to bude už vše ne? to je to jediné co mi teď chybí, časem určitě přijdu na další věci
            // měla bych udělat to, že na začátku je určitý počet min, takže jich tolik taky můžeš jen položit (aby všude nedávali možnou minu) => 
            //když někde označí špatně tak jim to nevyjde na konci a nebo si to pak spletou => vybuchnou :)
            bool znova;
            do
            {
                char[,] herniPole = VyplnPole();
                UmisteniMin(herniPole);
                Console.WriteLine("Vítejte ve hře Hledání min!");
                //Console.WriteLine("Musíte se vyhnout minimálně 5 minám!");

                do
                {
                    VypisPole(herniPole);
                    ZadaniTahu(herniPole);

                } while (!CelePoleProjite(herniPole));
                Console.WriteLine("Gratuluji! Prošli jste celé pole bez šlápnutí na minu!");
                Console.WriteLine("Hra skončila");

                Console.WriteLine("Chceš hrát znova?");
                string volba = Console.ReadLine().ToUpper();
                znova = (volba == "a");
            } while (znova); 
        }

        static char[,] VyplnPole()
        {
            char[,] pole = new char[10, 11];
            for (int r = 0; r < pole.GetLength(0); r++)
            {
                for (int s = 0; s < pole.GetLength(1); s++)
                {
                    if (r == 0 && s > 0)
                    {
                        pole[r, s] = (char)('A' + s - 1);
                    } else if (s == 0 && r > 0)
                    {
                        pole[r, s] = (char)('0' + r);
                    } else
                    {
                        pole[r, s] = '-';
                    }
                }
            }
            return pole;
        }


        static void UmisteniMin(char[,] pole)
        {
            Random random = new Random();
            int pocetMin = 10;
            for (int i = 0; i < pocetMin; i++)
            {
                int r;
                int s;

                r = random.Next(1, 10);
                s = random.Next(1, 10);

                do
                {
                    r = random.Next(1, 10); 
                    s = random.Next(1, 10); 
                } while (pole[r, s] == 'O'); // pokud na vygenerovaných souřadnicích již je mina, vygeneruj nové souřadnice

                pole[r, s] = 'O'; // umístění miny na herní pole
            }
        }

        static void ZadaniTahu(char[,] pole)
        {
            int r;
            int s;

            Console.WriteLine("Zadej řádek 1-9: ");
            while (!int.TryParse(Console.ReadLine(), out r) || r < 1 || r > 9)
            {
                Console.WriteLine("Špatně zadaný řádek! Zkus znovu: ");
                Console.WriteLine("Zadej řádek 1-9: ");
            }

            Console.WriteLine("Zadej sloupec A-J: ");
            string input = Console.ReadLine().ToUpper();
            s = input.Length == 1 && input[0] >= 'A' && input[0] <= 'J' ? input[0] - 'A' + 1 : -1;
            while (s == -1)
            {
                Console.WriteLine("Špatně zadaný sloupec! Zkus znovu: ");
                Console.WriteLine("Zadej sloupec A-J: ");
                input = Console.ReadLine().ToUpper();
                s = input.Length == 1 && input[0] >= 'A' && input[0] <= 'J' ? input[0] - 'A' + 1 : -1;

            }

            KontrolaTahu(pole, r, s);
        }

        static void KontrolaTahu(char[,] pole, int r, int s)
        {
            Console.WriteLine("Chceš toto pole oznaečit jako možnou minu? a/n");
            string volba = Console.ReadLine().ToLower();
            if (volba == "a" && pole[r, s] != 'O') //hráč zadá že chce pole označit jako minu, ale mina tam není
            {
                Console.WriteLine("Mina označena");
                pole[r, s] = 'X'; //pole bylo označeno jako možná mina (může to ještě změnit, kdyby se rozmyslel)
            }
            else if (volba == "a" && pole[r, s] == 'O') //uživatel zadá, že chce pole označit jako minu a je tam mina
            {
                Console.WriteLine("Mina označena");
                pole[r, s] = 'X';
            }
            else if (volba != "a" && pole[r, s] == 'O') // neoznačil jako možnou minu, ale mina tam je
            {
                Console.WriteLine("Vybuchli jste! Hra skončila");
                Environment.Exit(0); //ukončení
            }
            else if (volba != "a" && pole[r, s] != 'O')
            {
                Console.WriteLine("Správně, žádná mina tu nebyla.");
                //UkazatelMin(pole, r, s);
                //pole[r, s] = '/'; //aby hráč věděl, že už to zadával
            }
        }

        static void UkazatelMin(char[,] pole, int r, int s) 
        {
            int miny = 0;
            //procházení okolí zadaného políčka hráčem
            for (int i = r - 1; i <= r + 1; i++)
            {
                for (int j = s -1; j <= s+ 1; s++)
                {
                    //kontrola, zda je to ještě v herním poli
                    if (i >= 1 && i <= 9 && j >= 1 && j <= 9)
                    {
                        //kontrola, zda je tam mina
                        if (pole[r,s] == 'O')
                        {
                            miny++;
                        }
                    }
                }
            }

            pole[r, s] = (char)(miny + 'O');
        }

        static bool CelePoleProjite(char[,] pole)
        {
            for (int r = 1; r < pole.GetLength(0); r++)
            {
                for (int s = 1; s < pole.GetLength(1); s++)
                {
                    if (pole[r,s] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void VypisPole(char[,] pole) 
        { 
            for (int r = 0; r < pole.GetLength(0); r++)
            {
                for (int s = 0; s < pole.GetLength(1); s++)
                {
                    //char kryti = (pole[r, s] == 'O' ? '-' : pole[r, s]); //skryje nám miny
                    //Console.Write(kryti + " ");
                    Console.Write(pole[r, s] + " "); //miny jsou vidět
                }
                Console.WriteLine();
            }
        }
    }
}