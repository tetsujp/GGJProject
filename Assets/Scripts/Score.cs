using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static float nowScore;
    public static float MaxScore = 10000;//仮決め
    public float highScore;
    private Sound sound;
    // Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<Sound>();
	}
	
	// Update is called once per frame
	void Update () {
        SetScore();
	}

    public static void IncScore(float score)
    {
        nowScore += score;
        if (nowScore > MaxScore) nowScore = MaxScore;
        //Sound.Instance.PlaySmileSound();
    }
    public static void DecScore(float score)
    {
        nowScore -= score;
    }
    private void SetScore(){
        GetComponent<Text>().text=nowScore.ToString();
    }

}