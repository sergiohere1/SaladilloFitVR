///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: ButtonDeleteConsoleScript.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDeleteConsoleScript : MonoBehaviour {
	
	public string text;
	public Text ipAdress;

	// Use this for initialization
	void Start () {
		GetComponentInChildren<Text>().text = text;
	}

	public void Click()
	{
		ipAdress.text = ipAdress.text.Substring(0, ipAdress.text.Length-1);
	}
}
