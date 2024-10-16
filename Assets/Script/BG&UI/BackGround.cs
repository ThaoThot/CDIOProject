using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform mainCam;
    public Transform midBG;
    public Transform sideBG;
    public float length;

    private void LateUpdate()
    {
        if (mainCam.position.x > midBG.position.x + length / 2)
        {
            UpdateBackgroundPosition(Vector3.right);
        }
        else if (mainCam.position.x < midBG.position.x - length / 2)
        {
            UpdateBackgroundPosition(Vector3.left);
        }
    }

    private void UpdateBackgroundPosition(Vector3 direction)
    {
        sideBG.position = midBG.position + direction * length;
        Transform temp = midBG;
        midBG = sideBG;
        sideBG = temp;
    }
}