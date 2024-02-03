using Book_Shop_Management_API.Context;
using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.DTOs.Authantication;
using Book_Shop_Management_API.Interface;
using Book_Shop_Management_API.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Book_Shop_Management_API.Models.Entity.User;
using System.Reflection;
using System.Numerics;

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
        public async Task<BookDTO> GetBook(int BookId)
        {
            var query = from book in _BookShoopDBcontext.Books
                        where book.BookId == BookId
                        select new BookDTO
                        {
                            BookId = book.BookId,
                            Title = book.Title,
                            Description = book.Description,
                            Author = book.Author,
                            CreatedDate = book.CreatedDate,
                            DurationDayAvaible = book.DurationDayAvaible,
                            Isavailable = book.Isavailable,
                            Quantity = book.Quantity,
                            Version = book.Version
                        };
            return await query.SingleAsync();
        }
        [HttpGet]
        [Route("[action]")]
        public List<BookTypeDTO> GetBookTypes()
        {
            var query = from book in _BookShoopDBcontext.TypeBooks
                        select new BookTypeDTO
                        {
                            Name = book.Name,
                            BookTypeId = book.TypeBookId
                        };
            return query.ToList();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<BookTypeDTO> GetBookTypesById(int Id)
        {
            var query = from book in _BookShoopDBcontext.TypeBooks
                        where book.TypeBookId == Id
                        select new BookTypeDTO
                        {
                            Name = book.Name,
                            BookTypeId = book.TypeBookId
                        };
            return await query.SingleAsync();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<EmployeeDTO> GetEmployeeINFO(string Phone, string FirstName, string LastName, string Specilization)
        {
            var query = from emp in _BookShoopDBcontext.Users
                        where emp.Phone.Contains(Phone) ||
                        emp.FirstName.Contains(FirstName) ||
                        emp.lastName.Contains(LastName) ||
                        emp.Specilization.Contains(Specilization)
                        select new EmployeeDTO
                        {
                            EmployeeId = emp.UserId,
                            FirstName = emp.FirstName,
                            LastName = emp.lastName,
                            Email = emp.Email,
                            Phone = emp.Phone,
                            Password = emp.Password,
                            Age = emp.Age,
                            Gender = emp.Gender,
                            Specilization = emp.Specilization

                        };
            return await query.SingleAsync();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<EmployeeDTO> GetEmployeeById(int Id)
        {

            var query = from emp in _BookShoopDBcontext.Users
                        where emp.UserId == Id
                        select new EmployeeDTO
                        {
                            EmployeeId = emp.UserId,
                            FirstName = emp.FirstName,
                            LastName = emp.lastName,
                            Email = emp.Email,
                            Phone = emp.Phone,
                            Password = emp.Password,
                            Age = emp.Age,
                            Gender = emp.Gender,
                            Specilization = emp.Specilization

                        };
            return await query.SingleAsync();
        }
        #endregion

        #region Actions 
        [HttpPost]
        [Route("[action]")]
        public void AddNewSubsecription(Subsecription subsecription)
        {
            _BookShoopDBcontext.Add(subsecription);
            _BookShoopDBcontext.SaveChanges();
        }
        [HttpPost]
        [Route("[action]")]
        public Task<EmployeeDTO> CreateEmployee(User.Employee employee)
        {
            _BookShoopDBcontext.Add(employee);
            _BookShoopDBcontext.SaveChanges();
            return null;
        }

        [HttpPut]
        [Route("[action]")]
        public void UpdateNewSubsecription(Subsecription subsecription, int Id)
        {
            var subscription = _BookShoopDBcontext.Subsecriptions.Find(Id);
            if (subscription != null)
            {
                _BookShoopDBcontext.Update(subsecription);
                _BookShoopDBcontext.SaveChanges();
            }
        }

        [HttpPut]
        [Route("[action]")]
        public Task<EmployeeDTO> UpdateEmployeeInfo(User.Employee employee, int Id)
        {
            var emp = _BookShoopDBcontext.Users.Find(Id);
            if (employee != null)
            {
                _BookShoopDBcontext.Update(employee);
                _BookShoopDBcontext.SaveChanges();
            }
            return null;
        }

        [HttpDelete]
        [Route("[action]")]
        public void RemoveSubsecription(int Id)
        {
            var subscription = _BookShoopDBcontext.Subsecriptions.Find(Id);
            if (subscription != null)
            {
                _BookShoopDBcontext.Remove(subscription);
                _BookShoopDBcontext.SaveChanges();
            }

        }
        [HttpDelete]
        [Route("[action]")]

        public Task<EmployeeDTO> DeleteEmployee(int Id)
        {
            var employee = _BookShoopDBcontext.Users.Find(Id);
            if (employee != null)
            {
                _BookShoopDBcontext.Remove(employee);
                _BookShoopDBcontext.SaveChanges();
            }
            return null;
        }
        #endregion

    }
}
