using System;

namespace DecisionMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int stratsP1, stratsP2;
            Console.WriteLine("Estrategias jugador 1?");
            stratsP1=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Estrategias jugador 2?");
            stratsP2=Int32.Parse(Console.ReadLine());

            StrategicDominance(stratsP1,stratsP2);
        }

        static void StrategicDominance(int StrategiesP1, int StrategiesP2)
        {
            int[,] stratMatrix = new int[100, 100];
            bool correctNumber;
            bool[] stratUnviable = new bool[2];

            //Input data
            for (int i = 0; i < StrategiesP2; i++)
            {
                for (int j = 0; j < StrategiesP1; j++)
                {
                    do
                    {
                        Console.WriteLine("Input strat [{0},{1}]", i + 1, j + 1);
                        correctNumber = Int32.TryParse(Console.ReadLine(), out stratMatrix[i, j]);
                        if (!correctNumber)
                        {
                            Console.WriteLine("Numero invalido");
                        }
                    } while (!correctNumber);
                }
            }

            Console.Clear();
            //Check estrategias inviables para jugador 2
            for (int i = 0; i < StrategiesP2 - 1; i++) //strat principal
            {
                for (int j = 1; j < StrategiesP1; j++) //strat secundaria
                {
                    if (i < j)
                    {
                        stratUnviable[0] = false;
                        stratUnviable[1] = false;
                        //Console.WriteLine("Comparando estrategia {0} con estrategia {1}", i + 1, j + 1);
                        for (int k = 0; k < StrategiesP2; k++) //Filas
                        {
                            //Console.WriteLine("Comparando {0} con {1}", stratMatrix[i, k], stratMatrix[j, k]);
                            if (stratMatrix[i, k] > stratMatrix[j, k] && !stratUnviable[0])
                            {
                                stratUnviable[0] = true;
                            }
                            if (stratMatrix[i, k] < stratMatrix[j, k] && !stratUnviable[1])
                            {
                                stratUnviable[1] = true;
                            }
                        }

                        if (!stratUnviable[0])
                        {
                            Console.WriteLine("Estrategia {0} siempre es mejor que estrategia {1} para jugador 2", i + 1, j + 1);
                        }

                        if (!stratUnviable[1])
                        {
                            Console.WriteLine("Estrategia {1} siempre es mejor que estrategia {0} para jugador 2", i + 1, j + 1);
                        }
                    }
                }
            }

            //Check estrategias inviables para jugador 1
            for (int i = 0; i < StrategiesP2 - 1; i++) //strat principal
            {
                for (int j = 1; j < StrategiesP1; j++) //strat secundaria
                {
                    if (i < j)
                    {
                        stratUnviable[0] = false;
                        stratUnviable[1] = false;
                        //Console.WriteLine("Comparando estrategia {0} con estrategia {1}", i + 1, j + 1);
                        for (int k = 0; k < StrategiesP1; k++) //Filas
                        {
                            //Console.WriteLine("Comparando {0} con {1}", stratMatrix[i, k], stratMatrix[j, k]);
                            if (stratMatrix[k, i] < stratMatrix[k, j] && !stratUnviable[0])
                            {
                                stratUnviable[0] = true;
                            }
                            if (stratMatrix[k, i] > stratMatrix[k, j] && !stratUnviable[1])
                            {
                                stratUnviable[1] = true;
                            }
                        }

                        if (!stratUnviable[0])
                        {
                            Console.WriteLine("Estrategia {0} siempre es mejor que estrategia {1} para jugador 1", i + 1, j + 1);
                        }

                        if (!stratUnviable[1])
                        {
                            Console.WriteLine("Estrategia {1} siempre es mejor que estrategia {0} para jugador 1", i + 1, j + 1);
                        }
                    }
                }
            }
        }
    }
}
