using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light targetLight;

    private void Start()
    {
        if (targetLight != null)
            targetLight.enabled = false; // Light starts off
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && targetLight != null)
        {
            targetLight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && targetLight != null)
        {
            targetLight.enabled = false;
        }
    }
}
