using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerGame : MonoBehaviour
{	
	void Start()
	{
		DeadUI.ReloadScene += ReloadScene;
	}
	
	void ReloadScene()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("mainGame");
	}
}
