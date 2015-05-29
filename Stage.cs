using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	public GameObject ring;

	private float freq;
	private float dTime;
	public static float globalTime = 0.0f;
	private float speed;


	// Use this for initialization
	void Start () {
		this.speed = -6.0f;
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
	}


	void genRing() {
		Object obj = GameObject.Instantiate (this.ring, new Vector3 (8.0f, 2.1f, 0.0f), Quaternion.Euler (Vector3.up));
	}
}
