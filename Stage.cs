using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	public static float globalTime = 0.0f;

	public GameObject ring;
	public GameObject bg0;
	public GameObject bg1;
	public GameObject bg2;
	

	private float freq;
	private float dTime;
	private float speed;
	private float bgSpeed;


	// Use this for initialization
	void Start () {
		this.speed = -6.0f;
		this.bgSpeed = -4.0f;
		this.freq = 2.0f;
		this.dTime = 0.0f;
	}


	// Update is called once per frame
	void Update () {
		dTime += Time.deltaTime;
		globalTime += Time.deltaTime;

		if(dTime > freq) {
			dTime = 0.0f;
			genRing();
		}

		if (freq > 1.0f) {
			freq -= globalTime * Time.deltaTime / 10000.0f;
		}
		moveBG (Time.deltaTime);
	}


	void genRing() {
		Object obj = GameObject.Instantiate (this.ring, new Vector3 (10.0f, 2.1f, 0.0f), Quaternion.Euler (Vector3.up));
	}


	void moveBG(float deltaTime) {
		this.bg0.transform.Translate (new Vector3(this.bgSpeed*deltaTime, 0.0f, 0.0f));
		this.bg1.transform.Translate (new Vector3(this.bgSpeed*deltaTime, 0.0f, 0.0f));
		this.bg2.transform.Translate (new Vector3(this.bgSpeed*deltaTime, 0.0f, 0.0f));
		
		if (bg0.transform.position.x <= -22.8) {
			this.bg0.transform.position = new Vector3(this.bg2.transform.position.x + 22.8f, 0.0f, 0.0f);
		}
		if (bg1.transform.position.x <= -22.8) {
			this.bg1.transform.position = new Vector3(this.bg0.transform.position.x + 22.8f, 0.0f, 0.0f);
		}
		if (bg2.transform.position.x <= -22.8) {
			this.bg2.transform.position = new Vector3(this.bg1.transform.position.x + 22.8f, 0.0f, 0.0f);
		}
	}
}
