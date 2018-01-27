using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public float MenuVolume;
	void Start () {
        AudioListener.volume = MenuVolume;
	}
    public void OnStartGameClic()
    {
        SceneManager.LoadScene("TestScene");
    }
}
