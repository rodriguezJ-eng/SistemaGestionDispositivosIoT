
/*Console.WriteLine("--- DISPOSITIVOS IoT ---");

DispositivosIoT[] misDispositivos = new DispositivosIoT[3];

//  Inicialización de objetos
misDispositivos[0] = new Termostato("T-01", "Termostato Inteligente", false, 70, 25.3);
misDispositivos[1] = new LuzInteligente("L-02", "Luces de casa", true, 30, 55);
misDispositivos[2] = new CerraduraDigital("C-03", "Cerradura Principal", true, 37, "Huella Dactilar", 4);

string[] ubicaciones = { "Sala Principal", "Área Exterior", "Puerta de Entrada" };

// Demostración con las sobrecargas
for (int i = 0; i < misDispositivos.Length; i++)
{
    misDispositivos[i].Configurar();             // la que no tiene parametro
    misDispositivos[i].Configurar(ubicaciones[i]); //la que tiene parametro string
}

Console.WriteLine("\n--- REPORTES DE ESTADO0 ---");


for (int i = 0; i < misDispositivos.Length; i++)
{
    misDispositivos[i].ReportarEstado();
}
*/

// 
// CREACIÓN DE DISPOSITIVOS
// 

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

// 
// ENCENDIDO DE DISPOSITIVOS
// 
Separador("ENCENDIDO");

luz.Encender();
termostato.Encender();
cerradura.Encender();
camara.Encender();
camara360.Encender();

//
// POLIMORFISMO — colección de tipo base
// 
Separador("POLIMORFISMO — ReportarEstado()");

// Cada objeto en la lista es de tipo base DispositivosIoT,
// pero al llamar ReportarEstado() cada uno ejecuta SU propia versión.
List<DispositivosIoT> dispositivos = new List<DispositivosIoT>
{
    luz, termostato, cerradura, camara, camara360
};

foreach (var dispositivo in dispositivos)
{
    dispositivo.ReportarEstado(); // polimorfismo
}

// 
// SOBRECARGA DE MÉTODOS — Configurar()
// 
Separador("SOBRECARGA — Configurar() sin parámetros vs con string");

Console.WriteLine(">> Configuración estándar (sin parámetros):");
foreach (var dispositivo in dispositivos)
{
    dispositivo.Configurar(); // Configurar() base — sobrecarga 1
}

Console.WriteLine("\n>> Configuración por ubicación (con string):");
luz.Configurar("Sala de estar");           // override LuzInteligente
termostato.Configurar("22.5");             // override Termostato -> temperatura
cerradura.Configurar("Electromagnético");  // override CerraduraDigital -> tipo cierre
camara.Configurar("Jardín trasero");       // sealed override CamaraSeguridad
camara360.Configurar("Entrada principal"); // hereda el sealed, misma lógica

// 
// DEMOSTRACIÓN DEL sealed EN MÉTODO
// 
Separador("sealed EN MÉTODO — CamaraSeguridad vs CamaraSeguridad360");

Console.WriteLine("CamaraSeguridad360 puede sobreescribir ReportarEstado():");
camara360.ReportarEstado();

Console.WriteLine("Pero NO puede sobreescribir Configurar() — ver comentario en CamaraSeguridad.cs");
// El intento comentado está dentro del archivo CamaraSeguridad.cs

// 
// VALIDACIONES
// 
Separador("VALIDACIONES");

Console.WriteLine("Batería fuera de rango (negativa):");
luz.NivelBateria = -10; // ajusta a 0 automáticamente

Console.WriteLine("\nIntensidad fuera de rango (> 100):");
luz.Intensidad = 150; // ajusta a 100 automáticamente

Console.WriteLine("\nTemperatura fuera de rango (> 32°C):");
termostato.Configurar("40"); // ajusta a 32°C automáticamente

Console.WriteLine("\nTipoCierre vacío:");
try { cerradura.Configurar(""); }
catch (ArgumentException ex) { Console.WriteLine($"Excepción capturada: {ex.Message}"); }

Console.WriteLine("\nResolución inválida (> 64MP):");
try { camara.Resolucion = 100; }
catch (ArgumentOutOfRangeException ex) { Console.WriteLine($"Excepción capturada: {ex.ParamName}"); }

// 
// GRABACIÓN — CamaraSeguridad
// 
Separador("GRABACIÓN DE CÁMARAS");

camara.Grabando = true;
camara360.Grabando = true;

Console.WriteLine("\nEstado de cámaras grabando:");
camara.ReportarEstado();
camara360.ReportarEstado();

camara.Grabando = false;
camara360.Grabando = false;

// 
// APAGADO DEL SISTEMA
// 
Separador("APAGADO DEL SISTEMA");

foreach (var dispositivo in dispositivos)
{
    dispositivo.Apagar();
}


//  Utilidad visual 
static void Separador(string titulo)
{
    Console.WriteLine();
    Console.WriteLine(new string('=', 55));
    Console.WriteLine($"  {titulo}");
    Console.WriteLine(new string('=', 55));
}

