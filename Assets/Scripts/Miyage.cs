using UnityEngine;
using System.Collections;

public class Miyage : Guest {


    enum GuestSprite { first, action, smile}
	// Use this for initialization
    public float[] miyageScorePoint;
    override public void HitAction()
    {
        if (!isCheckGuest)
        {
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.action];
        }
    }

    override public void OnTouchDown(Touch tap)
    {
        if (isCollisionToDate&&!isCheckGuest)
        {
            //土産受け取り成功
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.smile];
            Score.IncScore(miyageScorePoint[(int)guestKind]);
            Sound.Instance.PlaySmileSound();
            isCheckGuest=true;
        }
    }
}
