using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksApi.Entities.Entities
{
    public class BookDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // auto-increment ID
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
