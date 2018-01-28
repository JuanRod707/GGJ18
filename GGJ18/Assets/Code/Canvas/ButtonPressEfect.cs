using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonPressEfect : MonoBehaviour {

	public float HighLigthTimer;
	public Color HighLigth;
	private Color defaultColor;
	private Image myImage;

	void Start(){
		myImage = this.GetComponent<Image>();
		defaultColor = myImage.color;
	}

	public void PressButton(){
		myImage.color = HighLigth;
		StartCoroutine(WaitHightligth());
	}

	private IEnumerator WaitHightligth(){
		yield return new WaitForSeconds(HighLigthTimer);
		ResetButtonColor();
	}
	private void ResetButtonColor(){
		myImage.color = defaultColor;
	}
}
