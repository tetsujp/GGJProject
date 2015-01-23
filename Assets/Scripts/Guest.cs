using UnityEngine;
using System.Collections;

public class Guest: MonoBehaviour {

    public float StartPosition;
    public float moveToCenter;//
    public float moveToEnd;
    public float moveSpeed;
    public float delayTime;

    [System.NonSerialized]
    public bool iskiller;
    private Hashtable moveTable = new Hashtable();//iTween用ハッシュ
	// Use this for initialization
	void Start () {
        moveTable.Add("x",moveToCenter);
        moveTable.Add("speed", moveSpeed);
        moveTable.Add("oncomplete", "CompleteHandler");	// トゥイーン終了時にCompleteHandler()を呼ぶ
        iTween.MoveTo(gameObject,moveTable);

        iskiller = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void CompleteHandler()
    {
        SetColor();
        moveTable = new Hashtable();
        moveTable.Add("x",moveToEnd);
        moveTable.Add("speed", moveSpeed);
        moveTable.Add("delay", delayTime);
        moveTable.Add("oncomplete", "EndDestory");
        iTween.MoveTo(gameObject,moveTable);
    }
    private void SetColor()
    {
        renderer.material.color = Color.red;
    }
    //行動が終了したら削除
    private void EndDestory()
    {
        Destroy(gameObject);
    }



}
