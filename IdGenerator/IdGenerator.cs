namespace SimpleIdGenerator
{
    //TODO Typically, you'd use hilo algorithm, sequence num, or guid if you require an Id before saving to the database
    //TODO Convert to appropriate database id strategy
    public class IdGenerator
    {
        private static readonly object SyncRoot = new object();

        private static int oneUpCounter;

        public int Get()
        {
            lock (SyncRoot)
            {
                ++oneUpCounter;
                return oneUpCounter;
            }
        }
    }
}