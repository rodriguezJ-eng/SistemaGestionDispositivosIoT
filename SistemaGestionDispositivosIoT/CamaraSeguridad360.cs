/// <summary>
/// Subclase de CamaraSeguridad que agrega visión 360°.
/// Existe para demostrar el efecto real del sealed en Configurar():
/// puede sobreescribir ReportarEstado() pero NO puede tocar Configurar().
/// </summary>
public class CamaraSeguridad360 : CamaraSeguridad
{
    // Atributo propio 
    private int _anguloVision; // en grados, máx 360

    //  Constructor 
    public CamaraSeguridad360(string id, string nombre, int nivelBateria, int resolucion, int anguloVision)
        : base(id, nombre, nivelBateria, resolucion)
    {
        AnguloVision = anguloVision;
    }

    // Propiedad con validación 
    public int AnguloVision
    {
        get => _anguloVision;
        set
        {
            if (value < 1 || value > 360)
                throw new ArgumentOutOfRangeException("El ángulo de visión debe estar entre 1 y 360 grados.");
            _anguloVision = value;
        }
    }

    //  Sobreescritura de ReportarEstado() 
    // Esto SÍ está permitido: ReportarEstado() no fue sellado en CamaraSeguridad
    public override void ReportarEstado()
    {
        base.ReportarEstado(); // muestra el reporte base
        Console.WriteLine($" [360°]: Ángulo de visión activo: {AnguloVision}°");
        Console.WriteLine("------------------------------------------------");
    }

    // INTENTO COMENTADO DE SOBREESCRIBIR UN MÉTODO SELLADO 
    /*
    public override void Configurar(string ubicacion)  //  Error CS0239
    {
        Console.WriteLine("Intento de sobreescribir Configurar en 360...");
    }
    */
    // El compilador rechaza esto:
    // "No se puede invalidar el miembro heredado 'CamaraSeguridad.Configurar(string)' porque está sellado"
}
