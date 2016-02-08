using UnityEngine;
using System.Collections;


public class spear_test : MonoBehaviour {

	public float speed = 1.0f;
	public float spinSpeed= 0.5f; 
	private GameObject clone;
	private SpriteRenderer cloneSR;
	private GameObject spear;
	public GameObject boomerang;
	private Vector3 target_dir = new Vector3();
	public static SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		spinSpeed = 15.0f;
		sr = GetComponent<SpriteRenderer> ();
		//spear = GameObject.Find ("spear_test");
	
	}

	public static void behind (){
		//sr.sortingLayerID = SortingLayer.NameToID ("weapon_back");
	}
	public static void ahead (){
		//sr.sortingLayerID = SortingLayer.NameToID ("weapon_forward");
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (Input.GetMouseButtonDown (0)) {
			attackL ();
		}
		//if (Input.GetMouseButtonDown (1)) {
			//attackR ();
		//}
		//Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		//transform.LookAt (mousePos);
	}

	void attackL(){
		//Debug.Log ("left click");
		if (sr.enabled == true)
			shoot ();
		else 
			shoot_fail ();
	}
	public void pick_up(){
		sr.enabled = true;
		Destroy (clone);

	}
	void shoot() {
		sr.enabled = false;
		clone = Instantiate (boomerang, transform.position, transform.rotation) as GameObject;
		clone.GetComponent<SpriteRenderer> ().enabled = true;
		clone.GetComponent<Rigidbody2D>().velocity = transform.right* speed;
		clone.GetComponent<boom_test> ().StartCoroutine ("boom_return");
		//clone.GetComponent<Rigidbody2D> ().angularVelocity = spinSpeed;

	}
	void shoot_fail(){

	}
	void attackR() {
		//Debug.Log ("right Click");
	}
}
