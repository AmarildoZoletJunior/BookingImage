using BookingImage.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingImage.Service.Interfaces
{
    public interface IImagemRepository
    {
        Task<bool> PostImage(IFormFile file,int roomId);
        Task<Imagem> GetImage(int id);
        Task<IEnumerable<Imagem>> GetAllImagesRoom(int roomId);
    }
}
