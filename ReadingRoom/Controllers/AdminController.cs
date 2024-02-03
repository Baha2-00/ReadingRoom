using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReadingRoom.Context;
using ReadingRoom.DTOs.Content;
using ReadingRoom.DTOs.Department;
using ReadingRoom.DTOs.Person.Admin;
using ReadingRoom.DTOs.Person.Employee;
using ReadingRoom.DTOs.Subscription;
using ReadingRoom.Interfaces;
using ReadingRoom.Models.Entity;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
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

        /// <summary>
        /// an action to Add Admin  
        /// </summary>
        /// <response code="200">Returns Admin Created  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>   

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
        /// <summary>
        /// an action to Add Department  
        /// </summary>
        /// <response code="200">Returns Department Created  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>   
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

        /// <summary>
        /// an action to Add Employee  
        /// </summary>
        /// <response code="200">Returns Employee Created  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>  
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
        /// <summary>
        /// an action to Add Content  
        /// </summary>
        /// <response code="200">Returns Content Created  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>  
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateContentAction(CreateContentDTO dto)
        {
            try
            {
                await CreateContent(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "New Content Has Been created" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Creating content  {ex.Message}" };
            }
        }

        /// <summary>
        /// an action to Add Subscription  
        /// </summary>
        /// <response code="200">Returns Subscription is Created  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>  
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

        /// <summary>
        /// an action to Dis Or ReActive Subscription
        /// </summary>
        /// <response code="200">Returns Update success  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> DisOrReActiveAction(UpdateSubs dto)
        {
            try
            {
                await DisOrReActive(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Update Done" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Updating Sub  {ex.Message}" };
            }
        }

        /// <summary>
        /// an action to Update Admin
        /// </summary>
        /// <response code="200">Returns Update success  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAdminAction(UpdateAdmin dto)
        {
            try
            {
                await UpdateAdmin(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Update Done" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Updating Admin  {ex.Message}" };
            }
        }
        /// <summary>
        /// an action to Update Employee
        /// </summary>
        /// <response code="200">Returns Update success  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEmployeeAction(UpdateEmpDTO dto)
        {
            try
            {
                await UpdateEmployee(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Update Done" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Updating Employee  {ex.Message}" };
            }
        }
        /// <summary>
        /// an action to Update Subscription
        /// </summary>
        /// <response code="200">Returns Update success  </response>
        /// <response code="400">Something Went Wrong</response>    
        /// <response code="500">Server is UnAvailable</response>  
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateSubAction(UpdateSubs dto)
        {
            try
            {
                await UpdateSub(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Update Done" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Updating Sub  {ex.Message}" };
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
            if (string.IsNullOrEmpty(dto.FullName))
                throw new Exception("FullName Is Required");
            Person user = new Person();
            user.fullName = dto.FullName;
            user.Email= dto.Email;
            user.Phone= dto.Phone;
            user.Password= dto.Password;
            user.Age = dto.Age;
            user.Gender = dto.Gender;
            user.Specialization = dto.Specialization;
            user.PersonType = PersonType.Admin;
            await _ReadingRoomDBContext.AddAsync(user);
            await _ReadingRoomDBContext.SaveChangesAsync();
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

            await _ReadingRoomDBContext.AddAsync(dep);
            await _ReadingRoomDBContext.SaveChangesAsync();

        }


        [NonAction]
        public async Task CreateContent(CreateContentDTO dto)
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
            user.Age = dto.Age;
            user.Gender = dto.Gender;
            user.Specialization = dto.Specialization;
            user.PersonType = PersonType.Employee;

            await _ReadingRoomDBContext.AddAsync(user);
           await _ReadingRoomDBContext.SaveChangesAsync();
     
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
                throw new Exception("Invalid Subscription Type Try Again");
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
        public async Task DisOrReActive(UpdateSubs dto)
        {
            if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Description))
                throw new Exception("Name and Description are required");
            var user = await _ReadingRoomDBContext.Subscriptions.Where(x => x.Name.Equals(dto.Name)
            && x.Description.Equals(dto.Description) && x.Price.Equals(dto.Price)
            && x.durationInDays.Equals(dto.durationInDays) && x.DownloadedBookAmount.Equals(dto.DownloadedBookAmount)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                if (Enum.TryParse(dto.Name, out SubscriptionType sub))
                {
                    user.Name = sub;
                }
                else
                {
                    throw new Exception("Invalid SubscriptionType value ");
                }
                user.Description = dto.Description;
                user.Price = dto.Price;
                user.durationInDays = dto.durationInDays;
                user.DownloadedBookAmount = dto.DownloadedBookAmount;
                user.IsActive = false;
            }
            _ReadingRoomDBContext.Update(user);
            await _ReadingRoomDBContext.SaveChangesAsync();
        }
        [NonAction]
        public async Task UpdateAdmin(UpdateAdmin dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.fullName) ||
                string.IsNullOrEmpty(dto.Phone) || string.IsNullOrEmpty(dto.Password))
                throw new Exception("enterd values are required");
            var user = await _ReadingRoomDBContext.Persons.Where(x => x.fullName.Equals(dto.fullName)
            && x.Email.Equals(dto.Email) && x.Phone.Equals(dto.Phone)
            && x.Password.Equals(dto.Password)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                user.fullName = dto.fullName;
                user.Email = dto.Email;
                user.Phone = dto.Phone;
                user.Password = dto.Password;
            }
            _ReadingRoomDBContext.Update(user);
            await _ReadingRoomDBContext.SaveChangesAsync();
        }
    
        [NonAction]
        public async Task UpdateEmployee(UpdateEmpDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.FullName) ||
                string.IsNullOrEmpty(dto.Phone) || string.IsNullOrEmpty(dto.Password))
                throw new Exception("enterd values are required");
            var user = await _ReadingRoomDBContext.Persons.Where(x => x.fullName.Equals(dto.FullName)
            && x.Email.Equals(dto.Email) && x.Phone.Equals(dto.Phone)
            && x.Password.Equals(dto.Password)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                user.fullName = dto.FullName;
                user.Email = dto.Email;
                user.Phone = dto.Phone;
                user.Password = dto.Password;
            }
            _ReadingRoomDBContext.Update(user);
            await _ReadingRoomDBContext.SaveChangesAsync();
        }
        [NonAction]
        public async Task UpdateSub(UpdateSubs dto)
        {
            if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Description))
                throw new Exception("Name and Description are required");
            var user = await _ReadingRoomDBContext.Subscriptions.Where(x => x.Name.Equals(dto.Name)
            && x.Description.Equals(dto.Description) && x.Price.Equals(dto.Price)
            && x.durationInDays.Equals(dto.durationInDays) && x.DownloadedBookAmount.Equals(dto.DownloadedBookAmount))
                .SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Sub Not Found");
            }
            else
            {
                if (Enum.TryParse(dto.Name, out SubscriptionType sub))
                {
                    user.Name = sub;
                }
                else
                {
                    throw new Exception("Invalid SubscriptionType value ");
                }
                user.Description = dto.Description;
                user.Price = dto.Price;
                user.durationInDays = dto.durationInDays;
                user.DownloadedBookAmount = dto.DownloadedBookAmount;
                user.IsActive = true;
            }
            _ReadingRoomDBContext.Update(user);
            await _ReadingRoomDBContext.SaveChangesAsync();
        }
    }
        #endregion
    }

