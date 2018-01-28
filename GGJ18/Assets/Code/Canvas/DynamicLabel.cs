using UnityEngine;
using UnityEngine.UI;
public class DynamicLabel : MonoBehaviour {

	public string Format;
	
	private Text myText;

	void Start () {
		myText = this.GetComponent<Text>();
	}
	
	public void SetLabel(params object[] values){
		myText = myText == null ? this.GetComponent<Text>() : myText;
		myText.text = string.Format(Format, values);
	}
}
