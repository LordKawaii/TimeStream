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
                {
                    NodeType connectecNodeType = nTransform.gameObject.GetComponent<NodeInfo>().nodeType;
                    switch (connectecNodeType)
                    { 
                        case NodeType.Brave:
                            {
                                Gizmos.color = Color.red;
                                Gizmos.DrawLine(transform.position, nTransform.position);
                                break;
                            }
                        case NodeType.Timid:
                            {
                                Gizmos.color = Color.yellow;
                                Gizmos.DrawLine(transform.position, nTransform.position);
                                break;
                            }
                        case NodeType.Curious:
                            {
                                Gizmos.color = Color.cyan;
                                Gizmos.DrawLine(transform.position, nTransform.position);
                                break;
                            }
                        case NodeType.Direct:
                            {
                                Gizmos.color = Color.black;
                                Gizmos.DrawLine(transform.position, nTransform.position);
                                break;
                            }
                    }
                    
                }
            }
    }
}
