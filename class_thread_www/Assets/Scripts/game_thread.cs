using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 多线程使用的名字空间
using System.Threading;

/*
 * step1: 创建一个线程对象;
 * step2: 线程对象运行起来;
 */ 

public class game_thread : MonoBehaviour {
    int a = 4;
    Thread r;

    public static Object o = new Object(); 

	// Use this for initialization
	void Start () {
        r = new Thread(this.thread_with_no_params);
        // r.Start("HelloWorld");
        r.Start();

        // 先后，是不确定的，是OS调度的结果;
        // this.thread_with_params("Test");

        // ManagedThreadId 管理的ID 

        /*
        lock (o) {
            Debug.Log("main begin");
            Debug.Log(Thread.CurrentThread.ManagedThreadId);
            Debug.Log("main end");
        }*/
        
	}

    void thread_with_no_params() {
        lock (o) { // 如果有人占用了，那么就要挂起
            Debug.Log("start lock " + Thread.CurrentThread.ManagedThreadId);
            Debug.Log("thread_with_no_params " + this.a);
            Thread.Sleep(5000); // 
            Debug.Log("end thread_with_no_params");
            Debug.Log("end lock");
        } // 释放这个锁，其它的人才可以继续获得;
    }

    // 线程入口函数
    void thread_with_params(object obj) { 
        //  
        
        string obj_str = (string)obj;
        Debug.Log(obj_str);
        // end 
        // 挂起, 等在条件上， 等在 同步上，休眠;
    }

	// Update is called once per frame
	void Update () {
        lock (o)
        {
            Debug.Log("update");
        }
	}
}
