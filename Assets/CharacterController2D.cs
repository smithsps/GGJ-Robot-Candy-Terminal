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

			//if(xDir > 0)
			//	GetComponent<Animator>().SetBool("MoveRight", true);

			RotateSprite(xDir, yDir);

			Vector3 moveDir = new Vector3(xDir, yDir, 0);

			transform.Translate(speed * moveDir * Time.deltaTime, Space.World);
		}
	}

	void RotateSprite(float xDir, float yDir)
	{
		if(xDir < 0)
		{
			if(yDir > 0)
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 1);
				//transform.Rotate(new Vector3(0, 0, 45));
			}
			else if(yDir < 0)
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 3);
				//transform.Rotate(new Vector3(0, 0, 135));
			}
			else
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 2);
				//transform.Rotate(new Vector3(0, 0, 90));
			}
		}
		else if(xDir > 0)
		{
			if(yDir > 0)
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 7);
				//transform.Rotate(new Vector3(0, 0, 315));
			}
			else if(yDir < 0)
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 5);
				//transform.Rotate(new Vector3(0, 0, 225));
			}
			else
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 6);
				//transform.Rotate(new Vector3(0, 0, 270));
			}
		}
		else
		{
			if(yDir > 0)
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 0);
				//transform.Rotate(new Vector3(0, 0, 0));
			}
			else if(yDir < 0)
			{
				GetComponent<Animator>().SetInteger("RotationDirection", 4);
				//transform.Rotate(new Vector3(0, 0, 180));
			}
		}
	}
}
