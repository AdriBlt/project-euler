// Copyright (c) Microsoft Corporation. All rights reserved.
namespace Euler.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Euler.Problems;
    using Xunit;

    public class ProblemsShould
    {
        public static IEnumerable<object[]> ProblemsOutput
            => new Dictionary<int, long>
            {
                [1] = 233168,
                [2] = 4613732,
                [3] = 6857,
                [4] = 906609,
                [5] = 232792560,
                [6] = 25164150,
                [7] = 104743,
                [8] = 23514624000,
                [9] = 31875000,
                [10] = 142913828922,
                [11] = 70600674,
                [12] = 76576500,
                [13] = 5537376230,
                [14] = 837799,
                [15] = 137846528820,
                [16] = 1366,
                [17] = 21124,
                [18] = 1074,
                [19] = 171,
                [20] = 648,
                [21] = 31626,
                [22] = 871198282,
                [23] = 4179871,
                [24] = 2783915460,
                [26] = 983,
            }
            .Select(entry => new object[] { entry.Key, entry.Value });


        [Theory]
        [MemberData(nameof(ProblemsOutput))]
        public void OutputTheExpectedSolution(int problemId, long expectedOutput)
        {
            AbstractProblem problem = AbstractProblem.InstanciateProblem(problemId);
            long solution = problem.ComputeSolution();
            Assert.Equal(expectedOutput, solution);
        }
    }
}
