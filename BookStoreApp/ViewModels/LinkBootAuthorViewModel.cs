using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.ViewModels
{
    public class LinkBootAuthorViewModel
    {

        [Required(ErrorMessage = "*")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "*")]
        public int BookId { get; set; }


    }
}