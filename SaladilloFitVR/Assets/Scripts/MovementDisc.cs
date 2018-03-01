///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: MovementDisk.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDisc : MonoBehaviour
{
	/// <summary>
	/// Velocidad máxima de desplazamiento
	/// </summary>
	public float maxSpeed = 0.5f;
	/// <summary>
	/// Fuerza de empuje
	/// </summary>
	public float pushForce = 10f;
	/// <summary>
	/// Para indicar si el usuario está mirando directamente el disco.
	/// </summary>
	[HideInInspector]
	public bool isHover = false;
	/// <summary>
	/// Rigidbody que queremos mover. El del player.
	/// </summary>
	public Rigidbody rigidbody;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (isHover)
		{
			if (rigidbody.velocity.magnitude < maxSpeed)
			{
				rigidbody.AddForce((GvrPointerInputModule.Pointer.CurrentRaycastResult.worldPosition - transform.position).normalized * pushForce);
			}
		}
	}

	/// <summary>
	/// Eventos a realizar para el evento de mirar al disco.
	/// </summary>
	public void StartLookingAtDisc()
	{
		isHover = true;
	}

	public void stopLookingAtDisc()
	{
		isHover = false;
	}
}
