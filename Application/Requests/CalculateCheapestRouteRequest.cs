namespace Application.Requests
{
    public class CalculateCheapestRouteRequest
    {
        public string OriginLocationName { get; set; } = string.Empty;
        public string DestinyLocationName { get; set; } = string.Empty;
    }
}
