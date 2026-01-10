namespace EHostels.API.AppAuthorization
{
    public class ProfileData
    {
        public string FullName { get; set; } = string.Empty!;
        public string Email { get; set; } = string.Empty!;
        public long UserId { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
