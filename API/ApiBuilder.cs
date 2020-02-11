using DataFlow;
namespace API
{
    public class ApiBuilder
    {
        private Api api;
        public ApiBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            api = new Api();
        }
        public void SetConsoleProtocol()
        {
            this.api.Flow = new ConsoleFlow();
        }
        public void SetNbThread(int nbThread)
        {
            this.api.NbThread = nbThread;
        }
        public void SetEncryption()
        {
            this.api.Flow = new EncryptionDecorator(this.api.Flow);
        }
        public void SetCompression()
        {
            this.api.Flow = new CompressionDecorator(this.api.Flow);
        }
        public Api GetResult()
        {
            Api temp = this.api;
            Reset();
            return temp;
        }
    }
}