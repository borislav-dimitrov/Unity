using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;

    public void ChangeFollowObject(GameObject followObject) {
        if (followObject && cinemachineCamera.Follow != followObject.transform) {
            cinemachineCamera.Follow = followObject.transform;
        }
    }
}
