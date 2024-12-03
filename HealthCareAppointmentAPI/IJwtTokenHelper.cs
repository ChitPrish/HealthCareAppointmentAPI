namespace HealthCareAppointmentAPI
{
    public interface IJwtTokenHelper
    {
        string GenerateToken(string username);
    }
}
