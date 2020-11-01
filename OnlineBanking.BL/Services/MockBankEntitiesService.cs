using System;
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

        public const int DistrictNumber = 56;
        public async Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakerRuleSets.FakeTransactionRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(1).First();
            return transaction;
        }

        public async Task<IEnumerable<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakerRuleSets.FakeTransactionRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(10);
            return transaction;
        }

        public async Task<BankCategoryDto> GetCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakerRuleSets.FakeCategoryRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(1).First();
            return transaction;
            
        }

        public async Task<IEnumerable<BankCategoryDto>> GetCategoryListAsync(CancellationToken cancellationToken = default)
        {
            var fakeTransactionRuleSet = FakerRuleSets.FakeCategoryRuleSet();
            var transaction = fakeTransactionRuleSet.Generate(10);
            return transaction;
        }

        public async Task<IEnumerable<PointWeightDto>> GetDataByColumnName(string columnName, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<DistrictsDescriptionDto> GetAverageBill(int? categoryId, int? tagId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DistrictWeightDto>> GetAverageAge(int? categoryId, IEnumerable<int> tags, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<DistrictsDescriptionDto> GetCreditWorthiness(int? categoryId, string tags, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}