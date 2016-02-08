using UnityEngine;
using System.Collections;

public class boom_test : MonoBehaviour {

	private Rigidbody2D boom_rigidbody;
	private SpriteRenderer sr;
	private GameObject player_char;
	private GameObject boom_held;
	public float returnSpeed = 1.0f;
	private bool returning = false;

	// Use this for initialization
	void Start () {
		boom_held = GameObject.Find ("spear_test");
		sr = boom_held.GetComponent<SpriteRenderer> ();
		//StartCoroutine ("boom_return");
		player_char = GameObject.FindGameObjectWithTag ("Player");
		boom_rigidbody = GetComponent<Rigidbody2D> ();
		//boom_rigidbody.AddTorque (10.0f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		boom_rigidbody.transform.Rotate (0, 0, 10);
		if (returning == true) {
			//boom_rigidbody.AddForce (Vector2.MoveTowards (transform.position, player_char.transform.position, returnSpeed));
			transform.position = Vector2.MoveTowards (transform.position, player_char.transform.position, returnSpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D collision){

		Debug.Log ("collision works");
		if (collision.gameObject.tag == "Player" && returning == true) {
			sr.enabled = true;
			Destroy (this.gameObject);
		} else if (collision.gameObject.tag == "Enemy") {
			boom_rigidbody.velocity = Vector2.zero;
			returning = true;
		}
	}
	private IEnumerator boom_return(){
		
		yield return new WaitForSeconds (1.5f);
		//Debug.Log ("REturning");
		boom_rigidbody.velocity = Vector2.zero;
		returning = true;

	}
}
