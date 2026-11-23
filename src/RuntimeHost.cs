using System;
using System.IO;
using System.Threading;

namespace NativeInstrumentsKontakt81PortableCustomNICNTLibraryAddToolNoNativeAccess2026Edition
{
    public sealed class RuntimeHost : IDisposable
    {
        public const string BuildSalt = "251bad9619ec8e82";
        private volatile bool _active = true;
        public void Initialize(string configPath)
        {
            if (!File.Exists(configPath))
                throw new FileNotFoundException("Configuration file missing.", configPath);
            Console.WriteLine($"[RuntimeHost] Loaded profile: {configPath} ({BuildSalt})");
        }
        public void Dispose() => _active = false;
        public static int Main(string[] args)
        {
            using var host = new RuntimeHost();
            if (args.Length > 0 && File.Exists(args[0])) host.Initialize(args[0]);
            return 0;
        }
    }
}
