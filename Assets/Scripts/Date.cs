using UnityEngine;
using System.Collections;

//プレイヤーキャラクター
public class Date : MonoBehaviour
{

    private bool isInputKey = false;
    private SceneManager nextScene;
    // Use this for initialization
    void Start()
    {
        nextScene=GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Guest")
        {
            
            if (isInputKey)
            {
                Debug.Log("Fire");
                //キラーではないのに殺した時
                if (!other.gameObject.GetComponent<Guest>().iskiller)
                {
                    nextScene.SetScene(SceneName.SceneResult);
                }
            }
        }
    }

}
