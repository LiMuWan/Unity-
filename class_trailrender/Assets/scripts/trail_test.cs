using UnityEngine;
using System.Collections;

public class trail_test : MonoBehaviour {
    public TrailRenderer trail;
    float total_time;
	// Use this for initialization
	void Start () {
        this.total_time = 0.0f;
        this.trail.enabled = true; // 开关拖尾
	}
	
	// Update is called once per frame
	void Update () {
        this.total_time += (Time.deltaTime);
        if (this.total_time >= 5) { // 静止了
            // this.trail.enabled = false;
            return;
        }

        float s = Time.deltaTime * 5;
        this.transform.Translate(0, 0, s, Space.World);

        Camera.main.transform.Translate(0, 0, s, Space.World);
	}
}
