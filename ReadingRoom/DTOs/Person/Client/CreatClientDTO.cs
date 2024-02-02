namespace ReadingRoom.DTOs.Person.Client
{
    public class CreatClientDTO
    {
        public string fullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime birthDate { get; set; }
        public int Age { get; set; }
        public string PersonType { get; set; }
        public string Specialization { get; set; }
        public string Gender { get; set; }
    }
}
