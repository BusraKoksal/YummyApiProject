namespace ApiProjeKampi.WebApi.Dtos.MessageDtos
{
    public class UpdateMessageDto
    {
        public int MessageId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public DateTime SendData { get; set; }
        public bool IsRead { get; set; }
    }
}
