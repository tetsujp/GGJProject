using UnityEngine;
using System.Collections;

public class NormalGuest : Guest {


    enum GuestSprite { first, action, smile}
    public float[] normalScorePoint;
    bool missFlag = false;
    // Use this for initialization

    override public void HitAction()
    {
        if (!isCheckGuest)
        {
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.action];
            Invoke("Smile", deathTime / 2);
        }
    }
    public void Smile()
    {
        if (!missFlag)
        {
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.smile];
            Score.IncScore(normalScorePoint[(int)guestKind]);
            Sound.Instance.PlaySmileSound();
        }

    }
    override public void OnTouchDown(Touch tap)
    {
        if (isCollisionToDate && !isCheckGuest)
        {
            //ミスタッチ
            nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.first];
            Score.DecScore(normalScorePoint[(int)guestKind]);
            Sound.Instance.MissSound();
            isCheckGuest = true;
            missFlag = true;

        }
    }

}
