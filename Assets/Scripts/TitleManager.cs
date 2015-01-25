using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject manualCanvas;
    public GameObject startCanvas;
	void Start () {

        menuCanvas.SetActive(false);
        manualCanvas.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetMenuCanvas()
    {
        startCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        manualCanvas.SetActive(false);
    }
    public void SetManualCanvas()
    {

        startCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        manualCanvas.SetActive(true);
    }
    public void SetStart()
    {
        Application.LoadLevel("main");
    }
}
