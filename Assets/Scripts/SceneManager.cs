using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetNextScene()
    {
        Invoke("InvokeNextScene", 2f);
    }
    void InvokeNextScene()
    {
        Application.LoadLevel("Result");
    }
}
