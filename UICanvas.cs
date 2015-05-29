using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICanvas : MonoBehaviour {
	public Image image0;
	public Image image1;
	public Image image2;

	public Sprite number0;
	public Sprite number1;
	public Sprite number2;
	public Sprite number3;
	public Sprite number4;
	public Sprite number5;
	public Sprite number6;
	public Sprite number7;
	public Sprite number8;
	public Sprite number9;

	private int score;
	private int hundred;
	private int ten;
	private int one;
	// Use this for initialization
	void Start () {
		this.transform.FindChild ("Image");
	}
	
	// Update is called once per frame
	void Update () {
		score = Player.score/2;
		Debug.Log (score);
		one = score % 10;
		ten = (score % 100) / 10;
		hundred = (score % 1000) / 100;
		switch (one) {
		case 0:
			image0.sprite = number0;
			break;
		case 1:
			image0.sprite = number1;
			break;
		case 2:
			image0.sprite = number2;
			break;
		case 3:
			image0.sprite = number3;
			break;
		case 4:
			image0.sprite = number4;
			break;
		case 5:
			image0.sprite = number5;
			break;
		case 6:
			image0.sprite = number6;
			break;
		case 7:
			image0.sprite = number7;
			break;
		case 8:
			image0.sprite = number8;
			break;
		case 9:
			image0.sprite = number9;
			break;
		}
		switch(ten) {
		case 0:
			image1.sprite = number0;
			break;
		case 1:
			image1.sprite = number1;
			break;
		case 2:
			image1.sprite = number2;
			break;
		case 3:
			image1.sprite = number3;
			break;
		case 4:
			image1.sprite = number4;
			break;
		case 5:
			image1.sprite = number5;
			break;
		case 6:
			image1.sprite = number6;
			break;
		case 7:
			image1.sprite = number7;
			break;
		case 8:
			image1.sprite = number8;
			break;
		case 9:
			image1.sprite = number9;
			break;
		}
		switch(hundred) {
			case 0:
			image2.sprite = number0;
			break;
			case 1:
			image2.sprite = number1;
			break;
			case 2:
			image2.sprite = number2;
			break;
			case 3:
			image2.sprite = number3;
			break;
			case 4:
			image2.sprite = number4;
			break;
			case 5:
			image2.sprite = number5;
			break;
			case 6:
			image2.sprite = number6;
			break;
			case 7:
			image2.sprite = number7;
			break;
			case 8:
			image2.sprite = number8;
			break;
			case 9:
			image2.sprite = number9;
			break;
		}
	}
}
