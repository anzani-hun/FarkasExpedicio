using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//fájlművelethez
using System.IO;

namespace FarkasExpedicio
{
    internal class Program
    {


        //strúktúra csoportokba rendezzük a kapcsolódó változókat - nem módosítható, és nem lehet null értéke.
        struct Adatok
        {
            public int nap_szam;        // a nap sorszáma
            public int amatorradios;    // a rádióamatőr sorszáma
            public string uzenet;       // maga az üzenet - 90 karakter
            /* A vett karakter az angol ábécé kisbetűje, számjegy, / jel vagy szóköz lehet. 
             * Ha az adott időegységben nem volt egyértelműen azonosítható a vett jel, akkor # karakter szerepel.
             * Ha a tényleges üzenet befejeződött, az adó a fennmaradó időegységekben $ jelet küld.
             * Ha a megfigyelés során láttak farkasokat, akkor az üzenet két, / jellel elválasztott egész számmal,
             * a látott kifejlett és kölyök egyedek számával kezdődik, amelyet szóköz követ. Más esetben nem szám az első karakter
             */
        }

        static void Main()
        {
            Adatok seged;
            List<Adatok> expedicio = new List<Adatok>();
            string sor;
            StreamReader olvaso = new StreamReader("veetel.txt");

            //beolvasás a végéig megy.
            while (!olvaso.EndOfStream)
            {
                sor = olvaso.ReadLine();

                //az adatok feldarabolása szóközöknél
                //[0] a nap száma konvertálás INTté
                //[1] a rádióamatör azonosítója konvertálás INTté
                //maga az uzenet 
                seged.nap_szam = Convert.ToInt32(sor.Split(' ')[0]);
                seged.amatorradios = Convert.ToInt32(sor.Split(' ')[1]);
                seged.uzenet = olvaso.ReadLine();
                expedicio.Add(seged);

            }
            olvaso.Close();



            //2. feladat kiíratni a tömb első és utolsó elemét  //  tömb megszámlálása - 1
            /* Írja a képernyőre, hogy melyik rádióamatőr rögzítette az állományban szereplő első és melyik az utolsó üzenetet! */
            Console.WriteLine("\n2.feladat megoldása: ");
            Console.WriteLine($"Az első üzenetet rögzítette: {expedicio[0].amatorradios}. számú rádióamatőr");
            Console.WriteLine($"Az utolsó üzenetet rögzítette: {expedicio[expedicio.Count - 1].amatorradios}. számú rádióamatör");






            //3. feladat  - összes olyan feljegyzés napját és a rádióamatőr sorszámát, amelynek szövegében a „farkas” karaktersorozat szerepel!
            Console.WriteLine("\n3.feladat megoldása: ");

            //for ciklus a tömb bejárására és ahol tartalmazza [Contains] a farkasz szót
            for ( int i = 0; i < expedicio.Count; i++ )
            {
                if (expedicio[i].uzenet.Contains("farkas"))
                {
                    Console.WriteLine($"A feljegyzés {expedicio[i].nap_szam}. napja és a hozzátartozó rádióamatőr száma: {expedicio[i].amatorradios}.");
                }
            }



            //4. feladat  - statisztika készítése!
            Console.WriteLine("\n4.feladat megoldása: [melyik napon hány rádióamatőr készített feljegyzést]");


            //  ------------ A napok sorszáma 1 és 11, a rádióamatőrök sorszáma 1 és 20 közötti egész szám
            //új tömb létrehozása a 11 napos felmérésről --> fix 11-es a tömb
            int[] nap_radios = new int[11];

            //for ciklus   -1 vagy +1   wwww   a tömb 0tól indúl
            for ( int i = 0; i < expedicio.Count; i++ )
            {
                nap_radios[expedicio[i].nap_szam - 1]++;
            }
            for ( int i = 0; i < nap_radios.Length; i++ )
            {
                Console.WriteLine($"{i + 1}. nap: {nap_radios[i]} rádióamatőr");
            }




            //5. feladat  - a sorok összefésülése
            Console.WriteLine("\n5.feladat megoldása: []");

            StreamWriter iro = new StreamWriter("adaas.txt");

            iro.Close();





            //6. feladat  - 
            Console.WriteLine("\n6.feladat megoldása: [függvény létrehozása]");


            Console.ReadKey();
        }

        public static bool Szame(string szo)
        {
            bool valasz = true;

            for ( int i = 0; i < szo.Length; i++ )
            {
                //akkor szám ha 0 vagy 9 között van a szónak az eleme
                if (szo[i] < '0' || szo[i] > '9')
                {
                    valasz = false;
                }
            }
            return valasz;
        }
    }
}
