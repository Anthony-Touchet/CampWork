using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

    List<Transform> pickUps;
    Text text;

	// Use this for initialization
	void Start () {
        PlayerController.collectPickUp.AddListener(SetText);
        PlayerController.playerDeath.AddListener(SetText);
        text = gameObject.GetComponent<Text>();
        pickUps = new List<Transform>();
        foreach(Transform t in GameObject.Find("PickUps").transform)
        {
            pickUps.Add(t);
        }
        SetText();
	}
	
	void SetText () {
        int pickUpsLeft = 0;
        foreach (Transform t in pickUps)
        {
            if (t.gameObject.activeSelf == true)
                pickUpsLeft++;
        }

        text.text = "PU Left: " + pickUpsLeft.ToString();
    }
}
