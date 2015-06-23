using UnityEngine;
using System.Collections;


public class PersonController : MonoBehaviour {
    public Person person;
    public GameObject startNode;
    public float speed;

    protected Transform nextNode;
    protected Transform previousNode;
    protected NodeInfo previousNodeInfo;
    protected NodeInfo nextNodeInfo;
    protected ObjectTags objTags;
    
	// Use this for initialization
	void Start () {
        //Making sure that nothing was forgoten in setup
        try
        {
            objTags = new ObjectTags();
            previousNode = startNode.transform;
            previousNodeInfo = previousNode.GetComponent<NodeInfo>();
            nextNode = previousNodeInfo.connectedNodes[0];
            nextNodeInfo = nextNode.GetComponent<NodeInfo>();
            
        }
        catch
        {
            Debug.LogError("No starting node set");
        }
        
	}
	
	void Update () {
        MoveToNextNode();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (transform.position == nextNode.position && otherObject.tag == objTags.decisionNode)
        {
            foreach (Transform nTransform in nextNodeInfo.connectedNodes)
            {
                NodeType nodeType;
                nodeType = nTransform.gameObject.GetComponent<NodeInfo>().nodeType;

                //Only set waypoint if it is not the current one
                if (nodeType == NodeType.Waypoint && nTransform != nextNode.transform)
                {
                    swapNodes(nTransform);
                }
                else
                //Go back the way you came
                {
                    Transform tempNode;
                    tempNode = previousNode;
                    swapNodes(tempNode);
                }
            }
            setNodeInfo(); //reset the nodeInfo objects
        }

    }

    //Resets the NodeInfo objects to the correct nodes
    protected void setNodeInfo()
    {
        previousNodeInfo = previousNode.GetComponent<NodeInfo>();
        nextNodeInfo = nextNode.gameObject.GetComponent<NodeInfo>();
    }

    //Swaps the previous node with the current one and sets next node the the new next node
    protected void swapNodes(Transform newNextNode)
    {
        previousNode = nextNode;
        nextNode = newNextNode;
    }
    
    protected void MoveToNextNode()
    {
        if (nextNode != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextNode.position, speed * Time.deltaTime);
        }
    }
}
