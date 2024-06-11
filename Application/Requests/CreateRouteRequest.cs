namespace Application.Requests
{
    public class CreateRouteRequest(string originName, string destinyName, double cost)
    {
        public string OriginLocationName { get; set; } = originName;
        public string DestinyLocationName { get; set; } = destinyName;
        public double Cost { get; set; } = cost;
    }
}
