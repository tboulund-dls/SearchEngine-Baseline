using LoadBalancer.Models;

namespace LoadBalancer.Strategies;

public class IdkStrategy : ILoadBalancerStrategy
{
    //Takes the service with the least amount of active queries
    public ServiceModel NextService(List<ServiceModel> services) {
        IOrderedEnumerable<ServiceModel> orderedServices = services.OrderBy(x => x.activeQueries);
        var service = orderedServices.First();
        Console.WriteLine($"Returned service url:{service.url} with {service.activeQueries} active queries");
        return service;
    }
}