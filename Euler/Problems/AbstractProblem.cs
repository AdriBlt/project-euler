// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Problems
{
    using System;
    using System.Diagnostics;

    public abstract class AbstractProblem
    {
        private const int ProblemNumberDigitSize = 3;

        public void Run()
        {
            this.DebugProblem();
            Console.WriteLine();
            this.SolveProblem();
            WaitForEsc();
        }

        private void WaitForEsc()
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void SolveProblem()
        {
            Console.WriteLine($"Solving problem #{GetProblemNumber()}");
            Stopwatch watch = Stopwatch.StartNew();
            long solution = this.ComputeSolution();
            watch.Stop();
            long elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Solution: {solution}");
            Console.WriteLine($"Executed in {elapsedMs} ms.");
        }

        public abstract void DebugProblem();

        public abstract long ComputeSolution();

        protected void DebugResult(long computedValue, long expectedValue)
        {
            Console.WriteLine($"Debugging problem #{GetProblemNumber()}: {computedValue} (Expect: {expectedValue})");
        }

        public int GetProblemNumber()
        {
            string type = GetType().ToString();
            return int.Parse(type.Substring(type.Length - ProblemNumberDigitSize));
        }

        public static AbstractProblem InstanciateProblem(int problemId)
        {
            string className = GetProblemName(problemId);
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new ArgumentException(nameof(problemId));
            }

            return (AbstractProblem)Activator.CreateInstance(type);
        }

        private static string GetProblemName(int id)
        {
            return "Euler.Problems.P" + id.ToString().PadLeft(ProblemNumberDigitSize, '0');
        }
    }
}
