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
        // this class basicly make a relationship between user and musics ( to add a music in a library from user)
        public int UsuarioMusicaId { get; set; }
        public int UserId { get; set; } //get UserId from current user logged at system
        public int MusicaId {get; set;} //get MusicId from music saved in database

    }
}