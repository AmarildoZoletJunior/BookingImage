using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingImage.Domain.Entities
{
    public class Imagem
    {
        public string ImageBase { get; set; }
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string FormatImage { get; set; }
    }
}
