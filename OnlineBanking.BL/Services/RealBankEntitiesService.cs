﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using OnlineBanking.BL.Models;
using OnlineBanking.Data.Repo;

namespace OnlineBanking.BL.Services
{
    public class RealBankEntitiesService : IBankEntitiesService
    {
        public RealBankEntitiesService(ITransactionsRepo transactionsRepo, IMapper mapper)
        {
            _transactionsRepo = transactionsRepo;
            Mapper = mapper;
        }

        ITransactionsRepo _transactionsRepo { get; }
        IMapper Mapper { get; }
        
        public async Task<BankTransactionDto> GetTransactionAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BankTransactionDto>> GetTransactionListAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<BankCategoryDto> GetCategoryAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            
        }

        public async Task<IEnumerable<BankCategoryDto>> GetCategoryListAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PointWeightDto>> GetDataByColumnName(string columnName, CancellationToken token = default)
        {
            var x = await _transactionsRepo.GetByColumnName(columnName, token);
            return x.AsEnumerable().Select(Mapper.Map<PointWeightDto>);
        }

        public Task<IEnumerable<DistrictWeightDto>> GetAverageBill(int? categoryId, int? tagId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}