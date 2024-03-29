﻿using Book_Shop_Management_API.DTOs;
using Book_Shop_Management_API.DTOs.Authantication;
using static Book_Shop_Management_API.Models.Entity.User;

namespace Book_Shop_Management_API.Interface
{
    public interface IClient
    {
        //ViewSubsecriptions
        List<SubsecriptionDTO> GetAllSubsecription();
        public List<SubsecriptionDTO> CheckSubsecriptionStatus(string SubsecriptionName, bool Isavailable);

        //ViewBook
        List<BookTypeDTO> GetAllBookType();

        List<BookDTO> GetAllBook();

        public List<BookDTO> CheckBookStatus(string Title, bool Isavailable);

        //FilteringSubsecriptions
        Task<List<SubsecriptionDTO>> Filtering(string SubsecriptionName, float price, string DurationDay);
        Task<List<BookDTO>> FilteringBook(string Title, int TypeBookId, string Author);
        Task<SubsecriptionDTO> DownloadBookAmount(string DownloadBookAmount, int SubsecriptionId);


    }

}
