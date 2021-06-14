using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// 声明一个可序列化的对象
// 对象里面的public成员，做序列化
// [System.Serializable]
[Serializable]
class sub {
    public string sub_name = "sub_name";
}

[Serializable]
class my_object {
    public int a = 3;
    public int b = 4;
    public string age = "blake";

    // 不是public,又想序列化?
    [SerializeField] // 可序列化的字段
    bool is_male = true;

    public int[] int_array;

    public sub s;
}
public class game_scene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // 数组
        /*
	    // string, 数组
        string[] str_array = new string[]{"yes", "blake", "hello"};
        int[] int_array = new int[100];

        // 索引来访问0, 
        int_array[0] = 1;
        int_array[1] = 2;
        // end 

        Debug.Log("Length = " + int_array.Length);
        // 连续的内存, 访问速度快, 大小是固定，已经创建就不能加大/缩小;
        */

        // ArrayList
        /*
        // 大小是灵活的，不是一开始写死的
        // 所有的操作都是Object;
        ArrayList array_list = new ArrayList();

        // 同一个list里面我可以是不同类型的数据;
        array_list.Add("string");
        array_list.Add(true);
        array_list.Add(false);
        array_list.Add(100);
        array_list.Add(10.5f);

        // array_list是把所有的对象都当作Object来处理
        // [索引]访问, 0开始
        string a = (string)array_list[0];
        Debug.Log(a);
        array_list.RemoveAt(0); // 删除第0个元素
        array_list[0] = false;
        bool e = (bool)array_list[0];
        Debug.Log(e);
        */

        /*
        // List<T>
        // List<T> 指定模板，那么List就是存放这种数据类型
        List<float> float_list = new List<float>();
        float_list.Add(5.3f);
        float_list.Add(5.4f);

        // 访问,读写
        Debug.Log(float_list[0]);
        float_list[1] = 8;
        Debug.Log(float_list[1]);
        Debug.Log(float_list.Count);
        float_list.RemoveAt(0);
        Debug.Log(float_list.Count);
         * */

        /*
        // 字典  key, value key(模板string, int..), value(模板...)
        // "string" ---key --> float;
        Dictionary<string, float> dict = new Dictionary<string,float>();
        dict.Add("speed", 100.0f);
        dict.Add("Attack", 20.0f);

        Debug.Log(dict.Count); // 2

        Debug.Log(dict["speed"]); // 100.0f
        dict["speed"] = 3.0f;
        Debug.Log(dict["speed"]); // 3.0f

        dict.Remove("Attack");
        Debug.Log(dict.Count); // 1*/

        // JSON
        // (1) 标记要序列化的对象，是可序列化的
        my_object obj = new my_object();
        obj.int_array = new int[]{1, 2, 3};
        obj.s = new sub();

        // (2) 内存数据对象，序列化成json字符串
        string json_string = JsonUtility.ToJson(obj);
        Debug.Log(json_string); // 存储，传输

        // json反序列化;
        // 
        my_object obj2 = new my_object();
        JsonUtility.FromJsonOverwrite(json_string, obj2);
        Debug.Log(obj2.int_array[1]); // 1

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
