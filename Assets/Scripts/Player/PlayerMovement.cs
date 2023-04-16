using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	public static bool isDead = false;

	bool doubleSpeedCheatActive;
	private void Awake() {
		speed = GameStates.getSpeed();
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
		transform.position = GameStates.getCurrCoordinat();
		transform.rotation = GameStates.getCurrRotation();
		PlayerMovement.isDead = false;
	}

	void Update() {
		speed = GameStates.getSpeed();
	}

	public void Turning() {
		if(!PlayerMovement.isDead){
			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit floorHit;

			// initialize Raycasting
			if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
				Vector3 playerToMouse = floorHit.point - transform.position;
				playerToMouse.y = 0f;
				Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
				GameStates.setCurrRotation(newRotation);
				// // rotate player
				playerRigidbody.MoveRotation(newRotation);
			}
		}
	}

	public void Animating(float h, float v) {
		bool walking = h != 0f || v != 0f;
		anim.SetBool("IsWalking", walking);
  }

	//Method player dapat berjalan
	public void Move(float h, float v) {
		if(!PlayerMovement.isDead){
			movement.Set(h, 0f, v);
			movement = movement.normalized * speed * Time.deltaTime;
			playerRigidbody.MovePosition(transform.position + movement);
			GameStates.setCurrCoordinat(transform.position);
			GameStates.setCameraPosition(GameObject.FindGameObjectWithTag("MainCamera").transform.position);
		}
	}

	// active for 10seconds
	public void ApplyDoubleSpeedCheat() {
		if (!doubleSpeedCheatActive) {
			doubleSpeedCheatActive = true;
			speed *= 2;
			// StartCoroutine(DisableDoubleSpeedCheat());
		}
	}

/* 	IEnumerator DisableDoubleSpeedCheat() {
		yield return new WaitForSeconds(10f);
		doubleSpeedCheatActive = false;
		speed /= 2;
	} */


}