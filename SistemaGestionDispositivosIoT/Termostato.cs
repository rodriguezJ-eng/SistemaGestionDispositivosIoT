/// <summary>
/// la clase hija que representa un Termostato Inteligente.
/// </summary>
public class Termostato : DispositivosIoT
{
    private double _temperaturaObjetivo;

    public Termostato(string id, string nombre, int nivelBateria, double temperaturaInicial)
        : base(id, nombre,nivelBateria)
    {
        TemperaturaObjetivo = temperaturaInicial;
    }

    // Decidir que hacer con esto 
    public double TemperaturaObjetivo
    {
        get => _temperaturaObjetivo;
        set
        {
            if (value < 15.0)
            {
                Console.WriteLine($"[ALERTA]: {value}°C está por debajo del mínimo. Ajustando a 15.0°C.");
                _temperaturaObjetivo = 15.0; 
            }
            else if (value > 32.0)
            {
                Console.WriteLine($"[ALERTA]: {value}°C excede el máximo. Ajustando a 32.0°C.");
                _temperaturaObjetivo = 32.0; 
            }
            else
            {
                _temperaturaObjetivo = value; 
            }
        }
    }

    public override void Configurar(string ModoOperacion)
    {
        Console.WriteLine($"[{Nombre}]: Modo de operación establecido a '{ModoOperacion}'.");
    }

    public override void Configurar(int valorTemperaturaObjetivo)
    {
        TemperaturaObjetivo = valorTemperaturaObjetivo;
        Console.WriteLine($"[{Nombre}]: Temperatura objetivo actualizada a {TemperaturaObjetivo}ºC.");
    }

    /// <summary>
    /// Reporta el estado actual del termostato en la consola
    /// </summary>
    public override void ReportarEstado()
    {
        string mensajeEstado = Encendido ? "ENCENDIDO y Climatizando la habitación" : "APAGADO y en modo de ahorro";

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"[TERMOSTATO]:{Nombre}");
        Console.WriteLine($"Estado:  {mensajeEstado}");
        Console.WriteLine($"Temperatura:  {TemperaturaObjetivo}°C");
        Console.WriteLine($"Batería:  {NivelBateria}%");
        Console.WriteLine("------------------------------------------------");
    }
}
