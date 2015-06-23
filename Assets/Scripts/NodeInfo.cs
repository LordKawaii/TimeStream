using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeInfo : MonoBehaviour {
    public NodeType nodeType;
    public List<Transform> connectedNodes;

    void OnDrawGizmos()
    {
        if (connectedNodes.Count <= 0)
        {
            return;
        }
        else
            foreach (Transform nTransform in connectedNodes)
            {
                if (nTransform != null)
                    Gizmos.DrawLine(transform.position, nTransform.position);
            }
    }
}
