using UnityEngine;
using System.Collections;

public class PlayerController : PersonController {
    public bool isBrave = false;
    public bool isCurious = false;

    private ObjectTags objTags = new ObjectTags();

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == objTags.decisionNode)
            MakeDecision();

        if (other.tag == objTags.intervention) 
            ChangeModivation(other.gameObject.GetComponent<InterventionController>().type);

    }

    
    void MakeDecision()
    {
        if (transform.position == nextNode.position)
        {
            if (nextNodeInfo.connectedNodes.Count > 0)
            {
                bool foundNode = false; //Used to brake out of the ForEach loop after the correct node is found.
                foreach (Transform nTransform in nextNodeInfo.connectedNodes)
                {

                    if (foundNode)
                        break;

                    //if the element in the array is null return to last node.
                    if (nTransform == null)
                    {
                        ReturnToLastNode();
                        break;
                    }


                    NodeType nodeType;
                    nodeType = nTransform.GetComponent<NodeInfo>().nodeType;

                    switch (nodeType)
                    {
                        case NodeType.Curious:
                            {
                                if (isCurious)
                                {
                                    SwapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        case NodeType.Direct:
                            {
                                if (!isCurious)
                                {
                                    SwapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        case NodeType.Brave:
                            {
                                if (isBrave)
                                {
                                    SwapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        case NodeType.Timid:
                            {
                                if (!isBrave)
                                {
                                    SwapNodes(nTransform);
                                    foundNode = true;
                                }
                                break;
                            }

                        //if no known nodetype is found return to last node
                        default:
                            {
                                ReturnToLastNode();
                                break;
                            }
                    }//End Switch statement 
                }//End Foreach loop
            }
        }
    }//End MakeDecision


    void ChangeModivation(InterventionType type)
    { 
        switch (type)
        {
            case InterventionType.InfoCryptic:
                {
                    isCurious = true;
                    break;
                }
            case InterventionType.InfoDirect:
                {
                    isCurious = false;
                    break;
                }
            case InterventionType.Weapon:
                {
                    isBrave = true;
                    break;
                }
            case InterventionType.Trap:
                {
                    isBrave = false;
                    break;
                }
        }
    }

}
