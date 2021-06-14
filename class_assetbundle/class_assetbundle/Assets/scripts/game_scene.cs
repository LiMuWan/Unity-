using UnityEngine;
using System.Collections;

public class game_scene : MonoBehaviour {
    public string url;
    public int version; // 自己控制的，
	// Use this for initialization
	void Start () {
        // this.StartCoroutine(this.nocache_load());
        this.StartCoroutine(this.cache_load());
	}

    //下载assetbundle,不缓存在本地
    IEnumerator nocache_load() {
        WWW w = new WWW(this.url);
        yield return w;

        // 下载完成;
        Debug.Log("download end");
        if (w.error != null) {
            Debug.Log(w.error);
        }
        // 内存镜像, assetbundle, 
        AssetBundle bundle = w.assetBundle;
        Debug.Log("download success...");
        // end 

        // 使用里面的资源

        Object prefab = bundle.LoadAsset("Assets/res/Cube.prefab");
        GameObject obj = (GameObject)Instantiate(prefab);
        obj.transform.parent = this.transform;
        // end 

        // 协助AssetBundle镜像, 压缩镜像
        bundle.Unload(false); // 只会卸载assetbundle内存镜像
        // bundle.Unload(true); // 会卸载内存镜像，也会释放掉从这个assetbunle里面加载起来的资源;
        // end 
    }

    IEnumerator cache_load() {
        WWW w = WWW.LoadFromCacheOrDownload(this.url, this.version);
        yield return w;
        // 下载完成;
        Debug.Log("download end");
        if (w.error != null) {
            Debug.Log(w.error);
        }
        // 内存镜像, assetbundle, 
        AssetBundle bundle = w.assetBundle;
        Debug.Log("download success...");
        // end 

        // 使用里面的资源

        Object prefab = bundle.LoadAsset("Assets/res/Cube.prefab");
        GameObject obj = (GameObject)Instantiate(prefab);
        obj.transform.parent = this.transform;
        // end 

        // 协助AssetBundle镜像, 压缩镜像
        bundle.Unload(false); // 只会卸载assetbundle内存镜像
        // bundle.Unload(true); // 会卸载内存镜像，也会释放掉从这个assetbunle里面加载起来的资源;
        // end 
    }
    // 下载assetbundle, nocache, cache, version
    // end 
	// Update is called once per frame
	void Update () {
	
	}
}
