using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class LoadBalancerController : Controller
{
    private ILoadBalancer _loadBalancer = new LoadBalancer.LoadBalancer(new BasicStrategy());

    public LoadBalancerController()
    {
        _loadBalancer.SetActiveStrategy(new BasicStrategy());
    }

    [HttpPost]
    public void Create(string url)
    {
        _loadBalancer.AddService(url);
    }
}