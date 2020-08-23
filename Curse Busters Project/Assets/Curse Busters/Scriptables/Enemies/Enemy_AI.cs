using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_AI : MonoBehaviour
{

	private Transform playerPos;
	public bool foundPlayer;
	public float speed;

	public Transform[] moveSpots;
	private int randomSpot;
	private float waitTime;
	public float startWaitTime;

	public float detectionDistance;
	public float stoppingDistance;
	public float retreatDistance;

	[SerializeField]
	GameObject bullet;
	public float fireRate;
	private float nextFire;
	private bool canFire;

	
	// Start is called before the first frame update
	void Start()
	{
		randomSpot = Random.Range(0,moveSpots.Length);
		waitTime = startWaitTime;
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (canFire)
		CheckIfTimeToFire();

		// Patrol an area 
		if (Vector2.Distance(transform.position, playerPos.position) > detectionDistance)
		{
			PatrolMovement();
		}

		// Chase the player
		else if (Vector2.Distance(transform.position, playerPos.position) > stoppingDistance &&
			Vector2.Distance(transform.position, playerPos.position) < detectionDistance)
		{
			aggressiveMovement();
		}
		// Stops moving next to player
		else if (Vector2.Distance(transform.position, playerPos.position) > stoppingDistance &&
				 Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
		{
			idleMovement();
		}

		// Move away from the player slightly
		else if (Vector2.Distance(transform.position, playerPos.position) < retreatDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed * Time.deltaTime);
		}
	}

	// Don't move? 
	void idleMovement()
	{
		transform.position = this.transform.position;
	}

	void PatrolMovement()
	{
		transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
		canFire = false;

		if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
		{
			if (waitTime <= 0)
			{
				randomSpot = Random.Range(0, moveSpots.Length);
				waitTime = startWaitTime;
			}
			else
			{
				waitTime -= Time.deltaTime;
			}
		}
	}

	void aggressiveMovement()
	{
		transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
		canFire = true;
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate(bullet, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
	}
}
