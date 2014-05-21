using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour 
{
	public float moveForce = 3.0f;
	public float maxVelocity = 6.0f;
	public float rotateSpeed = 90.0f;

	void Start () {}

	void Update () 
	{
		if(Input.GetAxisRaw("Vertical") > 0 && rigidbody.velocity.magnitude < maxVelocity)
		   rigidbody.AddForce(transform.forward * moveForce, ForceMode.Impulse);
		if(Input.GetAxisRaw("Vertical") < 0 && rigidbody.velocity.magnitude < maxVelocity)
			rigidbody.AddForce(-transform.forward * moveForce, ForceMode.Impulse);
		if(Input.GetAxisRaw("Horizontal") > 0)
			transform.Rotate(transform.up*rotateSpeed*Time.deltaTime);
		if(Input.GetAxisRaw("Horizontal") < 0)
			transform.Rotate( transform.up*-rotateSpeed*Time.deltaTime);
	}
}
