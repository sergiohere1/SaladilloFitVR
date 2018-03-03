///////////////////////////////////////////
// Práctica: SaladilloFitVR
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
    /// Variable para almacenar la IP de la Web API
    /// </summary>
    public static string ipAdress;
    /// <summary>
    /// Variable para almacenar el DNI del cliente. No se guarda como constante en PlayerPrefs por privacidad, sólo como
    /// variable estática del GameManager.
    /// </summary>
    public static string dniClient;
    /// <summary>
    /// Constante con el nombre del cliente que hayamos obtenido
    /// </summary>
    public static string nameClient;
    /// <summary>
    /// Entero que hará referencia al entrenamiento que haya seleccionado nuestro usuario
    /// </summary>
    public static int training;
    /// <summary>
    /// Constante con la URL del método de la WEB API para comprobar la conectividad.
    /// </summary>
    public const string WEB_API_CHECK_CONNECTIVITY =
        "http://{0}/SaladilloFitVR/api/SaladilloFitVR/CheckConnectivity";
    /// <summary>
    /// Constante con la URL del método de la WEB API para obtener clientes.
    /// </summary>
    public const string WEB_API_GET_CLIENT_NAME = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetClientName?dni={1}";
    /// <summary>
    /// Constante con la URL del método de la WEB API para obtener los entrenamientos en función al número
    /// </summary>
    public const string WEB_API_GET_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetTraining?training={1}";
    /// <summary>
    /// Constante con la URL del método de la WEB API que guarda los clientes
    /// </summary>
    public const string WEB_API_LOG_TRAINING= "http://{0}/SaladilloFitVR/api/SaladilloFitVR/LogTraining";



}
