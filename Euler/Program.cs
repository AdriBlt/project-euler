namespace Euler
{
    using Euler.Problems;

    class Program
    {
        static void Main(string[] args)
        {
            int problemId = 51;
            AbstractProblem problem = AbstractProblem.InstanciateProblem(problemId);
            problem.Run();
        }
    }
}
