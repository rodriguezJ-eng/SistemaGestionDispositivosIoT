/// <summary>
/// Clase hija heredada de dispositivosIot agregando un atributo propio de esta clase 
/// </summary>

public class LuzInteligente : DispositivosIoT
    {
        private int _intensidad;

        public LuzInteligente(string id, string nombre, bool encendido, int nivelBateria, int intensidadInicial)
            : base(id, nombre, encendido, nivelBateria)
        {
            Intensidad = intensidadInicial; 
        }

    public int Intensidad
    {
        get => _intensidad;
        set
        {
            if (value < 0)
            {
                Console.WriteLine($"[ALERTA - {Nombre}]: Intensidad negativa ({value}%). Ajustando al mínimo: 0%.");
                _intensidad = 0;
            }
            else if (value > 100)
            {
                Console.WriteLine($"[ALERTA - {Nombre}]: Intensidad excede el límite ({value}%). Ajustando al máximo: 100%.");
                _intensidad = 100; 
            }
            else
            {
                _intensidad = value;
            }
        }
        }
    //  Se sella el método para garantizar que ninguna subclase
    //  futura altere la lógica estandarizada de ubicación.
    public sealed override void Configurar(string ubicacion)
        {
            Console.WriteLine($"[{Nombre}]: Intensidad regulada al {Intensidad}% y vinculada a: {ubicacion}.");
        }

        public override void ReportarEstado()
        {
            string mensajeEstado = Encendido ? "ENCENDIDO y alumbrando la zona" : "APAGADO y en modo de ahorro energético";
           Console.WriteLine("-----------------------------------------------");
           Console.WriteLine($"[LUCES]: {Nombre}");
            Console.WriteLine($"Estado:  {mensajeEstado}");
            Console.WriteLine($"Intensidad: {Intensidad}%"); 
            Console.WriteLine($"Batería:  {NivelBateria}%");
            Console.WriteLine("------------------------------------------------");
        }
    }