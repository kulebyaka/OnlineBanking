using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using OnlineBanking.BL.Models;

namespace OnlineBanking.BL.Services
{
    public class MockBankEntitiesService : IBankEntitiesService
    {
        private static Faker<BankTransactionDto> FakeTransactionRuleSet()
        {
            var fakeTransactionRuleSet = new Faker<BankTransactionDto>("en")
                .RuleFor(u => u.Id, f => f.UniqueIndex)
                .RuleFor(u => u.Date, f => f.Date.Past())
                .RuleFor(u => u.Change, f => f.Random.Decimal(-1000, 10000))
                .RuleFor(u => u.Currency, f => $"{f.Finance.Currency().Code} ({f.Finance.Currency().Symbol})")
                .RuleFor(u => u.GeoCoordinate, f => new GeoCoordinateDto
                {
                    Latitude = f.Random.Double(),
                    Longitude = f.Random.Double()
                })
                .RuleFor(u => u.Brand, f => f.Company.CompanyName())
                .RuleFor(u => u.Category, f => f.Commerce.Categories(1).First())
                .RuleFor(u => u.CategoryId, f => f.UniqueIndex)
                .RuleFor(u => u.Note, f => f.Lorem.Paragraph());
            return fakeTransactionRuleSet;
        }
        
        private static Faker<BankCategoryDto> FakeCategoryRuleSet()
        {
            var fakeTransactionRuleSet = new Faker<BankCategoryDto>("en")
                .RuleFor(u => u.Name, f => f.Commerce.Categories(1).First());
            return fakeTransactionRuleSet;
        }
        
        public async Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakeTransactionRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(1).First();
            return transaction;
        }

        public async Task<IEnumerable<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakeTransactionRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(10);
            return transaction;
        }

        public async Task<BankCategoryDto> GetCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakeCategoryRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(1).First();
            return transaction;
            
        }

        public async Task<IEnumerable<BankCategoryDto>> GetCategoryListAsync(CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakeCategoryRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(10);
            return transaction;
        }
    }
}