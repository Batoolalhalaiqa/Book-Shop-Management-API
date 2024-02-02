using Book_Shop_Management_API.Context;
using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.DTOs.Authantication;
using Book_Shop_Management_API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Book_Shop_Management_API.Models.Entity.User;
using System;
using Book_Shop_Management_API.Models.Entity;

namespace Book_Shop_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase, Ishared
    {
        private readonly BookShoopDBcontext _BookShoopDBcontext;
        public SharedController(BookShoopDBcontext context)
        {
            _BookShoopDBcontext = context;
        }

        #region Get Information
        [HttpGet]
        [Route("[action]/{Id}")]
        public async Task<IActionResult> GetBook(int BookId)
        {
            try
            {
                return Ok(await GetBook(BookId));
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = "Something Went Wrong" };
            }
        }
        /// <summary>
        /// Retrieves  All Books Type In The Data base
        /// </summary>
        /// <response code="200">Returns All type</response>
        /// <response code="400">Sommething Went Wronh</response>    
        /// <response code="503">Server Un Available</response>
        [HttpGet]
        [Route("[action]")]
        public List<BookTypeDTO> GetBookTypes()
        {

            var reslt = from item in _BookShoopDBcontext.TypeBooks
                        select new BookTypeDTO
                        {
                            TypeBookId = item.TypeBookId,
                            Name = item.Name,
                        };
            return reslt.ToList();
        }

        public Task<BookTypeDTO> GetBookTypesById(int Id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Authantication
        [HttpPost]
        [Route("[action]")]
        public async Task Registration(RegistraionDTO dto)
        {
            User p1 = new Client();
            p1.FirstName = dto.FirstName;
            p1.lastName = dto.lastName;
            p1.Email = dto.Email;
            p1.Phone = dto.Phone;
            p1.Password = dto.Password;
            p1.Age = dto.Age;
            p1.UserType = await _BookShoopDBcontext.UserTypes.FirstOrDefaultAsync(x => x.UserTypeID == 3);

            await _BookShoopDBcontext.AddAsync(p1);
            await _BookShoopDBcontext.SaveChangesAsync();
        }
        public async Task<IActionResult> CreateNewAccountAction(RegistraionDTO dto)
        {

            try
            {
                await CreateNewAccount(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "New Account Has Been Activated" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Failed Createing Account  {ex.Message}" };
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LoginAction(LoginDTO dto)
        {
            try
            {
                await LoginAction(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Login Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Login Failed {ex.Message}" };
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ResetPasswordAction(ResetPasswordDto dto)
        {
            try
            {
                await ResetPasswordAction(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "ResetPassword Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"ResetPassword Failed {ex.Message}" };
            }
        }

        Task<BookDTO> Ishared.GetBook(int BookId)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Implementations
        [NonAction]
        public async Task CreateNewAccount(RegistraionDTO dto)
        {
            //validation
            if (string.IsNullOrEmpty(dto.Email))
                throw new Exception("Email Is Required");
            if (string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Phone Is Required");
            if (string.IsNullOrEmpty(dto.Password))
                throw new Exception("Password Is Required");
            if (string.IsNullOrEmpty(dto.FirstName))
                throw new Exception("Name Is Required");
            User user = new User();
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Password = dto.Password;
            user.FirstName = dto.FirstName;
            user.lastName = dto.lastName;
            await _BookShoopDBcontext.AddAsync(user);
            await _BookShoopDBcontext.SaveChangesAsync();
        }

        [NonAction]
        public async Task Login(LoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                throw new Exception("Email and Password are required");
            var login = await _BookShoopDBcontext.Users
                 .Where(x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password))
                 .SingleOrDefaultAsync();
            if (login == null)
            {
                throw new Exception("Email Or Password Is Not Correct");
            }
        }

        [NonAction]
        public async Task ResetPassword(ResetPasswordDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Email and Phone are required");
            var user = await _BookShoopDBcontext.Users.Where(x => x.Email.Equals(dto.Email)
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
                        _BookShoopDBcontext.Update(user);
                        await _BookShoopDBcontext.SaveChangesAsync();
                    }
                }

            }
        }

        
    }
}