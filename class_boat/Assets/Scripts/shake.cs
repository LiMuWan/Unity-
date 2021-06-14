using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour {
    private float z_w_speed = 3.0f; // 开始是水平的
    private float x_w_speed = 2.0f; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // 当前选转的欧拉角[0, 360]
        if (this.transform.eulerAngles.z >= 4 && this.transform.eulerAngles.z < 180) {
            this.z_w_speed = -this.z_w_speed;
        }
        else if (this.transform.eulerAngles.z <= (360 - 4) && this.transform.eulerAngles.z > 180) {
            this.z_w_speed = -this.z_w_speed;
        }

        if (this.transform.eulerAngles.x >= 4 && this.transform.eulerAngles.x < 180) {
            this.x_w_speed = -this.x_w_speed;
        }
        else if (this.transform.eulerAngles.x <= (360 - 4) && this.transform.eulerAngles.x > 180)
        {
            this.x_w_speed = -this.x_w_speed;
        }
        this.transform.Rotate(this.z_w_speed * Time.deltaTime, 0, this.z_w_speed * Time.deltaTime);
	}
}
