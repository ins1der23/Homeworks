using System;
public class Point
{
    public static double GetDouble(string text)
    {
        double num = 0;
        bool flag = true;
        do
        {
            Console.Write($"{text}: ");
            flag = double.TryParse(Console.ReadLine(), out num);
        } while (!flag);
        return RoundTo2(num);
    }
    public static double ReturnDouble(double num)
    {
        return RoundTo2(num);
    }
    public static bool ParallelCheck(double kx1, double kx2)
    {
        return kx1 == kx2;
    }
    public static bool PositiveCheck(double b)
    {
        return b >= 0;
    }
    public static double RoundTo2(double num)
    {
        return Math.Round(num, 2);
    }
    public static string ShowMatrix(double[,] anyMatrix)
    {
        string output = String.Empty;
        for (int rows = 0; rows < anyMatrix.GetLength(0); rows++)
        {
            for (int columns = 0; columns < anyMatrix.GetLength(1); columns++)
            {
                output = output + anyMatrix[rows, columns] + " ";
            }
            output = output + Environment.NewLine;
        }
        return output;
    }

    public static double[,] InverseMatrix(double[,] someMatrix)
    {
        double denominator = someMatrix[0, 0] * someMatrix[1, 1] - someMatrix[0, 1] * someMatrix[1, 0];
        double[,] inverseMatrix = new double[2, 2];
        inverseMatrix[0, 0] = RoundTo2((someMatrix[1, 1] / denominator));
        inverseMatrix[0, 1] = RoundTo2((-someMatrix[0, 1] / denominator));
        inverseMatrix[1, 0] = RoundTo2((-someMatrix[1, 0] / denominator));
        inverseMatrix[1, 1] = RoundTo2((someMatrix[0, 0] / denominator));
        return inverseMatrix;
    }
    public static double[,] MultiplyMatrix(double[,] firstMatrix, double[,] secondMatrix)
    {
        double[,] resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                for (int k = 0; k < firstMatrix.GetLength(1); k++)
                {
                    resultMatrix[i, j] += (firstMatrix[i, k] * secondMatrix[k, j]);
                    resultMatrix[i, j] = RoundTo2(resultMatrix[i, j]);
                }
            }
        }
        return resultMatrix;
    }
    public static double[,] CrossPoint(double[,] matrixK, double[,] matrixB)
    {
        double[,] inverseMatrix = InverseMatrix(matrixK);
        double[,] resultMatrix = MultiplyMatrix(inverseMatrix, matrixB);
        return resultMatrix;
    }
}
