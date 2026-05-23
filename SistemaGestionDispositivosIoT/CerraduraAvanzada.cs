// INTENTO COMENTADO DE HEREDAR DE UNA CLASE SELLADA
/*
public class CerraduraAvanzada : CerraduraDigital
{
    public CerraduraAvanzada(string id, string nombre, int bateria, string tipo)
        : base(id, nombre, bateria, tipo, 0) { }
}
*/

/*
 * El compilador rechaza esto: 'CerraduraAvanzada' no puede derivar del
 * tipo sellado 'CerraduraDigital)' 
 * 
 * 
 */

/*
 * Se sella la clase CerraduraDigital por seguridad muy Crítica
 * una cerradura digital controla el acceso físico a el hogar, 
 * entonces su comportamiento debe ser inmutable
 * 
 * Si se permitiera heredar esta clase, alguien podría intentar crear 
 * una subclase maliciosa 
 * sobreescribir  ReportarEstado(), mintiendo sobre su estado cerrada o abierta
 * El diseño tiene como fin la extensión de forma intencional: 
 */