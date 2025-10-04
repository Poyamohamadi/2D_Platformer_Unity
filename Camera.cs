using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
	public GameObject Player;
	
    void Update()
    {
	    if ( Player.transform.position.x > ( transform.position.x + 4.3f ) )
	    {
	    	transform.position = new Vector3(
	    		Time.deltaTime * 10 + transform.position.x , //x
	    		transform.position.y, //y
	    		transform.position.z  //z
	    	);
	    }
	    
	    if ( Player.transform.position.x < ( transform.position.x - 4.3f ) )
	    {
	    	transform.position = new Vector3(
	    		transform.position.x - Time.deltaTime * 10, //x
	    		transform.position.y, //y
	    		transform.position.z  //z
	    	);
	    }
	    
	    if ( Player.transform.position.y < -10 )
	    {
	    	transform.position = transform.position;
	    }
	    else
	    {
	    	transform.position = new Vector3(
		    	transform.position.x,
		    	Player.transform.position.y,
		    	transform.position.z
	    	);
	    }
    }
}
