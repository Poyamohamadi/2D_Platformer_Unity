using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
	public GameObject Container;

	void Start()
	{
		Player.OnPlayerWin += funcOnPlayerWin;
	}
    
	
	void funcOnPlayerWin()
	{
		Container = GameObject.Find("Canvas/WinUI/Container");
		Container.SetActive(true);
	}
	
	
	void Update()
	{
		if ( Input.GetButtonDown("Jump") && Container.activeSelf )
		{	
			Container.SetActive(false);
			DeadUI.ReloadScene?.Invoke();
			
		}
	}
    
}
