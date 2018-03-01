///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
    // Fichero: SpeedScript.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour {
    // Material de la esfera cuando no está siendo mirada
    public Material sphereMaterial;
    //Material de la esfera cuando está siendo mirada
    public Material sphereHoverMaterial;
    
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material = sphereMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Método que se ejecuta cuando se empieza a mirar la esfera
	public void HoveredSphere(){
	    GetComponent<Renderer>().material = sphereHoverMaterial;
	}
	
	// Método que se ejecuta cuando se deja de mirar la esfera
	public void NotHoveredSphere(){
		GetComponent<Renderer>().material = sphereMaterial;
	}
}
