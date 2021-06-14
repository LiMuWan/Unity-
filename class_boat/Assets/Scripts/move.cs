using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    private float speed = 5.0f;
    private float w_speed = 120;

    public EasyJoystick joystick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // 往后[-0.5, -1]
        if (this.joystick.JoystickTouch.y < -0.5f) {
            this.transform.Translate(0, 0, -this.speed * Time.deltaTime);
        }
        else if (this.joystick.JoystickTouch.y > 0.5f) {  // [0.5, 1]
            this.transform.Translate(0, 0, this.speed * Time.deltaTime);
        }

        if (this.joystick.JoystickTouch.x < -0.5f) {
            this.transform.Rotate(0, -this.w_speed * Time.deltaTime, 0);
        }
        else if (this.joystick.JoystickTouch.x > 0.5f) {
            this.transform.Rotate(0, this.w_speed * Time.deltaTime, 0);
        }
	}
}
