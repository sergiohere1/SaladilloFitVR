///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: SetButtonText.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonText : MonoBehaviour
{

	public string text;
	public Text ipAdress;

	// Use this for initialization
	void Start ()
	{
		GetComponentInChildren<Text>().text = text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click()
	{
		ipAdress.text += text;
	}
}
