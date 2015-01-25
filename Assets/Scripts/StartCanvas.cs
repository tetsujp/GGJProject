using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour {

	// Use this for initialization

    public GameObject CanvasMoveButton;
    //private Text messageText;
    //public GameObject messageText;
    public float moveToEnd;
    public float moveSpeed;
    void Start()
    {
        /*messageText = GetComponent<Text>();
        messageText.text = "";
        messageText.text += "時は戦国…　「アイドル戦国時代」！！\n";
        messageText.text += "多くの猛者が名乗りを上げては、時代の波に飲まれ散っていった…\n";
        messageText.text += "大人気『戦国アイドル　伊達政宗（仮）』\n";
        messageText.text += "彼女もまた、この時代に覇を唱える猛者の一人\n";
        messageText.text += "人気者故に、彼女は常に命を狙われている\n";
        messageText.text += "伊達政宗は、アイドルの戦場…　「握手会」へ出陣する\n";
        messageText.text += "君は、彼女の命を守りきれるか！？\n";
        messageText.text += "今…　戦国乱世の歴史が動く！！\n";
        //messageText.text += "（Let’s Party!!）\n";
        */
        
//        iTween.MoveTo(messageText.gameObject,moveTable);
        rigidbody.velocity+= new Vector3(0,moveSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.y > moveToEnd)
        {
            rigidbody.velocity = Vector3.zero;

            CanvasMoveButton.SetActive(true);
            //Debug.Log("next");
        }
	}
    //public void SetNextCanvas(Tap tap)
    //{
    //        menuCanvas.SetActive(true);
    //        gameObject.SetActive(false);
    //}
    //void OnDisable()
    //{
    //    IT_Gesture.onMultiTapE -= SetNextCanvas;

    //}
}
