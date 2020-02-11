namespace JobSystem
{
    public class AdditionCommand: Command<int>
    {
        public int a;
        public int b;
        public AdditionCommand(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public override void Execute()
        {
            result = a + b;            
        }
    }
}