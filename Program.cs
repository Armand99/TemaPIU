using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Telefon[] telefoane = new Telefon[10];
            int index = 0;
            string NumeFisier = "Telefoane.txt";
            using (StreamReader fisier = new StreamReader(NumeFisier))
            {
                string linie;
                while ((linie = fisier.ReadLine()) != null)
                {
                    telefoane[index] = new Telefon(linie);
                    index++;
                }
            }
            string optiune;
            do
            {
                Console.WriteLine("C. Citire");
                Console.WriteLine("A. Afisare");
                Console.WriteLine("S. Salvare in fisier");
                Console.WriteLine("O. Optiuni");
                Console.WriteLine("P. Compara pretul");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        Console.WriteLine("Indroduceti marca telefonului :");
                        string marca = Console.ReadLine();
                        Console.WriteLine("Indroduceti modelul telefonului :");
                        string model = Console.ReadLine();
                        Console.WriteLine("Indroduceti memoria interna a telefonului :");
                        string mem = Console.ReadLine();
                        Console.WriteLine("Indroduceti pretul telefonului :");
                        double pret = Convert.ToDouble(Console.ReadLine());
                        telefoane[index] = new Telefon(marca, model, mem, pret);
                        index++;
                        break;
                    case "A":
                        for (int i = 0; i < index; i++)
                        {
                            Console.WriteLine("{0}", telefoane[i].Info());
                        }

                        break;
                    case "S":
                        for (int i = 0; i < index; i++)
                        {
                            telefoane[i].AF();
                        }
                        Console.WriteLine("Datele au fost salvate !");
                        break;
                    case "O":
                        Console.WriteLine("Ce culoare sa aiba telefonul ? ( Alb = 1 , Negru = 2 , Gold = 3 , Silver = 4 )");
                        telefoane[0]._Culoare = (Telefon.Culoare)Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Culoarea aleasa este : {0}" , telefoane[0]._Culoare);
                        Console.WriteLine("Ce tip de SIM sa aibe telefonul ? ( Single = 1 , Dual = 2)");
                        telefoane[0]._Sim = (Telefon.Sim)Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Tipul de SIM ales este : {0}", telefoane[0]._Sim);
                        break;
                    case "P":
                        if (index >= 2)
                        {
                            telefoane[0].comp(telefoane[1]);
                        }
                        else
                            Console.WriteLine("Nu ai destule telefoane!");
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            /*
            //Instantierea unui obiect de tip Telefon utilizand constructorul fara parametrii
            var T = new Telefon();
            string t = T.Info();
            Console.WriteLine(t);

            //Instantierea unui obiect de tip Telefon utilizand constructorul cu parametrii
            Telefon T1 = new Telefon("Samsung", "A40", "64GB" ,900);
            string t1 = T1.Info();
            Console.WriteLine(t1);

            //Apelarea constructorului
            var T2 = new Telefon("Huawei","P40 lite" ,"128GB" ,3700);
            string t2 = T2.Info();
            Console.WriteLine(t2);
            Console.ReadKey();
            //Apelul functiei de comparare
            T1.comp(T2);
            Console.ReadKey();
            */

        }
    }
}