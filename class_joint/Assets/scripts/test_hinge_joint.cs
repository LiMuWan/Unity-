using UnityEngine;
using System.Collections;

public class test_hinge_joint : MonoBehaviour {
    Rigidbody body;
	// Use this for initialization
	void Start () {
        this.body = this.GetComponent<Rigidbody>();
        this.body.AddForce(new Vector3(0, 0, 100));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
