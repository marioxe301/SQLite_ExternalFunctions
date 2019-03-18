using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Data;

namespace ExternalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion = "";
            bool check = true;
            while (check)
            {
               
                Console.WriteLine("----------------Funciones Externas con SQLite----------------");
                Console.WriteLine("Opciones: \n query (Ejecutar Funciones) \n salir");
                opcion = Console.ReadLine();

                switch (opcion.ToLower())
                {
                    case "query":
                        Console.Clear();
																	//Poner el Path del archivo database creado por SQLite
                        SQLiteConnection con = new SQLiteConnection("Data Source=C:\\Users\\MGFE\\Desktop\\DatabaseTest.db; Version = 3; Compress = True;");
                        con.Open();

                        String sql = "";
                        Console.WriteLine("Escriba el nombre de la funcion con sus parametros (SELECT por default):");
                        sql = Console.ReadLine();

                        SQLiteCommand cmd = new SQLiteCommand("select " + sql, con);

                        SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        cmd.Dispose();
                        con.Close();

                        foreach (DataRow dr in dt.Rows)
                        {
                            Console.WriteLine(dr[sql].ToString());
                        }

                        break;
                    case "salir":
                        check = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opcion Invalida");
                        break;
                }
            }
        }
    }
}
