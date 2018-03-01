///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: ScrollDown.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GetComponent<Animator>().Play("Scrolldown");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
