using CalculadoraNomina.Models;

namespace CalculadoraNomina.Services
{
    public class NominaService
    {
        //Salario mínimo Colombia 2026 1.750.905

        private const decimal SALARIO_MINIMO =1_750_905m;

        public object CalculadoraNomina(Empleado emp)
        {
            decimal salarioProporcional = (emp.SalarioBasico / 30) * emp.DiasTrabajados;
            decimal pagoHorasExtras = emp.HorasExtras * emp.ValorHoraExta;
            decimal totalDevengado = salarioProporcional + pagoHorasExtras + emp.Bonificaciones;

            //Deducciones de ley - cuando supera 2 SMMLV
            decimal salud = 0, pension = 0;
            if (emp.SalarioBasico > 2 * SALARIO_MINIMO)
            {
                salud =totalDevengado * 0.04m;
                pension = totalDevengado * 0.04m;
            }

            decimal totalDeducciones = salud + pension + emp.Deducciones;
            decimal netoPagar = totalDevengado - totalDeducciones;

            return new
            {
                Empleado = emp.Nombre,
                salarioProporcional = salarioProporcional,
                PagoHorasExtras = pagoHorasExtras,
                Bonificaciones = emp.Bonificaciones,
                TotalDevengado = totalDevengado,
                DeduccionSalud = salud,
                DeduccionPension= pension,
                OtrasDeducciones = emp.Deducciones,
                TotalDeducciones = totalDeducciones,
                NetoPagar = netoPagar
            };
        }
    }
}