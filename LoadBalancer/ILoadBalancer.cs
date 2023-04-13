using LoadBalancer.Strategies;

namespace LoadBalancer;

public interface ILoadBalancer
{
    public string AddServer(string url);

    public string RemoveServer(string id);

    public string GetServer();
    public List<Server> GetServers();

    public int SetLoadBalancerStrategy(int selection);
}