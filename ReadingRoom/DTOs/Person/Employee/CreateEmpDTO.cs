namespace ReadingRoom.DTOs.Person.Employee
{
    public class CreateEmpDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Gender { get; set; }
        public string personType { get; set; }
    }
}
