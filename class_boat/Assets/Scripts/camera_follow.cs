using UnityEngine;
using System.Collections;

public class camera_follow : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.target == null) {
            return;
        }

        // (1)摄像机移动到当前的物体所在的位置
        this.transform.position = this.target.position;
        // (2)往后拉4米
        Quaternion rot = Quaternion.Euler(0, this.target.eulerAngles.y, 0);
        this.transform.position -= rot * Vector3.forward * 4;

        // (3)将摄像机抬高一米
        Vector3 position = this.transform.position;
        position.y += 1;
        this.transform.position = position;
        // (4) 摄像机对准某个物体
        this.transform.LookAt(this.target);
	}
}
