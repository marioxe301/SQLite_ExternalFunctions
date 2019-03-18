using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Net.NetworkInformation;

namespace ExternalFunctions
{
       /*  public int Ping(string ip)
         {
             Ping Pings = new Ping();
             PingReply Reply = Pings.Send(ip);

             if (Reply.Status == IPStatus.Success)
             {
                 Console.WriteLine("Succes");
                 return 1;
             }
             else
             {
                 Console.WriteLine("Error");
                 return 0;
             }
         }
         public double PMT(double Rate, double NPer, double Pv)
         {
             //P = (Pv*R) / [1 - (1 + R)^(-n)]
             return (Pv*Rate)/((1-(Math.Pow(1+Rate,-NPer))));
         }

         public string Bin2Dec(string binary)
         {
             return Convert.ToInt32(binary, 2).ToString();
         }

         public double C2F(double C)
         {
             return (C * 9) / 5 + 32;
         }

         public double F2C(double F)
         {
             return (F - 32) * 5 / 9;
         }

         public int Factorial(int num)
         {
             int resultado = 1;
             for (int i = 1; i <= num; i++)
             {
                 resultado = resultado * i;
             }

             return resultado;
         }

         public string Hex2Dec(string hex)
         {
             return Convert.ToInt64(hex, 16).ToString();
         }

         public string Dec2Hex(int dec)
         {
             string r = dec.ToString("X");
             return r;
         }

         public int CompareString(string a,string b)
         {
             if (a.Length < b.Length)
             {
                 return -1;
             }else if (a.Length == b.Length)
             {
                 return 0;
             }
             else
             {
                 return 1;
             }
         }

         public string trim(string palabra,string letra)
         {
             return palabra.Trim(letra.ToCharArray());
         }

         public string repeat(string palabra,int n)
         {
             string a = palabra;

             for(int i = 0; i <= n-1; i++)
             {
                 a = a + palabra;
             }

             return a;
         }
     }*/
    [SQLiteFunction(Name ="PING",Arguments =1,FuncType = FunctionType.Scalar)]
    class PING : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            Ping Pings = new Ping();
            try
            {

            PingReply Reply = Pings.Send(args[0].ToString());

                if (Reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Succes");
                    return 1;
                }
                
            }catch(Exception e)
            {
                Console.WriteLine("Error");
            }

            return 0;
        }
    }

    [SQLiteFunction(Name = "PMT", Arguments = 3, FuncType = FunctionType.Scalar)]
    class PMT : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return (Convert.ToDouble(args[2]) * Convert.ToDouble(args[0])) / ((1 - (Math.Pow(1 + Convert.ToDouble(args[0]), -Convert.ToDouble(args[1])))));
        }
    }

    [SQLiteFunction(Name = "B2D", Arguments = 1, FuncType = FunctionType.Scalar)]
    class B2D : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return Convert.ToInt32(args[0].ToString(), 2).ToString();
        }
    }

    [SQLiteFunction(Name = "C2F", Arguments = 1, FuncType = FunctionType.Scalar)]
    class C2F : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return (Convert.ToDouble(args[0]) * 9) / 5 + 32;
        }
    }

    [SQLiteFunction(Name = "F2C", Arguments = 1, FuncType = FunctionType.Scalar)]
    class F2C : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return (Convert.ToDouble(args[0]) - 32) * 5 / 9;
        }
    }

    [SQLiteFunction(Name = "Factorial", Arguments = 1, FuncType = FunctionType.Scalar)]
    class Factorial : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            int resultado = 1;
            for (int i = 1; i <= Convert.ToInt32(args[0]); i++)
            {
                resultado = resultado * i;
            }

            return resultado;
        }
    }

    [SQLiteFunction(Name = "H2D", Arguments = 1, FuncType = FunctionType.Scalar)]
    class H2D : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return Convert.ToInt64(args[0].ToString(), 16).ToString();
        }
    }

    [SQLiteFunction(Name ="D2H",Arguments =1,FuncType =FunctionType.Scalar)]
    class D2H : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            string r = Convert.ToInt32(args[0]).ToString("X");
            return r;
        }
    }

    [SQLiteFunction(Name ="CmpS",Arguments =2,FuncType =FunctionType.Scalar)]
    class CmpS : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            if (args[0].ToString().Length < args[1].ToString().Length)
            {
                return -1;
            }
            else if (args[0].ToString().Length == args[1].ToString().Length)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    [SQLiteFunction(Name ="TrimS",Arguments =2,FuncType =FunctionType.Scalar)]
    class TrimS : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            return args[0].ToString().Trim(args[1].ToString().ToCharArray());
        }
    }

    [SQLiteFunction(Name ="RepeatS",Arguments =2,FuncType =FunctionType.Scalar)]
    class RepeatS : SQLiteFunction
    {
        public override object Invoke(object[] args)
        {
            string a = args[0].ToString();

            for (int i = 1; i <= Convert.ToInt32(args[1]) - 1; i++)
            {
                a = a + args[0].ToString();
            }

            return a;
        }
    }

}
