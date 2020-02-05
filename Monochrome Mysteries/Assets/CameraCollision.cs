using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDist = 1.0f;
    public float maxDist = 20.0f;
    public float smooth = 10.0f;
    public float distance;
    Vector3 collision;


	void Awake()
    {
        collision = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 desiredCam = transform.parent.TransformPoint(collision * maxDist);
        RaycastHit hit = new RaycastHit();

        if (Physics.Linecast(transform.parent.position, desiredCam, out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.9f, minDist, maxDist);
        }
        else
        {
            distance = maxDist;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, collision * distance, Time.deltaTime * smooth);
    }

}
