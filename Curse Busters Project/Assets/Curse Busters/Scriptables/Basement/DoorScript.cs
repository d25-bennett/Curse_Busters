using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	private GameObject cam;
	private GameObject player;
	public Transform camPos;
	public Transform playerPos;
	private bool camMove;
	private bool playerMove;
	public GameObject[] deloadedEnemies;
	public GameObject[] loadedEnemies;
	private GameObject[] onscreenBullets;

	private void Start()
	{
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		if (camMove)
		{
			cam.transform.position = Vector3.MoveTowards(cam.transform.position, camPos.transform.position, 10 * Time.deltaTime);
			if (Vector2.Distance(cam.transform.position, camPos.transform.position) <= 0)
			{
				camMove = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
			Debug.Log("Hit");
		if (collision)
		{
			// Unload enemies
			if (deloadedEnemies != null)
			{
				for (int i = 0; i < deloadedEnemies.Length; i++)
				{
					deloadedEnemies[i].SetActive(false);
				}
			}

			onscreenBullets = GameObject.FindGameObjectsWithTag("Bullet");

			if (onscreenBullets != null)
			{
				for (int i = 0; i < onscreenBullets.Length; i++)
				{
					Destroy(onscreenBullets[i]);
				}
			}

			// Move player
			player.transform.position = playerPos.transform.position;

			// Move camera
			camMove = true;
			
			// Load Enemies
			if (loadedEnemies != null)
			{
				for (int i = 0; i < loadedEnemies.Length; i++)
				{
					loadedEnemies[i].SetActive(true);
				}
			}
		}
	}
}
