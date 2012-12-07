namespace StephanieJay.Classes
{
    public class DataFactory
    {
        public DataFactory()
        {
            this.News = new NewsData();
        }

        public NewsData News { get; set; }
    }
}