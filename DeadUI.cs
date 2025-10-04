using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadUI : MonoBehaviour
{
	public GameObject Container;

    void Start()
    {
    	Player.OnPlayerDied += OnPlayerDied;
    }
	
	void OnPlayerDied()
	{
		// Container = transform.FindChild("Canvas/DeadUI").gameObject;
		Container = GameObject.Find("Canvas/DeadUI/Container");
		Container.SetActive(true);
		Player.CoinAmount = 0;
	}
	
	public static System.Action ReloadScene;
	
	void Update()
	{
		if ( Input.GetButtonDown("Jump") && Container.activeSelf )
		{	
			Container.SetActive(false);
			ReloadScene?.Invoke();
			
		}
	}
    
}
