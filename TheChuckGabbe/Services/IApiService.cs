using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheChuckGabbe.Services
{
    public interface IApiService
    {
        Task<Joke> GetRandom();
        Task<Joke> GetRandomByCategory(string category);
        Task<string[]> GetCategories();
        Task<SearchResult<Joke>> Search(string query);
    }
}
