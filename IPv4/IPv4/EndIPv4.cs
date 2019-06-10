using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPv4
{
    class EndIPv4
    {
        int p1, p2, p3, p4, mask, id;
        public EndIPv4()
        {
            id = 0;
            p1 = 0;
            p2 = 0;
            p3 = 0;
            p4 = 0;
            mask = 32;
        }
        public EndIPv4(int id, int p1, int p2, int p3, int p4, int m)
        {
            this.id = id;
            if (!setP1(p1)) this.p1 = 0;
            if (!setP2(p2)) this.p2 = 0;
            if (!setP3(p3)) this.p3 = 0;
            if (!setP4(p4)) this.p4 = 0;
            if (!setMask(m)) mask = 32;
        }
        public EndIPv4(EndIPv4 ip)
        {
            p1 = ip.getP1();
            p2 = ip.getP2();
            p3 = ip.getP3();
            p4 = ip.getP4();
            mask = ip.getMask();
        }
        public bool setP1(int p1)
        {
            if(p1 > 0 && p1 < 255)
            {
                this.p1 = p1;
                return true;
            }
            return false;
        }
        public bool setP2(int p2)
        {
            if(p2 > 0 && p2 < 255)
            {
                this.p2 = p2;
                return true;
            }
            return false;
        }
        public bool setP3(int p3)
        {
            if(p3 > 0 && p3 < 255)
            {
                this.p3 = p3;
                return true;
            }
            return false;
        }
        public bool setP4(int p4)
        {
            if(p4 > 0 && p4 < 255)
            {
                this.p4 = p4;
                return true;
            }
            return false;
        }
        public bool setMask(int m)
        {
            if(m >= 0 && m <= 32)
            {
                mask = m;
                return true;
            }
            return false;
        }
        public int getP1()
        {
            return p1;
        }
        public int getP2()
        {
            return p2;
        }
        public int getP3()
        {
            return p3;
        }
        public int getP4()
        {
            return p4;
        }
        public int getMask()
        {
            return mask;
        }
        public int getId()
        {
            return id;
        }

        public void Binario()
        {
            int[] ver = { 128, 64, 32, 16, 8, 4, 2, 1 };
            int[] bin = new int[8];

            for (int a = 0; a < bin.Length; a++)
            {
                for (int i = 0; i < ver.Length; i++)
                {
                    if(p1 < ver[i])
                    {
                        p1 -= ver[i];
                        bin[i] = 1;
                    }
                    else
                    {
                        bin[i] = 0;
                    }
                }
            }
        }

        public void Classe()
        {
            string a = "A";
            string b = "B";
            string c = "C";
            if (p1 >= 0 && p1 <= 127) { Console.WriteLine(a); } else { if (p1 >= 128 && p1 <= 191) { Console.WriteLine(b); } else { if (p1 >= 192 && p1 <= 223) { Console.WriteLine(c); } else { Console.WriteLine("D"); } } }
            
            
        }
        public void PrivPub()
        {
            string p = "Privado";
            if (p1 == 10 && p2 <= 255) 
            {
                Console.WriteLine(p);
            }
            else
            {
                if (p1 == 102 && p2 == 16)
                {
                    Console.WriteLine(p);
                }
                else
                {
                    if (p1 == 172 && p2 >= 16 && p2 <= 31)
                    {
                        Console.WriteLine(p);
                    }
                    else
                    {
                        Console.WriteLine("Publico");
                    }
                }
            }
            Console.Clear();
        }

        public void testCom()
        {

        }

        public override string ToString()
        {
            return id + " - " + p1 + "." + p2 + "." + p3 + "." + p4 + "/" + mask;
        }
    }
}
