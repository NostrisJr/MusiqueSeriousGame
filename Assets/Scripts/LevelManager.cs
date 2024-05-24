using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	/*************************************************/
	// Singleton
	private static LevelManager _instance;
	public static LevelManager instance
	{
		get
		{
			return _instance;
		}
	}
	
	void Start ()
	{
		_instance = this;
	}
	/*************************************************/
	
	
	string levelLoadedName;
	public List<string> levels;
	
	
	public void LoadLevel (int levelIndex)
 	{
		levelLoadedName = levels[levelIndex];
		SceneManager.LoadScene (levelLoadedName, LoadSceneMode.Additive);
	}    
	
	public void GameOver ()
	{
		
		AsyncOperation op = SceneManager.UnloadSceneAsync (levelLoadedName);
		//op.completed += OnSceneCompletedUnload;
	}
	
	void OnSceneCompletedUnload ()
	{

	}		
	
}
