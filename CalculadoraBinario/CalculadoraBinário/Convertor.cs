using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraBinário
{
    public class Convertor
    {        
        public static string BinToDec(string a)
        {
            float result = 0;
            char[] algarismos = a.ToArray();

            for (int i = 0; i < algarismos.Length; i ++)
            {
                result += float.Parse(algarismos[(algarismos.Length - 1) - i].ToString()) * Calculador.Potencia(2, i);
            }

            return result.ToString();
        }

        public static string BinToHex(string a)
        {
            return DecToHex(float.Parse(BinToDec(a)));
        }

        static string DecToHex(float a)
        {
            if ((a - a % 16) / 16 == 0)
            {
                if(a%16 < 10)
                {
                    return (a % 16).ToString();
                }

                else
                {
                    if (a % 16 == 10) 
                    {
                        return "a";
                    }
                    else if (a % 16 == 11) 
                    {
                        return "b";
                    }
                    else if (a % 16 == 12) 
                    {
                        return "c";
                    }
                    else if (a % 16 == 13) 
                    {
                        return "d";
                    }
                    else if (a % 16 == 14) 
                    {
                        return "e";
                    }
                    else 
                    {
                        return "f";
                    }
                }  
            }

            else
			{
				if(a%16 < 10)
				{
					return DecToHex((a - (a % 16)) / 16) + "" + (a % 16).ToString();
				}				
	
				else
				{
					if (a % 16 == 10) 
					{
						return DecToHex((a - (a % 16)) / 16) + "" + "a";
					}
					else if (a % 16 == 11) 
					{
						return DecToHex((a - (a % 16)) / 16) + "" + "b";
					}
					else if (a % 16 == 12) 
					{
						return DecToHex((a - (a % 16)) / 16) + "" + "c";
					}
					else if (a % 16 == 13) 
					{
						return DecToHex((a - (a % 16)) / 16) + "" + "d";
					}
					else if (a % 16 == 14) 
					{
						return DecToHex((a - (a % 16)) / 16) + "" + "e";
					}
					else 
					{
						return DecToHex((a - (a % 16)) / 16) + "" + "f";
					}
				}
			}
        }
    }
}
