using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour {

    List<Transform> pickUps;
    bool active;
    public string level;

	// Use this for initialization
	void Start () {
        pickUps = new List<Transform>();
	    foreach(Transform t in GameObject.Find("PickUps").transform)
        {
            pickUps.Add(t);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach(Transform t in pickUps)
            {
                if (t.gameObject.activeSelf == true)
                    break;
                if (pickUps.IndexOf(t) >= pickUps.Count - 1)
                    active = true;
            }

            if (active == true)
                SceneManager.LoadScene(level);
        }
    }
}
