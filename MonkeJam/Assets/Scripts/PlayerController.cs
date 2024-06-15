using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	CharacterController controller;

	[Header("Controller Stats")]
	public float speed = 3.0F;
	public float basespeed = 3;
	public float rotateSpeed = 1.0F;
	bool moving = false;
	public float numberOfTea;
	public GameObject firingPoint;
	public GameObject teaBox;
	


	void Update ()
	{
		#region CharacterController
		CharacterController controller = GetComponent<CharacterController> ();
		rotateSpeed = 0.25f / speed;

		transform.Rotate (0,Input.GetAxis ("Horizontal") * rotateSpeed,0);

		
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		float curSpeed = speed * Input.GetAxis ("Vertical");
		controller.SimpleMove (forward * curSpeed);

		if(Input.GetKey(KeyCode.W) && speed < 15)
		{
			speed += 0.7f * Time.deltaTime;
			moving = true;	
		}

		if(Input.GetKeyUp (KeyCode.W))
		{
			moving = false;
		}

		if(Input.GetKeyDown (KeyCode.Mouse0) && numberOfTea > 0)
		{
			Instantiate (teaBox,firingPoint.transform.position,firingPoint.transform.rotation);
			numberOfTea--;
		}

		if(!moving && speed > basespeed)
		{
			speed -= Time.deltaTime;
		}

		
		#endregion

		
	}

	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.tag == "Tea")
		{
			numberOfTea++;
		}
	}
}
