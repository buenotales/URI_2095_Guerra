using System;
using System.Collections;
using System.Linq;

namespace URI_2095_Guerra
{
    class Item
    {
        public int Valor { get; set; }
        public int Usado { get; set; } // Para indicar se o guerreiro ja entrou em combate
    }

    class Guerra
    {
        public Item[] Quadradonia { get; set; }
        public Item[] Noglonia { get; set; }

        //Contruindo os times da batalha com a quantidade de guerreiros
        public Guerra(int tam = 0)
        {
            Quadradonia = new Item[tam];
            Noglonia = new Item[tam];
        }

        public int Compare(Item x, Item y)
            => new CaseInsensitiveComparer().Compare(y.Valor, x.Valor);

        //Foi realizado uma ordenação dos times e comparado se cada guerreiro Nogloniano é mais forte que o guerreiro Quadradoni,
        //caso seja verdade os guerreiros ficam flegados como ja "usados" e passam a ser ignorados nas proximas verificações
        public int BuscaGulosa()
        {
            Array.Sort<Item>(Quadradonia, Compare);
            Array.Sort<Item>(Noglonia, Compare);

            foreach (Item gn in Noglonia)
                foreach (Item gq in Quadradonia)
                    if (gn.Valor > gq.Valor && gn.Usado == 0 && gq.Usado == 0)
                        gn.Usado = gq.Usado = 1;

            return Noglonia.Where(n => n.Usado == 1).Count();
        }

        public int Cenario1()
        {
            Quadradonia = new Item[]
            {
                new Item { Valor = 2 },
                new Item { Valor = 1 },
                new Item { Valor = 10000000 }
            };
            Noglonia = new Item[]
            {
                new Item { Valor = 1 },
                new Item { Valor = 1 },
                new Item { Valor = 2 }
            };

            return BuscaGulosa();
        }

        public int Cenario2()
        {
            Quadradonia = new Item[]
            {
                new Item { Valor = 6 },
                new Item { Valor = 3 },
                new Item { Valor = 1 },
                new Item { Valor = 4 }
            };
            Noglonia = new Item[]
            {
                new Item { Valor = 2 },
                new Item { Valor = 7 },
                new Item { Valor = 4 },
                new Item { Valor = 3 }
            };

            return BuscaGulosa();
        }

        public int Cenario3()
        {
            Quadradonia = new Item[]
            {
                new Item { Valor = 4 },
                new Item { Valor = 5 },
                new Item { Valor = 1 },
                new Item { Valor = 6 },
                new Item { Valor = 9 },
                new Item { Valor = 100 },
                new Item { Valor = 934 },
                new Item { Valor = 2 },
                new Item { Valor = 934 },
                new Item { Valor = 5 },
            };
            Noglonia = new Item[]
            {
                new Item { Valor = 3 },
                new Item { Valor = 4 },
                new Item { Valor = 6 },
                new Item { Valor = 19 },
                new Item { Valor = 30 },
                new Item { Valor = 1 },
                new Item { Valor = 1 },
                new Item { Valor = 200 },
                new Item { Valor = 101 },
                new Item { Valor = 1000 },
            };

            return BuscaGulosa();
        }

        public int Cenario4()
        {
            Quadradonia = new Item[]
            {
                new Item { Valor = 934 },
                new Item { Valor = 21 },
                new Item { Valor = 1 },
                new Item { Valor = 14 },
                new Item { Valor = 9 },
                new Item { Valor = 100 },
                new Item { Valor = 934 },
                new Item { Valor = 2 },
                new Item { Valor = 934 },
                new Item { Valor = 23 },
            };
            Noglonia = new Item[]
            {
                new Item { Valor = 3 },
                new Item { Valor = 4 },
                new Item { Valor = 19 },
                new Item { Valor = 10 },
                new Item { Valor = 1 },
                new Item { Valor = 1 },
                new Item { Valor = 7 },
                new Item { Valor = 101 },
                new Item { Valor = 1000 },
                new Item { Valor = 20 },
            };

            return BuscaGulosa();
        }

        public int Cenario5()
        {
            Quadradonia = new Item[]
            {
                new Item { Valor = 5 },
                new Item { Valor = 5 },
                new Item { Valor = 7 },
                new Item { Valor = 2 },
                new Item { Valor = 9 },
            };
            Noglonia = new Item[]
            {
                new Item { Valor = 3 },
                new Item { Valor = 5 },
                new Item { Valor = 8 },
                new Item { Valor = 10 },
                new Item { Valor = 3 },
            };

            return BuscaGulosa();
        }

        public int Cenario6()
        {
            Quadradonia = new Item[]
            {
                new Item { Valor = 9 },
                new Item { Valor = 40 },
                new Item { Valor = 12 },
                new Item { Valor = 435 },
                new Item { Valor = 5 },
                new Item { Valor = 4 },
                new Item { Valor = 4 },
                new Item { Valor = 5 },
                new Item { Valor = 9 },
                new Item { Valor = 200 },
                new Item { Valor = 189 },
                new Item { Valor = 3 },
                new Item { Valor = 56 },
                new Item { Valor = 55 },
                new Item { Valor = 3 },
                new Item { Valor = 9 },
                new Item { Valor = 10 },
                new Item { Valor = 29 },
                new Item { Valor = 39 },
                new Item { Valor = 20 },
            };
            Noglonia = new Item[]
            {
                new Item { Valor = 400 },
                new Item { Valor = 299 },
                new Item { Valor = 59 },
                new Item { Valor = 2 },
                new Item { Valor = 4 },
                new Item { Valor = 400 },
                new Item { Valor = 3 },
                new Item { Valor = 200 },
                new Item { Valor = 43 },
                new Item { Valor = 88 },
                new Item { Valor = 99 },
                new Item { Valor = 12 },
                new Item { Valor = 34 },
                new Item { Valor = 4 },
                new Item { Valor = 1 },
                new Item { Valor = 2 },
                new Item { Valor = 1 },
                new Item { Valor = 1 },
                new Item { Valor = 45 },
                new Item { Valor = 5 },
            };

            return BuscaGulosa();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"### TESTES ###");
            Console.WriteLine($"Cenário 1: {new Guerra(3).Cenario1()}");
            Console.WriteLine($"Cenário 2: {new Guerra(4).Cenario2()}");
            Console.WriteLine($"Cenário 3: {new Guerra(10).Cenario3()}");
            Console.WriteLine($"Cenário 4: {new Guerra(10).Cenario4()}");
            Console.WriteLine($"Cenário 5: {new Guerra(5).Cenario5()}");
            Console.WriteLine($"Cenário 6: {new Guerra(20).Cenario6()}");
            Console.WriteLine($"##############");

            while (true)
            {
                Console.WriteLine($"### Novo Cenário #####");

                int size = Convert.ToInt32(Console.ReadLine());

                Guerra guerra = new Guerra(size);

                string[] inputQ = Console.ReadLine().Split(" ");

                for (int x = 0; x < size; x++)
                    guerra.Quadradonia[x] = new Item { Valor = Convert.ToInt32(inputQ[x]) };


                string[] inputN = Console.ReadLine().Split(" ");

                for (int x = 0; x < size; x++)
                    guerra.Noglonia[x] = new Item { Valor = Convert.ToInt32(inputN[x]) };

                Console.WriteLine($"Meu Cenário: {guerra.BuscaGulosa()}");
            }
        }
    }
}
