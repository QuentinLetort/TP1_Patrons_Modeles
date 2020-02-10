namespace DataFlow
{
    public class EncryptionDecorator : DataFlowDecorator
    {
        private const string ENCRYPTION = "CHIFFRE:";
        public EncryptionDecorator(IDataFlow flow) : base(flow)
        { }
        public override void WriteData(string data)
        {
            base.WriteData(ENCRYPTION + data);
        }
        public override string ReadData()
        {
            return base.ReadData().Substring(ENCRYPTION.Length);
        }
    }
}