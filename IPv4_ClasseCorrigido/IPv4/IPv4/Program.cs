using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPv4
{
    class Program
    {
        enum Opcao { Inserir = 1, Favoritos = 2, Sair = 3};
        enum m3 { Apresentar_classe = 1, Identificar_Pub_Priv = 2, TestarConectividade = 3, Guardar_fav = 4 }
        enum EscolherIP { EscolhaIP = 1, Sair = 0 };
        static List<EndIPv4> ipv4 = new List<EndIPv4>();
        static List<EndIPv4> favs = new List<EndIPv4>();


        static int Menu()
        {
 
            int aux = 0;
            Console.WriteLine("Qual a opção pretendida?");
            foreach (Opcao val in Enum.GetValues(typeof(Opcao)))
            {
                Console.WriteLine(++aux + " - " + val);
            }
            return LerValor();
        }

        static void Menu3()
        {
            Console.Clear();
            int aux = 0;
            Console.WriteLine(ipv4.Last());
            foreach(m3 val in Enum.GetValues(typeof(m3)))
            {
                Console.WriteLine(++aux + " - " + val);
            }
            Console.WriteLine("Escolha a opcao:");
            try
            {
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        saberClass();
                        break;
                    case 2:
                        ipv4.Last().PrivPub();
                        break;
                    case 4:
                        addFav();
                        break;
                    case 5:
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Insira um numero correto.");
            }
            
        }
        static int id;

        static void saberClass()
        {
            ipv4.Last().Classe();
        }

        static void addFav()
        {
            try
            {
                StreamWriter wr = new StreamWriter(@"favoritos.txt");
                favs.Add(new EndIPv4(ipv4.Last()));
                foreach (EndIPv4 ip in favs)
                {
                    wr.WriteLine(ip);
                }
                wr.Close();
            }
            catch
            {
                Console.WriteLine("OCORREU UM ERRO!");
            }
        }


        static void lerFav()
        {
            Console.Clear();
            int p1, p2, p3, p4, p5;
            try
            {
                StreamReader rd = new StreamReader(@"favoritos.txt");
                while (!rd.EndOfStream)
                {
                    string read = rd.ReadLine();
                    //split ao endereço
                    string[] split = read.Split('/');
                    //split aos octetos
                    string[] split2 = split[0].split('.');
                    p1 = int.Parse(split2[0]);
                    p2 = int.Parse(split2[1]);
                    p3 = int.Parse(split2[2]);
                    p4 = int.Parse(split2[3]);
                    p5 = int.Parse(split[1]);
                    EndIPv4 ip = new EndIPv4(id, p1, p2, p3, p4, p5);
                    favs.Add(ip);
                }
                rd.Close();
            }
            catch
            {
                Console.WriteLine("O ficheiro não existe!");
            }
        }


        
        static int LerValor()
        {
            int val = 0;
            bool flag = false;
            do
            {
                try
                {
                    val = int.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valor incorrecto, digite novamente:");
                    flag = false;
                }
            } while (!flag);
            return val;
        }

        static void inserir()
        {
            try
            {
                Console.WriteLine("Insira o 1º Octeto:");
                int p1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o 2º Octeto:");
                int p2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o 3º Octeto:");
                int p3 = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o 4º Octeto:");
                int p4 = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira a mascara:");
                int mask = int.Parse(Console.ReadLine());
                int id = ipv4.Count();
                ipv4.Add(new EndIPv4(id, p1, p2, p3, p4, mask));
                Menu3();
            }
            catch
            {
                Console.WriteLine("Insira um valor valido.");
            }
            
        }

        static void listarM1()
        {
            Console.Clear();

            foreach (EndIPv4 ip in ipv4)
            {
                Console.WriteLine(ip.ToString());
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int op;
            do
            {
                op = Menu();
                switch (op)
                {
                    case 1:
                        inserir();
                        break;
                    case 2:
                        lerFav();
                        Menu3();
                        break;
                }
            } while (op != (int)Opcao.Sair);
        }
    }
}
