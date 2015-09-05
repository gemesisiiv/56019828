using UnityEngine;
using System.Collections;

public class PacmanController : MonoBehaviour {


		
		public float MoveSpeed;
		public Stage CurrentStage;
		
		float mTimer;
		Vector3 mNextPosition;
		Vector3 mNextDirection;
		Vector3 mMoveDirection;

	// Use this for initialization
	void Start () {
		Debug.Log("Pacman - Start");
		mNextPosition = transform.position;
		mTimer = 0.001f;
	
	}
	void Update () {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		if (h > 0) mNextDirection = new Vector3(1, 0, 0);
		else if (h < 0) mNextDirection = new Vector3(-1, 0, 0);
		else if (v > 0) mNextDirection = new Vector3(0, 0, 1);
		else if (v < 0) mNextDirection = new Vector3(0, 0, -1);
	if (mTimer > 0) {
			mTimer -= Time.deltaTime;
			transform.position += mMoveDirection * MoveSpeed * CurrentStage.CellSize * Time.deltaTime;
		}
		else {
			transform.position = mNextPosition;

			bool isCollided = true;
			if (!Physics.Raycast(transform.position, mNextDirection, 1.5f,1<<8)) {
				mMoveDirection = mNextDirection;
				isCollided = false;
			}
			else {
				if (!Physics.Raycast(transform.position, mMoveDirection, 1.5f,1<<8)) {
					isCollided = false;
				}
			}
			
			if (!isCollided) { 

				mNextPosition = transform.position + (mMoveDirection * CurrentStage.CellSize);
				mTimer = 1 / MoveSpeed;
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("111");
		if (other.gameObject.tag == "patdot") {
			Destroy(other.gameObject);
		}
	}
}