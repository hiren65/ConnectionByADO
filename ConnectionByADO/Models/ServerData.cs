namespace ConnectionByADO.Models
{
    public class ServerData
    {
        public int Id { get; set; }
        public string? ServerName { get; set; }
        public string? ServerString { get; set; }
        public string? State { get; set; }
        public string? DataSource { get; set; }
        public string? Version { get; set; }
        public string? ServerId { get; set; }
        public string? ConnectionTimeOut { get; set; }
        public int? PacketSize { get; set; }
    }
}
