using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
	// animate the game object from -1 to +1 and back
	public float minimumPos;
	public float maximumPos;
	
	public bool horizontal;

	// starting value for the Lerp
	static float t = 0.0f;

	private void Start()
	{
		if (horizontal)
		{
			minimumPos = transform.position.x + minimumPos;
			maximumPos = transform.position.x + maximumPos;
		}
		else
		{
			minimumPos = transform.position.y + minimumPos;
			maximumPos = transform.position.y + maximumPos;
		}
	}

	void Update()
	{
		// animate the position of the game object...
		if (horizontal)
			transform.position = new Vector3(Mathf.Lerp(minimumPos, maximumPos, t), transform.position.y, 0);
		else
			transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimumPos, maximumPos, t), 0);


		// .. and increase the t interpolater
		t += 0.5f * Time.deltaTime;

		// now check if the interpolator has reached 1.0
		// and swap maximum and minimum so game object moves
		// in the opposite direction.
		
		if (t > 1)
		{
			float temp = maximumPos;
			maximumPos = minimumPos;
			minimumPos = temp;
			t = 0.0f;
		}
	}
}
