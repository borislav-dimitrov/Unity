using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeFollowObject(GameObject followObject) {
        if (followObject && cinemachineCamera.Follow != followObject.transform) {
            cinemachineCamera.Follow = followObject.transform;
        }
    }
}
