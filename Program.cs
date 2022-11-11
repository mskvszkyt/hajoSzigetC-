using System;

namespace ConsoleApp1
{
    class Program
    {
        const int SOROK_SZAMA = 20;
        const int OSZLOPOK_SZAMA = 60;
        const char TENGER_JEL = '*';
        const char SZIGET_JEL = 'O';
        const char HAJO_JEL = '█';

        static void Megjelenit(char[,] terkep)
        {
            Console.Clear();
            for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < terkep.GetLength(1); oszlopIndex++)
                {
                    Console.Write(terkep[sorIndex, oszlopIndex]);
                }
                Console.WriteLine();
            }
        }

        static int MegszamolSzigetet(char[,] terkep)
        {
            int szigetekSzama = 0;
            for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < terkep.GetLength(1); oszlopIndex++)
                {
                    if (terkep[sorIndex, oszlopIndex] == SZIGET_JEL)
                    {
                        szigetekSzama++;
                    };
                }
            }

            return szigetekSzama;
        }

        static int MegszamolSzigetSzelen(char[,] terkep)
        {
            int szigetekSzamaSzelen = 0;
            for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < terkep.GetLength(1); oszlopIndex++)
                {
                    if (sorIndex == SOROK_SZAMA - 1 && terkep[sorIndex, oszlopIndex] == SZIGET_JEL)
                    {
                        szigetekSzamaSzelen++;
                    }
                    else if (sorIndex == 0 && terkep[sorIndex, oszlopIndex] == SZIGET_JEL)
                    {
                        szigetekSzamaSzelen++;
                    }
                    else if (oszlopIndex == OSZLOPOK_SZAMA - 1 && terkep[sorIndex, oszlopIndex] == SZIGET_JEL)
                    {
                        szigetekSzamaSzelen++;
                    }
                    else if (oszlopIndex == 0 && terkep[sorIndex, oszlopIndex] == SZIGET_JEL)
                    {
                        szigetekSzamaSzelen++;
                    }
                }
            }

            return szigetekSzamaSzelen;
        }

        static void HajotCsinal(char[,] terkep, int kx, int ky)
        {
            terkep[kx, ky] = terkep[kx + 1, ky + 1] = terkep[kx + 1, ky] = terkep[kx + 1, ky - 1] = terkep[kx + 2, ky + 1] = terkep[kx + 2, ky] = terkep[kx + 2, ky - 1] = HAJO_JEL;
        }

        static void Main(string[] args)
        {


            char[,] tenger = new char[SOROK_SZAMA, OSZLOPOK_SZAMA];

            for (int sorIndex = 0; sorIndex < tenger.GetLength(0); sorIndex++)
            {
                for (int oszlopIndex = 0; oszlopIndex < tenger.GetLength(1); oszlopIndex++)
                {
                    tenger[sorIndex, oszlopIndex] = TENGER_JEL;
                }
            }
            Random vel = new Random();

            //3) Van-e olyan sziget, ami mellett közvetlenül másik sziget is van?

            bool vanEMellette = false;
            for (int i = 0; i < 50; i++)
            {
                int hajoSor = vel.Next(tenger.GetLength(0));
                int hajoOszlop = vel.Next(tenger.GetLength(1));
                tenger[hajoSor, hajoOszlop] = SZIGET_JEL;

                try
                {
                    if (tenger[hajoSor + 1, hajoOszlop] == SZIGET_JEL)
                    {
                        vanEMellette = true;

                    }
                    else if (tenger[hajoSor - 1, hajoOszlop] == SZIGET_JEL)
                    {
                        vanEMellette = true;

                    }
                    else if (tenger[hajoSor, hajoOszlop + 1] == SZIGET_JEL)
                    {
                        vanEMellette = true;

                    }
                    else if (tenger[hajoSor, hajoOszlop - 1] == SZIGET_JEL)
                    {
                        vanEMellette = true;

                    }
                }
                catch (Exception)
                {

                    continue;
                }
            }

            HajotCsinal(tenger, 10, 35);

            Megjelenit(tenger);


            //1) Hány sziget van a tengeren?
            Console.WriteLine($"szigetek szama: {MegszamolSzigetet(tenger)}");
            //2) Hány sziget van a tenger szélén?
            Console.WriteLine($"szigetek szama a tenger szelen: {MegszamolSzigetSzelen(tenger)}");
            //3) Van-e olyan sziget, ami mellett közvetlenül másik sziget is van?
            Console.WriteLine($"Van-e olyan sziget, ami mellett közvetlenül másik sziget is van? {vanEMellette}");
        }


    }
}
