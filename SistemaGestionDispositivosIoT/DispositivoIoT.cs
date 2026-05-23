/// <summary>
/// Clase abstracta base que representa cualquier dispositivo IoT del hogar.
/// Define una estructura común y el contrato (métodos abstractos) que todas las subclases deben cumplir
/// </summary>

public abstract class DispositivosIoT
{
    private string _id;
    private string _nombre;
    private bool _encendido;
    private int _nivelBateria;

    protected DispositivosIoT(string id, string nombre, int nivelBateria)
    {
        Id = id;
        Nombre = nombre;
        _encendido = false;
        NivelBateria = nivelBateria;
    }

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

    /// <summary>
    /// Sobrecarga 1: configuración estándar automática sin parámetros.
    /// Es para establecer ajustes por defecto en cualquier dispositivo
    /// </summary>
    public void Configurar()
    {
        Console.WriteLine($"[{Nombre}] Aplicando configuración automática estándar.");
    }

    /// <summary>
    /// Sobrecarga 2: Configuración con valor de texto.
    /// Cada Clase hija lo interpreta según su contexto: 
    /// - Ubicación
    /// - Modo de operar
    /// - Tipo (ejemplo: tipo de cierre)
    /// Creando su propia lógica sin romper el contrato de la clase base
    /// </summary>
    /// <param name="ubicacion"></param>
    public virtual void Configurar(string valor)
    {
    
        Console.WriteLine($"[{Nombre}] Configurado con valor: {valor}.");
    }

    /// <summary>
    /// Sobrecarga 3: Configuración con valor numérico (int)
    /// Cada clase hija lo interpreta según su contexto:
    /// - nivel de intesidad de luz
    /// - nivel de temperatura
    /// - resolución de camara
    /// </summary>
    public virtual void Configurar(int valor)
    {
        Console.WriteLine($"[{Nombre}] Configurado con valor numérico: {valor}.");
    }

    /// <summary>
    /// Reporta el estado del dispositivo en consola
    /// </summary>
    public abstract void ReportarEstado();
}