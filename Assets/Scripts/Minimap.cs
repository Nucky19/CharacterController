using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform character;
    // public Image iconCharcter;

    private void LateUpdate()
    {
        Vector3 updatePosition=character.position;
        updatePosition.y=transform.position.y;
        transform.position=updatePosition;

        transform.rotation=Quaternion.Euler(90f,character.eulerAngles.y,0f);
    }
}
