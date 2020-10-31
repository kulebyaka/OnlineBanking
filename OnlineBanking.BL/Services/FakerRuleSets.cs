using System.Linq;
using Bogus;
using OnlineBanking.BL.Models;

namespace OnlineBanking.BL.Services
{
    public static class FakerRuleSets
    {
        public static Faker<BankTransactionDto> FakeTransactionRuleSet()
        {
            var fakeTransactionRuleSet = new Faker<BankTransactionDto>("en")
                .RuleFor(u => u.TransactionId, f => f.UniqueIndex)
                .RuleFor(u => u.TxDate, f => f.Date.Past())
                .RuleFor(u => u.Amount, f => f.Random.Decimal(-1000, 10000))
                .RuleFor(u => u.GeoCoordinate, f => new GeoCoordinateDto
                {
                    Latitude = f.Random.Double(),
                    Longitude = f.Random.Double()
                })
                .RuleFor(u => u.Brand, f => f.Company.CompanyName())
                .RuleFor(u => u.Category, f => f.PickRandom<ECategory>());
            return fakeTransactionRuleSet;
        }
        
        public static Faker<BankCategoryDto> FakeCategoryRuleSet()
        {
            var fakeTransactionRuleSet = new Faker<BankCategoryDto>("en")
                .RuleFor(u => u.Name, f => f.Commerce.Categories(1).First());
            return fakeTransactionRuleSet;
        }
        
        public static Faker<DistrictWeightDto> FakeAverageBillRuleSet()
        {
            int val = 0;
            var fakeTransactionRuleSet = new Faker<DistrictWeightDto>("en")
                .RuleFor(u => u.DistrictId, f => f.UniqueIndex)
                .RuleFor(u => u.Value, f =>
                {
                    val = f.Random.Int(1, 1200);
                    return val;
                })
                .RuleFor(u => u.Color, (f,u) => ((double)val)/1200);
            return fakeTransactionRuleSet;
        }
    }
}