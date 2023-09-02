using Microsoft.Extensions.Primitives;

namespace UoSeaSite
{
    public class CentredConfiguration
    {
        public string? this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Path { get; set; } = Directory.GetCurrentDirectory();
        public string Output { get; set; } = Directory.GetCurrentDirectory();
        public int Port { get; set; } = 10000;
        public string Host { get; set; } = "localhost";
    }
}
