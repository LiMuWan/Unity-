using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 协程:
 * (1)仍然是再主线程里面运行的, 不是多线程;
 * (2)另外一段逻辑处理, 和当前程序在一起协同执行;
 * update 模拟的unity已经帮我们做好了;
 * 
 * IEnumerator: 协程的代码容器对象;
 * 
 * 使用协程：
 * (1): 创建一个函数: IEnumerator 作为返回值;
 * (2): 启动一个协程: 
 */
public class game : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        IEnumerator r = this.do_func(); // IEnumerator 对象, 并没有执行协程;
        // r = this.do_for();
        // r = this.do_wait();
        r = this.do_www();
        Debug.Log("Start Coroutine"); // 1
        // Coroutine c = this.StartCoroutine(r);
        // 终止这个协程
        // this.StopCoroutine(c);
        // this.StartCoroutine("do_wait");
        this.StartCoroutine(r);

        Debug.Log("End Coroutine"); // 3
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 这个地方是协程的处理函数;
    IEnumerator do_func() {
        Debug.Log("do_func"); // 2
        yield return null; // yield return 中断当前的携程程序;
        // yield break; // 终止了整个携程;
        Debug.Log("do_func yield return");// 4
    }

    IEnumerator do_for() {
        for (int i = 0; i < 100; i++) {
            Debug.Log("i = " + i);
            yield return null;
        }

        // yield return null;
    }

    // 不卡主 主线程的情况下，delay 0.3秒后执行
    IEnumerator do_wait() {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("time out");
    }

    IEnumerator do_www() {
        WWW w = new WWW("https://www.baidu.com"); // 创建了w 对象
        yield return w;

        Debug.Log(w.text);
    }
}
