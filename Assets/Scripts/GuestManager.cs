using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//ゲストを作成、削除
public class GuestManager : MonoBehaviour {

    //キャラごとのstate確率
    [System.Serializable]
    public class PrefabGuestProbability
    {
        public GameObject[] prefab;
        public float[] probability;
    }
    //Guestの全GameObject
    public PrefabGuestProbability[] prefabGuest;
    //どのキャラがでるかの確率
    public float[] guestKindProbability;
    private float sumProbability;
	// Use this for initialization
	void Start () {
        //確率の合計
	    foreach(var pro in guestKindProbability)sumProbability+=pro;
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
        //ランダムで生成
        //どのキャラを生成するかGuestKind
        float randGuest = Random.Range(0, sumProbability);
        float sumGuest=0;
        bool instanceFlag = false;
        for(int guest=0;guest<guestKindProbability.ToArray().Length;guest++){
            sumGuest += guestKindProbability[guest];
            if (randGuest < sumGuest)
            {
                //生成するキャラ確定
                //killer,normal,miyageの決定
                float sumStateProbability=0;
                foreach(var pro in prefabGuest[guest].probability)sumStateProbability+=pro;
                float randState = Random.Range(0, sumStateProbability);
                float sumState = 0;
                for (int state = 0; state < prefabGuest.ToArray().Length; state++)
                {
                    sumState += prefabGuest[guest].probability[state];
                    if (randState < sumState)
                    {
                        //生成
                        GameObject instance= (GameObject)Instantiate(prefabGuest[guest].prefab[state]);
                        //スプライト設定
                        instance.GetComponent<Guest>().SetGuestKind((GuestKind)guest);
                        instanceFlag = true;
                        break;
                    }
                }
            }
            if (instanceFlag) break;
        }
    }
}
