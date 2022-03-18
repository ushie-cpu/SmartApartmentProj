using Microsoft.AspNetCore.Mvc;
using Nest;
using SmartApartmentElasticSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartmentElasticSearch.Services.Interfaces
{
    public interface ISearchRepo
    {
        Task<ISearchResponse<Property>> MatchAll();
        Task<ISearchResponse<Mgmt>> QuerySearch(string query);
    }
}
