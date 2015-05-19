using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jump : MonoBehaviour {
	public Text score;

	public AudioClip left;
	public AudioClip loncat;
	public GameObject bom;
	Vector3 position;
	bool jump;
	float speedmove=10;
	float speedjump=300;

	void start (){
		score.text= "0";
	}


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
		if (other.gameObject.tag == "hppoint") {
			other.gameObject.audio.Play ();
			int point = int.Parse (score.text) + 100;
			Destroy (other.gameObject);
			score.text = point.ToString ();

		}
		if (other.gameObject.tag == "point") {
			other.gameObject.audio.Play ();
		}
		if (other.gameObject.tag == "hpbom") {
			Destroy (other.gameObject);
			int point = int.Parse (score.text) - 100;
			score.text = point.ToString ();
			bom.transform.position = new Vector3(bom.transform.position.x,bom.transform.position.y,6);
		}
	}
	
	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "hppoint") {
			other.gameObject.audio.Stop ();
			int point = int.Parse(score.text)+100;
			Destroy(other.gameObject);
			score.text = point.ToString ();

		}
		if (other.gameObject.tag == "point")
			other.gameObject.audio.Stop ();

	}
}
