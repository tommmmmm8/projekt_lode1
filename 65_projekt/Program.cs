namespace _65_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] pole = new string[10, 10];
            //VypsaniLodi(pole);
            int Zacinajici_s = VypsaniLodi(pole);
            int Radek = ZiskaniRadku(pole, Zacinajici_s);
            PracovniVypisPole(pole);
            bool lod = false;
            int pocetpokusu = 0;
            int radek_Zasah = 0;
            int sloupec_Zasah = 0;
            while (lod == false) 
            {
                Console.Write("Zadej radek pro zasah: ");
                while (!int.TryParse(Console.ReadLine(), out radek_Zasah))
                {
                    Console.WriteLine("Spatne zadany udaj.");
                    Console.Write("Zadej radek pro zasah: ");
                }
                if (radek_Zasah > pole.GetLength(0))
                {
                    Console.WriteLine("Udaj mimo rozhrani pole.");
                    break;
                }
                radek_Zasah = radek_Zasah-1;

                Console.Write("Zadej sloupec pro zasah: ");
                while (!int.TryParse(Console.ReadLine(), out sloupec_Zasah))
                {
                    Console.WriteLine("Spatne zadany udaj.");
                    Console.Write("Zadej sloupec pro zasah: ");

                }
                if (sloupec_Zasah > pole.GetLength(1))
                {
                    Console.WriteLine("Udaj mimo rozhrani pole.");
                    break;
                }
                sloupec_Zasah = sloupec_Zasah-1;
                pocetpokusu++;
                Zasah(pole, radek_Zasah, sloupec_Zasah, pocetpokusu);
                VypisPoZasahu(pole, radek_Zasah, sloupec_Zasah);
                lod = lodCheck(pole, Zacinajici_s, Radek);
            } 
            
        }

        static int VypsaniLodi(string[,] pole1)
        {
            for (int R = 0; R < pole1.GetLength(0); R++)
            {
                for (int s = 0; s < pole1.GetLength(1); s++)
                {
                    pole1[R, s] = "O";
                }
            }

            Random generator = new Random();
            int r = generator.Next(0, 10);
            int zacatecni_s = generator.Next(0, 7);

            for (int i = zacatecni_s; i < zacatecni_s+4; i++)
            {
                pole1[r, i] = "x";
            }

            return zacatecni_s;
        }

        static int ZiskaniRadku(string[,] pole1, int zacinajici_s)
        {
            int radek = 0;
            for (int r = 0; r < pole1.GetLength(0); r++)
            {
                if (pole1[r, zacinajici_s] == "x")
                {
                    radek = r;
                    break;
                }
            }
            return radek;
        }

        static void PracovniVypisPole(string[,] pole1)
        {
            for (int r = 0; r < pole1.GetLength(0); r++)
            {
                for (int s = 0; s < pole1.GetLength(1); s++)
                {
                    Console.Write(pole1[r, s] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Zasah(string[,] pole1, int radek, int sloupec, int pocetPokusu)
        {
            int r = radek;
            int s = sloupec;
            
            if (r<= pole1.GetLength(0) || s <= pole1.GetLength(1))
            {
                
                if (pole1[r,s] == "x")
                {
                    Console.WriteLine("Zasah!!!");
                    pole1[r, s] = "X";
                }
                else if (pole1[r,s] == "X")
                {
                    Console.WriteLine("Tato cast uz byla zasahnuta.");
                }
                else
                {
                    Console.WriteLine("Vedle.");
                }
            }
            else
            {
                Console.WriteLine("Spatne zadany souradnice.");
            }
            Console.WriteLine($"Pocet pokusu: {pocetPokusu}");
        }

        static void VypisPoZasahu(string[,] pole1, int radek, int sloupec)
        {
            for (int r = 0; r < pole1.GetLength(0); r++)
            {
                for (int s = 0; s < pole1.GetLength(1); s++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (pole1[r, s] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(pole1[r, s] + " ");
                    }
                    else if (pole1[r,s] == "x")
                    {
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.Write(pole1[r, s] + " ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        static bool lodCheck(string[,] pole1, int zacinajici_s, int radek)
        {
            int S = zacinajici_s;
            int R = radek;
            if (pole1[R, S] == "X" & pole1[R, S+1] == "X" & pole1[R, S+2] == "X" & pole1[R, S+3] == "X" )
            {
                Console.WriteLine("Lod byla potopena.");
                Console.WriteLine("Konec hry.");
                Console.WriteLine();
                /*for (int r = 0; r < pole1.GetLength(0); r++)
                {
                    for (int s = 0; s < pole1.GetLength(1); s++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        if (pole1[r, s] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(pole1[r, s] + " ");
                        }
                        else
                        {
                            Console.Write(pole1[r, s] + " ");
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }*/
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}