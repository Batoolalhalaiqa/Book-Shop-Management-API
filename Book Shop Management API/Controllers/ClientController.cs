using Book_Shop_Management_API.Context;
using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.Interface;
using Book_Shop_Management_API.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var query = from book in _BookShoopDBcontext.Books
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
            return query.ToList();
        }
        [HttpGet]
        [Route("[action]")]
        public List<BookTypeDTO> GetAllBookType()
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
        public List<SubsecriptionDTO> GetAllSubsecription()
        {
            var query = from book in _BookShoopDBcontext.Subsecriptions
                        select new SubsecriptionDTO
                        {
                            SubsecriptionId = book.SubsecriptionId,
                            SubsecriptionType = book.SubsecriptionType,
                            SubsecriptionName = book.SubsecriptionName,
                            Description = book.Description,
                            DurationDay = book.DurationDay,
                            DownloadBookAmount = book.DownloadBookAmount,
                            Price = book.Price,
                            Isavailable = book.Isavailable

                        };
            return query.ToList();
        }
        #endregion
        #region
        public List<BookDTO> CheckBookStatus(string Title, bool Isavailable)
        {
            var query = from book in _BookShoopDBcontext.Books
                        where book.Title.Contains( Title) && book.Isavailable == Isavailable
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
            return query.ToList();
        }
        public List<SubsecriptionDTO> CheckSubsecriptionStatus(string SubsecriptionName, bool Isavailable)
        {
            var query = from book in _BookShoopDBcontext.Subsecriptions
                        where book.SubsecriptionName.Contains( SubsecriptionName )
                        && book.Isavailable == Isavailable
                        select new SubsecriptionDTO
                        {
                            SubsecriptionId = book.SubsecriptionId,
                            SubsecriptionType = book.SubsecriptionType,
                            SubsecriptionName = book.SubsecriptionName,
                            Description = book.Description,
                            DurationDay = book.DurationDay,
                            DownloadBookAmount = book.DownloadBookAmount,
                            Price = book.Price,
                            Isavailable = book.Isavailable

                        };
            return query.ToList();
        }

        public async Task<SubsecriptionDTO> DownloadBookAmount(string DownloadBookAmount, int SubsecriptionId)
        {
            var query = from book in _BookShoopDBcontext.Subsecriptions
                        where book.DownloadBookAmount.Contains(DownloadBookAmount)
                        && book.SubsecriptionId == SubsecriptionId
                        select new SubsecriptionDTO
                        {
                            SubsecriptionId = book.SubsecriptionId,
                            SubsecriptionType = book.SubsecriptionType,
                            SubsecriptionName = book.SubsecriptionName,
                            Description = book.Description,
                            DurationDay = book.DurationDay,
                            DownloadBookAmount = book.DownloadBookAmount,
                            Price = book.Price,
                            Isavailable = book.Isavailable

                        };
            return await query.SingleAsync();
        }
        #endregion
    }
}
