using UnityEngine;
using System.Collections.Generic;

public class EnemyPatrol : MonoBehaviour {

    public List<Transform> points;
    public float speed;
    int currentpoint;

	void Start () {
        PlayerController.playerDeath.AddListener(ResetEnemies);
        transform.position = points[0].position;
        currentpoint = 0;
	}
	
	void FixedUpdate () {
        if (IsClose(gameObject.transform, points[currentpoint], .1f))
        {
            currentpoint++;    
        }

        if (currentpoint >= points.Count)
        {
            currentpoint = 0;
        }
        Vector3 dist = points[currentpoint].position - gameObject.transform.position;
        transform.Translate(dist.normalized * speed * Time.deltaTime);
	}

    bool IsClose(Transform self, Transform target, float radius)
    {
        if ((self.position.x - radius) <= target.position.x && target.position.x <= (self.position.x + radius))
        {
            if ((self.position.z - radius) <= target.position.z && target.position.z <= (self.position.z + radius))
            {
                return true;
            }
        }
        return false;
    }

    void ResetEnemies()
    {
        transform.position = points[0].position;
        currentpoint = 0;
    }
}
