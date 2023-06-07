using System.Threading.Tasks;

/// <summary>
/// Please see the readme.md for details and information.
/// </summary>
namespace Diana.Code.Challenge
{
    /// <question>
    /// Please review the program below and refactor/change as required.
    /// </question>
    /// <answer>
    /// Fix code below.
    /// </answer>
    class Program
    {
        private static readonly int _cacheSize = 999_999;

        private static readonly uint _testNumber = 3;

        private static readonly uint _testLoopNumber = 100;

        static async Task Main(string[] args)
        {
            var caches = new ICacheStuff<Employee>[]{
                new SlowCache<Employee>(),
                new SuperFastCache<Employee>() // <-- Need to make this really FAST!
            };

            foreach (var cache in caches)
            {
                await TestCache(cache);
            }
        }

        public static async Task TestCache(ICacheStuff<Employee> cache)
        {
            var test = new TestHarness();

            await test
                .Setup(cache: cache,
                        count: _cacheSize,
                        testNumber: _testNumber,
                        loopNumber: _testLoopNumber,
                        /// <question>
                        /// What is this code doing?
                        /// Why do you think that the coder used this approach?
                        /// <question>
                        /// Using a mocking framework, to set up a mock behavior for a test object.
                        /// The coder is creating a test scenario to mock the behavior of a cache system and test the functionality using the provided lambda expression as a factory for creating Employee instances. 
                        ///     By setting up the mock behavior, coder can control the behavior of the cache and ensure that the test runs consistently and predictably.
                        /// </answer>
                        (System.Guid id, string name, string description) => new Employee()
                        {
                            Id = id,
                            name = name,
                            _description = description
                        })
                .Run();
        }
    }
}
