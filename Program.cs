namespace PrimeFactorization
{
    class Program {
        static void Main(string[] args) {
            int userNum = 0;

            //region Accounting for the user being mentally challenged
            if (args.Length == 0) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Pass in an integer as an argument to run the app!");
                Console.ResetColor();

                Environment.Exit(1);
            }

            try {
                userNum = Convert.ToInt32(args[0]);
            }

            catch {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid argument - {args[0]} is not an integer.");
                Console.ResetColor();

                Environment.Exit(-1);
            }
            //endregion

            Console.WriteLine($"Input number: {userNum}");

            List<int> factors = [];
            int workingNum = userNum;

            DateTime startTime = DateTime.Now;
            for (int currentDivisor = 2; workingNum != 1; currentDivisor = currentDivisor) {
                if (workingNum % currentDivisor == 0) {
                    factors.Add(currentDivisor);
                    workingNum /= currentDivisor;
                } else {
                    currentDivisor++;
                }
            }
            DateTime endTime = DateTime.Now;

            TimeSpan elapsedTime = endTime - startTime;

            Console.Write("Factorization finished! Factors: ");
            Console.Write(string.Join(", ", factors)); // TODO: Output cleanly as powers where applicablee

            Console.WriteLine();
            Console.WriteLine($"Took {Math.Round(elapsedTime.TotalMilliseconds)} ms");
        }
    }
}