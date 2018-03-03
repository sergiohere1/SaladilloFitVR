///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: SaveDNI.cs
///////////////////////////////////////////
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SaveDNI : MonoBehaviour
{
	/// <summary>
	/// Texto de Bienvenida que ve el usuario nada más abrir la aplicación
	/// </summary>
	public Text welcomeText;
	/// <summary>
	/// Texto de DNI en el que escribe el usuario
	/// </summary>
	public Text dniText;
	/// <summary>
	/// Panel de entrenamientos que se activa una vez el DNI introducido es válido.
	/// </summary>
	public GameObject trainingItem;
	/// <summary>
	/// Gameobject que hace referencia al detailPanel, para destruir su contenido en caso de que el usuario
	/// cambie de DNI o introduzca uno inválido
	/// </summary>
	private GameObject detailPanel;
	

	/// <summary>
	/// Método que se ejecutará una vez hagamos click en guardar
	/// <remarks>
	/// Lo que se realizará tras el click será almacenar el valor del DNI escrito en el GameManager para posteriormente
	/// realizar una petición a la WebAPI para obtener el nombre del cliente al que le corresponda dicho DNI
	/// </remarks>
	/// </summary>
	public void Click()
	{
		GameManager.dniClient = dniText.text;
		GetClientName();
		// Destruimos el contenido del Detail Panel y desactivamos el DetailPanel
		foreach (Transform child in detailPanel.transform)
		{
			Destroy(child.gameObject);
		}
		detailPanel.SetActive(false);
		
	}
	
	/// <summary>
	/// Método que realiza la petición a la WebAPI para obtener el nombre del cliente
	/// </summary>
	private void GetClientName()
	{
		StartCoroutine(GetClientWebAPI());
	}

	IEnumerator GetClientWebAPI()
	{
		// Creamos la petición para la WEB API
		using (UnityWebRequest www = UnityWebRequest.Get(
			Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENT_NAME, GameManager.ipAdress,
				GameManager.dniClient))))
		{
			yield return www.SendWebRequest();

			if (!www.isNetworkError)
			{
				//Como el nombre que obtenemos nos viene entre comillas, las eliminamos.
				GameManager.nameClient = www.downloadHandler.text.Replace("\""," ").Trim();
				print("Nombre : "+GameManager.nameClient);
				if (!string.IsNullOrEmpty(GameManager.nameClient))
				{
					dniText.text = GameManager.nameClient;
					welcomeText.text = string.Format("Hola {0}", GameManager.nameClient);
					trainingItem.SetActive(true);

				}
				else
				{
					welcomeText.text = "Bienvenid@ a Saladillo FIT VR";
					trainingItem.SetActive(false);
					
				}
			}
		}
	}	
}
