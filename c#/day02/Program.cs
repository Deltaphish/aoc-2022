using System.Collections;

public class Program
{
    public static void Main()
    {
        string input = System.IO.File.ReadAllText("./input");
        ArrayList solvers = new ArrayList();
        solvers.Add(new Part01());
        solvers.Add(new Part02());


        foreach (ISolver s in solvers)
        {
            System.Console.WriteLine(s.Run(input));
        }
    }

}