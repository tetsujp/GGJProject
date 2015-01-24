using UnityEngine;
using System.Collections;

public class Killer : Guest {


    enum GuestSprite { first, action, smile }
	// Use this for initialization
    public float[] killerScorePoint;


    override public void HitAction()
    {
        nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.action];
    }
    override public void OnSwipe(SwipeInfo sw)
    {
        //中心に来ている
        if (isCollisionToDate)
        {
            //キラーなので殺せた
            Score.IncScore(killerScorePoint[(int)guestKind]);
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.smile];
        }
    }
    //処理を行わない
    override public void OnMultiTap(Tap Tap)
    {

    }
}
