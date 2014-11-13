using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Web.Security;

namespace TestTcc2.Models
{
    public class Musica
    {
        public int MusicaId { get; set; }
        public int GeneroId { get; set; } //GenreID
        public int UserId { get; set; } //Needs to take the username from current user logged in app
        public string Nome { get; set; }
        public string NomeArtista { get; set; }
        public Genero genero { get; set; }
        public decimal Preco { get; set; }
        public bool isFree { get; set; }
        public string path { get; set; }
    }
}