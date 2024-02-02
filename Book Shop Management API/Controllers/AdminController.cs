using Book_Shop_Management_API.Context;
using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.DTOs.Authantication;
using Book_Shop_Management_API.Interface;
using Book_Shop_Management_API.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Shop_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdmin
    {
        private readonly BookShoopDBcontext _BookShoopDBcontext;
        public AdminController(BookShoopDBcontext context)
        {
            _BookShoopDBcontext = context;
        }
        #region Get Information
        [HttpGet]
        [Route("[action]")]
        public Task<BookDTO> GetBook(int BookId)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public List<BookTypeDTO> GetBookTypes()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public Task<BookTypeDTO> GetBookTypesById(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public Task<EmployeeDTO> GetEmployeeINFO(string Phone, string FirstName, string LastName, string Specilization)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public Task<EmployeeDTO> GetEmployeeById(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Actions 
        [HttpPost]
        [Route("[action]")]
        public void AddNewSubsecription(Subsecription subsecription)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        [Route("[action]")]
        public Task<EmployeeDTO> CreateEmployee(User.Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("[action]")]
        public void UpdateNewSubsecription(Subsecription subsecription, int Id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("[action]")]
        public Task<EmployeeDTO> UpdateEmployeeInfo(User.Employee employee, int Id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [Route("[action]")]
        public void RemoveSubsecription(int Id)
        {
            throw new NotImplementedException();

        }
            [HttpDelete]
            [Route("[action]")]

            public Task<EmployeeDTO> DeleteEmployee(int Id)
            {
                throw new NotImplementedException();
            }
            #endregion
        
    }
}
