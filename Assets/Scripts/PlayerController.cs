using UnityEngine;
using System.Collections;

public class PlayerController : PersonController {
    public bool isBrave = false;
    public bool isCurious = false;

    void OnTriggerEnter2d(Collision2D other)
    {
        if (transform.position == nextNode.position)
        {
            if (nextNodeInfo.connectedNodes.Count > 0)
            {
                bool foundNode = false; //Used to brake out of the ForEach loop after the correct node is found.
                foreach (Transform nTransform in nextNodeInfo.connectedNodes)
                {
                    NodeType nodeType;
                    nodeType = nTransform.GetComponent<NodeInfo>().nodeType;

                    if (foundNode)
                        break;

                    switch (nodeType)
                    {
                        case NodeType.Curious:
                            {
                                if (isCurious)
                                {
                                    swapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        case NodeType.Direct:
                            {
                                if (!isCurious)
                                {
                                    swapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        case NodeType.Brave:
                            {
                                if (isBrave)
                                {
                                    swapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        case NodeType.Timid:
                            {
                                if (!isBrave)
                                {
                                    swapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        default:
                            {
                                Transform tempNode;
                                tempNode = previousNode;
                                swapNodes(tempNode);
                                break;
                            }
                    }//End Switch statement 
                }//End Foreach loop
            }
        }//End OnTriggerEnter2d
    }


}
