namespace ReadingRoom.DTOs.Person.Admin
{
    public class AddAdmin
    {
        public int PersonId { get; set; }
        public string fullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string personType { get; set; }
    }
}
