using UnityEngine;
using System.Collections;

public class Killer : Guest {


    enum GuestSprite { first, action, smile }
	// Use this for initialization
    public float[] killerScorePoint;
    public GameObject deathEffect;
    private bool isClearDeath=false;
    private bool isNowAction = false;
    float startActionTime;
    public float deathTime;//スタートをインスペクターで設定
    private SceneManager sceneManager;

    void Start()
    {
        base.Start();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
    }
    override public void HitAction()
    {
        nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.action];
        startActionTime = Time.time;
        isNowAction = true;
    }
    void Update()
    {
        CheckDeath();
    }
    void CheckDeath()
    {
        if (!isClearDeath&&isNowAction)
        {
            //時間を越える→死亡
            if (Time.time -startActionTime> deathTime)
            {
                isClearDeath = true;
                Instantiate(deathEffect);
                //終了する
                iTween.Stop();
                sceneManager.SetNextScene();
                
            }
        }
    }
    override public void OnSwipe(SwipeInfo sw)
    {
        //中心に来ている
        if (isCollisionToDate)
        {
            //キラーなので殺せた
            Score.IncScore(killerScorePoint[(int)guestKind]);
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.smile];
            isClearDeath=true;
        }
    }
    //処理を行わない
    override public void OnMultiTap(Tap Tap)
    {

    }
}
