using UnityEngine;
using System.Collections;

public class easyMove : MonoBehaviour {

	private bool isRolling = false;
	public float forwardSpeed = 1.0f;
	public float sideSpeed = 0.8f;
	public float backSpeed = 0.6f;
	public float rollSpeed = 1.0f;
	public float recoverSpeed = 0.1f;
	private float speed = 1.0f;
	private float velAngle = 0.0f;
	private float pi = Mathf.PI;
	public Sprite top1;
	public Sprite top2;
	public Sprite top3;
	public Sprite top4;
	public Sprite right;
	public Sprite down;
	public Sprite left;
	public Sprite topRight;
	public Sprite topLeft;
	public Sprite downRight;
	public Sprite downLeft;
	private float movex = 0f;
	private float movey = 0f;
	private float moveTotal;
	public static SpriteRenderer sr;
	public static Animator ar;
	private Vector2 mouse;
	private float tan;
	private float vtan;
	private static int rHeight;
	private static int rWidth;
	private static GameObject spear;
	private float time;
	private Vector2 vel;
	private Rigidbody2D rb;
	//private  class ArrayList: aTop,aBot,aLeft,aRight,aTopR,aTopL,aBotR,aBotL;

	// Use this for initialization
	void Start () {
		speed = forwardSpeed;
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = right;
		ar = GetComponent<Animator>();
		rHeight = Screen.height;
		rWidth = Screen.width;
	}

	// Update is called once per frame
	void Update () {
		mouse.x = Input.mousePosition.x - rWidth / 2;
		mouse.y = Input.mousePosition.y - rHeight / 2;
		movex = Input.GetAxis ("Horizontal");
		movey = Input.GetAxis ("Vertical");
		moveTotal = Mathf.Abs(movex) + Mathf.Abs(movey);
		if (moveTotal == 0)
			moveTotal = 1;

		tan = Mathf.Atan2 (mouse.y, mouse.x);
		vtan = Mathf.Atan2 (rb.velocity.y, rb.velocity.x);
//		velAngle = Mathf.Abs (tan - vtan);
//		if (velAngle <= pi / 3) {
//			speed = forwardSpeed;
//		} else if (velAngle <= pi * 2 / 3) {
//			speed = sideSpeed;
//		} else {
//			speed = backSpeed;
//		}
		if (Input.GetButtonDown ("Jump")) {
			StartCoroutine("roll");
		}
		if (isRolling == false) {
			rb.velocity = new Vector2 (movex * speed / moveTotal , movey * speed / moveTotal);
		}
		//if (tan < 0)
		//	tan *= -1;
		if (tan >= Mathf.PI / -8 && tan <= Mathf.PI / 8) {
			rightSprite (sr);
		} else if (tan >= Mathf.PI * 3/8 && tan <= Mathf.PI * 5/8) {
			topSprite (sr);
		} else if (tan >= Mathf.PI * 7/8 || tan <= Mathf.PI * -7/8) {
			leftSprite (sr);
		} else if (tan >= Mathf.PI * -5/8 && tan <= Mathf.PI * -3/8) {
			downSprite (sr);
		} else if ( tan > Mathf.PI /8 &&  tan < Mathf.PI * 3/8 ){
			topRightSprite(sr);
		} else if ( tan > Mathf.PI * 5/8 && tan < Mathf.PI *7/8){
			topLeftSprite(sr);
		} else if ( tan > Mathf.PI * -7/8 && tan < Mathf.PI * -5/8) {
			downLeftSprite(sr);
		} else if ( tan < Mathf.PI /-8 && tan > Mathf.PI * -3/8) {
			downRightSprite(sr);
		}

		if (Input.GetMouseButtonDown (1)) {
			Debug.Log (rb.velocity);
		}
	}
		
//			} else if (sr.sprite != down) {
//				downSprite(sr);
//			}
//		} else {
//			if (mouse.x > 0 && sr.sprite != right) {
//				rightSprite(sr);
//			} else if (sr.sprite != left){
//				leftSprite(sr);
//			}
//		}
//	

	private IEnumerator roll() {
		isRolling = true;
		rb.velocity = rb.velocity * rollSpeed;
		yield return new WaitForSeconds (0.25f);
		rb.velocity = rb.velocity * recoverSpeed;
		yield return new WaitForSeconds (0.15f);
		isRolling = false;
		//rb.AddForce (rb.velocity * rollSpeed, ForceMode2D.Force);
	}
	void topSprite(SpriteRenderer sr){
		spear_test.behind ();
		sr.sprite = top1;
	}
	void leftSprite(SpriteRenderer sr){
		spear_test.behind ();
		sr.sprite = left;
	}
	void downSprite(SpriteRenderer sr){
		spear_test.ahead ();
		sr.sprite = down;
	}
	void rightSprite(SpriteRenderer sr){
		spear_test.ahead ();
		sr.sprite = right;
	}
	void topLeftSprite(SpriteRenderer sr) {
		spear_test.behind ();
		sr.sprite = topLeft;
	}
	void topRightSprite(SpriteRenderer sr) {
		spear_test.behind ();
		sr.sprite = topRight;
	}
	void downRightSprite(SpriteRenderer sr) {
		spear_test.ahead ();
		sr.sprite = downRight;
	}
	void downLeftSprite(SpriteRenderer sr) {
		spear_test.ahead ();
		sr.sprite = downLeft;
	}
	public void equipSpell(string spellNumber){
		Debug.Log ("Equip spell number " + spellNumber);
	}

}