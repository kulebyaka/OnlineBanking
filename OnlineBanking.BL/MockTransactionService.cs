using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bogus;

namespace OnlineBanking.BL
{
    public class MockTransactionService : ITransactionService
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
        
        public async Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakeTransactionRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(1).First();
            return transaction;
        }

        public async Task<IList<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakeTransactionRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(10);
            return transaction;
        }
    }
}