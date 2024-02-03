using ReadingRoom.DTOs.Content;
using ReadingRoom.DTOs.Department;
using ReadingRoom.DTOs.Person.Admin;
using ReadingRoom.DTOs.Person.Employee;
using ReadingRoom.DTOs.Subscription;

namespace ReadingRoom.Interfaces
{
    public interface IAdmin
    {
        Task CreateEmployee(CreateEmpDTO dto);
        Task UpdateEmployee(UpdateEmpDTO dto);
        //CreateDepartment
        Task AddDepartment(AddDepartmentDTOcs dto);
        //Subs
        Task CreateSubs(CreateSubDTO dto);
        Task UpdateSub(UpdateSubs dto);
        Task DisOrReActive(UpdateSubs dto);
        //AdminAdd
        Task AddAdmin(AddAdmin dto);
        Task UpdateAdmin(UpdateAdmin dto);
        //Context
        Task CreateContent(CreateContentDTO dto);
    }
}
