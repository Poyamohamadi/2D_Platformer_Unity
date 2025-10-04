![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/1.PNG)
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D rb;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
	}
	void FixedUpdate()
	{
		rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*12 , rb.velocity.y);
	}
}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/2.PNG)
```csharp
// Player
void Update()
	{
		if (Input.GetButtonDown("Jump")){
			rb.velocity = new Vector2(rb.velocity.x, 25);
		}
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/3.PNG)
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/4.PNG)
```csharp
// Player
void Update()
	{
		if (Input.GetButtonDown("Jump")){
				
			if ( IsGround() )
			{
				rb.velocity = new Vector2(rb.velocity.x, 25);
			}	
		}
	}
	
	public bool IsGround()
	{
		UnityEngine.Collider2D raycasthitCollider = Physics2D.BoxCast(
			(capsuleColider.offset + 
			new Vector2(transform.position.x, transform.position.y)), // origin
			capsuleColider.size, // size
			0, // angle
			new Vector2(0, -1),
			0.1f,
			LayerMask.GetMask("Floor")).collider;
			
		bool notNull = raycasthitCollider != null;
		
		return notNull;
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/5.PNG)
```csharp
// Player
Animator animator;

	void Start()
	{	
		...
		
		animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		...
		
		animator.SetBool("isWalking", 
			Input.GetAxisRaw("Horizontal") != 0f);
			
		animator.SetBool("isJump", 
			!IsGround());
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/6.PNG)
```csharp
// Player

public SpriteRenderer sprite;
bool flipx;

void Update()
	{
		...
		
		if (Input.GetAxisRaw("Horizontal") < 0 && !flipx)
		{
			sprite.flipX = true;
			flipx = sprite.flipX;
		}
		else if(Input.GetAxisRaw("Horizontal") > 0 && flipx)
		{
			sprite.flipX = false;
			flipx = sprite.flipX;
		}
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/7.PNG)

```csharp
// Camera
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
    }
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/8.PNG)
```csharp
// Camera
public GameObject Player;
	
void Update()
    {
	    ...
	    
	    if ( Player.transform.position.x < ( transform.position.x - 4.3f ) )
	    {
	    	transform.position = new Vector3(
	    		transform.position.x - Time.deltaTime * 10, //x
	    		transform.position.y, //y
	    		transform.position.z  //z
	    	);
	    }
    }
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/9.PNG)
```csharp
public GameObject Player;
	
void Update()
    {
	    ...
	    
	    transform.position = new Vector3(
	    	transform.position.x,
	    	Player.transform.position.y,
	    	transform.position.z
	    );
    }
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/10.PNG)
```csharp
// Player
void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		Debug.Log(
			LayerMask.LayerToName( collisionInfo.gameObject.layer )
		);
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/11.PNG)
```csharp
// Player
void OnCollisionEnter2D(Collision2D collisionInfo)
	{
	if (LayerMask.LayerToName( collisionInfo.gameObject.layer ) == "Hazards")
		{
			this.gameObject.SetActive(false);
		}
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/12_1.PNG)
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/12_2.PNG)
```csharp
// Player
public static System.Action OnPlayerDied;
	
void OnCollisionEnter2D(Collision2D collisionInfo)
	{
	if (LayerMask.LayerToName( collisionInfo.gameObject.layer ) == "Hazards")
		{
			this.gameObject.SetActive(false);
			OnPlayerDied?.Invoke();
		}
	}
```

```csharp
void Start()
	{
		// ( Player.cs ).OnPlayerDied
		Player.OnPlayerDied += OnPlayerDied;
	}
	
public void OnPlayerDied ()
	{
	    UnityEngine.SceneManagement.SceneManager.LoadScene("mainGame");
/* UnityEngine.SceneManagement.SceneManager.LoadScene( UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); */
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/13.PNG)
```csharp
// DeadUI
public class DeadUI : MonoBehaviour
{
	public GameObject Container;
	
    void Start()
    {
    	Player.OnPlayerDied += OnPlayerDied;
    }
	
	void OnPlayerDied()
	{
		Container.SetActive(true);
	}   
}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/14_2.PNG)

![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/14_1.PNG)



```csharp
// DeadUI
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
```

```csharp
// SceneManagerGame
void Start()
	{
		DeadUI.ReloadScene += ReloadScene;
	}
	
