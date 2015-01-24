using UnityEngine;
using System.Collections;

public class NormalGuest : Guest {


    enum GuestSprite { first, action, smile,miss }
    public float[] normalScorePoint;
	// Use this for initialization

    override public void HitAction()
    {
        nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.action];
        Score.IncScore(normalScorePoint[(int)guestKind]);
    }
    override public void OnSwipe(SwipeInfo sw)
    {
        //中心に来ている
        if (isCollisionToDate)
        {
            //殺してしまった
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.miss];
            //Score.DecScore(normalScorePoint);
 //tweet
            //string text = "ついーとやで";
            //Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(text));
        }
    }
}
