using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private static float nowScore;
    private float highScore;
    private Sound sound;
    // Use this for initialization
	void Start () {
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
	}
	
	// Update is called once per frame
	void Update () {
        SetScore();
	}

    public static void IncScore(float score)
    {
        nowScore += score;
        Sound.Instance.PlaySmileSound();
    }
    public static void DecScore(float score)
    {
        nowScore -= score;
    }
    private void SetScore(){
        GetComponent<Text>().text=nowScore.ToString();
    }

}