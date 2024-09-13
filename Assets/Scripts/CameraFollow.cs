using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    void LateUpdate()
    {
        if (GameManager.Instance.playerController != null)
        {
            Vector3 desiredPosition = GameManager.Instance.playerController.transform.position;

            transform.position = new Vector3(desiredPosition.x, desiredPosition.y, transform.position.z);
        }
    }
}