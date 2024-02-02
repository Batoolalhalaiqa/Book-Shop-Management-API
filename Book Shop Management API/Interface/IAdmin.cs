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
        Task<EmployeeDTO> UpdateEmployeeInfo(Employee employee, int Id);
        Task<EmployeeDTO> GetEmployeeById(int Id);

        //Subsecription

        void AddNewSubsecription(Subsecription subsecription);
        void UpdateNewSubsecription(Subsecription subsecription, int Id);
        void RemoveSubsecription(int Id);

      
        
    }
}
