using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_29_Ricciotti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AlberoBinarioIntero radice = new AlberoBinarioIntero();

            radice.inserisci(69);
            radice.inserisci(89);
            radice.inserisci(28);
            radice.inserisci(39);
            radice.inserisci(66);
            radice.inserisci(44);
            radice.inserisci(12);
            radice.inserisci(2);
            radice.inserisci(71);

            Console.WriteLine(radice);

            Console.ReadKey();
        }

        public class AlberoBinarioIntero
        {
            private int val;
            private AlberoBinarioIntero dx;
            private AlberoBinarioIntero sx;
            private int depth;
            private static int depthMax = 0;

            public AlberoBinarioIntero()
            {
                this.val = 0;

            }

            public bool inserisci(int n)
            {


                if (this.val == 0)
                {
                    this.val = n;

                    return true;
                }
                else if (this.val > n)
                {
                    if (dx == null)
                    {
                        dx = new AlberoBinarioIntero();
                        sx = new AlberoBinarioIntero();
                    }
                    sx.depth = this.depth + 1;
                    if (sx.depth > depthMax)
                    {
                        depthMax = sx.depth;
                    }
                    return sx.inserisci(n);
                }
                else if (this.val <= n)
                {
                    if (dx == null)
                    {
                        dx = new AlberoBinarioIntero();
                        sx = new AlberoBinarioIntero();
                    }
                    dx.depth = this.depth + 1;
                    if (dx.depth > depthMax)
                    {
                        depthMax = dx.depth;
                    }
                    return dx.inserisci(n);
                }
                return false;
            }

            public override string ToString()
            {
                if (dx != null && sx!=null)
                {
                    return this.val + "(" + sx + "," + dx + ")";

                }
                else if(sx == null&& dx==null)
                {
                    return this.val+"";
                }
                else if(sx != null && dx == null)
                {
                    return this.val + "(" + sx + "," + 0 + ")";
                }
                else
                {
                    return this.val + "(" + 0 + "," + dx + ")";
                }
            }
            /*
            public string findlevel(int d, string s, string spazio)
            {
                string a = spazio;
                int cont = 0;
                if (d == this.depth)
                {
                    return val + "";
                }


                if (val == 0)
                {
                    return 0 + "";
                }
                else
                {

                    //for (int i = 0; i <= depthMax - d; i++)
                    //{
                    //    a += spazio;
                    //}

                    if (sx == null && dx != null)
                        s += dx.findlevel(d, "", spazio);
                    else if (sx != null && dx == null)
                        s += sx.findlevel(d, "", spazio); //+ a + 0;
                    else if (dx != null && sx != null)
                    {
                        s += sx.findlevel(d, "", spazio);
                        if (cont != 1)
                        {
                            s += a + a;
                            cont++;
                        }
                        else
                        {
                            s += " ";
                            cont--;
                        }
                        s += dx.findlevel(d, "", spazio);

                    }

                }
                return s;
            }

            public void stampa()
            {
                int strati = depthMax;
                int conta = 0;
                string spazio;
                do
                {
                    spazio = "      ";

                    for (int i = 0; i < strati; i++)
                    {
                        spazio += spazio;
                    }
                    Console.Write(spazio);
                    Console.WriteLine(findlevel(conta, " ", spazio));

                    conta++;
                    strati--;

                } while (conta <= depthMax);

            }
            */

        }
    }
}
