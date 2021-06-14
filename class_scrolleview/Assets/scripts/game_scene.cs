using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game_scene : MonoBehaviour {
    public GameObject item_prefab;
    public GameObject rank_prefab;

    public ScrollRect rank;
	// Use this for initialization
	void Start () {
	    /*GameObject item = GameObject.Instantiate(this.item_prefab);
        item.transform.SetParent(this.transform);
        item.transform.localPosition = new Vector3(0, 0, 0); */
        
        // rect transorm
        this.rank.content.sizeDelta = new Vector2(0, 20 * 160);

        for (int i = 0; i < 20; i++) {
            GameObject opt = GameObject.Instantiate(this.rank_prefab);
            opt.transform.SetParent(this.rank.content);
            opt.transform.Find("unick").GetComponent<Text>().text = "" + (i + 1);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
