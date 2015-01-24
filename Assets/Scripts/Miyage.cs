using UnityEngine;
using System.Collections;

public class Miyage : Guest {


    enum GuestSprite { first, action, smile,miss }
	// Use this for initialization
    public float[] miyageScorePoint;
    override public void HitAction()
    {
        nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.action];
    }

    override public void OnSwipe(SwipeInfo sw)
    {
        //中心に来ている
        if (isCollisionToDate)
        {
            //殺してしまった
            nowSprite.sprite =guestSprite[(int)guestKind].spriteList[(int)GuestSprite.miss];
        }
    }
    override public void OnMultiTap(Tap Tap)
    {
        if (isCollisionToDate&&!isCheckGuest)
        {
            //土産受け取り成功
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.smile];
            Score.IncScore(miyageScorePoint[(int)guestKind]);
            isCheckGuest=true;
        }
    }
}
