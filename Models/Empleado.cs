namespace CalculadoraNomina.Models
{
    public class Empleado
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal SalarioBasico { get; set; }
        public int DiasTrabajados { get; set; }
        public decimal HorasExtras { get; set; }
        public decimal ValorHoraExta { get; set; }
        public decimal Bonificaciones { get; set; }
        public decimal Deducciones { get; set; }
    }
}