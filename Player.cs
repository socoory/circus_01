﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private float jumpSpeed = 25.0f;
	private float jumpingSpeed;
	private float gravity = 80.0f;
	private float bottomPivot;
	private bool isJumping = false;
	private Animator animator;
	private bool isDamaging = false;


	// Use this for initialization
	void Start () {
		bottomPivot = this.transform.position.y;
		this.animator = this.GetComponent<Animator> ();
	}


	// Update is called once per frame
	void Update () {
		/*
		 * jump
		 */
		if (Input.touchCount > 0) {
			if (this.isJumping) {
			} else {
				this.jumpingSpeed = this.jumpSpeed;
				this.isJumping = true;
				animator.Play("jump");
			}
		}
		/*
		 * ㅎㅏㄱㅏㅇ ㅅㅣ x ㄴㅜㄹㅡㅁㅕㄴ
		 * ㄱㅗㅇㅈㅜㅇㅂㅜㅇㅑㅇ
		 */
		else if (Input.GetKeyDown (KeyCode.X)) {
			if (this.isJumping && this.jumpingSpeed < 0.0f) {
				this.jumpingSpeed += 20.0f;
			}
		}

		/*
		 * ㅈㅓㅁㅍㅡ ㅈㅜㅇㅇㅣㅁㅕㄴ ㅈㅓㅁㅍㅡ ㅎㅏㅁㅅㅜ ㅎㅗㅊㅜㄹ
		 */
		if (isJumping) {
			handleJump (Time.deltaTime);
		}
		if(Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKey(KeyCode.Escape))
			{
				 Application.Quit();
			}
		}
	}


	/**
	 * ㅈㅓㅁㅍㅡ ㅊㅓㄹㅣ
	 **/
	private void handleJump(float deltaTime) {
		/*
		 * if cat's position Y is under bottom pivot
		 * quit jump state and cat's position Y to bottom pivot
		 * ㄱㅣㅈㅜㄴ ㅅㅓㄴㅇㅔ ㅁㅏㅈㅊㅜㄱㅗ ㅈㅓㅁㅍㅡ ㅈㅗㅇㄹㅛ
		 * ㅎㅏㄴㄱㅡㄹ ㅇㅗㅐ ㅇㅣㄹㅐ ㅇㅏㅇㅏㅇㅏ 
		 */
		if(this.transform.position.y + jumpingSpeed*deltaTime < bottomPivot) {
			this.transform.position = new Vector3(this.transform.position.x, bottomPivot, this.transform.position.z);
			this.isJumping = false;

			if(animator.GetCurrentAnimatorStateInfo(0).shortNameHash != Animator.StringToHash("damage")) {
				animator.Play("ready");
			}
		}
		else {
			this.transform.Translate(0.0f, jumpingSpeed*deltaTime, 0.0f);
		}

		this.jumpingSpeed -= gravity*deltaTime;
	}
	

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ring") {
			if (this.animator != null) {
				this.animator.Play ("damage");
			}
		}
		else if (other.gameObject.tag == "Hole") {
			/*
			 * ㅈㅓㅁㅅㅜ ㅇㅓㄷㄴㅡㄴ ㅂㅜㅂㅜㄴ
			 */
			Debug.Log ("Hole");
		}
	}
	
	public void OnTriggerExit2D(Collider2D other) {
	}
}