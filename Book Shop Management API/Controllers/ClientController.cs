using Book_Shop_Management_API.Context;
using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Shop_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase, IClient
    {
        private readonly BookShoopDBcontext _BookShoopDBcontext;
        public ClientController(BookShoopDBcontext context)
        {
            _BookShoopDBcontext = context;
        }
        #region
        [HttpGet]
        [Route("[action]")]
        public Task<List<SubsecriptionDTO>> Filtering(string SubsecriptionName, float price, string DurationDay)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public Task<List<BookDTO>> FilteringBook(string Title, int TypeBookId, string Author)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public List<BookDTO> GetAllBook()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public List<BookTypeDTO> GetAllBookType()
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("[action]")]
        public List<SubsecriptionDTO> GetAllSubsecription()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region
        public List<BookDTO> CheckBookStatus(string Title, bool Isavailable)
        {
            throw new NotImplementedException();
        }

        public List<SubsecriptionDTO> CheckSubsecriptionStatus(string SubsecriptionName, bool Isavailable)
        {
            throw new NotImplementedException();
        }

        public Task<SubsecriptionDTO> DownloadBookAmount(string DownloadBookAmount, int SubsecriptionId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