void ReloadScene()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("mainGame");
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/15.PNG)
```csharp
// Player
void FixedUpdate()
	{
		...
		
		if ( rb.velocity.y < - 100)
		{
			this.gameObject.SetActive(false);
			OnPlayerDied?.Invoke();
		}
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/16.PNG)
```csharp
// Camera
void Update()
    {
		...
		
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
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/17.PNG)
```csharp
// Player ( Coin )
void OnTriggerEnter2D(Collider2D other)
	{
		if ( LayerMask.LayerToName( other.gameObject.layer ) == "Coin" )
		{
			Destroy(other.gameObject);
		}
	}
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/18.PNG)
```csharp
// Player ( Coin )
int CoinAmount = 0;
	
void OnTriggerEnter2D(Collider2D other)
	{
		if ( LayerMask.LayerToName( other.gameObject.layer ) == "Coin" )
		{
			Destroy(other.gameObject);
			
			CoinAmount += 1;
			CoinUI.OnPlayerGrabbedCoin?.Invoke(CoinAmount);
		}
	}
```

---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/19.PNG)

```csharp
// CoinUI
public class CoinUI : MonoBehaviour
{
	public static System.Action<int> OnPlayerGrabbedCoin;
	 
	TMPro.TextMeshProUGUI CoinText;
	
    void Start()
    {
	    CoinUI.OnPlayerGrabbedCoin += funcOnPlayerGrabbedCoin;
	    CoinText = GameObject.Find("CoinUI/Text").GetComponent<TMPro.TextMeshProUGUI>();
    }

	void funcOnPlayerGrabbedCoin( int CoinAmount )
	{
		CoinText.SetText( CoinAmount.ToString() );
	}
}
```

---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/20.PNG)
```csharp
 // CoinUI
 void Start()
    {
	    ...
	    
	CoinText = GameObject.Find("CoinUI/Text").GetComponent<TMPro.TextMeshProUGUI>();
	    
	CoinText.SetText( Player.CoinAmount.ToString() );
    }
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/21.PNG)
```csharp
// Player
public static System.Action OnPlayerWin;
	
void OnTriggerEnter2D(Collider2D other)
	{
		if ( LayerMask.LayerToName( other.gameObject.layer ) == "Star" )
		{
			Destroy(other.gameObject);
			
			this.gameObject.SetActive(false);
			
			OnPlayerWin?.Invoke();
		}
	}
```

---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/22.PNG)
```csharp
// WinUI
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
```
---
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/23.PNG)

```csharp
// GameManager
public class GManager : MonoBehaviour
{
	public GameObject[] levelGameObjectList;
	public static int level = 0;
	
    void Start()
    {
	    foreach(GameObject l in levelGameObjectList){
	    	l.SetActive(false);
	    }
	    
	    levelGameObjectList[level].SetActive(true);
    }
}
```

---

![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/24_1.PNG)
```csharp
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
```
![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/24_2.PNG)

```csharp
// Player
void OnTriggerEnter2D(Collider2D other)
	{
		if ( LayerMask.LayerToName( other.gameObject.layer ) == "Star" )
		{
			Destroy(other.gameObject);
			this.gameObject.SetActive(false);
			//-------------------------------
			GManager.nextLevel += 1;
			//-------------------------------
			OnPlayerWin?.Invoke();
		}
	}
```



![](https://github.com/Poyamohamadi/2D_Platformer_Unity/blob/main/image/25_2.PNG)

```csharp
// Player
void Update()
	{
		if (Input.GetButtonDown("Jump")){
				
			if ( IsGround() )
			{
				rb.velocity = new Vector2(rb.velocity.x, 25);
				SoundManager.playSound?.Invoke("jump");
			}	
		}
	}
```
