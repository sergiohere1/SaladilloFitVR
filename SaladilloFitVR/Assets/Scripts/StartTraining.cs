///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: StartTraining.cs
///////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartTraining : MonoBehaviour {

	public void Click()
	{
		// En el caso de que algún entrenamiento haya sido especificado (Sea distinto de 0 en Gamemanager),
		// realizamos el log
		if (GameManager.training != 0)
		{
			makeClientLog();
		}

		
	}

	/// <summary>
	/// Método encargado de llamar a la Subrutina que realiza el log.
	/// <remarks>
	/// Realiza un Post en la Api respecto al log con el DNI y Entrenamiento elegido por el
	/// cliente, y una vez se ha realizado, inicia la actividad Machines.</remarks>
	/// </summary>
	private void makeClientLog()
	{
		StartCoroutine(ClientLog());
	}

 	IEnumerator ClientLog()
	{
		WWWForm form = new WWWForm();
		form.AddField("dni", GameManager.dniClient);
		form.AddField("training", GameManager.training);

		// Crea la petición a la Web API, en este caso de Post para realizar el Log y almacenarlo
		using (UnityWebRequest www = UnityWebRequest.Post(
			Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_TRAINING, GameManager.ipAdress)), form))
		{
			// Envía la petición a la Web API y espera para recibir una respuesta
			yield return www.SendWebRequest();

			// Acción a realizar si la petición se ha ejecutado sin error
			if (!www.isNetworkError)
			{
				// Cargamos la escena Machines
				SceneManager.LoadScene("Machines");
			}
		}
	}
}

