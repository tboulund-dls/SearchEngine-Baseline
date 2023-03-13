using RoundRobin;

namespace LoadBalancer.LoadBalancer;

public class RoundRobinStrategy
{
    private int _count = 0;

    
    public string NextService(List<string> services)
    {
        var serviceToUse = services[_count];
        _count += 1;
        if (_count == services.Count) _count = 0;
        return serviceToUse;
        //todo implement round robin
    }
}