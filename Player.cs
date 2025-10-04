using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	Rigidbody2D rb;
	CapsuleCollider2D capsuleColider;
	
	Animator animator;
	void Start()
	{	
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		
		capsuleColider = GetComponent<CapsuleCollider2D>();
		
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate()
	{
		rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*12 , rb.velocity.y);
		
		if ( rb.velocity.y < - 50)
		{
			this.gameObject.SetActive(false);
			OnPlayerDied?.Invoke();
		}
	}
	
	public SpriteRenderer sprite;
	bool flipx;
	void Update()
	{
		if (Input.GetButtonDown("Jump")){
				
			if ( IsGround() )
			{
				rb.velocity = new Vector2(rb.velocity.x, 25);
			}	
		}
		
		animator.SetBool("isWalking", 
			Input.GetAxisRaw("Horizontal") != 0f);
			
		animator.SetBool("isJump", 
			!IsGround());
		
		
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
	
	public bool IsGround(){
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
	
	public static System.Action OnPlayerDied;
	
	
	
	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		if (LayerMask.LayerToName( collisionInfo.gameObject.layer ) == "Hazards")
		{
			this.gameObject.SetActive(false);
			OnPlayerDied?.Invoke();
		}
	}
	
	public static int CoinAmount = 0;
	
	public static System.Action OnPlayerWin;
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if ( LayerMask.LayerToName( other.gameObject.layer ) == "Coin" )
		{
			Destroy(other.gameObject);
			
			CoinAmount += 1;
			CoinUI.OnPlayerGrabbedCoin?.Invoke(CoinAmount);
		}
		
		if ( LayerMask.LayerToName( other.gameObject.layer ) == "Star" )
		{
			Destroy(other.gameObject);
			this.gameObject.SetActive(false);
			GManager.nextLevel += 1;
			OnPlayerWin?.Invoke();
		}
	}
	
	
}
