using UnityEngine;
using System.Collections;

public class Killer : Guest {


    enum GuestSprite { first, action, smile }
	// Use this for initialization
    public float[] killerScorePoint;
    private bool isNowAction = false;
    float startActionTime;

    
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
                Sound.Instance.KillSount();
                //終了する
                iTween.Stop();
                sceneManager.SetNextScene();
                
            }
        }
    }
    override public void OnSwipe(SwipeInfo sw)
    {
        //中心に来ている
        if (isCollisionToDate&&!isCheckGuest)
        {
            //キラーなので殺せた
            Score.IncScore(killerScorePoint[(int)guestKind]);
            Sound.Instance.PlaySmileSound();
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.smile];
            isClearDeath=true;
            isCheckGuest = true;
        }
    }
    //処理を行わない
    override public void OnTouchDown(Touch tap) 
    {

    }
}
