using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace variacao_ativo.Model
{
    public class PrecoAtivoDTO
    {
        public PrecoAtivoDTO() { }

        public PrecoAtivoDTO(JToken timestamp, JToken open)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp.Value<long>());
            this.Data = dateTimeOffset.ToLocalTime().UtcDateTime;
            this.Valor = open.Value<decimal>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        [Column(TypeName = "decimal(15, 5)")]
        public decimal Valor { get; set; }
    }
}
