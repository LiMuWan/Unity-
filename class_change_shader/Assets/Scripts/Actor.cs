using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
    public Material mat;
    
    static Shader s_normal = null; // normal
    static Shader s_attack = null; // attack

    private bool is_normal = true;

    Shader get_noraml() {
        if (s_normal) {
            return s_normal;
        }
        // 加载Shader是有开销的, 如果这个Shader没有人使用了，是会被释放的;
        // 在运行的时候，去加载Shader 耗CPU的，预先把这个Shader加载好不就可以了吗？
        // 机制，常用的Shader设置告诉他，那么他会帮你把这个Shader常驻内存;
        // 常用的Shader, 预先加载好
        s_normal = Shader.Find("Toon/Basic"); // Shader的名字
        return s_normal;
    }

    Shader get_outline() {
        if (s_attack) {
            return s_attack;
        }

        s_attack = Shader.Find("Toon/Basic Outline"); //
        return s_attack;
    }

	// Use this for initialization
	void Start () {
        this.mat.shader = this.get_noraml();
        this.is_normal = true;

        this.InvokeRepeating("change_shader", 3, 3);
	}

    void change_shader() {
        if (this.is_normal) { // 描边状态
            this.is_normal = false;
            this.mat.shader = this.get_outline();
        }
        else {
            this.is_normal = true;
            this.mat.shader = this.get_noraml();
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
