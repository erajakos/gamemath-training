using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RadialTrigger : MonoBehaviour
{
    public Transform objTransform;

    [Range(0f, 4f)]
    public float radius = 0f;

    private void OnDrawGizmos()
    {
        Vector2 objPos = objTransform.position;
        Vector2 origin = transform.position;

        float distance = Vector2.Distance(objPos, origin);

        bool isInside = distance < radius;

        Handles.color = isInside ? Color.green : Color.red;

        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), radius);
    }
}
