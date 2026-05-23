Separador("CREACIÓN DE DISPOSITIVOS");

var luz = new LuzInteligente("LUZ-001", "Luz Sala Principal", nivelBateria: 90, intensidadInicial: 70);
var termostato = new Termostato("TERM-001", "Termostato Dormitorio", nivelBateria: 85, temperaturaInicial: 22.0);
var cerradura = new CerraduraDigital("CERR-001", "Cerradura Puerta Principal", nivelBateria: 100, tipoCierre: "Magnético", intentosIniciales: 0);
var camara = new CamaraSeguridad("CAM-001", "Cámara Jardín", nivelBateria: 75, resolucion: 12);
var camara360 = new CamaraSeguridad360("CAM-002", "Cámara Entrada 360°", nivelBateria: 80, resolucion: 8, anguloVision: 360);

Console.WriteLine("Dispositivos creados exitosamente:");
Console.WriteLine($"  - {luz.Nombre}");
Console.WriteLine($"  - {termostato.Nombre}");
Console.WriteLine($"  - {cerradura.Nombre}");
Console.WriteLine($"  - {camara.Nombre}");
Console.WriteLine($"  - {camara360.Nombre}");

// ENCENDIDO DE DISPOSITIVOS
Separador("ENCENDIDO");

luz.Encender();
termostato.Encender();
cerradura.Encender();
camara.Encender();
camara360.Encender();
Console.WriteLine();

// POLIMORFISMO (Demuestre polimorfismo utilizando una colección de objetos del tipo base).
Separador("POLIMORFISMO — ReportarEstado()");

// Cada objeto en la lista es de tipo base de DispositivosIoT, (Demuestre polimorfismo utilizando una colección de objetos del tipo base).
// pero al llamar ReportarEstado() cada uno ejecuta SU propia versión.
List<DispositivosIoT> dispositivos = new List<DispositivosIoT>
{
    luz, termostato, cerradura, camara, camara360
};

foreach (var dispositivo in dispositivos)
{
    dispositivo.ReportarEstado(); // polimorfismo
}
Console.WriteLine();

// SOBRECARGA DE MÉTODOS — Configurar()
Separador("SOBRECARGA en Configurar() sin parámetros, con string y con int");

Console.WriteLine(" Configuración estándar (sin parámetros):");
foreach (var dispositivo in dispositivos)
{
    dispositivo.Configurar(); // Configurar() base — sobrecarga 1
}

// Sobrecarga 2: con string 
Console.WriteLine("\nConfiguración con string:");
luz.Configurar("Sala de estar");            // LuzInteligente - ubicación
termostato.Configurar("Enfriamiento");      // Termostato - modo
cerradura.Configurar("Electromagnético");   // CerraduraDigital - tipo de cierre
camara.Configurar("grabar");            // inicia grabación 
camara360.Configurar("detener");        // detiene grabación 

// Sobrecarga 3: con int
Console.WriteLine("\nConfiguración con int:");
luz.Configurar(85);         // LuzInteligente - intensidad
termostato.Configurar(24);  // Termostato - temperatura
camara.Configurar(16);      // CamaraSeguridad - resolución (sealed)
camara360.Configurar(8);    // hereda el sealed, misma lógica
Console.WriteLine();

// DEMOSTRACIÓN DEL sealed EN MÉTODO
Separador("sealed EN MÉTODO — CamaraSeguridad y CamaraSeguridad360");

Console.WriteLine("CamaraSeguridad360 puede sobreescribir ReportarEstado():");
camara360.ReportarEstado();

Console.WriteLine("Pero NO puede sobreescribir Configurar()  ver comentario en CamaraSeguridad360.cs");
// El intento comentado está dentro del archivo CamaraSeguridad360.cs
Console.WriteLine();


// VALIDACIONES
Separador("VALIDACIONES");

Console.WriteLine("Batería fuera de rango (negativa):");
luz.NivelBateria = -10; // ajusta a 0 automáticamente

Console.WriteLine("\nIntensidad fuera de rango (> 100):");
luz.Intensidad = 150; // ajusta a 100 automáticamente

Console.WriteLine("\nTemperatura fuera de rango (> 32°C):");
termostato.Configurar(40); // ajusta a 32°C automáticamente

Console.WriteLine("\nTipoCierre vacío:");
try { cerradura.Configurar(""); }
catch (ArgumentException ex) { Console.WriteLine($"Excepción capturada: {ex.Message}"); }

Console.WriteLine("\nResolución inválida (> 64MP):");
try { camara.Resolucion = 100; }
catch (ArgumentOutOfRangeException ex) { Console.WriteLine($"Excepción capturada: {ex.ParamName}"); }


// GRABACIÓN — CamaraSeguridad
Separador("GRABACIÓN DE CÁMARAS");

camara.Grabando = true;
camara360.Grabando = true;

Console.WriteLine("\nEstado de cámaras grabando:");
camara.ReportarEstado();
camara360.ReportarEstado();

camara.Grabando = false;
camara360.Grabando = false;


// APAGADO DEL SISTEMA
Separador("APAGADO DEL SISTEMA");

foreach (var dispositivo in dispositivos)
{
    dispositivo.Apagar();
}


// Método para separar visualmente las impresiones en consola 
static void Separador(string titulo)
{
    Console.WriteLine();
    Console.WriteLine(new string('=', 55));
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"  {titulo}");
    Console.ResetColor();
    Console.WriteLine(new string('=', 55));
}

