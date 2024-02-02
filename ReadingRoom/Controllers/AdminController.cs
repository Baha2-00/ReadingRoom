using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingRoom.Context;
using ReadingRoom.DTOs.Content;
using ReadingRoom.DTOs.Department;
using ReadingRoom.DTOs.Person.Admin;
using ReadingRoom.DTOs.Person.Employee;
using ReadingRoom.DTOs.Subscription;
using ReadingRoom.Interfaces;
using ReadingRoom.Models.Entity;
using System.Reflection;
using static ReadingRoom.Helper.Enum.Enums;

namespace ReadingRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase,IAdmin
    {
        private readonly ReadingRoomDBContext _ReadingRoomDBContext;
        public AdminController(ReadingRoomDBContext context)
        {
            _ReadingRoomDBContext = context;
        }

        #region Post

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAdminAction(AddAdmin dto)
        {
            try
            {
                await AddAdmin(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Create Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Create Failed {ex.Message}" };
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddDepartmentAction(AddDepartmentDTOcs dto)
        {
            try
            {
                await AddDepartment(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Create Department Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Create Failed {ex.Message}" };
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateEmployeeAction(CreateEmpDTO dto)
        {
            try
            {
                await CreateEmployee(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Create Employee Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Create Failed {ex.Message}" };
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateContextAction(CreateContentDTO dto)
        {
            try
            {
                await CreateContext(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "New Content Has Been created" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Creating content  {ex.Message}" };
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateSubsAction(CreateSubDTO dto)
        {
            try
            {
                await CreateSubs(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "New Subscription Has Been created" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Creating Sub  {ex.Message}" };
            }
        }

        #endregion

        #region Put
        [HttpPut]
        [Route("[action]")]
        public Task<IActionResult> DisOrReActiveAction(UpdateSubs dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPut]
        [Route("[action]")]
        public Task<IActionResult> UpdateAdminAction(UpdateAdmin dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPut]
        [Route("[action]")]
        public Task<IActionResult> UpdateEmployeeAction(UpdateEmpDTO dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPut]
        [Route("[action]")]
        public Task<IActionResult> UpdateSubAction(UpdateSubs dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Implementation
        [NonAction]
        public async Task AddAdmin(AddAdmin dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email Is Required");
            if (string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Phone Is Required");
            if (string.IsNullOrEmpty(dto.Password))
                throw new Exception("Password Is Required");
            if (string.IsNullOrEmpty(dto.fullName))
                throw new Exception("FullName Is Required");
            Person user = new Person();
            user.fullName = dto.fullName;
            user.Email= dto.Email;
            user.Phone= dto.Phone;
            user.Password= dto.Password;
            if (Enum.TryParse(dto.personType, out PersonType type))
            {
                user.PersonType = type;
            }
            else
            {
                throw new Exception("Invalid Gender value Make sure it's either Male or Female");
            }
            _ReadingRoomDBContext.AddAsync(user);
            _ReadingRoomDBContext.SaveChangesAsync();
        }
        [NonAction]
        public async Task AddDepartment(AddDepartmentDTOcs dto)
        {
           
            Department dep = new Department();
            
            if (Enum.TryParse(dto.ArabicName, out DepartmentNameAR Arname))
            {
                dep.ArabicName = Arname;
            }
            else
            {
                throw new Exception("Invalid Gender value Make sure it's either Male or Female");
            }
            if (Enum.TryParse(dto.EnglishName, out DepartmentNameEN enName))
            {
                dep.EnglishName = enName;
            }
            else
            {
                throw new Exception("Invalid Gender value Make sure it's either Male or Female");
            }
            dep.Description = dto.Description;
            dep.ContactEmail = dto.ContactEmail;
            dep.PhoneNumber = dto.PhoneNumber;
            dep.IsActive = true;

            _ReadingRoomDBContext.AddAsync(dep);
            _ReadingRoomDBContext.SaveChangesAsync();

        }


        [NonAction]
        public async Task CreateContext(CreateContentDTO dto)
        {
            Content content = new Content();
            content.Name = dto.Name;
            content.Description = dto.Description;
            content.Author = dto.Author;
            content.Price = dto.Price;
            content.DatePublished = dto.DatePublished;
            content.IsActive = true;
            if (Enum.TryParse(dto.ContentType, out ContentType cont))
            {
                content.ContentType = cont;
            }
            else
            {
                throw new Exception("Invalid ContentType value Make sure it's one of the listed in the Enum\"");
            }
            
            await _ReadingRoomDBContext.AddAsync(content);
            await _ReadingRoomDBContext.SaveChangesAsync();
        }
        [NonAction]
        public async Task CreateEmployee(CreateEmpDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email Is Required");
            if (string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Phone Is Required");
            if (string.IsNullOrEmpty(dto.Password))
                throw new Exception("Password Is Required");

            Person user = new Person();
            user.fullName = dto.FullName;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Password = dto.Password;
            if (Enum.TryParse(dto.personType, out PersonType type))
            {
                user.PersonType = type;
            }
            else
            {
                throw new Exception("Invalid Gender value Make sure it's either Male or Female");
            }

            _ReadingRoomDBContext.AddAsync(user);
            _ReadingRoomDBContext.SaveChangesAsync();
     
        }


        [NonAction]
        public async Task CreateSubs(CreateSubDTO dto)
        {
            Subscription sub = new Subscription();
            if (Enum.TryParse(dto.Name, out SubscriptionType subs))
            {
                sub.Name = subs;
            }
            else
            {
                throw new Exception("Invalid ContentType value Make sure it's one of the listed in the Enum\"");
            }
            sub.Price = dto.Price;
            sub.Description = dto.Description;
            sub.DownloadedBookAmount = dto.DownloadedBookAmount;
            sub.durationInDays = dto.durationInDays;
            sub.IsActive = true;
            

            await _ReadingRoomDBContext.AddAsync(sub);
            await _ReadingRoomDBContext.SaveChangesAsync();
        }



        [NonAction]
        public Task DisOrReActive(UpdateSubs dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task UpdateAdmin(UpdateAdmin dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task UpdateEmployee(UpdateEmpDTO dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task UpdateSub(UpdateSubs dto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
