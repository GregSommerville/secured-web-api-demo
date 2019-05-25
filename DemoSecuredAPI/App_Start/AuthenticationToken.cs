namespace DemoSecuredAPI
{
    public class AuthenticationToken
    {
        internal static bool IsValidToken(string token)
        {
            // Obviously in the real world this authentication would involve some kind of 
            // database lookup that checks if this token is valid

            // For this simple example, we simply check for the one demo key
            return token == "790EF0D3-5A9F-4437-A594-59D18B60866B";
        }
    }
}