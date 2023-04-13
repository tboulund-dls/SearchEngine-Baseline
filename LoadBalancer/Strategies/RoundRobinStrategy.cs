namespace LoadBalancer.Strategies;

public class RoundRobinStrategy : ILoadBalancerStrategy
{
    private int _index;
    public string GetServer(List<Server> servers)
    {
        var server = servers[_index];
        _index = (_index + 1) % servers.Count;
        return server.Url;
    }
}