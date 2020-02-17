using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTests
{
    [TestClass]
    public class CandidateRepositoryTests
    {
        IRepository<IStoreable<IComparable>, IComparable> candidaterepository;

        [TestInitialize]
        public void Setup() {
            candidaterepository = new CandidateRepository<IStoreable<IComparable>, IComparable>();
        }

        private IStoreable<IComparable> GetData()
        {
            return new Candidate<IComparable>()
            {
                Id = 101
            };
        }

        [TestMethod]
        public void Test_Repo_Returns_CorrectType()
        {
           var candidates = candidaterepository.GetAll();

            Assert.IsInstanceOfType(candidates, typeof(IEnumerable<IStoreable<IComparable>>));
        }

        [TestMethod]
        public void Interview_CheckAddedCandidateExists()
        {
            var candidate = GetData();

            candidaterepository.Save(candidate);

            var candidates = candidaterepository.Get(candidate.Id);

            Assert.AreSame(candidate, candidates);
        }

        [TestMethod]
        public void Interview_CheckDeletedCandidateDoesNotExist()
        {
            var candidate = GetData();

            candidaterepository.Save(candidate);
            candidaterepository.Delete(candidate.Id);

            var candidates = candidaterepository.Get(candidate.Id);

            Assert.AreNotSame(candidate, candidates);
        }

        [TestMethod]
        public void Interview_CheckDuplicateCandidateDoesNotExist()
        {
            var candidate1 = GetData();
            candidaterepository.Save(candidate1);

            var candidate2 = GetData();
            candidaterepository.Save(candidate2);

            var candidates = candidaterepository.GetAll();

            Assert.AreEqual(1, candidates.Count());
        }
    }
}
