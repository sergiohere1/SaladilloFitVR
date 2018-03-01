///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: GameManager.cs
///////////////////////////////////////////

public static class GameManager
{
    /// <summary>
    /// Clave para la dirección IP
    /// </summary>
    public const string IP_ADDRESS = "IP_ADDRESS";
    /// <summary>
    /// Variable para amacenar la IP de la Web API
    /// </summary>
    public static string ipAdress;
    /// <summary>
    /// Constante con la URL del método de la WEB API para comprobar la conectividad.
    /// </summary>
    public const string WEB_API_CHECK_CONNECTIVITY =
        "http://{0}/SaladilloFitVR/api/SaladilloFitVR/CheckConnectivity";
    /// <summary>
    /// Constante con la URL del método de la WEB API para obtener clientes.
    /// </summary>
    public const string WEB_API_GET_CLIENTS = "http://{0}/SaladilloVR/api/SaladilloVR/GetClients";
    /// <summary>
    /// Constante con la URL del método de la WEB API que guarda los clientes
    /// </summary>
    public const string WEB_API_LOG_CLIENT= "http://{0}/SaladilloVR/api/SaladilloVR/LogClient";



}
