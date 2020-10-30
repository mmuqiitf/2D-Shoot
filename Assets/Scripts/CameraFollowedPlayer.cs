using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowedPlayer : MonoBehaviour {

    [SerializeField] private Transform objectToFollow;

    private float nextTimeToSearch = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (objectToFollow == null)
        {
            FindPlayer();
            return;
        }

        Camera.main.transform.position = Vector3.Lerp(this.transform.position,
            new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y + 2,
            this.transform.position.z), 300 * Time.deltaTime);

	}

    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
            if (searchResult != null)
            {
                objectToFollow = searchResult.transform;
                nextTimeToSearch = Time.time + 0.5f;
            }
        }
    }

}
