using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Diana.Code.Challenge
{
    /// <summary>
    /// Company class that contains information about the company and its employees.
    /// </summary>
    public class Company : ICachedObject
    {
        [BsonId]
        public Guid Id { get; set; }

        public string name { get; set; }

        public string Description { get; set; }

        public Decimal Profit_1 { get; set; }

        public Double Profit_2 { get; set; }

        /// <question>
        /// What issues can you see with using string as the key for the dictionary? 
        /// What suggestions do you have to resolve this?
        /// </question>
        /// <answer>
        /// Case sensitivity can lead to unexpected behavior if you're not consistent with the casing when accessing or inserting items into the dictionary. 
        /// And performance impact since string comparison is slower compared to other types, especially when the dictionary contains a large number of items. 
        /// Insted of string we can use Guid as Dictionary key, 
        ///     with Guid it is easier to genarate new key by Guid.NewGuid()
        ///     and we can easily persist data since Guild is unuique.
        /// Compare Guids by ('==') or Guid.CompareTo().  
        /// </answer>
        public Dictionary<string, Employee> Employees { get; set; } = new Dictionary<string, Employee>();

        public int CompareTo(object obj)
        {
            return this.Id.CompareTo(((Employee)obj).Id);
        }
    }
}
