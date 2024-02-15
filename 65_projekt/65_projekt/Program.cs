using System.Runtime.CompilerServices;

namespace _65_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] pole = new string[10, 10];
            (int Zacinajici_s, int Radek) = VypsaniLode1(pole); // vypisu pole, a dostanu nazpet radek lode + zacinajici sloupec
            VypsaniLode2(pole, Zacinajici_s);
            PracovniVypisPole(pole); // pracovni vypis
            bool lod = false;
            int pocetpokusu = 0;
            int radek_Zasah = 0;
            int sloupec_Zasah = 0;
            while (lod == false)
            {
                (radek_Zasah,sloupec_Zasah) = ZvoleniZasahu(pole, radek_Zasah, sloupec_Zasah); // uzivatel zvoli souradnice zasahu
                pocetpokusu++;
                Zasah(pole, radek_Zasah, sloupec_Zasah, pocetpokusu); // Zhodnoti se zasah a zapise se do pole
                VypisPoZasahu(pole, radek_Zasah, sloupec_Zasah); // vypise uzivateli pole s jeho zasahem
                lod = lodCheck(pole); // zkontrolujeme, jestli nejsou lode uz potopeny
            }
        }

        
        static (int, int) VypsaniLode1(string[,] pole1)
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

            return (zacatecni_s, r);
        }

        static void VypsaniLode2(string[,] pole1, int zacatecni_s_lod1)
        {
            Random generator = new Random();

            int zacatecni_r = generator.Next(0, 7);
            int s = 0;
            do
            {
                s = generator.Next(0, 10);
            } while (pole1[zacatecni_r, s] == "x" || pole1[zacatecni_r+1, s] == "x" || pole1[zacatecni_r+2, s] == "x" || pole1[zacatecni_r+3, s] == "x");

            for (int i = zacatecni_r; i < zacatecni_r + 4; i++)
            {
                pole1[i, s] = "x";
            }

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
        static (int, int) ZvoleniZasahu(string[,] pole1, int radek_Zasah, int sloupec_Zasah)
        {
            Console.Write("Zadej radek pro zasah: ");
            while (!int.TryParse(Console.ReadLine(), out radek_Zasah))
            {
                Console.WriteLine("Spatne zadany udaj.");
                Console.Write("Zadej radek pro zasah: ");
            }
            if (radek_Zasah > pole1.GetLength(0))
            {
                Console.WriteLine("Udaj mimo rozhrani pole.");
                Console.Write("Zadej znova radek pro zasah: ");
                radek_Zasah = int.Parse(Console.ReadLine());
            }
            radek_Zasah = radek_Zasah - 1;

            Console.Write("Zadej sloupec pro zasah: ");
            while (!int.TryParse(Console.ReadLine(), out sloupec_Zasah))
            {
                Console.WriteLine("Spatne zadany udaj.");
                Console.Write("Zadej sloupec pro zasah: ");

            }
            if (sloupec_Zasah > pole1.GetLength(1))
            {
                Console.WriteLine("Udaj mimo rozhrani pole.");
                Console.Write("Zadej znova sloupec pro zasah: ");
                sloupec_Zasah = int.Parse(Console.ReadLine());

            }
            sloupec_Zasah = sloupec_Zasah - 1;
            Console.WriteLine();
            return (radek_Zasah, sloupec_Zasah);
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
                else if (pole1[r, s] == "O")
                {
                    Console.WriteLine("Vedle.");
                    pole1[r, s] = "0";
                }
                else if (pole1[r, s] == "X")
                {
                    Console.WriteLine("Tato cast uz byla zasahnuta.");
                }
                else if (pole1[r, s] == "0")
                {
                    Console.WriteLine("Vedle.");
                }
                /*else
                {
                    Console.WriteLine("Vedle.");
                }*/
            }
            else
            {
                Console.WriteLine("Spatne zadany souradnice.");
            }
            Console.WriteLine($"Pocet pokusu: {pocetPokusu}");
        }

        static void VypisPoZasahu(string[,] pole1, int radek, int sloupec)
        {

            Console.Clear();
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
                    else if (pole1[r,s] == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
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

        static bool lodCheck(string[,] pole1)
        {
            int pocetX = 0;
            int i = 0;
            int[,] souradnice = new int[8, 2];
            for (int r = 0; r < pole1.GetLength(0); r++)
            {
                for (int s = 0; s < pole1.GetLength(1); s++)
                {
                    if (pole1[r,s] == "X")
                    {
                        pocetX++;
                        souradnice[i, 0] = r;
                        souradnice[i, 1] = s;
                        i++;
                    }
                }
            }

            if (pocetX == 4)
            {
                int j = 0;
                int k = 0;
                // vezmeme prvni souradnici "X", ktere jsme ziskali z predesliho for cyklu a zjistime jestli dalsi 3 policka zanim je "X" cimz zjistime jestli uz potopil lod ktera nalezato
                if (pole1[souradnice[j, k], souradnice[j, k + 1]] == "X" && pole1[souradnice[j, k], souradnice[j, k + 1] + 1] == "X" && pole1[souradnice[j, k], souradnice[j, k + 1] + 2] == "X" && pole1[souradnice[j, k], souradnice[j, k + 1] + 3] == "X")
                {
                    Console.WriteLine("Gratuluju k potopeni 1. lodi!!!");
                    Console.WriteLine();
                }
                // zjisteni jestli se uz potopila 1. lod (lod nastojato) - je to na stejny princip jako u lodi nalezato (akorat zjistuju jestli pod tim prvnim "X", ktere jsme nasli se nanachazi dalsi 3 "X")
                else if (pole1[souradnice[j, k], souradnice[j, k + 1]] == "X" && pole1[souradnice[j, k]+1, souradnice[j, k + 1]] == "X" && pole1[souradnice[j, k]+2, souradnice[j, k + 1]] == "X" && pole1[souradnice[j, k]+3, souradnice[j, k + 1]] == "X")
                {
                    Console.WriteLine("Gratuluju k potopeni 1. lodi!!!");
                    Console.WriteLine();
                }
            }

            if (pocetX == 8)
            {
                Console.WriteLine("Vsechy lode byly potopeny.");
                Console.WriteLine("Konec hry.");
                Console.WriteLine();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}