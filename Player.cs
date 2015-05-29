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
	private Rect windowRect = new Rect ((Screen.width)/4, (Screen.height)/3, (Screen.width)/2, (Screen.height)/3);
	private bool show = false;

	public static int score = 0;

	private bool touchFlag = false;
	private int dialogFlag = 0;

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
		if (Input.GetKeyDown (KeyCode.C)) {
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
		 * touch jump
		 */
		if (Input.touchCount > 0 && !this.touchFlag) {
			this.touchFlag = true;
			if (this.isJumping) {
				if (this.jumpingSpeed < 0.0f) {
					this.jumpingSpeed += 20.0f;
				}
			} else {
				this.jumpingSpeed = this.jumpSpeed;
				this.isJumping = true;
				animator.Play ("jump");
			}
		} else {
			//this.touchFlag = false;
		}

		if (Input.touchCount == 0) {
			this.touchFlag = false;
		}

		/*
		 * ㅈㅓㅁㅍㅡ ㅈㅜㅇㅇㅣㅁㅕㄴ ㅈㅓㅁㅍㅡ ㅎㅏㅁㅅㅜ ㅎㅗㅊㅜㄹ
		 */
		if (isJumping) {
			handleJump (Time.deltaTime);
		}

		/*
		 * 뒤로가기 키로 게임을 종료
		 */
		if(Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				if(show) {					
					Time.timeScale = 1;
					show = false;
				}
				else {
					Time.timeScale = 0;
					show = true;
				}
			}
		}
	}

	void OnGUI() {
		GUIStyle myButtonStyle1 = new GUIStyle(GUI.skin.button);
		myButtonStyle1.fontSize = Screen.height/10;
		if(show)
			windowRect = GUI.Window (0, windowRect, DialogWindow, "", myButtonStyle1);
	}
	
	void DialogWindow (int windowID)
	{
		
		GUIStyle myButtonStyle2 = new GUIStyle(GUI.skin.button);
		myButtonStyle2.fontSize = Screen.height / 12;
		float y = Screen.height / 6;
		
		if(GUI.Button(new Rect(5, 0, windowRect.width - 10, y), "Restart", myButtonStyle2))
		{
			Time.timeScale = 1;
			Application.LoadLevel (0);
			Player.score = 0;
			Stage.globalTime = 0.0f;
			show = false;
		}
		
		if(GUI.Button(new Rect(5, y, windowRect.width - 10, y), "Exit", myButtonStyle2))
		{
			Application.Quit();
			show = false;
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
			GameObject.Destroy(other.gameObject);
			score = score + 1;

		}
	}
	
	public void OnTriggerExit2D(Collider2D other) {
	}
}
