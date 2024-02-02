using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingRoom.Context;
using ReadingRoom.DTOs.Authentication;
using ReadingRoom.DTOs.Content;
using ReadingRoom.DTOs.Person.Client;
using ReadingRoom.DTOs.Subscription;
using ReadingRoom.Interfaces;
using ReadingRoom.Models.Entity;
using System.Reflection;
using static ReadingRoom.Helper.Enum.Enums;

namespace ReadingRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase,IShared
    {
        private readonly ReadingRoomDBContext _ReadingRoomDBContext;
        public SharedController(ReadingRoomDBContext context)
        {
            _ReadingRoomDBContext = context;
        }


        #region Get

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSubsAction()
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpGet]
        [Route("[action]")]
        public Task<IActionResult> GetBooksAction(int ContentType)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpGet]
        [Route("[action]")]
        public Task<IActionResult> GetContentDetailsAction(float Price, int ContentType, string Name)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpGet]
        [Route("[action]")]
        public Task<IActionResult> GetSubsFilterAction(float Price, float durationInDays, int Name)
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

        #region Post

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewAccountAction(CreatClientDTO dto)
        {
            try
            {
                await CreateNewAccount(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "New Account Has Been Activated" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Creating Account  {ex.Message}" };
            }
        }
        #endregion

        #region Authentication

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LoginAction(Login dto)
        {
            try
            {
                await Login(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Login Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Login Failed {ex.Message}" };
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ResetPasswordAction(ResetPasswordDTO dto)
        {
            try
            {
                await ResetPassword(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "ResetPassword Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"ResetPassword Failed {ex.Message}" };
            }
        }
        #endregion


        #region Implementation

        [NonAction]
        public async Task CreateNewAccount(CreatClientDTO dto)
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
            user.Password = dto.Password;
            user.Age = dto.Age;
            user.birthDate = dto.birthDate;
            user.Specialization = dto.Specialization;
            user.Gender = dto.Gender;
            user.IsActive = true;
            if (Enum.TryParse(dto.PersonType, out PersonType Per))
            {
                user.PersonType = Per;
            }
            else
            {
                throw new Exception("Invalid PersonType value Make sure it's one of the listed in the Enum\"");
            }

            await _ReadingRoomDBContext.AddAsync(user);
            await _ReadingRoomDBContext.SaveChangesAsync();
        }


        [NonAction]
        public  Task<List<GetSubDTO>> GetAllSubs()
        {
            throw new NotImplementedException();
            //var query = await(from e in _ReadingRoomDBContext.Subscriptions

            //                  select new GetSubDTO
            //                  {
            //                     subscriptionId=e.subscriptionId,
            //                      Name=e.Name.ToString(),
            //                      Description=e.Description,
            //                      Price=e.Price,
            //                      durationInDays=e.durationInDays,
            //                      DownloadedBookAmount =e.DownloadedBookAmount,
            //                  }).SingleAsync();
            //
        }


        [NonAction]
        public Task<List<GetContentDTO>> GetBooks(int ContentType)
        {
            throw new NotImplementedException();
        }


        [NonAction]
        public Task<List<GetContentDetailsDTO>> GetContentDetails(float Price, int ContentType, string Name)
        {
            throw new NotImplementedException();
        }


        [NonAction]
        public Task<List<GetSubDTO>> GetSubsFilter(float Price, float durationInDays, int Name)
        {
            throw new NotImplementedException();
        }


        [NonAction]
        public async Task Login(Login dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password) || 
                string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Email Or Phone and Password are required");
            var login = await _ReadingRoomDBContext.Persons
                 .Where(x => (x.Email.Equals(dto.Email) || x.Phone.Equals(dto.Phone)) && x.Password.Equals(dto.Password))
                 .SingleOrDefaultAsync();
            if (login == null)
            {
                throw new Exception("Email Or Password Is Not Correct");
            }
        }

        [NonAction]
        public async Task ResetPassword(ResetPasswordDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Email and Phone are required");
            var user = await _ReadingRoomDBContext.Persons.Where(x => x.Email.Equals(dto.Email)
            && x.Phone.Equals(dto.Phone)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                if (string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.ConfirmPassword))
                    throw new Exception("Password and ConfirmPassword are required");
                else
                {
                    if (dto.Password.Equals(dto.ConfirmPassword))
                    {
                        user.Password = dto.ConfirmPassword;
                        _ReadingRoomDBContext.Update(user);
                        await _ReadingRoomDBContext.SaveChangesAsync();
                    }
                }

            }
        }

        #endregion

    }
}
