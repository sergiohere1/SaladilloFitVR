///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: ConfigurationScript.cs
///////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class ConfigurationScript : MonoBehaviour
{
	/// <summary>
	/// Objeto que indica que se ha establecido conexión.
	/// </summary>
	public GameObject connected;
	/// <summary>
	/// Objeto que indica que no se ha establecido conexión.
	/// </summary>
	public GameObject disconnected;
	
	// Use this for initialization
	void Start ()
	{
		// Se recupera el valor de dirección IP almacenado en la configuración de la aplicación
		GameManager.ipAdress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);

		GetComponent<Text>().text = GameManager.ipAdress;
		// Se comprueba la conectividad con la WEB API
		CheckConnectivity();
	}

	/// <summary>
	/// Comprueba si existe conexión con la WEB API
	/// </summary>
	/// <remarks>
	/// Llama a la corrutina CheckConnectivityWEBAPI para comprobar la conexión
	/// </remarks>
	private void CheckConnectivity()
	{
		StartCoroutine(CheckConnectivityWebAPI());
	}

	IEnumerator CheckConnectivityWebAPI()
	{
		// Prepara la petición a la webApi
		using (UnityWebRequest www = UnityWebRequest.Get(
			Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONNECTIVITY, GameManager.ipAdress))))
		{
			//Se hace la petición a la WebAPI
			yield return www.SendWebRequest();
			
			// Coprueba el valor devuelto por el método. Si la respuesta es correcta, activa el objeto que
			// indica que se ha establecido conexión, y activa el objeto que indica que está desconectado
			// en caso contrario.
			connected.SetActive(www.responseCode == 200);
			disconnected.SetActive(!connected.activeSelf);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
