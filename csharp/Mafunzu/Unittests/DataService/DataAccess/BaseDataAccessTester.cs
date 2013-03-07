using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.DataAccess;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class BaseDataAccessTester
    {
        private readonly InMemoryDataContext _memoryDataContext;

        public BaseDataAccessTester()
        {
            _memoryDataContext = new InMemoryDataContext();
            AthleteDataAccess.ResolveDataContext = () => _memoryDataContext;
            UserDataAccess.ResolveDataContext = () => _memoryDataContext;
            ShoeDataAccess.ResolveDataContext = () => _memoryDataContext;
            RunDataAccess.ResolveDataContext = () => _memoryDataContext;
            WorkoutDataAcces.ResolveDataContext = () => _memoryDataContext;
        }

        public InMemoryDataContext MemoryDataContext
        {
            get { return _memoryDataContext; }
        }

        [SetUp]
        public void Setup()
        {
            AthleteDataAccess.ResolveDataContext = () => _memoryDataContext;
            UserDataAccess.ResolveDataContext = () => _memoryDataContext;
            ShoeDataAccess.ResolveDataContext = () => _memoryDataContext;
            RunDataAccess.ResolveDataContext = () => _memoryDataContext;
            WorkoutDataAcces.ResolveDataContext = () => _memoryDataContext;
        }

    }
}
