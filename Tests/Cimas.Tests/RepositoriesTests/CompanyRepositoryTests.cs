using Cimas.Entities.Companies;
using Cimas.Storage.Configuration;
using Cimas.Storage.Repositories.Companies;
using Cimas.Tests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimas.Tests.RepositoriesTests
{
    [TestFixture]
    public class CompanyRepositoryTests
    {
        [TestCase(1)]
        public async Task CompanyRepository_FindAsync_ReturnsCorrectValue(int id)
        {
            using var context = new CimasDbContext(UnitTestHelper.GetCimasDbOptions());

            var companyRepository = new CompanyRepository(context);

            var company = await companyRepository.FindAsync(id);
            var expected = UnitTestHelper.Companies.FirstOrDefault(item => item.Id == id);

            Assert.That(company, Is.EqualTo(expected).Using(new CompanyEqualityComparer()), message: "FindAsync method works incorrect");
        }

        [Test]
        public async Task CompanyRepository_FindAllAsync_ReturnsReturnsAllValues()
        {
            using var context = new CimasDbContext(UnitTestHelper.GetCimasDbOptions());

            var companyRepository = new CompanyRepository(context);

            var companies = await companyRepository.FindAllAsync();
            var expected = UnitTestHelper.Companies;

            Assert.That(companies, Is.EqualTo(expected).Using(new CompanyEqualityComparer()), message: "FindAllAsync method works incorrect");
        }

        [Test]
        public async Task CompanyRepository_Add_AddsValueToDatabase()
        {
            using var context = new CimasDbContext(UnitTestHelper.GetCimasDbOptions());

            var companyRepository = new CompanyRepository(context);

            var company = new Company() { Id = 2 };
            companyRepository.Add(company);
            await context.SaveChangesAsync();

            Assert.That(context.Company.Count(), Is.EqualTo(2).Using(new CompanyEqualityComparer()), message: "Add method works incorrect");
        }

        [Test]
        public async Task CompanyRepository_AddRange_AddsValuesToDatabase()
        {
            using var context = new CimasDbContext(UnitTestHelper.GetCimasDbOptions());

            var companyRepository = new CompanyRepository(context);

            var companies = new List<Company>
            {
                new Company() { Id = 2 },
                new Company() { Id = 3 },
            };
            companyRepository.AddRange(companies);
            await context.SaveChangesAsync();

            Assert.That(context.Company.Count(), Is.EqualTo(3).Using(new CompanyEqualityComparer()), message: "AddRange method works incorrect");
        }

        [Test]
        public async Task CompanyRepository_Remove_RemovesValueFromDatabase()
        {
            using var context = new CimasDbContext(UnitTestHelper.GetCimasDbOptions());

            var companyRepository = new CompanyRepository(context);

            var company = await companyRepository.FindAsync(1);
            companyRepository.Remove(company);
            await context.SaveChangesAsync();

            Assert.That(context.Company.Count(), Is.EqualTo(0).Using(new CompanyEqualityComparer()), message: "Remove method works incorrect");
        }

        [Test]
        public async Task CompanyRepository_RemoveRange_RemovesValuesFromDatabase()
        {
            using var context = new CimasDbContext(UnitTestHelper.GetCimasDbOptions());

            var companyRepository = new CompanyRepository(context);

            var companies = await companyRepository.FindAllAsync();

            companyRepository.RemoveRange(companies);
            await context.SaveChangesAsync();

            Assert.That(context.Company.Count(), Is.EqualTo(0).Using(new CompanyEqualityComparer()), message: "RemoveRange method works incorrect");
        }
    }
}
