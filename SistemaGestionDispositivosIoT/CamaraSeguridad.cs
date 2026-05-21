/// <summary>
/// Representa una cámara de seguridad inteligente con control de resolución y grabación.
/// Hereda de DispositivosIoT.
///
/// Configurar(string ubicacion) está SELLADO aquí porque la lógica de asignación
/// de zona de vigilancia es crítica: una cámara mal ubicada lógicamente puede
/// dejar puntos ciegos en la seguridad del hogar. Las subclases (como CamaraSeguridad360)
/// no deben poder cambiar cómo se vincula la cámara a su área de cobertura.
/// </summary>
public class CamaraSeguridad : DispositivosIoT
{
    //  Atributos propios 
    private int _resolucion; // en megapíxeles
    private bool _grabando;

    // Constructor 
    public CamaraSeguridad(string id, string nombre, int nivelBateria, int resolucion)
        : base(id, nombre, nivelBateria)
    {
        Resolucion = resolucion;
        _grabando = false;
    }

    // Propiedades con validación 
    public int Resolucion
    {
        get => _resolucion;
        set
        {
            if (value < 1 || value > 64)
                throw new ArgumentOutOfRangeException("La resolución debe estar entre 1 y 64 MP.");
            _resolucion = value;
        }
    }

    public bool Grabando
    {
        get => _grabando;
        set
        {
            _grabando = value;
            Console.WriteLine($"[{Nombre}]: Grabación {(_grabando ? "INICIADA " : "DETENIDA ")}.");
        }
    }

    // Configurar sellado 
    // Esto garantiza que la lógica de asignación de zona sea siempre la misma
    // en toda la familia de cámaras del sistema.
    public sealed override void Configurar(string ubicacion)
    {
        Console.WriteLine($"[{Nombre}]: Zona de vigilancia asignada a '{ubicacion}'. Resolución: {Resolucion}MP.");
    }

    // Implementación del método abstracto
    public override void ReportarEstado()
    {
        string estadoGrabacion = _grabando ? "Grabando" : "En espera";
        string mensajeEstado = Encendido ? "ENCENDIDO" : "APAGADO";

        Console.WriteLine("------------------------------------------------");
        Console.WriteLine($"[CÁMARA]: {Nombre}");
        Console.WriteLine($"Estado:     {mensajeEstado}");
        Console.WriteLine($"Grabación:  {estadoGrabacion}");
        Console.WriteLine($"Resolución: {Resolucion}MP");
        Console.WriteLine($"Batería:    {NivelBateria}%");
        Console.WriteLine("------------------------------------------------");
    }
}
