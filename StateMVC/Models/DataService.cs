using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StateMVC.Views.States;

namespace StateMVC.Models
{
    public class DataService
    {
        public IMemoryCache Cache { get; set; }
        public DataService(IMemoryCache cache)
        {
            this.Cache = cache;
        }
        public void GetEmail(IndexVM index)
        {
            Cache.Set("SupportEmail", index.SupportEmail);
        }






    }
}
