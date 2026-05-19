
Console.WriteLine("--- DISPOSITIVOS IoT ---");

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

