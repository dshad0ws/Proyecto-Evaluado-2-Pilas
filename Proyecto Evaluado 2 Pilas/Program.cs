using System;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography;

namespace Proyecto_Evaluado_2_Pilas
{
    internal class Program
    {
        static int calcular(string op1, string op2, string oper)
        {
            int r = 0;
            if (oper == "+") { r = int.Parse(op1) + int.Parse(op2); }
            else if (oper == "-") { r = int.Parse(op2) - int.Parse(op1); }
            else if (oper == "*") { r = int.Parse(op1) * int.Parse(op2); }
            else if (oper == "/")
            {
                if (int.Parse(op2) != 0)
                {
                    r = int.Parse(op2) / int.Parse(op1);
                }
                else
                {
                    Console.WriteLine("Error");
                    r = 0;
                }
            }
            else
            {
                r = Convert.ToInt32(Math.Pow(double.Parse(op1), double.Parse(op2)));
            }
            return r;
        }
            static void evaluando(string ex)
        {
            bool Error = false;
            int cp = 0;
            Pilas p1 = new Pilas();
            string op1 = null;
            string op2 = null;
            string oper = null;
            string expf = null;
            for (int i = 0; i < ex.Length; i++)
            {
                if (ex[i] == '(')
                {
                    cp++;
                }
                else if (ex[i] == ')')
                {
                    op2 = p1.Pop();
                    oper = p1.Pop();
                    op1 = p1.Pop();
                    if (op1 != null && op2 != null && oper != null)
                    {
                        if ((oper == "+" || oper == "-" || oper == "*" || oper == "/" || oper == "*"))
                        {

                            expf = Convert.ToString(calcular(op1, op2, oper));
                            p1.Push(expf);
                        }
                    }
                    else
                    {
                        Error = true;
                    }
                    cp--;
                    op2 = "";
                    oper = "";
                    op1 = "";

                }
                else if (cp > 0)
                {
                    p1.Push(Convert.ToString(ex[i]));

                }
            }

            if (Error)
            {
                Console.WriteLine("Mano eso ta mal escrito");
            }
            else
            {
                Console.WriteLine(p1.Pop());
            }

            Console.ReadKey();
        }
            static void transformando(string ex)
            {
            bool Error = false;
            int cp = 0;
                Pilas p1 = new Pilas();
                string op1 = null;
                string op2 = null;
                string oper = null;
                string expf = null;
                for (int i = 0; i < ex.Length; i++)
                {
                if (ex[i]=='(')
                {
                    cp++;
                }
                    else if (ex[i] == ')')
                    {
                        op2 = p1.Pop();
                        oper = p1.Pop();
                        op1 = p1.Pop();
                        if(op1 != null && op2 != null && oper != null)
                        {
                        if((oper == "+" || oper == "-" || oper == "*" || oper == "/" || oper == "*"))
                        {
                            expf = op1 + op2 + oper;
                            p1.Push(expf);
                        }
                            
                        }
                    else
                    {
                        Error = true;
                    }
                    cp--;
                        op2 = "";
                        oper = "";
                        op1 = "";

                }
                    else if(cp>0)
                    {
                        p1.Push(Convert.ToString(ex[i]));

                    }
                }

            if (Error)
            {
                Console.WriteLine("Mano eso ta mal escrito");
            }
            else
            {
                Console.WriteLine(p1.Pop());
            }
            
                Console.ReadKey();
            }
            static bool validarexpos(string ex)//funcion para validar la expresion tomando en cuenta la parametros
            {
                int pa = 0;
                int pc = 0;
                int op = 0;
                int ope = 0;
                for (int i = 0; i < ex.Length; i++)
                {
                    if (ex[i] == '(')
                    {
                        pa++;
                    }
                    else if (ex[i] == ')')
                    {
                        pc++;
                    }
                    else if ((ex[i] == '+' || ex[i] == '-' || ex[i] == '*' || ex[i] == '/' || ex[i] == '^'))
                    {
                        op++;

                    }
                    else if ((ex[i] >= 65 && ex[i] <= 90) || (ex[i] >= 97 && ex[i] <= 122))
                    {
                        ope++;

                    }


                }
                if (pa == pc && pa >= 1)
                {
                    if (ope == op + 1)
                    {
                        if (op >= 1 && op == pa)
                        {
                            if(pa+pc+op+ope==ex.Length) return true;
                        }
                    }
                }
                return false;
            }
            static bool validarex(string ex)
            {
                int pa = 0;
                int pc = 0;
                int op = 0;
                int ope = 0;
                for (int i = 0; i < ex.Length; i++)
                {
                    if (ex[i] == '(')
                    {
                        pa++;
                    }
                    else if (ex[i] == ')')
                    {
                        pc++;
                    }
                    else if (ex[i] == '+' || ex[i] == '-' || ex[i] == '*' || ex[i] == '/' || ex[i] == '^')
                    {
                        op++;

                    }
                    else if (ex[i] >= 48 && ex[i] <= 57)
                    {
                        ope++;

                    }

                }
                if (pa == pc && pa >= 1)
                {
                    if (ope == op + 1)
                    {
                        if (op >= 1 && op == pa)
                        {
                        if (pa + pc + op + ope == ex.Length) return true; 
                        }
                    }
                }
                return false;
            }
            static void menu() //menu de opciones
            {
                int op = 1;
                string exp = "";
                bool error;
                string msj = "";

                do
                {//creamos las opciones dentro de un do while para evitar alguna opcion no permitida 
                    Console.Clear();
                    error = false;
                    Console.WriteLine("Menu de opciones");
                    Console.WriteLine("<1> Transformar Expresion");
                    Console.WriteLine("<2> Evaluar Expresion");
                    Console.WriteLine("<3> Salir");
                    try
                    {
                        Console.Write("Opcion: ");
                        op = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        op = -1;
                        msj = ex.Message;
                        error = true;
                    }

                    if (op == 3)
                    {
                        Console.Clear();
                        Console.Write("Hasta la proximaaa");
                        Console.ReadKey();
                    }
                    else if (op == 1)
                    {

                        Console.Clear();
                        Console.WriteLine("Ingrese la expresion que desea transformar");
                        exp = Console.ReadLine();
                        if (validarexpos(exp) == true)
                        {
                            transformando(exp);
                        }
                        else
                        {
                            Console.WriteLine("Mano eso ta malo. No cumple con los parametros establecidos.");
                        }
                        Console.ReadKey();


                    }
                    else if (op == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Por favor Ingrese la expresion");
                    exp= Console.ReadLine();
                        if (validarex(exp) == true)
                        {
                            evaluando(exp);
                        }
                        else
                        {
                            Console.WriteLine("Mano eso ta malo. No cumple con los parametros establecidos");
                        }
                        Console.ReadKey();

                    }
                    else if (error == false)
                    {
                        msj = "Valor invalido";
                        error = true;
                    }
                    if (error)
                    {
                        Console.WriteLine("Error: " + msj);
                        op = -1;
                        Console.ReadKey();
                    }
                } while (op != 3);
            }
            static void Main(string[] args)
            {
                menu();
           }
    }
}
