using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour 
{
	public float speed = 3;
	// Use this for initialization
	void Start () 
	{
		if(Network.isServer)
		{
			this.enabled = false; 
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(true)//Network.isClient)
		{
			float xDir = Input.GetAxis("Horizontal");
			float yDir = Input.GetAxis("Vertical");

			RotateSprite(xDir, yDir);

			Vector3 moveDir = new Vector3(xDir, yDir, 0);


			transform.Translate(speed * moveDir * Time.deltaTime);

			RotateSprite(this.rigidbody2D.velocity.x, this.rigidbody2D.velocity.y);

		}
	}

	void RotateSprite(float xDir, float yDir)
	{
		if(xDir > 0)
		{
			if(yDir > 0)
			{
				transform.Rotate(new Vector3(0, 0, 45));
			}
			else if(yDir < 0)
			{
				transform.Rotate(new Vector3(0, 0, 135));
			}
			else
			{
				transform.Rotate(new Vector3(0, 0, 90));
			}
		}
		else if(xDir < 0)
		{
			if(yDir > 0)
			{
				transform.Rotate(new Vector3(0, 0, 315));
			}
			else if(yDir < 0)
			{
				transform.Rotate(new Vector3(0, 0, 225));
			}
			else
			{
				transform.Rotate(new Vector3(0, 0, 270));
			}
		}
		else
		{
			if(yDir > 0)
			{
				transform.Rotate(new Vector3(0, 0, 0));
			}
			else if(yDir < 0)
			{
				transform.Rotate(new Vector3(0, 0, 180));
			}
		}

	}
}
