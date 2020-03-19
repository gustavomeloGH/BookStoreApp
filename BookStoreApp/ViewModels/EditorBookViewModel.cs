using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStoreApp.ViewModels
{
    public class EditorBookViewModel
    {
        public int Id{ get; set; }

        [Required(ErrorMessage ="*")]
        [Display(Name = "Nome do livro")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "*")]
        [Display(Name = "ISBN do livro")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Data de lançamento do livro")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Categoria do livro")]
        public int CategoryId { get; set; }
        public SelectList CategoryOptions { get; set; }

    }
}