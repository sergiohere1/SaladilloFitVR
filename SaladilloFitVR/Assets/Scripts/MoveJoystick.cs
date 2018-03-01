///////////////////////////////////////////
// Práctica: SaladilloVR
// Alumno/a: Sergio García-Consuegra Berná
// Curso: 2017/2018
// Fichero: MoveJoystick.cs
///////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoystick : MonoBehaviour {
	/// <summary>
	/// Velocidad máxima de desplazamiento
	/// </summary>
	public float maxSpeed = 0.5f;
	/// <summary>
	/// Fuerza de empuje
	/// </summary>
	public float pushForce = 10f;
	/// <summary>
	/// Rigidbody que queremos mover. El del player.
	/// </summary>
	public Rigidbody rigidbody;
	
	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		// Recuperamos el valor de los ejes horizontal y vertical. Son valores normalizados que van de 0 a 1.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		// Calculamos el vector de movimiento con la dirección a la que mira la cámara
		Vector3 moveDirection = (h * Camera.main.transform.right + v * Camera.main.transform.forward).normalized;

		if (rigidbody.velocity.magnitude < maxSpeed)
		{
			rigidbody.AddForce(moveDirection * pushForce);
		}
	}
}
