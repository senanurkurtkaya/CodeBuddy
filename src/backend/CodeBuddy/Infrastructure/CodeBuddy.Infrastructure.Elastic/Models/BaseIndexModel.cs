namespace CodeBuddy.Infrastructure.Elastic.Models
{
    public abstract class BaseIndexModel
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
