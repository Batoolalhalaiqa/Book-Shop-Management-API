using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.DTOs.Authantication;
using Microsoft.AspNetCore.Mvc;

namespace Book_Shop_Management_API.Interface
{
    public interface Ishared
    {

        //Login 
        Task CreateNewAccount(RegistraionDTO dto);
        Task Login(LoginDTO dto);
        Task RestPassword(ResetPasswordDto dto);


        //bookType
        List<BookTypeDTO> GetBookTypes();
        Task<BookTypeDTO> GetBookTypesById(int Id);

        //Book
        Task<BookDTO> GetBook(int BookId);
        Task<IActionResult> CreateNewAccount(RegistraionDTO dto);
    }
}
