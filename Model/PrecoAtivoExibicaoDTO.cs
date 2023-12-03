namespace variacao_ativo.Model
{
    public class PrecoAtivoExibicaoDTO
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public double? PercentualValorDiaAnterior { get; set; }
        public double? PercentualValorDiaPrimeiro { get; set; }
        public int Dia => Data.Day;

        public PrecoAtivoExibicaoDTO(DateTime Data, decimal Valor, decimal? ValorDiaAnterior, decimal? ValorDiaPrimeiro)
        {
            this.Data = Data;
            this.Valor = Valor;
            PercentualValorDiaAnterior = ValorDiaAnterior != null ? Convert.ToDouble(Valor / ValorDiaAnterior / 100) : null;
            PercentualValorDiaPrimeiro = ValorDiaPrimeiro != null ? Convert.ToDouble(Valor / ValorDiaPrimeiro / 100) : null;
        }
    }
}
