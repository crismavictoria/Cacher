using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Diana.Code.Challenge
{
    /// <summary>
    /// The test harness creates each cache implementation (fast/slow) and executes the
    /// methods. Your challenge is to implement the fast cache and make it super fast.
    /// </summary>
    public class TestHarness
    {
        private int _count;

        /// <question>
        /// What is a uint and why would you use one?
        /// </question>
        /// <answer>
        /// uint is a data type that represents an unsigned integer.
        /// uint is used when there is a specific need for an unsigned integer (non-negative) or to optimize memory usage.
        /// </answer>

        private uint _testNumber;

        private uint _loopNumber;

        private ICacheStuff<Employee> _cache;

        private String _results;

        public TestHarness()
        {
        }

        private ICachedObject a;
        private ICachedObject b;
        private ICachedObject c;

        public TestHarness Setup(ICacheStuff<Employee> cache, int count, uint testNumber, uint loopNumber, Func<Guid, string, string, Employee> createItem)
        {
            _cache = cache;
            _count = count;
            _testNumber = testNumber;
            _loopNumber = loopNumber;

            Console.WriteLine($"\r\n\r\n{_cache.CacheName}\r\n");

            for (int i = 0; i < _count; i++)
            {
                var item = createItem(
                    Guid.NewGuid(),
                    $"Name {i}",
                    "Description " + i.ToString("0000")
                );

                if (i == 0) a = item;
                if (i == _count/2) b = item;
                if (i == _count - 1) c = item;

                _cache.AddItem(item);
            }

            return this;
        }

        public ICachedObject First()
        {
            return a;
        }

        public ICachedObject Last()
        {
            return c;
        }

        public ICachedObject Mid()
        {
            return b;
        }
        /// <question>
        /// What is the recommended usage of vars?
        /// </question>
        /// <answer>
        /// var is commonly used when working with anonymous types, which are types inferred by the compiler based on the properties assigned in an object initializer.
        /// var is appropriate when the exact type is not relevant or when you want to take advantage of polymorphism.
        /// </answer>
        public async Task<TestHarness> Run()
        {
            var firstItem = First();
            var lastItem = Last();
            ICachedObject midItem = Mid();

            uint totalTests = _testNumber;

            await TestFind("First Item ", firstItem, totalTests);
            await TestFind("Mid Item   ", midItem, totalTests);
            await TestFind("Last Item  ", lastItem, totalTests);

            return this;
        }

        /// <question>
        /// What improvements you suggest to the coder for this method?
        /// Please refactor/change this method and make it better.
        /// Describe what you did.
        /// </question>
        /// <answer>
        /// 1. Use Stopwatch consistently. The method creates two instances of Stopwatch, testWatch and stopWatch. It's recommended to use a single Stopwatch instance consistently for accurate timing measurements. We can declare and start the Stopwatch at the beginning of the method and stop it at the end to measure the total elapsed time.
        /// 2. Improve variable naming. Some variable names are not very descriptive and could be improved for better readability. 
        /// 3. Separate responsibilities into smaller methods. The method currently has multiple responsibilities, including finding objects in the cache, measuring performance, and displaying output. Extract some of these responsibilities into separate methods to improve code organization and maintainability.
        /// 4. Encapsulate the logic of finding objects in the cache. Instead of having the object-finding logic within the loop, consider encapsulating it in a separate method that returns a boolean indicating if the object was found or not. This can make the code more readable and easier to follow.
        /// </answer>
        private async Task<bool> TestFind(string testName, ICachedObject objectToFind, uint totalTests)
        {
            if (objectToFind == null)
            {
                Console.WriteLine("Not Implemented");
                return  await Task.FromResult(false);
            }

            bool match = true;
            Stopwatch stopwatch = Stopwatch.StartNew();

            long totalTicks = 0;
            long minTicks = long.MaxValue;
            long maxTicks = long.MinValue;

            for (int run = 0; run < totalTests; run++)
            {
                Stopwatch iterationStopwatch = Stopwatch.StartNew();

                match &= FindObjectInCache(testName, objectToFind, run);

                iterationStopwatch.Stop();

                long elapsedTicks = iterationStopwatch.ElapsedTicks;
                totalTicks += elapsedTicks;
                minTicks = Math.Min(minTicks, elapsedTicks);
                maxTicks = Math.Max(maxTicks, elapsedTicks);

                Console.Write($"\r{testName} {run + 1}  ");
            }

            stopwatch.Stop();

            TimeSpan totalTime = stopwatch.Elapsed;

            string stats = $"(found={match,-5}) | min:{minTicks,12} ticks | avg ms per find:{totalTime.TotalMilliseconds / (totalTests * 1.0),10:#####0.00} ms | max:{maxTicks,12} ticks | #Tests: {totalTests,3} | Total Time: {totalTime.TotalMilliseconds,7:0} ms |";

            _results += $"{testName,10} {stats}\r\n";

            Console.WriteLine(stats);

            return await Task.FromResult(match);
        }

        private bool FindObjectInCache(string testName, ICachedObject objectToFind, int run)
        {
            bool match = true;
            int i = 0;
            ICachedObject result;

            do
            {
                result = _cache.FindItem(objectToFind.Id);
                match &= (result != null) && result.Id == objectToFind.Id;

                Console.Write($"\r{testName} {run + 1}.{i}  ");
            }
            while (match && i++ < _loopNumber);

            return match;
        }
        

        public void Output()
        {
            Console.WriteLine(_results);
        }
    }
}
