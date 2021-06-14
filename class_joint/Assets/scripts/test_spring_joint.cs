using UnityEngine;
using System.Collections;

public class test_spring_joint : MonoBehaviour {

    Rigidbody body;
    // Use this for initialization
    void Start()
    {
        this.body = this.GetComponent<Rigidbody>();
        this.body.AddForce(new Vector3(200, 0, 0));
    }
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
