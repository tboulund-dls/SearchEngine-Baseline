using RoundRobin;

namespace LoadBalancer.LoadBalancer;

public class RoundRobinStrategy
{
    public string NextService(List<string> services)
    {
        var roundRobinList = new RoundRobinList<string>(services);
        
        for (var i = 0; i < 8; i++)
        {
            
        }
        return services.First(); //todo implement round robin
    }
}