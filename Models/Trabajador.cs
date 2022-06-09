using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Inkasign.Models
{
   [Table("t_trabajador")]
    public class Trabajador
    {

       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Column("id")]


       public int Id { get; set;}
       [Column("Nombres")]
       public string Nombres { get; set;} 

       [Column("Apellidos")]
       public string Apellidos { get; set;}
       [Column("Correo")]
       
       public string Correo { get; set;}
       [Column("Celular")]
       
       public string Celular { get; set;}

       [Column("Nacimiento")]
       
       public string Nacimiento { get; set;}
       [Column("Rol")]
       
       public string Rol { get; set;}
       
       
    }
}