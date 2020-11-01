﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OnlineBanking.BL.Models;
using OnlineBanking.Data.Repo;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using OnlineBanking.Data.Models;

namespace OnlineBanking.BL.Services
{
    public class RealBankEntitiesService : IBankEntitiesService
    {
        public RealBankEntitiesService(ITransactionsRepo transactionsRepo, IShopsRepo shopsRepo, IMapper mapper)
        {
            _transactionsRepo = transactionsRepo;
            _shopsRepo = shopsRepo;
            Mapper = mapper;
        }

        ITransactionsRepo _transactionsRepo { get; }
        IShopsRepo _shopsRepo { get; }
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
            var x = await _transactionsRepo.Get(token);
            return x.Select(Mapper.Map<PointWeightDto>);
        }

        public async Task<DistrictsDescriptionDto> GetAverageBill(int? categoryId, int? tagId, CancellationToken token = default)
        {
            /*var x = await _transactionsRepo.Get(token);
            return x.Select(a=>new DistrictWeightDto()
            {
                  Value = a.Amount
            });*/

            using (StreamReader r = new StreamReader("../OnlineBanking.Data/json/districts_geojson_tmp.json")) //todo: set proper dir and read file not in this function 
            {
                string json = r.ReadToEnd();
                DistrictsDescriptionDto districtsDescription = JsonConvert.DeserializeObject<DistrictsDescriptionDto>(json);
                
                Random rnd = new Random();
                long value  = rnd.Next(0, 1001);
                districtsDescription.features.ForEach(dists => dists.properties.Value = value);

                districtsDescription.features.First(dists => dists.properties.ID == 0).properties.Value = 700;
                districtsDescription.features.First(dists => dists.properties.ID == 1).properties.Value = 700;

                var output = new DistrictsDescriptionDto {
                    type = "Type",
                    name = "BankApp",
                    features = districtsDescription.features
                };
                return output;
            }

        }
    }
}