using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 農民、サラリーマン、足軽、親衛隊、徳川
/// </summary>
public enum GuestKind {nomin,sara,ashigaru,lover,syojo,tokugawa }
public class Guest: MonoBehaviour
{
    //移動用座標
    #region
    //public float StartPosition;
    public float moveToCenter;//
    public float moveToEnd;
    public float moveSpeed;
    public float speedUpValue;//1体毎に時間を早める
    //public float delayTime;

    public float deathTime;//スタートをインスペクターで設定
    public float deathUpValue;
    private Hashtable moveTable = new Hashtable();//iTween用ハッシュ
    public GameObject deathEffect;
    protected bool isClearDeath = false;
    protected SceneManager sceneManager;
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
    [System.NonSerialized]public bool isCheckGuest=false;//スワイプ、タップなどで仕分け終わった
    #endregion
    protected bool isCollisionToDate = false;
    // Use this for initialization
	public void Start () {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        //セット
        IT_Gesture.onSwipeE += OnSwipe;
        //IT_Gesture.onMultiTapE += OnMultiTap;
        IT_Gesture.onTouchDownE += OnTouchDown;
	}
    public void SetGuestKind(GuestKind kind,int count)
    {
        guestKind = kind;
        nowSprite = GetComponent<SpriteRenderer>();
        nowSprite.sprite = guestSprite[(int)guestKind].spriteList[0];
        //アクション
        //
        moveSpeed += speedUpValue*count;
        deathTime -= deathUpValue * count;
        if (deathTime < 0.01f) deathTime = 0.01f;
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
        moveTable.Add("time", moveSpeed);
        moveTable.Add("oncomplete", "CompleteHandler");	// トゥイーン終了時にCompleteHandler()を呼ぶ
        iTween.MoveTo(gameObject, moveTable);

    }
    private void CompleteHandler()
    {
        HitAction();
        moveTable = new Hashtable();
        moveTable.Add("x", moveToEnd);
        moveTable.Add("speed", moveSpeed);
        //moveTable.Add("time", moveSpeed);
        moveTable.Add("delay", deathTime);
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
    public virtual void OnSwipe(SwipeInfo sw){
        //中心に来ている
        if (isCollisionToDate&&!isClearDeath)
        {
            //殺してしまった
            //nowSprite.sprite = guestSprite[(int)guestKind].spriteList[(int)GuestSprite.miss];
            //Score.DecScore(normalScorePoint);
            Instantiate(deathEffect);
            Sound.Instance.KillSount();
            //終了する
            iTween.Stop();
            sceneManager.SetNextScene();
            isClearDeath = true;

        }
    }

    //public virtual void OnMultiTap(Tap tap){}
    public virtual void OnTouchDown(Touch tap) {
    }
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
        //IT_Gesture.onMultiTapE -= OnMultiTap;
        IT_Gesture.onTouchDownE -= OnTouchDown;
    }


}
