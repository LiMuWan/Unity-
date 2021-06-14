using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameApp : MonoBehaviour
{

    public void EnterGame() {
        // this.StartCoroutine(this.getBaidu());
        // this.StartCoroutine(this.GetUploadData());
        // this.StartCoroutine(this.ReadResVersion());
        // this.StartCoroutine(this.downloadResFile());
        this.StartCoroutine(this.uploadFile());
    }

    IEnumerator uploadFile() {
        string fileName = Application.persistentDataPath + "/80000.mp3";
        byte[] body = GameUtility.SafeReadAllBytes(fileName);

        UnityWebRequest req = UnityWebRequest.Put("http://127.0.0.1:6080/UploadFile", body);
        yield return req.SendWebRequest();

        Debug.Log(req.downloadHandler.text);
        
        yield break;
    }


    IEnumerator downloadResFile() {
        string url = "http://127.0.0.1:6080/Sounds/Audio_Bg_LogOn.mp3";
        UnityWebRequest req = UnityWebRequest.Get(url);
        yield return req.SendWebRequest();

        byte[] body = req.downloadHandler.data;

        // 保存到你的本地,  C#读写文件就可以了;
        string fileName = Application.persistentDataPath + "/80000.mp3";
        Debug.Log(fileName);

        GameUtility.SafeWriteAllBytes(fileName, body);
        yield break;
    }

    IEnumerator ReadResVersion() {
        UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/version.txt");
        yield return req.SendWebRequest();

        Debug.Log(req.downloadHandler.text);

        yield break;
    }

    IEnumerator getBaidu() {
        UnityWebRequest req = UnityWebRequest.Get("http://www.baidu.com");
        yield return req.SendWebRequest(); // 不卡住，然后住线程做别的，请求返回后;


        Debug.Log("Success");
        Debug.Log(req.downloadHandler.text);
    }

    IEnumerator GetUploadData() {
        UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/uploadData?uname=blake&upwd=123456") ;
        yield return req.SendWebRequest(); // 不卡住，然后住线程做别的，请求返回后;

        Debug.Log(req.downloadHandler.text);
    } 
}
