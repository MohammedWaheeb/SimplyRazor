﻿using Bogus;
using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace SW.SimplyRazor.SampleWeb.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName { get; set; }
        //public TimeSpan  ArrivalTime { get; set; }
        public Gender Gender { get; set; }
        public decimal? Age { get; set; }
        public bool Married { get; set; }
        public Money Salary { get; set; }
        public int EmploymentStatus { get; set; }
        public string Country { get; set; }

        public string BirthCountry { get; set; }

        public DateTime? EmploymentDate { get; set; }

        public DateTime[] AbsentPeriod { get; set; }
        public RemoteBlob Photo { get; set; }
        public ICollection<Leave> Leaves { get; set; }

        public ICollection<string> Roles { get; set; }

        public ICollection<RemoteBlob> Photos { get; set; }

        public IDictionary<string, string> AdditionalValues { get; set; }

        //public static IList<Employee> Sample = new List<Employee>
        //{
        //    new Employee()
        //    {
        //        Id=1,
        //        FirstName="Samer",
        //        LastName="Awajan",
        //        Gender="M",
        //        Salary = new Money{Amount=100, Currency="USD" },
        //        Leaves = new List<Leave>()
        //        {
        //            new Leave {Days=100, Reason="sick" },
        //            new Leave {Days=30, Reason="marriage" }
        //        }
        //    },
        //    new Employee() {Id=2, FirstName="Yaser", LastName="Awajan", Gender="M" },
        //    new Employee() {Id=3, FirstName="Osama", LastName="Awajan", Gender="M" },
        //    new Employee() {Id=4, FirstName="Ahmad", LastName="Awajan", Gender="M" },

        //};

    }



    public static class FakeEmployees
    {


        static readonly Faker<Employee> testUsers = new Faker<Employee>("ar")
            //Optional: Call for objects that have complex initialization
            //.CustomInstantiator(f => new User(userIds++, f.Random.Replace("###-##-####")))

            //Use an enum outside scope.
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())

            //Basic rules using built-in generators
            .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
            .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender))
            //.RuleFor(u => u.Avatar, f => f.Internet.Avatar())
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.Id, f => f.UniqueIndex)
            .RuleFor(u=> u.Country, f=> f.Address.CountryCode()) 
            
            .RuleFor(u => u.EmploymentDate, f => f.Date.Past())
            //Use a method outside scope.
            //.RuleFor(u => u.CartId, f => Guid.NewGuid())
            //Compound property with context, use the first/last name properties
            .RuleFor(u => u.DisplayName, (f, u) => u.FirstName + " " + u.LastName);
            //And composability of a complex collection.
            //.RuleFor(u => u.Orders, f => testOrders.Generate(3).ToList())
            //Optional: After all rules are applied finish with the following action
            //.FinishWith((f, u) =>
            //{
            //    Console.WriteLine("User Created! Id={0}", u.Id);
            //});
            

        public static readonly List<Employee> Data = testUsers.Generate(5000); 

    }


    public class Money
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Leave
    {
        public int Days { get; set; }
        public string Reason { get; set; }

        public RemoteBlob Photo { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Leave leave &&
                   Days == leave.Days &&
                   Reason == leave.Reason;
        }

        public override int GetHashCode()
        {
            int hashCode = -588109197;
            hashCode = hashCode * -1521134295 + Days.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Reason);
            return hashCode;
        }
    }

}