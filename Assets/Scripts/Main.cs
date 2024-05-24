using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public enum GAME_STATE { MENU, GAME_MODE, GAME_OVER }
	public GAME_STATE state;

	//Singleton
	private static Main _instance;
	public static Main instance
	{
		get
		{
			return _instance;
		}
	}
	//////////////////////////////////////////////////////////////////////////
	void Start()
	{
		_instance = this;

	}
	//////////////////////////////////////////////////////////////////////////
	public void BackToMenu()
	{
		state = GAME_STATE.MENU;

	}
	//////////////////////////////////////////////////////////////////////////
	public void EnterGameMode()
	{
		state = GAME_STATE.GAME_MODE;
		LevelManager.instance.LoadLevel(1);
	}
	//////////////////////////////////////////////////////////////////////////
	public void GameOver()
	{
		state = GAME_STATE.GAME_OVER;
		UIManager.instance.GameOver();
		LevelManager.instance.GameOver();
	}
}
