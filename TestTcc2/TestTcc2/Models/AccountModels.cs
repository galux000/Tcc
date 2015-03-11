using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Web.Security;

namespace TestTcc2.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ExternalUserInformation> ExternalUsers { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<UsuarioMusica> UsuarioMusicas { get; set; }

    }

        [Table("UserProfile")]
        public class UserProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserType { get; set; } //flag de tipo usuário musico ou ouvinte


        }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Nome de Usuário")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }

        [Display(Name = "Nome Completo")]
        public string FullName { get; set; }

        [Display(Name = "Link da sua Página")]
        public string Link { get; set; }
        [Display(Name ="Tipo de Usuário")]
        public string UserType { get; set; }
    }

    [Table("ExtraUserInformation")] 
    public class ExternalUserInformation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Link { get; set; }
        public bool? Verified { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ser menor que {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e sua confirmação não correspondem.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Nome do Usuário")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ser menor que {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua nova senha")]
        [Compare("Password", ErrorMessage = "A nova senha e sua confirmação não correspondem.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Tipo de Usuario")]
        public string UserType { get; set; }

        
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
