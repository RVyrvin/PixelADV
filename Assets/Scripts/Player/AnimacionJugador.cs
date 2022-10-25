using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class AnimacionJugador : MonoBehaviour
{
	private GameObject player;

	private Animator animacion;
	private Rigidbody2D fisicas;


	public enum AnimationOptions
	{
		IDLE,
		RUN,
		JUMP
	};
	
	
    // Start is called before the first frame update
    void Start()
    {
		animacion = gameObject.GetComponentInChildren<Animator>();
		fisicas = gameObject.GetComponent<Rigidbody2D>();
	}


	void Update()
    {
		animacion.SetFloat("VelocidadX", Math.Abs(fisicas.velocity.x));
		animacion.SetFloat("VelocidadY", Math.Abs(fisicas.velocity.y));
	}
}
