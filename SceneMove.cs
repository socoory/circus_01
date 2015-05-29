using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour {

	public GUISkin scene;
	Texture bg;

	void Start() {
		this.bg = Resources.Load ("Sprites/catBackgroud") as Texture;
	}

	void Update() {	
		if (Input.touchCount > 0) {
			Application.LoadLevel (1);
		}	
	}

	void OnGUI()  
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), this.bg);  
	}  
}
