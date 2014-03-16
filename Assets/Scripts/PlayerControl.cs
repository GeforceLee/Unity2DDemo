using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	[HideInInspector]
	public bool facingRight = true;
	[HideInInspector]
	public bool jump = false;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public AudioClip[] jumpClips;
	public float jumpForce = 1000f;
	public AudioClip[] taunts;
	public float tauntProbablity = 50f;
	public float tauntDelay = 1f;

	private int tauntIndex;
	private Transform groundCheck;
	private bool grounded = false;
	private Animator anim;


	private float h=0f;

	void Awake(){
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position,groundCheck.position,1 << LayerMask.NameToLayer("Ground"));	

		if(Input.GetButtonDown("Jump") && grounded){
			jump = true;
		}
	}


	void FixedUpdate(){
		if(Mathf.Abs(Input.GetAxis("Horizontal"))>0){
			h = Input.GetAxis("Horizontal");
		}

		anim.SetFloat("Speed",Mathf.Abs (h));

		if(h * rigidbody2D.velocity.x < maxSpeed){
			rigidbody2D.AddForce(Vector2.right * h * moveForce);
		}

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed){
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed , rigidbody2D.velocity.y);
		}

		if(h > 0 && !facingRight){
			Flip();
		}else if(h < 0 && facingRight){
			Flip();
		}

		if(jump){
			playerJump();
		}
		h = 0;
	}

	void playerJump(){

		anim.SetTrigger("Jump");

		int i = Random.Range(0,jumpClips.Length);
		AudioSource.PlayClipAtPoint(jumpClips[i],transform.position);

		rigidbody2D.AddForce(new Vector2(0f,jumpForce));

		jump = false;

	}

	void Flip(){
		facingRight = !facingRight;

		Vector3 theScalse = transform.localScale;
		theScalse.x *= -1;

		transform.localScale = theScalse;
	}

	public IEnumerator Taunt(){
		float tauntChance = Random.Range(0,100f);
		if (tauntChance > tauntProbablity) {
			yield return new WaitForSeconds(tauntDelay);

			if(!audio.isPlaying){
				tauntIndex = TauntRandom();

				audio.clip = taunts[tauntIndex];
				audio.Play();
			}
		}

	}

	int TauntRandom(){
		int i = Random.Range (0, taunts.Length);
		if (i == tauntIndex) 
			return TauntRandom ();
		else 
			return i;
		
	}
}
