using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace movieproject.Dtos
{
    public class CreateUpdateMovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int RunningTime { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        public int DirectorId { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public Byte StarRate { get; set; }
        public string Poster { get; set; }
    }
}
