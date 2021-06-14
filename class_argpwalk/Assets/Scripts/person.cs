using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DIR {
    INVALID_DIR = -1,
    UP = 0,
    DOWN = 1,
    LEFT = 2,
    RIGHT = 3,
    RU = 4, 
    LU = 5,
    LD = 6,
    RD = 7,
}

public class person : MonoBehaviour {
    float move_speed = 8.0f;
    CharacterController c_ctrl;

    public EasyJoystick joystick;
    float[] x_set;
    float[] z_set;
    float[] rot_set;
    Vector3 camera_offset;

    // Use this for initialization
    void Start () {
        this.c_ctrl = this.GetComponent<CharacterController>();

        this.x_set = new float[8]{0, 0, -1, 1, 0.707f, -0.707f, -0.707f, 0.707f };
        this.z_set = new float[8]{1, -1, 0, 0, 0.707f, 0.707f, -0.707f, -0.707f };
        this.rot_set = new float[8]{0, 180, -90, 90, 45, -45, -135, 135};

        this.camera_offset = Camera.main.transform.position - this.transform.position;
    }

    int get_dir(float r) {
        if (r >= -Mathf.PI && r < -7 * Mathf.PI / 8)
        { // 左边
            return (int)DIR.LEFT;
        }
        else if (r >= -7 * Mathf.PI / 8 && r < -5 * Mathf.PI / 8) {
            return (int)DIR.LD;
        }
        else if (r >= -5 * Mathf.PI / 8 && r < -3 * Mathf.PI / 8) {
            return (int)DIR.DOWN;
        }
        else if (r >= -3 * Mathf.PI / 8 && r < -1 * Mathf.PI / 8) {
            return (int)DIR.RD;
        }
        else if (r >= -1 * Mathf.PI / 8 && r < 1 * Mathf.PI / 8) {
            return (int)DIR.RIGHT;
        }
        else if (r >= 1 * Mathf.PI / 8 && r < 3 * Mathf.PI / 8) {
            return (int)DIR.RU;
        }
        else if (r >= 3 * Mathf.PI / 8 && r < 5 * Mathf.PI / 8)
        {
            return (int)DIR.UP;
        }
        else if (r >= 5 * Mathf.PI / 8 && r < 7 * Mathf.PI / 8)
        {
            return (int)DIR.LU;
        }
        else if (r >= 7 * Mathf.PI / 8 && r < 8 * Mathf.PI / 8)
        {
            return (int)DIR.LEFT;
        }
        return (int)DIR.INVALID_DIR;
    }

    void walk_update() {
        float x = this.joystick.JoystickTouch.x;
        float y = this.joystick.JoystickTouch.y;
        float len = (x * x + y * y);
        if (len < (0.5f * 0.5f)) {
            return;
        }

        // 获取这个方向
        float r = Mathf.Atan2(y, x); // 反三角函数, 向量的角度, [-PI, PI]
        int dir = this.get_dir(r);
        if (dir != (int)DIR.INVALID_DIR) {
            float s = this.move_speed * Time.deltaTime;
            Vector3 offset = new Vector3(s * this.x_set[dir], 0, s * this.z_set[dir]);
            this.c_ctrl.Move(offset);

            // 切换人物行走的朝向
            Vector3 e_rot = this.transform.eulerAngles;
            e_rot.y = this.rot_set[dir];
            this.transform.eulerAngles = e_rot;
            // end 
        }
        // end 
    }

    // Update is called once per frame
    void Update () {
        this.walk_update();
        Camera.main.transform.position = this.transform.position + this.camera_offset;
    }
}
