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
using OnlineBanking.Data.Models;

namespace OnlineBanking.BL.Services
{
    public class RealBankEntitiesService : IBankEntitiesService
    {

        public RealBankEntitiesService(ITransactionsRepo transactionsRepo, IShopsRepo shopsRepo, IDistrictStatisticsRepo districtStatisticsRepo, IMapper mapper)
        {
            _transactionsRepo = transactionsRepo;
            _shopsRepo = shopsRepo;
            _districtStatisticsRepo = districtStatisticsRepo;
            _mapper = mapper;
        }

        private IDistrictStatisticsRepo _districtStatisticsRepo;
        private readonly ITransactionsRepo _transactionsRepo;
        private readonly IShopsRepo _shopsRepo;
        private readonly IMapper _mapper;
        
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
            return x.Select(_mapper.Map<PointWeightDto>);
        }

        public async Task<IEnumerable<DistrictWeightDto>> GetAverageBill(int? categoryId, int? tagId, CancellationToken token = default)
        {
            var x = await _transactionsRepo.Get(token);
            return x.Select(a=>new DistrictWeightDto()
            {
                  Value = a.Amount
            });
        }
        
        public async Task<IEnumerable<DistrictWeightDto>> GetAverageAge(int? categoryId, List<int> tags, CancellationToken token = default)
        {
            var x = _districtStatisticsRepo.GetDistrictStatistics();

            return x.Select(a => new DistrictWeightDto()
            {
                Color = a.MedianAmount
            });
        }

        public async Task<DistrictsDescriptionDto> ReturnJSONForFrontend(CancellationToken token = default)
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(CurrentDirectory);
            using (StreamReader r = new StreamReader("../OnlineBanking.Data/json/districts_geojson_tmp.json")) //todo: set proper dir and read file not in this function 
            {
                string json = r.ReadToEnd();
                DistrictsDescriptionDto districtsDescription = JsonConvert.DeserializeObject<DistrictsDescriptionDto>(json);

                var output = new DistrictsDescriptionDto {
                    type = "Type",
                    name = "BankApp",
                    features = districtsDescription.features.Where(dist => dist.properties.ID < 2).ToList<Models.Feature>(),
                    
                };
                return output;
            }
        }
    }
}