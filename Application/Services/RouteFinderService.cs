using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public interface IRouteFinderService
    {
        Task<(List<string> Path, double Cost)> FindCheapestRouteAsync(string origin, string destiny);
    }

    public class RouteFinderService(IRouteRepository routeRepository, ILocationRepository locationRepository) : IRouteFinderService
    {
        private readonly IRouteRepository _routeRepository = routeRepository;
        private readonly ILocationRepository _locationRepository = locationRepository;

        public async Task<(List<string> Path, double Cost)> FindCheapestRouteAsync(string origin, string destiny)
        {
            var routes = await _routeRepository.GetAllAsync();
            var graph = await BuildGraph(routes);

            var result = Dijkstra(graph, origin, destiny);
            return result;
        }

        private async Task<Dictionary<string, List<(string Destination, double Cost)>>> BuildGraph(IEnumerable<Route> routes)
        {
            var graph = new Dictionary<string, List<(string Destination, double Cost)>>();

            foreach (var route in routes)
            {
                var origin = await _locationRepository.GetById(route.OriginLocationId);
                var destiny = await _locationRepository.GetById(route.DestinyLocationId);

                if (!graph.ContainsKey(origin.Name))
                {
                    graph[origin.Name] = new List<(string Destination, double Cost)>();
                }

                if (!graph.ContainsKey(destiny.Name))
                {
                    graph[destiny.Name] = new List<(string Destination, double Cost)>();
                }

                graph[origin.Name].Add((destiny.Name, route.Cost));
            }

            return graph;
        }


        private (List<string> Path, double Cost) Dijkstra(Dictionary<string, List<(string Destination, double Cost)>> graph, string start, string end)
        {
            var distances = new Dictionary<string, double>();
            var previous = new Dictionary<string, string>();
            var nodes = new PriorityQueue<string, double>();

            foreach (var node in graph)
            {
                if (node.Key == start)
                {
                    distances[node.Key] = 0;
                    nodes.Enqueue(node.Key, 0);
                }
                else
                {
                    distances[node.Key] = double.MaxValue;
                    nodes.Enqueue(node.Key, double.MaxValue);
                }

                previous[node.Key] = null;
            }

            while (nodes.Count > 0)
            {
                var smallest = nodes.Dequeue();

                if (smallest == end)
                {
                    var path = new List<string>();
                    var totalCost = distances[smallest];

                    while (previous[smallest] != null)
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    path.Add(start);
                    path.Reverse();

                    return (path, totalCost);
                }

                if (distances[smallest] == double.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in graph[smallest])
                {
                    var alt = distances[smallest] + neighbor.Cost;
                    if (alt < distances[neighbor.Destination])
                    {
                        distances[neighbor.Destination] = alt;
                        previous[neighbor.Destination] = smallest;
                        nodes.Enqueue(neighbor.Destination, alt);
                    }
                }
            }

            return (new List<string>(), double.MaxValue);
        }
    }

    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private readonly List<(TElement Element, TPriority Priority)> _elements = new List<(TElement Element, TPriority Priority)>();

        public int Count => _elements.Count;

        public void Enqueue(TElement element, TPriority priority)
        {
            _elements.Add((element, priority));
            _elements.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public TElement Dequeue()
        {
            var element = _elements[0];
            _elements.RemoveAt(0);
            return element.Element;
        }
    }
}
