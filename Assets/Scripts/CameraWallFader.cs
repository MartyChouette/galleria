using UnityEngine;
using System.Collections.Generic;

public class CameraWallFader : MonoBehaviour
{
    public Transform player;
    public LayerMask fadeLayer; // Set to "Fadeable" objects
    public float fadeRadius = 0.3f;

    private List<FadingWall> currentFaded = new List<FadingWall>();

    void LateUpdate()
    {
        Vector3 direction = player.position - transform.position;
        float distance = Vector3.Distance(player.position, transform.position);

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, fadeRadius, direction, distance, fadeLayer);

        List<FadingWall> hitWalls = new List<FadingWall>();

        foreach (RaycastHit hit in hits)
        {
            FadingWall wall = hit.collider.GetComponent<FadingWall>();
            if (wall != null)
            {
                wall.FadeOut();
                hitWalls.Add(wall);
            }
        }

        // Revert any walls that are no longer hit
        foreach (var wall in currentFaded)
        {
            if (!hitWalls.Contains(wall))
            {
                wall.FadeIn();
            }
        }

        currentFaded = hitWalls;
    }
}