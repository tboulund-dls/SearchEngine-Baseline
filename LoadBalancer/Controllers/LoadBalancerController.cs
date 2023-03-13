﻿using Common;
using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
namespace LoadBalancer.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LoadBalancerController : Controller
    {
        private static readonly ILoadBalancer
            _loadBalancer = new LoadBalancer.LoadBalancer(new BasicStrategy()); //todo make loadbalancer singleton

        public LoadBalancerController()
        {
            _loadBalancer.SetActiveStrategy(new BasicStrategy());
        }

        [HttpPost]
        public void Create(string url)
        {
            _loadBalancer.AddService(url);
            Console.WriteLine("added service: " + url);
        }

        [HttpGet]
        public IActionResult Search(string terms, int numberOfResults)
        {
            string serviceUrl = _loadBalancer.NextService();

            RestClient serviceClient = new(serviceUrl);
            RestRequest request = new("/Search");
            request.AddParameter("terms", terms);
            request.AddParameter("numberOfResults", numberOfResults);
            Task<SearchResult?> response = serviceClient.GetAsync<SearchResult>(request);
            response.Wait();
            SearchResult? result = response.Result;
            if (result is null)
            {
                return NotFound("Search failed lmao");
            }
            Console.WriteLine("the result is:" + result);
            return Ok(result);
        }
    }
}
