using System;

namespace Diana.Code.Challenge
{
    /// <summary>
    /// Interface that implements the methods for the cache
    /// allows the test harness to switch implementations
    /// easily.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICacheStuff<T> where T : Employee
    {
        string CacheName { get; }
        void AddItem(T newItem);
        T FindItem(Guid id);
        string GetName(Guid id);
    }
}
