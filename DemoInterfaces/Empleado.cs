namespace DemoInterfaces
{
    public class Empleado : Persona, IAsalariable
    {
        public readonly decimal EstimuloPorAniosTrabajados = 50.0M;
        public readonly int MinimoAniosSinRecibirEstimulo = 5;
        public readonly int NumeroDeDiasDelPeriodo = 15;
        public string Rfc { get; set; }

        public DateTime FechaDeIngreso { get; set; }
        public decimal SalarioDiario { get; set; }

        public Empleado(string nombre, string apellidos, string rfc, DateTime fechaDeingreso, decimal salarioDiario)
            : base(nombre, apellidos)
        {
            Rfc = rfc;
            FechaDeIngreso = fechaDeingreso;
            SalarioDiario = salarioDiario;
        }
        public decimal CalcularSalarioFijoDelPeriodo(int numeroDeDiasTrabajados)
        {
            return SalarioDiario * numeroDeDiasTrabajados;
        }

        public decimal CalcularEstimuloPorAntiguedad()
        {
            int aniosLaborando = 0;
            decimal estimulo = 0.0M;

            if (FechaDeIngreso < DateTime.Now)
            {
                DateTime momentoCero = new DateTime(1, 1, 1);
                TimeSpan lapso = DateTime.Now - FechaDeIngreso;
                aniosLaborando = (momentoCero + lapso).Year - 1;
            }
            if (aniosLaborando > MinimoAniosSinRecibirEstimulo)
            {
                estimulo = (aniosLaborando - MinimoAniosSinRecibirEstimulo) * EstimuloPorAniosTrabajados;
            }
            return estimulo;
        }

        public decimal CalcularSalario()
        {
            return CalcularSalarioFijoDelPeriodo(NumeroDeDiasDelPeriodo) + CalcularEstimuloPorAntiguedad();
        }
    }
}
