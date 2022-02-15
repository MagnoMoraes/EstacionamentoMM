using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace estacionamentoMM.Model
{
    public class Cars
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a placa do veículo")]
        [MaxLength(8), MinLength(7)]             
        public string Placa { get; set; }
        [Required(ErrorMessage = "É obrigatório informar a vaga que o veículo ocupa")]
        public int VagaOcupada { get; set; }
    }
}
