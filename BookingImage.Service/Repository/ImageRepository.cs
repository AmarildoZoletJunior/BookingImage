using BookingImage.Domain.Entities;
using BookingImage.Service.Exceptions;
using BookingImage.Service.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BookingImage.Service.Repository
{
    public class ImageRepository : IImagemRepository
    {
        public string connection;
        private readonly IConfiguration configuration;
        public ImageRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connection = configuration.GetConnectionString("ConnectionImage");
        }
        public async Task<IEnumerable<Imagem>> GetAllImagesRoom(int roomId)
        {
            string query = $@"SELECT * FROM Imagem WHERE roomId = {roomId}";
            using (var connect = new SqlConnection(connection))
            {
                var imageFind = await connect.QueryAsync<Imagem>(query);
                if (!imageFind.Any())
                {
                    throw new NotFind("Erro ao buscar imagens");
                }
                return imageFind;
            }
        }

        public async Task<Imagem> GetImage(int id)
        {
            string query = $@"SELECT * FROM Imagem WHERE id = {id}";
            using (var connect = new SqlConnection(connection))
            {
               var imageFind =  await connect.QueryFirstAsync<Imagem>(query);
                if(imageFind == null)
                {
                    throw new NotFind("Erro ao buscar imagem");
                }

                return imageFind;
            }
        }

        public async Task<bool> PostImage(IFormFile file,int roomId)
        {
            byte[] imageData = new byte[file.Length];
            using (var stream = file.OpenReadStream())
            {
                stream.Read(imageData, 0, imageData.Length);
            }

            string base64String = Convert.ToBase64String(imageData);
            var command = $@"INSERT INTO Imagem(RoomId,ImageBase,FormatImage) VALUES ({roomId},'{base64String}','{file.ContentType}')";
            using (var sql = new SqlConnection(connection))
            {
                var insert = await sql.ExecuteAsync(command);
                if (insert > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
