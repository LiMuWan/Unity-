using UnityEngine;
using System.Collections;

using DG.Tweening; // 添加这个DOTween所在的名字空间

public class dotween_use : MonoBehaviour {
    void on_tween_start() {
        Debug.Log("on_tween_start");
    }

    void on_tween_end() {
        Debug.Log("on_tween_end");
    }

	// Use this for initialization
	void Start () {
        /*
	    // 创建一个补间动画，在5秒之内移动到目标点
        // Tweener t = this.transform.DOMove(new Vector3(0, 0, 10), 5.0f);
        // t = this.transform.DOScale(new Vector3(0, 0, 0), 5.0f);
        Tweener t = this.transform.DORotate(new Vector3(0, 145, 0), 3.0f);
        t.SetLoops(4); // -1无限制
        // this.transform.DOPause(); // 暂停
        // this.transform.DOPlay(); // 开发播放;
        // this.transform.DOKill(); // 
        t.OnStart(this.on_tween_start);
        t.OnComplete(this.on_tween_end); // 大写
        // t.onComplete += this.on_tween_end;
        // end 
         * */

        // 队列容器
        // (1)创建一个队列
        /*Sequence seq = DOTween.Sequence();
        // 将一个Tweener对象放到队列的后面
        seq.Append(this.transform.DOMoveX(10, 5.0f));
        seq.Append(this.transform.DOMoveX(0, 5.0f));
        seq.SetLoops(-1);
        // 插入
        seq.Insert(0, this.transform.DOScale(new Vector3(2, 2, 2), 5.0f));*/

        // Tweener t = this.transform.DORotate(new Vector3(0, 270, 0), 3.0f);
        // t.SetEase(Ease.OutBack);

        this.transform.DOMoveX(4, 3.0f).SetEase(Ease.OutBack);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
