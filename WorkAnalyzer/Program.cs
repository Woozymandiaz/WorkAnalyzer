using System;
using System.Collections.Generic;
using System.IO;

namespace WorkAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = null;
            List<int> incidents = new List<int>();
            List<int> repeateds = new List<int>();

            try
            {
                sr = new StreamReader("C:..\\..\\..\\incidents.txt");
                String line = sr.ReadLine();
                while (line != null)
                {
                    int workItem = workNumber(line);
                    incidents.Add(workItem);
                    line = sr.ReadLine();
                }

                Console.WriteLine($"Incidentes repetidos:{System.Environment.NewLine}");

                foreach(int incident in incidents)
                {
                    if(moreThanOne(incidents, incident))
                    {
                        if (!repeateds.Contains(incident))
                        {
                            repeateds.Add(incident);
                        }
                    }
                }

                foreach(int incident in repeateds)
                {
                    Console.WriteLine(incident);
                }

                Console.WriteLine();
                Console.WriteLine($"Total de incidentes: {incidents.Count}");
                Console.WriteLine($"Total de incidentes repetidos: {repeateds.Count}");
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine($"Arquivo não encontrado: {e.Message}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ocorreu algum erro: {e.Message}");
            }
            finally
            {
                sr.Close();
            }

            Console.Write($"{System.Environment.NewLine}Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static bool moreThanOne(List<int> list, int target)
        {
            int repeats = 0;
            foreach (int item in list)
            {
                if (target == item)
                {
                    repeats += 1;
                }
                if (repeats > 1)
                {
                    return true;
                }
            }
            return false;
        }

        static int workNumber(String line)
        {
            String[] aux = line.Split('/');
            int workItem = int.Parse(aux[aux.Length - 1]);
            return workItem;
        }
    }
}
