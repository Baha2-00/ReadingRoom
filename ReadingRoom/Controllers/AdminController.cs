using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingRoom.Context;
using ReadingRoom.DTOs.Content;
using ReadingRoom.DTOs.Department;
using ReadingRoom.DTOs.Person.Admin;
using ReadingRoom.DTOs.Person.Employee;
using ReadingRoom.DTOs.Subscription;
using ReadingRoom.Interfaces;

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
        public Task<IActionResult> AddAdminAction(AddAdmin dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPost]
        [Route("[action]")]
        public Task<IActionResult> AddDepartmentAction(AddDepartmentDTOcs dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPost]
        [Route("[action]")]
        public Task<IActionResult> CreateEmployeeAction(CreateEmpDTO dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPost]
        [Route("[action]")]
        public Task<IActionResult> CreateContextAction(CreateContentDTO dto)
        {
            throw new NotImplementedException();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPost]
        [Route("[action]")]
        public Task<IActionResult> CreateSubsAction(CreateSubDTO dto)
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
        public Task AddAdmin(AddAdmin dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task AddDepartment(AddDepartmentDTOcs dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task CreateContext(CreateContentDTO dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task CreateEmployee(CreateEmpDTO dto)
        {
            throw new NotImplementedException();
        }
        [NonAction]
        public Task CreateSubs(CreateSubDTO dto)
        {
            throw new NotImplementedException();
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
