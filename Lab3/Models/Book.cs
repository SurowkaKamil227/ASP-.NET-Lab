using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3.Models
{
    public class Book
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole 'Tytuł' jest wymagane.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole 'Autor' jest wymagane.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Pole 'Liczba stron' jest wymagane.")]
        [Range(1, int.MaxValue, ErrorMessage = "Liczba stron musi być większa niż 0.")]
        public int PageCount { get; set; }

        [Required(ErrorMessage = "Pole 'ISBN' jest wymagane.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Pole 'Rok wydania' jest wymagane.")]
        [Range(1000, 9999, ErrorMessage = "Podaj poprawny rok wydania.")]
        public int YearPublished { get; set; }

        [Required(ErrorMessage = "Pole 'Wydawnictwo' jest wymagane.")]
        public string Publisher { get; set; }
    }

}
