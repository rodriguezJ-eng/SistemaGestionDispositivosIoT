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
            if (value < 0)
            {
                Console.WriteLine($"[ALERTA - {Nombre}]: Batería negativa ({value}%). Ajustando al mínimo: 0%.");
                _nivelBateria = 0;
            }
            else if (value > 100)
            {
                Console.WriteLine($"[ALERTA - {Nombre}]: Batería excede el límite ({value}%). Ajustando al máximo: 100%.");
                _nivelBateria = 100; 
            }
            else
            {
                _nivelBateria = value;
            }
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

    // aqui tenemos una configuración estándar general
    public void Configurar()
    {
        Console.WriteLine($"[{Nombre}] Aplicando configuración automática estándar.");
    }

    //tenemos un metodo sobrecargado, sobre la Configuración personalizada segun el área de la casa o logar
    //  donde se instale
    public virtual void Configurar(string ubicacion)
    {
    
        Console.WriteLine($"[{Nombre}] Registrado y optimizado para el área: {ubicacion}.");
    }
    
    // Nuestro metodo abstracto
    public abstract void ReportarEstado();
}