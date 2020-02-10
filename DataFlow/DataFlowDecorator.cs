namespace DataFlow
{
    public class DataFlowDecorator : IDataFlow
    {
        public IDataFlow wrappee;
        public DataFlowDecorator(IDataFlow flow)
        {
            wrappee = flow;
        }
        public virtual void WriteData(string data)
        {
            this.wrappee.WriteData(data);
        }
        public virtual string ReadData()
        {
            return this.wrappee.ReadData();
        }
    }
}