using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTcc2.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Primeiro nome é um campo obrigatório")]
        [DisplayName("Primeiro Nome")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Ultimo nome é um campo obrigatório")]
        [DisplayName("Ultimo Nome")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Endereço é um campo obrigatório")]
        [DisplayName("Endereço")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Cidade é um campo obrigatório")]
        [DisplayName("Cidade")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "Estado é um campo obrigatório")]
        [DisplayName("Estado")]
        [StringLength(40)]
        public string State { get; set; }
        [Required(ErrorMessage = "CEP é um campo obrigatório")]
        [DisplayName("CEP")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "País é um campo obrigatório")]
        [DisplayName("País")]
        [StringLength(40)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Telefone é um campo obrigatório")]
        [DisplayName("Telefone")]
        [StringLength(24)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "E-mail é um campo obrigatório")]
        [DisplayName("E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "E-mail invalido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}