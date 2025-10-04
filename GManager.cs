using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
	public GameObject[] level;
	
	public static int nextLevel = 0;
	
    void Start()
	{
	    foreach(GameObject l in level){
	    	l.SetActive(false);
	    }
	    
		level[nextLevel].SetActive(true);
    }
	
	
	
	
    
}
