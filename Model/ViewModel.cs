using Diplom.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.Model
{
    public class ViewModel:DbContext
    {

        public ViewModel() :base("DataBaseConnection")
        { }
        public DbSet<CognitiveLoadLookup> CognitiveLoad { get; set; }
        public DbSet<DriversLicense> DriversLicense { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<FamilyState> FamilyState { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Group>Group { get; set; }
        public DbSet<ReactionTime> ReactionTime { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<TestType> TestType { get; set; }
        public DbSet<Profile>Profile { get; set; }
        public DbSet<TestPack> TestPack { get; set; }
        public DbSet<TestResults> TestResult { get; set; }
        public DbSet<User> User { get; set; }
    }
}
