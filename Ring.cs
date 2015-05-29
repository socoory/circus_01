using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {
	public GameObject ring;

	private float speed;

	// Use this for initialization
	void Start () {
		this.speed = -6.0f - Stage.globalTime/10.0f;

		float y = Random.Range (0.0f, 2.0f) > 1.0f ? 2.1f : 1.5f;

		this.transform.position = new Vector3 (10.0f, y, 0.0f);

		float gen = Random.Range (0.0f, 10.0f);
		if (gen > 9.5f) {
			GameObject.Instantiate(ring, this.transform.position + new Vector3(0.5f, 0.0f, 0.0f), Quaternion.Euler(Vector3.up));
		}
	}
	
	// Update is called once per frame
	void Update () {
		move (Time.deltaTime);
	}

	private void move(float deltaTime) {
		this.transform.Translate (new Vector3 (this.speed*deltaTime, 0.0f, 0.0f));

		if (this.transform.position.x < -8.0f) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
