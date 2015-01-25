using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour {

	// Use this for initialization
    //Score score;
    public GameObject scoreText;
    public Sprite[] syogoPanel;
    public GameObject syogo;
	void Start () {
        scoreText.GetComponent<Text>().text = Score.nowScore.ToString();
        SetPanel();
        
	}
    void SetPanel()
    {
        syogo.GetComponent<Image>().sprite=syogoPanel[(int)(Score.nowScore/Score.MaxScore*syogoPanel.Length)];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnDisable()
    {
        Score.nowScore = 0;
    }
    public void Tweet()
    {
        //tweet
        string text = string.Format("{0}人を従えた!! #ggj15",(int)Score.nowScore);
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(text));
    }
    public void SetNextScene()
    {
        Application.LoadLevel("Title");
    }
}
