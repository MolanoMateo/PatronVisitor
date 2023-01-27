using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PatronVisitor.Models
{
    public abstract class Componente
    {
        public int id { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Serie")]
        public string NSerie { get; set; }

        
        public string Serial
        {
            get
            {
                return NSerie;
            }
        }
        public string Aceptar()
        {
            return "ID: "+id+" - Nombre: "+Nombre+" - Serie: "+NSerie;
        }
    }
}
