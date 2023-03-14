using LoadBalancer.Models;

namespace LoadBalancer.Strategies;

public class RoundRobinStrategy : ILoadBalancerStrategy
{
    private int _count;

    
    public ServiceModel NextService(List<ServiceModel> services)
    {
        if(services.Count > 0 && _count < services.Count)
        {
            var serviceToUse = services[_count];
            
            _count += 1;
            if (_count == services.Count) _count = 0;
            Console.WriteLine($"Returned service index: {_count}");
            Console.WriteLine($"Returned service url:{serviceToUse.url} with {serviceToUse.activeQueries} active queries");
            return serviceToUse;
        }
        throw new IndexOutOfRangeException();
    }
}