using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraBinário
{
    class Calculador
    {
        public static float Potencia(float a, float b)
        {
            float r = 1;
            for (int i = 0; i < b; i++)
            {
                r *= a;
            }
            return r;
        }

        public static string SomaBin(string a, string b)
        {
            char[] alg_a = a.ToArray();
            char[] alg_b = b.ToArray();

            if(a.ToArray().Length < b.ToArray().Length)
            {
                for (int i = 0; i < alg_b.Length - alg_a.Length;i++)
                {
                    a = "0" + a;
                }
            }

            else if(a.ToArray().Length > b.ToArray().Length)
            {
                for (int i = 0; i < alg_a.Length - alg_b.Length; i++)
                {
                    b = "0" + b;
                }
            }            
            
            alg_a = a.ToArray();
            alg_b = b.ToArray();
            string[] alg_r = new string[alg_a.Length];
            float extra = 0;

            for (int i = 0; i < alg_a.Length; i++)
            {
                if(float.Parse(alg_a[(alg_a.Length - 1) - i].ToString()) + float.Parse(alg_b[(alg_a.Length - 1) - i].ToString()) + extra < 2)
                {
                    alg_r[i] = (float.Parse(alg_a[(alg_a.Length - 1) - i].ToString()) + float.Parse(alg_b[(alg_a.Length - 1) - i].ToString()) + extra).ToString();
                    extra = 0;
                }

                else
                {
                    if(float.Parse(alg_a[(alg_a.Length - 1) - i].ToString()) + float.Parse(alg_b[(alg_a.Length - 1) - i].ToString()) + extra == 2)
                    {
                        alg_r[i] = "0";
                        extra = 1;
                    }
                    else if(float.Parse(alg_a[(alg_a.Length - 1) - i].ToString()) + float.Parse(alg_b[(alg_a.Length - 1) - i].ToString()) + extra > 2)
                    {
                        alg_r[i] = "1";
                        extra = 1;
                    }
                }                
            }

            string result = "";
            if(extra > 0)
            {
                result = extra.ToString();
            }

            for (int i = 0; i < alg_r.Length; i++)
            {
                result += alg_r[(alg_r.Length - 1) - i];
            }

            return result;
        }

        public static string MultBin(string a, string b)
        {
            string result = "0";

            for (int i = 0; i < int.Parse(Convertor.BinToDec(b)); i++)
            {
                result = SomaBin(result, a);
            }

            return result;
        }

        public static string SubBin(string a, string b)
        {
            if (float.Parse(a) > float.Parse(b))
            {
                char[] alg_a = a.ToArray();
                char[] alg_b = b.ToArray();

                for (int i = 0; i < alg_a.Length - alg_b.Length; i++)
                {
                    b = "0" + b;
                }

                alg_b = b.ToArray();
                string[] alg_r = new string[a.ToArray().Length];
                int x = 0;

                for (int i = 0; i < alg_b.Length;i++ )
                {
                    if(float.Parse(alg_a[alg_a.Length - 1 - i].ToString()) - float.Parse(alg_b[alg_b.Length - 1 - i].ToString()) >= 0)
                    {
                        alg_r[i] = (float.Parse(alg_a[alg_a.Length - 1 - i].ToString()) - float.Parse(alg_b[alg_b.Length - 1 - i].ToString())).ToString();
                    }

                    else if (float.Parse(alg_a[alg_a.Length - 1 - i].ToString()) - float.Parse(alg_b[alg_b.Length - 1 - i].ToString()) < 0)
                    {
                        x = 1;
                        while(x > 0)
                        {
                            if( (alg_a[alg_a.Length - 1 - i - x].Equals('1')))
                            {
                                alg_a[alg_a.Length - 1 - i - x] = '0';
                                x = 0;
                            }

                            else
                            {
                                alg_a[alg_a.Length - 1 - i - x] = '1';
                                x++;
                            }
                        }
                        alg_r[i] = "1";
                    }
                }
                string result = "";
                bool leftZero = true;
                
                for (int i = alg_r.Length - 1; i >= 0; i--)
                {
                    if(leftZero && alg_r[i].Equals("1"))
                    {
                        leftZero = false;
                    }

                    if(!leftZero)
                    {
                        result += alg_r[i];
                    }
                }                
                    return result;
            }

            else if (float.Parse(a) < float.Parse(b))
            {
                return "-"+SubBin(b,a);
            }

            else
            {
                return "0";
            }
        }

        public static string DivBin(string a, string b)
        {
            string q = "0";
            while(float.Parse(a) >= float.Parse(b))
            {
                a = SubBin(a,b);
                q = SomaBin(q, "1");
            }
            return "Quo="+q+"   Res="+a;
        }
    }
}