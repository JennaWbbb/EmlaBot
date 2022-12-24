namespace EmlaBot.Models
{
    public interface IApiToken
    {
        string UserId { get; set; }

        string ApiKey { get; set; }
    }
}