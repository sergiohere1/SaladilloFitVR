///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: ButtonGazeClick.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGazeCick : MonoBehaviour
{
	/// <summary>
	/// Tiempo que tardará en activarse el temporizador.
	/// </summary>
	public float activationTime = 3f;

	/// <summary>
	/// Indica si el puntero está sobre el objeto.
	/// </summary>
	private bool isHover = false;
	/// <summary>
	/// Indica si la acción se ha realizado.
	/// </summary>
	private bool executed = false;
	
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Si el usuario está mirando el objeto y el temporizador
		// ha terinado de contar o si le usuario está mirando el
		// objeto y pulsa el botón Fire1 del mando y la acción aún
		// no se ha ejecutado, realizaremos la acción correspondiente
		if ((isHover && CustomPointerTimer.CPT.ended && !executed) ||
		    (isHover && Input.GetButtonDown("Fire1") && executed))
		{
			// Se indica que ya se ha realizado la acción
			executed = true;
			//Desactivamos el contador de tiempo del cursor, para
			// evitar que se quede bloqueado
			CustomPointerTimer.CPT.StopCounting();
			// Se invoca al click del botón.
			GetComponent<Button>().onClick.Invoke();
		}
	}
	
	/// <summary>
	/// Método que se llamará desde el EventTrigger PointerEnter (Cuando miremos el objeto que cambia de color)
	/// </summary>
	public void StartHover()
	{
		// Indicamos que el objeto está siendo mirado direcamente
		isHover = true;
		// Marcamos la acción como no realizada
		executed = false;
		// Iniciamos el contador del puntero, indicándole el tiempo de activación
		CustomPointerTimer.CPT.StartCounting(activationTime);
	}
	
	/// <summary>
	/// Método que llamaremos desde el EventTrigger PointerExit
	/// </summary>
	public void EndHover()
	{
		// Indicamos que el objeot ya NO está siendo mirado
		isHover = false;
		// Reiniciamos el contador del puntero
		CustomPointerTimer.CPT.StopCounting();
	}
}
