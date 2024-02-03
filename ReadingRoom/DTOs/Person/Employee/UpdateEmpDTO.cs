using static ReadingRoom.Helper.Enum.Enums;

namespace ReadingRoom.DTOs.Person.Employee
{
    public class UpdateEmpDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
