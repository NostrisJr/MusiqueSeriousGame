using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int score;
	public float speed;
	public int life;


	void onEnterCollision(Collider other)
	{
		if (other.GetComponent<Ennemy>())
		{
			Ennemy ennemy = other.GetComponent<Ennemy>();
			if (ennemy.fatal = true)
			{
				GameOver();
			}
		}
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("KEY !");
			GameOver();
		}

	}

	public void GameOver()
	{
		Main.instance.GameOver();
	}

}
