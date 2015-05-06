using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public AudioClip left;
	public AudioClip loncat;
	Vector3 position;
	bool jump;
	float speedmove=10;
	float speedjump=300;



	void Update () {
		if (Input.GetKey (KeyCode.A)|| Input.GetKey (KeyCode.LeftArrow)) {
			audio.clip = left;
			audio.Play();
			position= transform.position+Vector3.left;
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.D)|| Input.GetKey (KeyCode.RightArrow)) {
			audio.clip = left;
			audio.Play();
			position= transform.position+Vector3.right;
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
		}
		if (!jump) {
			if (Input.GetKey (KeyCode.Space)|| Input.GetKey (KeyCode.UpArrow)||Input.GetKey (KeyCode.W)) {
				audio.clip = loncat;
				audio.Play();
				GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
				GetComponent<Rigidbody2D> ().AddForce (Vector3.up * speedjump);		
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D other){
		//jump = false;;
		//Debug.Log ("Tersentuh");
		if (other.gameObject.tag == "point")
			other.gameObject.audio.Play ();
	}
	
	void OnCollisionExit2D(Collision2D other){
		//jump = true;
		//Debug.Log ("Terlepas");
		if (other.gameObject.tag == "point")
			other.gameObject.audio.Stop ();
	}
}
