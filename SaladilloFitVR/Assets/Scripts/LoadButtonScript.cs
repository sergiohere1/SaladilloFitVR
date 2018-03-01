///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: LoadButtonScript.cs
///////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadButtonScript : MonoBehaviour
{
	/// <summary>
	/// Objeto donde se va a crear la información de los clientes.
	/// </summary>
	public GameObject information;
	/// <summary>
	/// Objeto que se crea para un cliente.
	/// </summary>
	public GameObject client;
	
	/// <summary>
	/// Método que se ejecuta cuando se pulsa el botón Load
	/// </summary>
	public void Click()
	{
		GetClientes();
	}
	
	/// <summary>
	/// Obtiene la lista de Clientes
	/// </summary>
	/// <remarks>Llama una corurutina que conecta con la WEB API</remarks>
	private void GetClientes()
	{
		StartCoroutine(GetClientsWebAPI());
	}
	
	
	IEnumerator GetClientsWebAPI()
	{
		using (UnityWebRequest www = UnityWebRequest.Get(Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENTS, GameManager.ipAdress))))
		{
			//Se hace la petición a la WebAPI
			yield return www.SendWebRequest();

			if (!www.isNetworkError)
			{
				ClientList clientList = JsonUtility.FromJson<ClientList>(www.downloadHandler.text);
				
				//Recorremos la lista de clientes
				for (int i = 0; i < clientList.clients.Length; i++)
				{
					//Se crea el objeto para un cliente
					GameObject clientItem = Instantiate(client);
					
					//Se asigna el textto que debe mostrar
					clientItem.GetComponentInChildren<Text>().text = clientList.clients[i].dni + " - " + clientList.clients[i].name;
					
					//Se estable quien es su padre
					clientItem.transform.SetParent(information.transform);
					
					//Se posiciona respecto al padre
					clientItem.GetComponent<RectTransform>().localPosition = new Vector3(0,-0.13f*(i+1) , 0);		
				}
			}
		}
	}
	
	
	#region Entidades
	/// <summary>
	/// 
	/// </summary>
	public class ClientList
	{
		/// <summary>
		/// El nombre del parametro que representa la lista tiene que coincidir con el nombre de la lista que te devuelve el servicio.
		/// </summary>
		public Client[] clients;
	}
	
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class Client
	{	
		/// <summary>
		/// DNI del cliente.
		/// </summary>
		public string dni;
		/// <summary>
		/// Nombre del cliente.
		/// </summary>
		public string name;
	}
	
	#endregion
}
