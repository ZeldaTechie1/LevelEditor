using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiObject : MonoBehaviour
{

    bool isSelected;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MoveOnScreen(Vector3 moveVelocity)
    {
        this.transform.position += moveVelocity;
    }
    public void RotateOnScreen(Vector2 lookAt)
    {
        this.transform.LookAt(lookAt,Vector3.forward);
    }
}
