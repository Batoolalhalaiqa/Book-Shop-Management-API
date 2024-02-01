using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.DTOs.Authantication;
using Book_Shop_Management_API.Models.Entity;
using System;
using static Book_Shop_Management_API.Models.Entity.User;

namespace Book_Shop_Management_API.Interface
{
    public interface IAdmin
    {

        //CRUD Employee
        Task<EmployeeDTO> GetEmployeeINFO(string Phone, string FirstName, string LastName, string Specilization);
        Task<EmployeeDTO> CreateEmployee(Employee employee);
        Task<EmployeeDTO> DeleteEmployee(int Id);
        Task<EmployeeDTO> UpdatePersonInfo(Employee employee, int Id);
        Task<EmployeeDTO> GetPersonById(int Id);

        //Login 

        Task CreateNewAccount(RegistraionDTO dto);
        Task Login(LoginDTO dto);
        Task RestPassword(RestPasswordDto dto);

        //Subsecription

        void AddNewSubsecription(Subsecription subsecription);
        void UpdateNewSubsecription(Subsecription subsecription, int Id);
        void RemoveSubsecription(int Id);

        //bookType
        List<BookTypeDTO> GetBookTypes();
        Task<BookTypeDTO>GetBookTypesById(int Id);

        //Book
        Task<BookDTO> GetBook(int BookId);
        
    }
}
