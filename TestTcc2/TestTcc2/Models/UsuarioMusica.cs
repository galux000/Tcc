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
using System.IO;

namespace TestTcc2.Models
{
    public class UsuarioMusica
    {
        public int UsuarioMusicaId { get; set; }
        public int UserId { get; set; }
        public int MusicaId {get; set;}

    }
}