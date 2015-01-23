using UnityEngine;
using System.Collections;

public class Composer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rigidbody.velocity =new Vector3(2,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Date")
        {
            renderer.material.color = Color.red;
        }
    }
}
