///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: CustomPointerTimer.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPointerTimer : MonoBehaviour
{
	/// <summary>
	/// Objeto compartido para todos los scripts.
	/// </summary>
	public static CustomPointerTimer CPT;
	/// <summary>
	/// Tiempo por defecto que vamos a tener que esperar para que el contador se rellene.
	/// </summary>
	private float timeToWait = 3f;
	/// <summary>
	/// Temporizador
	/// </summary>
	private float timer = 0f;
	/// <summary>
	/// Componente Image de la Imagen de relleno
	/// </summary>
	private Image image;
	
	[HideInInspector]
	public bool counting = false;
	[HideInInspector]
	public bool ended = false;
	
	// Use this for initialization (Awake se invoca antes que Start)
	void Awake () {
	    // Se comprueba si el objeto está inicializado
		if(CPT == null){
		    //Se obtiene el objeto temporizador
		    CPT = GetComponent<CustomPointerTimer>();
		}
		// Se obtiene la imagen del reloj
		image = GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (counting)
		{
			// Se incrementa el temporizador y la porción del tiempo que ha tardado en renderizar
			// el último update. De esta manera se tiene un control de tiempo real independientemente
			// de las características.
			timer += Time.deltaTime;
			// Se rellena la imagen en una cantidad proporcional al temporizador
			image.fillAmount = timer / timeToWait;
		}
		else
		{
			// Se reinicia el temporizador
			timer = 0f;
			// Se reinicia el relleno de la imagen
			image.fillAmount = timer;
		}
		// Se comprueba si se ha cumplido el tiempo de espera
		if (timer >= timeToWait)
		{
			// Se indica que el contador ha finalizado
			ended = true;
		}
	}

	/// <summary>
	/// Inicia el temporizador, utilizando el tiempo indicado como parámetro.
	/// </summary>
	/// <param name="time">Tiempo de espera</param>
	public void StartCounting(float time)
	{
		counting = true;
		ended = false;
		timeToWait = time;
	}

	/// <summary>
	/// Para el temporizador.
	/// </summary>
	public void StopCounting()
	{
		counting = false;
		ended = true;
		
	}
}
