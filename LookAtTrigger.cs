using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LookAtTrigger : MonoBehaviour
{
    public Transform objTransform;

    public float threshold;

    private void OnDrawGizmos()
    {
        Vector2 objPos = objTransform.position;
        Vector2 origin = transform.position;

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, Vector2.up);
        
        Vector2 toObjPos = objPos - origin;
        threshold = Vector2.Dot(Vector2.up, toObjPos.normalized);
        Debug.Log(threshold);
        Gizmos.color = threshold >= 0.2 ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, objPos);

    }
}
