using UnityEngine;
using System.Collections;

public class test_particle : MonoBehaviour {
    ParticleSystem ps;
	// Use this for initialization
	void Start () {
        this.ps = this.GetComponent<ParticleSystem>();
        Debug.Log(this.ps.duration);
        this.Invoke("play_particle", 5);
	}

    void play_particle() {
        this.ps.Play();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (this.ps.isPaused)
            {
                this.ps.Play();
            }
            else {
                this.ps.Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            if (this.ps.isStopped) {
                this.ps.Play();
            }
            else {
                this.ps.Stop();
            }
            
        }
	}
}
