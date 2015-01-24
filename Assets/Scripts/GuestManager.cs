using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//ゲストを作成、削除
public class GuestManager : MonoBehaviour {

    public GameObject[] prefabGuest;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckCreate();
	}

    //作成するか
    private void CheckCreate()
    {
        if (GameObject.FindGameObjectsWithTag("Guest").ToList().Count == 0)
        {
            CreateGuest();
        }
    }
    //作成
    private void CreateGuest()
    {
        Instantiate(prefabGuest[Random.Range(0,3)]);
    }
}
