using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] float distanceFromTargetZ;
    [SerializeField] float distanceFromTargetY;
    [SerializeField] float distanceFromTargetX;

    public GameObject target;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(distanceFromTargetX, distanceFromTargetY, distanceFromTargetZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
