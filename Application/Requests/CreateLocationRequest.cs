namespace Application.Requests
{
    public class CreateLocationRequest(string locationName)
    {
        public string LocationName { get; set; } = locationName;
    }
}
