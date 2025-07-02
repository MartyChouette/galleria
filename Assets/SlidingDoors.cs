using UnityEngine;

public class SlidingDoors : MonoBehaviour
{
    public GameObject leftDoorObject;
    public GameObject rightDoorObject;

    public float slideAmount = 2f;
    public float slideSpeed = 2f;

    private Vector3 leftClosedPos;
    private Vector3 rightClosedPos;
    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;

    private bool isPlayerInside = false;

    void Start()
    {
        // Get Transforms
        Transform leftDoor = leftDoorObject.transform;
        Transform rightDoor = rightDoorObject.transform;

        // Store closed positions
        leftClosedPos = leftDoor.localPosition;
        rightClosedPos = rightDoor.localPosition;

        // Calculate open positions
        leftOpenPos = leftClosedPos + Vector3.left * slideAmount;
        rightOpenPos = rightClosedPos + Vector3.right * slideAmount;
    }

    void Update()
    {
        Transform leftDoor = leftDoorObject.transform;
        Transform rightDoor = rightDoorObject.transform;

     
            if (Input.GetKeyDown(KeyCode.O))
            {
                leftDoorObject.transform.localPosition += Vector3.left * 1f;
                rightDoorObject.transform.localPosition += Vector3.right * 1f;
            }
        


        // Move doors
        if (isPlayerInside)
        {
            leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftOpenPos, Time.deltaTime * slideSpeed);
            rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightOpenPos, Time.deltaTime * slideSpeed);
        }
        else
        {
            leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftClosedPos, Time.deltaTime * slideSpeed);
            rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightClosedPos, Time.deltaTime * slideSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered door trigger");
            isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited door trigger");
            isPlayerInside = false;
        }
    }
}