using UnityEngine;
using System.Collections;

public enum SceneName { SceneMain, SceneTitle, SceneResult }

public class SceneManager : MonoBehaviour {

    public GameObject resultCanvas;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetScene(SceneName nextScene)
    {
        Debug.Log("Scene");
        Instantiate(resultCanvas);
    }
}
