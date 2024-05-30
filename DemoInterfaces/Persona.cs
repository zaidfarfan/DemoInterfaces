namespace DemoInterfaces
{
    public class Persona
    {
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellidos} ";

        public Persona(string nombre, string apellidos) 
        { 
            Nombre = nombre;
            Apellidos = apellidos;  
        }
    }
}
