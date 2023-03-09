namespace LoadBalancer.LoadBalancer;

public class BasicStrategy : ILoadBalancerStrategy
{
    public string NextService(List<string> services)
    {
        return services.First();
    }
}