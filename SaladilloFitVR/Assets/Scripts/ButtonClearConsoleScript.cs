///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: ButtonClearScript.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonClearConsoleScript : MonoBehaviour {
	
	public string text;
	public Text ipAdress;


	private void Start()
	{
		// Le cambiamos el texto al botón por el que establezcamos en el Editor de Unity
		GetComponentInChildren<Text>().text = text;
	}

	public void Click()
	{
		ipAdress.text = "";
	}
}
