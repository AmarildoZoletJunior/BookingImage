using Azure;
using BookingImage.Domain.Entities;
using BookingImage.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingImage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImagemRepository _imagem;

        public ImageController(IImagemRepository imagem) 
        {
            _imagem = imagem;
        }

        [HttpPost]
        public async Task<IActionResult> PostImagemAsync(IFormFile file,int roomId)
        {
            var insert = await _imagem.PostImage(file, roomId);
            if (insert)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetImage(int id)
        {
            try
            {
                Imagem find = await _imagem.GetImage(id);
                Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
                return Ok(File(find.ImageBase,find.FormatImage,find.RoomId.ToString()));

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);            
            }

        }

        [HttpGet("RoomsImage/{roomId:int}")]
        public async Task<IActionResult> GetImages(int roomId)
        {
            try
            {
                IEnumerable<Imagem> find =  await _imagem.GetAllImagesRoom(roomId);
                Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200");
                Console.WriteLine(find.Count());
                return Ok(find);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
