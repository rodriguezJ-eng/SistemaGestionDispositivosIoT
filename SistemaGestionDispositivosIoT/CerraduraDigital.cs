
    // Se sella la clase por seguridad crítica,
    // impidiendo herencia para evitar alteraciones en el control de acceso.
public sealed class CerraduraDigital : DispositivosIoT
{
    private string _tipoCierre;
    private int _intentosFallidos;

    public CerraduraDigital(string id, string nombre, int nivelBateria, string tipoCierre, int intentosIniciales)
            : base(id, nombre, nivelBateria)
    {
        TipoCierre = tipoCierre;
        IntentosFallidos = intentosIniciales; 
    }

    public string TipoCierre
    {
        get => _tipoCierre;
        set // (NUEVO: IMPLEMENTE UNA VALIDACIÓN)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("El tipo de cierre no puede estar vacío");
            _tipoCierre = value;
        }
    }
    public int IntentosFallidos
    {
        get => _intentosFallidos;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("El número de intentos fallidos no puede ser menor a cero.");
            _intentosFallidos = value;
        }
    }

    // implementación del método Configuración (NUEVO)
    public override void Configurar(string parametro)
    {
        TipoCierre = parametro;
        Console.WriteLine($"[{Nombre}]: Tipo de cierre actualizado a '{TipoCierre}'.");
    }


    public override void ReportarEstado()
    {
        string mensajeEstado = Encendido ? "ENCENDIDO y con cerrojo asegurado" : "APAGADO (Sistema inactivo)";

        Console.WriteLine($"[CERRADURA]: {Nombre}");
        Console.WriteLine($"Estado:  {mensajeEstado}");
        Console.WriteLine($"Tipo de Cierre: {TipoCierre}");
        Console.WriteLine($"Intentos Fallidos: {IntentosFallidos}");
        Console.WriteLine($"Batería:  {NivelBateria}%");
        Console.WriteLine("------------------------------------------------");
    }
}

    /* ── INTENTO COMENTADO DE HEREDAR UNA CLASE SELLADA ──────────────────────────
    //
    // public class CerraduraAvanzada : CerraduraDigital   // ❌ Error CS0509
    // {
    //     public CerraduraAvanzada(string id, string nombre, int bateria, string tipo)
    //         : base(id, nombre, bateria, tipo, 0) { }
    // }
    //
    // El compilador rechaza esto:
    // "cannot derive from sealed type 'CerraduraDigital'"
    //
    // SOLUCIÓN CORRECTA: usar composición (patrón Adapter).
    // Crear una clase que contenga internamente una CerraduraDigital
    // como campo, sin heredarla, preservando su lógica de seguridad intacta.
    // ────────────────────────────────────────────────────────────────────────────
}*/
