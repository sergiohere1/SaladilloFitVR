///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: ButtonClick.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonClick : MonoBehaviour
{

	public GameObject clickObject;

	public void Click()
	{
		//Recibe un parámetro true o false para activar o no un gameobject
		clickObject.SetActive(!clickObject.activeSelf);
	}
}
