using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowedPlayer : MonoBehaviour {

    [SerializeField] private GameObject objectToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = Vector3.Lerp(this.transform.position,
            new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y,
            this.transform.position.z), 300 * Time.deltaTime);
	}
}
