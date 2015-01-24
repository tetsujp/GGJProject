using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 農民、サラリーマン、足軽、親衛隊、徳川
/// </summary>
public enum GuestKind {nomin,sara,ashigaru,lover,tokugawa }
public class Guest: MonoBehaviour
{
    //移動用座標
    #region
    //public float StartPosition;
    public float moveToCenter;//
    public float moveToEnd;
    public float moveSpeed;
    public float delayTime;
    private Hashtable moveTable = new Hashtable();//iTween用ハッシュ
    #endregion
    //Sprite
    #region
    protected GuestKind guestKind;
    //public List<Sprite[]> guestSprite;

    [System.Serializable]
    public class SpriteList
    {
        public List<Sprite> spriteList;
    }
    public List<SpriteList> guestSprite;

    protected SpriteRenderer nowSprite;
    #endregion
    //状態
    #region
    //public bool iskiller;//暗殺者、スワイプできなかったらゲームオーバー
    //public bool isMiyage;//差し入れ、タップできたらスコアアップ
    [System.NonSerialized]public bool isCheckGuest;//スワイプ、タップなどで仕分け終わった
    #endregion
    protected bool isCollisionToDate = false;


    // Use this for initialization
	void Start () {

        guestKind=GetGuestKind();
        nowSprite = GetComponent<SpriteRenderer>();
        nowSprite.sprite = guestSprite[(int)guestKind].spriteList[0];
        //セット
        IT_Gesture.onSwipeE += OnSwipe;
        IT_Gesture.onMultiTapE += OnMultiTap;
        //アクション
        StartTween();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //移動用
    #region
    private void StartTween()
    {
        moveTable.Add("x", moveToCenter);
        moveTable.Add("speed", moveSpeed);
        moveTable.Add("oncomplete", "CompleteHandler");	// トゥイーン終了時にCompleteHandler()を呼ぶ
        iTween.MoveTo(gameObject, moveTable);

    }
    private void CompleteHandler()
    {
        HitAction();
        moveTable = new Hashtable();
        moveTable.Add("x", moveToEnd);
        moveTable.Add("speed", moveSpeed);
        moveTable.Add("delay", delayTime);
        moveTable.Add("oncomplete", "EndDestory");
        iTween.MoveTo(gameObject, moveTable);
    }
    #endregion
    //移動後の行動を継承させる
    public virtual void HitAction(){}
        //行動が終了したら削除
    private void EndDestory()
    {
        Destroy(gameObject);
    }
    //入力
    #region
    public virtual void OnSwipe(SwipeInfo sw){}

    public virtual void OnMultiTap(Tap tap){}
    #endregion
    //当たり判定
    #region
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Date")
        {
            isCollisionToDate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Date")
        {
            isCollisionToDate = false;
        }
    }
    #endregion
    void OnDestroy()
    {
        IT_Gesture.onSwipeE -= OnSwipe;
        IT_Gesture.onMultiTapE -= OnMultiTap;
    }
    private GuestKind GetGuestKind()
    {
        return GuestKind.ashigaru;
        //Random.Range();
    }

}
