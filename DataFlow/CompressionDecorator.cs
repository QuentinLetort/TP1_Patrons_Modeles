using System;
namespace DataFlow
{
    public class CompressionDecorator : DataFlowDecorator
    {
        public const string COMPRESSION = "COMPRESSE:";
        public CompressionDecorator(IDataFlow flow) : base(flow)
        { }
        public override void WriteData(string data)
        {
            this.wrappee.WriteData(COMPRESSION + data);
        }
        public override string ReadData()
        {
            return base.ReadData().Substring(COMPRESSION.Length);
        }

    }
}