namespace Ordering.Application.Models
{
    public class Email
    {
        public string To { get; set; }
        public string ToName { get; set; } = string.Empty;
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
