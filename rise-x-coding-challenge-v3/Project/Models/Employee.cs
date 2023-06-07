using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Diana.Code.Challenge
{
    /// <question>
    /// Please refactor this class and related interfaces as required to meet your
    /// minimum coding standards.
    /// </question>
    public class Employee : ICachedObject
    {
        /// <question>
        /// What is the purpose of this attribute?
        /// </question>
        /// <answer>
        /// [BsonId] attribute is to mark a property within a class as the identifier (ID) field for MongoDB documents.
        /// </answer>
        [BsonId]
        public Guid Id { get; set; }

        public string name { get; set; }

        public string _description { get; set; }

        /// <question>
        /// Review the next two properties, what suggestions do you have
        /// for these?
        /// </question>
        /// <answer>
        /// Since there is no code referencing US_Salary_2, PHP_Salary_1, Email and CompareTo we can delete them
        /// </answer>
        public Double PHP_Salary_1 { get; set; }

        public decimal US_Salary_2
        {
            get
            {
                return ((decimal) PHP_Salary_1) * ((decimal)51.6932);
            }
        }

        public string Email { get; set; }

        public int CompareTo(object obj)
        {
            return this.Id.CompareTo(((Employee)obj).Id);
        }
    }
}
