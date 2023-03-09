using RoundRobin;

namespace LoadBalancer.LoadBalancer;

public class RoundRobinStrategy
{
    public string NextService(List<string> services)
    {
        
        // var roundRobinList = new RoundRobinList<int>(
        //     new List<int>{
        //         1,2,3,4,5
        //     }
        // );
        //
        // for (var i = 0; i < 8; i++)
        // {
        //     Write($"{roundRobinList.Next()},");
        // }
        return services.First(); //todo implement round robin
    }
}