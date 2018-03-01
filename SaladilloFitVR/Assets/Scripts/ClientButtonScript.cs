///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: ClientButtonScript.cs
///////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientButtonScript : MonoBehaviour {

	/// <summary>
	/// Método para el click de nuestro ClientButton
	/// </summary>
	public void Click()
	{
		logClient();
	}

	/// <summary>
	/// Llama a una corrutina que conecta con la WEBAPI para guardar la información del cliente
	/// </summary>
	private void logClient()
	{
		StartCoroutine(LogClientWebApi());
	}

	
	private IEnumerator LogClientWebApi()
	{
		//Construimos la información que se envía a la WEBAPI
		WWWForm form = new WWWForm();
		form.AddField("dni", GetComponentInChildren<Text>().text.Split('-')[0].Trim());
		form.AddField("name", GetComponentInChildren<Text>().text.Split('-')[1].Trim());
		
		// Crea la petición a la Web API
		using (UnityWebRequest www = UnityWebRequest.Post(
			(string.Format(GameManager.WEB_API_LOG_CLIENT, GameManager.ipAdress)), form))
		{
			yield return www.SendWebRequest();

			if (!www.isNetworkError)
			{
				GetComponentInParent<AudioSource>().Play();
			}
		}
	}
}
