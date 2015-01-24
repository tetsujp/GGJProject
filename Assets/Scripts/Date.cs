using UnityEngine;
using System.Collections;

//プレイヤーキャラクター
public class Date : MonoBehaviour
{

    private bool isInputKey = false;
 //   private SceneManager nextScene;
    // Use this for initialization
    void Start()
    {
   //     nextScene=GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetInputKey();
    }

    private void SetInputKey()
    {
        isInputKey = Input.GetButtonDown("Fire");
    }

}
