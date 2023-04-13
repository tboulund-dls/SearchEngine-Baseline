using LoadBalancer.Strategies;

namespace LoadBalancer;

public class LoadBalancer : ILoadBalancer
{
    private ILoadBalancerStrategy _strategy;
    private readonly List<Server> _servers = new();
    private static readonly LoadBalancer LoadBalancerInstance = new();

    private LoadBalancer()
    {
    }

    public static LoadBalancer GetInstance()
    {
        return LoadBalancerInstance;
    }

    public string AddServer(string url)
    {
        var id = Guid.NewGuid().ToString();
        _servers.Add(new Server { Id = id, Url = url, Connections = 0 });
        return id;
    }

    public string RemoveServer(string id)
    {
        var server = _servers.FirstOrDefault(server => server.Id == id);
        if (server == null)
        {
            throw new Exception("Server not found!");
        }

        var isServerRemoved = _servers.Remove(server);

        if (!isServerRemoved)
        {
            throw new Exception("Server could not be removed!");
        }

        return server.Id;
    }

    public int SetLoadBalancerStrategy(int selection)
    {
        switch (selection)
        {
            case 1:
                _strategy = new RoundRobinStrategy();
                return selection;
            case 2:
                _strategy = new LeastConnectionsStrategy();
                return selection;
            default:
                throw new Exception("Could not find load balancer strategy!");
        }
    }

    public string GetServer()
    {
        if (_servers.Count <= 0)
        {
            throw new Exception("No servers available!");
        }

        return _strategy.GetServer(_servers);
    }

    public List<Server> GetServers()
    {
        return _servers;
    }
}