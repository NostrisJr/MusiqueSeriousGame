using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	/*************************************************/
	// Singleton
	private static UIManager _instance;
	public static UIManager instance
	{
		get
		{
			return _instance;
		}
	}
	
	void Start ()
	{
		_instance = this;
		OnEnterMenu ();
	}
	/*************************************************/
	
	
	public GameObject panelMenu;
	public GameObject panelInGame;
	public GameObject panelGameOver;
	//public Main main;

	public void OnEnterMenu ()
 	{
		panelMenu.SetActive(true);
		panelInGame.SetActive(false);
		panelGameOver.SetActive(false);
	}

	public void OnEnterGameMode ()
	{
		panelMenu.SetActive(false);
		panelInGame.SetActive(true);
		panelGameOver.SetActive(false);
		Main.instance.EnterGameMode ();
	}
	
	public void GameOver ()
	{
		panelMenu.SetActive(false);
		panelInGame.SetActive(false);
		panelGameOver.SetActive(true);
	}
	 public void BackToMenu ()
	 {
		panelMenu.SetActive(true);
		panelInGame.SetActive(false);
		panelGameOver.SetActive(false);
		 
	 }
	 

}
