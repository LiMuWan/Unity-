using UnityEngine;
using System.Collections;

public class audio_test : MonoBehaviour {

    public AudioSource s;
	// Use this for initialization
	void Start () {
        // 声音的全局设置
        AudioConfiguration audio_config = AudioSettings.GetConfiguration();
        AudioSettings.Reset(audio_config);
        // end 

        // this.s.Play();
        this.s.PlayDelayed(5);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            if (this.s.isPlaying)
            {
                this.s.Pause();
            }
            else {
                this.s.Play();
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            this.s.Stop();
        }
	}
}
