using Common;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class LoadBalancerController : Controller
{
    private ILoadBalancer _loadBalancer = LoadBalancer.GetInstance();
    
    [HttpPost("AddServer")]
    public IActionResult  AddServer(string url)
    {
        return Ok(_loadBalancer.AddServer(url));
    }
    
    [HttpPost("RemoveServer")]
    public IActionResult  RemoveServer(string id)
    {
        return Ok(_loadBalancer.RemoveServer(id));
    }
    
    [HttpPost("SetLoadBalancerStrategy")]
    public IActionResult  SetLoadBalancerStrategy(int selection)
    {
        int selected = _loadBalancer.SetLoadBalancerStrategy(selection);
        switch (selected)
        {
            case 1:
                return Ok("Round Robin Strategy Enabled");
            case 2:
                return Ok("Least Connections Strategy Enabled");
            default: return BadRequest();
        }
    }
    
    [HttpGet("GetServers")]
    public List<Server> AddServer()
    {
        return _loadBalancer.GetServers();
    }
    
    [HttpGet]
    public IActionResult Search(string terms, int numberOfResults)
    {
        var server = _loadBalancer.GetServer();
        
        RestClient serviceClient = new(server.Url);
        RestRequest request = new("/Search");
        request.AddParameter("terms", terms);
        request.AddParameter("numberOfResults", numberOfResults);
        Console.WriteLine(request.ToString());
        Task<SearchResult?> response = serviceClient.GetAsync<SearchResult>(request);
        response.Wait();
        SearchResult? result = response.Result;
        if (result is null)
        {
            return NotFound("Results not found");
        }
        return Ok(result);
    }
}