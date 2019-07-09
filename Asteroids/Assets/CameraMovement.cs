using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform targetTransform;
    private Transform cachedTransform;
    private Vector2 cameraPositionShift = Vector2.zero;

    public void Init(Transform targetTransform)
    {
        cachedTransform = transform;
        this.targetTransform = targetTransform;

        if (this.targetTransform != null)
        {
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            cameraPositionShift = targetTransform.position - cachedTransform.position;
            cachedTransform.Translate(cameraPositionShift);
            yield return null;
        }
    }
}
