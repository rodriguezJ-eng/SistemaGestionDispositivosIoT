/// <summary>
/// Clase abstracta base que representa cualquier dispositivo IoT del hogar.
/// Define una estructura común y el contrato (métodos abstractos) que todas las subclases deben cumplir
/// </summary>

public abstract class DispositivosIoT
{
    // atributos
    private string _id;
    private string _nombre;
    private bool _encendido;
    private int _nivelBateria;

    protected DispositivosIoT(string id, string nombre, bool encendido, int nivelBateria)
    {
        Id = id;
        Nombre = nombre;
        _encendido = false;
        NivelBateria = nivelBateria;
    }

    // propiedades
    public string Id
    {
        get => _id;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El ID del dispositivo no puede estar vacío.");
            _id = value;
        }
    }

    public string Nombre
    {
        get => _nombre;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del dispositivo no puede estar vacío.");
            _nombre = value;
        }
    }

    public bool Encendido
    {
        get => _encendido;
        protected set => _encendido = value;
    }

    public int NivelBateria
    {
        get => _nivelBateria;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException("El nivel de batería debe estar entre 0 y 100.");
            _nivelBateria = value;
        }
    }

    // Métodos
    public void Encender()
    {
        if (NivelBateria == 0)
        {
            Console.WriteLine($"[{Nombre}] No se puede encender: batería agotada");
            return;
        }
        Encendido = true;
        Console.WriteLine($"[{Nombre}] Dispositivo ENCENDIDO");
    }

    public void Apagar()
    {
        Encendido = false;
        Console.WriteLine($"[{Nombre}] Dispositivo APAGADO");
    }

    //TODO: Métodos abstractos
}