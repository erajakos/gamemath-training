using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpaceConverter : MonoBehaviour
{
    public Transform objTransform;

    public Vector2 localPos;

    private void OnDrawGizmos()
    {
        Vector2 objPos = objTransform.position;
        Vector2 right = objTransform.right;
        Vector2 up = objTransform.up;

        DrawBasisVectors(Vector2.zero, transform.right, transform.up);
        DrawBasisVectors(objPos, right, up);

        // local pos is drawn now in world spce, this is incorrect
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(localPos, 0.05f);

        // Calculate childs world offset in local coordinate system
        Vector2 localPosOnWorld = LocalToWorld(localPos, objTransform);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(localPosOnWorld, 0.05f);
    }

    private Vector2 LocalToWorld(Vector2 localPos, Transform objTransform)
    {
        // direction vectors
        Vector2 right = objTransform.right;
        Vector2 up = objTransform.up;

        Vector2 worldOffset = right * localPos.x + up * localPos.y;
        return (Vector2)objTransform.position + worldOffset;
    }

    private void DrawBasisVectors(Vector2 pos, Vector2 right, Vector2 up)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + right);
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pos, pos + up);
    }
}
