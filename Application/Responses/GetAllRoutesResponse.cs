namespace Application.Responses
{
    public class GetAllRoutesResponse(string originLocationName, string destinyLocationName, double cost)
    {
        public string OriginLocationName { get; set; } = originLocationName;
        public string DestinyLocationName { get; set; } = destinyLocationName;
        public double Cost { get; set; } = cost;
    }
}
