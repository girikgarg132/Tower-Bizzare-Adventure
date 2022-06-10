using System.Collections;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [HideInInspector] public bool isPlaceable = true;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            FindObjectOfType<CannonFactory>().AddCannon(this);
        }
    }

}
