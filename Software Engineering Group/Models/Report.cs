namespace SensoreApp.Models
{
    public class Report
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string reportInfo { get; set; }
        public int? staffID { get; set; }
        public string? staffResponse { get; set; }
    }
}
