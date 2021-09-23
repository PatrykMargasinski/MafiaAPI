namespace MafiaAPI.Services
{
    public interface ISecurityService
    {
        public string Encrypt(string text);
        public string Decrypt(string text);
        public string Hash(string text);
    }
}