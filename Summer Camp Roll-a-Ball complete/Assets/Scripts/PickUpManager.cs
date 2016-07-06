using UnityEngine;
using System.Collections;

public class PickUpManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        PlayerController.playerDeath.AddListener(ResetPickups);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ResetPickups()
    {
        foreach(Transform t in transform)
        {
            t.gameObject.SetActive(true);
        }
    }
}
