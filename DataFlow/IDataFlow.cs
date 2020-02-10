namespace DataFlow
{
    public interface IDataFlow
    {
        void WriteData(string data);
        string ReadData();
    }
}