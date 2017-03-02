using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	Rigidbody rb;
	public Text countText;
	public Text winText;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		winText.text = "";
		}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement);
	}

	void OnTriggerEnter(Collider other){
		
		if(other.CompareTag("Pickup"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}

	}

	void SetCountText(){
		countText.text = "Count - " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Won!";
		}
	}
		
}