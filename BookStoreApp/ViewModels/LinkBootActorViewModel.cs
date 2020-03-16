using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStoreApp.ViewModels
{
    public class LinkBootActorViewModel
    {

        [Required(ErrorMessage = "*")]
        public int ActorId { get; set; }

        [Required(ErrorMessage = "*")]
        public int BookId { get; set; }


    }
}