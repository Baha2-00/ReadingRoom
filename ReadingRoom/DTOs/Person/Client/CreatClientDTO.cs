namespace ReadingRoom.DTOs.Person.Client
{
    public class CreatClientDTO
    {
        public int PersonId { get; set; }
        public string fullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime birthDate { get; set; }
    }
}
