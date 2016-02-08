using UnityEngine;
using System.Collections;

public class ui : MonoBehaviour {

	private Canvas inventoryUI;
	// Use this for initialization
	void Start () {
		inventoryUI = GameObject.Find ("Inventory").GetComponent<Canvas>();
		inventoryUI.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.I)) {
			inventoryToggle ();
		}
	}

	public void inventoryToggle() {
		if (inventoryUI.isActiveAndEnabled) {
			inventoryUI.enabled = false;
			Time.timeScale = 0.0f;
		} else {
			inventoryUI.enabled = true;
			Time.timeScale = 1.0f;
		}

	}
}
