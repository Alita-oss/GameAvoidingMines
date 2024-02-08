namespace _2_projekt_hledani_min
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool znova;
            do
            {
                char[,] herniPole = VyplnPole();
                Console.WriteLine("Vítejte ve hře Hledání min!");
                Console.WriteLine("Musíte se vyhnout minimálně 5 minám!");

               // do
                //{
                    VypisPole(herniPole);
                    ZadaniTahu();

                //} while (!CelePoleProjite(herniPole));
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


        static void UmisteniMin()
        {

        }

        static void ObsahujeMinu()
        {

        }

        static void ZadaniTahu()
        {

        }

        static void KontrolaTahu()
        {

        }

        static void UkazatelMin()
        {

        }

        /*static void SlapnutiNaMinu()
        {

        }*/

        static void CelePoleProjite()
        {

        }

        static void VypisPole(char[,] pole) 
        { 
            for (int r = 0; r < pole.GetLength(0); r++)
            {
                for (int s = 0; s < pole.GetLength(1); s++)
                {
                    Console.Write(pole[r, s] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}