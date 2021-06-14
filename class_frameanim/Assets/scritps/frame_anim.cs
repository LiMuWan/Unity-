using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// 我们当前代码强制要求要加入一个Image组件，
// 如果没有Image组件，那么自动加上，如果有就使用；
// 如果你的代码要求这个节点必须挂某个组件，那么
// 使用RequireComponent
[RequireComponent(typeof(Image))]

public class frame_anim : MonoBehaviour {
    // 我们这个动画所需要的画面;
    public Sprite[] sprite_frames;
    // 帧动画的间隔时间
    public float duration = 0.1f;
    // 是否循环播放
    public bool is_loop = false;
    // 是否在加载的时候开始播放;
    public bool play_onload = false;

    private float played_time;
    private bool is_playing = false;

    private Image img;
	// Use this for initialization
	void Start () {
        this.img = this.GetComponent<Image>();
        if (this.play_onload) {
            if (this.is_loop) {
                this.play_loop();
            }
            else {
                this.play_once();
            }
        }
	}

    // 只播放一次
    void play_once() {
        if (this.sprite_frames.Length <= 1) {
            return;
        }

        this.played_time = 0;
        this.is_playing = true;
        this.is_loop = false;
    }

    // 循环播放
    void play_loop() {
        if (this.sprite_frames.Length <= 1) {
            return;
        }
        this.played_time = 0;
        this.is_playing = true;
        this.is_loop = true;
    }
    // 停止当前的动画播放
    void stop_anim() {
        this.is_playing = false;
    }
	// Update is called once per frame
	void Update () {
        if (this.is_playing == false) {
            return;
        }

        // 
        float dt = Time.deltaTime;
        this.played_time += dt;
        // 向下取整;
        int index = (int)(this.played_time / this.duration);
        if (this.is_loop == false) {
            // 结束了
            if (index >= this.sprite_frames.Length) { // 停止播放
                this.is_playing = false;
                this.played_time = 0;
            }
            else {
                this.img.sprite = this.sprite_frames[index];
            }
        }
        else {
            // 超过了范围，减掉一个周期
            while (index >= this.sprite_frames.Length) {
                this.played_time -= (this.duration * this.sprite_frames.Length);
                index -= this.sprite_frames.Length;
            }

            this.img.sprite = this.sprite_frames[index];
        }
        // end 
	}
}
