///////////////////////////////////////////
// Práctica: SaladilloFitVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: TrainingButton.cs
///////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrainingButtonScript : MonoBehaviour
{
	/// <summary>
	/// Entero relacionado con el entrenamiento que elegirá el cliente
	/// </summary>
	public int training = 0;
	/// <summary>
	/// Panel de Detalle con información del contenido del entrenamiento elegido por el cliente
	/// </summary>
	public GameObject detailPanel;
	/// <summary>
	/// Objeto trainingItem que contiene un hijo que es un Text
	/// </summary>
	public GameObject trainingItem;
	
	/// <summary>
	/// Método a realizar con el Click en el botón de Entrenamiento
	/// <remarks>
	/// Realiza una petición a la Web API para obtener el contenido de un determinado entrenamiento en
	/// función al índice que haya elegido el Cliente (1, 2 o 3)
	/// </remarks>
	/// </summary>
	public void Click()
	{
		GetDetailTrainings();
		GameManager.training = training;
	}

	private void GetDetailTrainings()
	{
		detailPanel.SetActive(true);
		StartCoroutine(GetTrainingWebApi());
	}

	IEnumerator GetTrainingWebApi()
	{
		using (UnityWebRequest www = UnityWebRequest.Get(
			Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_TRAINING, GameManager.ipAdress,
				training))))
		{
			
			// Envia la petición a la web api y espera la respuesta
			yield return www.SendWebRequest();
			
			if (!www.isNetworkError)
			{
				
				TrainingsList trainingItems = JsonUtility.FromJson<TrainingsList>(www.downloadHandler.text);
				
				foreach (Transform child in detailPanel.transform)
				{
					Destroy(child.gameObject);
				}

				GameObject trainingItemName = Instantiate(trainingItem);
				trainingItemName.GetComponentInChildren<Text>().text = "Entrenamiento " + training;

				// Se establece su padre que esta en la escena
				trainingItemName.transform.SetParent(detailPanel.transform);
				
				// Se posición en la escena
				trainingItemName.GetComponent<RectTransform>().localPosition = new Vector3(15.4f, 47.3f, -8.9f);
				trainingItemName.GetComponent<RectTransform>().localRotation = this.gameObject.GetComponent<RectTransform>().rotation;
				trainingItemName.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
				
				// Se recorre la lista de entrenamientos
				for (int i = 0; i < 3; i++)
				{
					// Se instancia el objeto
					GameObject trainItem = Instantiate(trainingItem);
					
					trainItem.GetComponentInChildren<Text>().text = trainingItems.training[i].machine;

					// Se establece su padre que esta en la escena
					trainItem.transform.SetParent(detailPanel.transform);
					// Se posición en la escena
					trainItem.GetComponent<RectTransform>().localRotation = this.gameObject.GetComponent<RectTransform>().rotation;
					trainItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
					trainItem.GetComponent<RectTransform>().localPosition = new Vector3(15.4f, (-i * 20), 2.2f);
				}
			}
			
		}
	}
	
	#region Entidades 
	
	public class TrainingsList
	{
		public TrainingItem[] training;
	}
	
	
	[Serializable]
	public class TrainingItem
	{
		
		// Identificador correspondiente al entrenamiento
		public int training;

		// Nombre de la máquina
		public string machine;
		
	}
	#endregion

	
}
