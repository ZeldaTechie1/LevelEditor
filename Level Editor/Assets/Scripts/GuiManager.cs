using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour {

    public GameObject blockPrefab;
    public GameObject circlePrefab;
    Vector2 mouseDelta;
    Vector2 mousePosition;
    float mouseRotationAngleFromPivot;
    Camera cam;

    public GameObject[] SelectedObjects;
    Vector2 objectsPivotLocation;
    
    public enum Tools
    {
        None,
        Transform,
        Rotate,
        Scale
    }

    public Tools CurrentTool;

    void Start()
    {
        CurrentTool = Tools.None;
        cam = Camera.main;
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDelta = Vector2.zero;
        mouseRotationAngleFromPivot = 0;
    }
    public void SpawnBlock()
    {
        GameObject spawnedBlock = Instantiate(blockPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void SpawnCircle()
    {
        GameObject spawnedCircle = Instantiate(circlePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    void Update()
    {

        if(SelectedObjects.Length > 0)
        {
            Vector3 pivot = Vector2.zero;
            int numObjects = 0;
            foreach(GameObject g in SelectedObjects)
            {
                if(g!=null)
                {
                    pivot += g.transform.position;
                    numObjects++;
                }
            }
        }

        GrabMouseMovement();
        GrabKeyPresses();

        if(CurrentTool == Tools.Transform)
        {
            foreach(GameObject g in SelectedObjects)
            {
                g.GetComponent<GuiObject>().MoveOnScreen(mouseDelta);
            }
        }
        else if (CurrentTool == Tools.Rotate)
        {
            Quaternion rotation = Quaternion.Euler(0,0,mouseRotationAngleFromPivot);
            foreach (GameObject g in SelectedObjects)
            {
                g.GetComponent<GuiObject>().RotateOnScreen(mousePosition);
            }
        }
    }

    void GrabMouseMovement()
    {
        Vector2 prevMousePosition = mousePosition;
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDelta = mousePosition - prevMousePosition;
    }
    void GrabKeyPresses()
    {
        if(Input.GetButtonDown("TransformTool"))
        {
            if (CurrentTool != Tools.Transform)
            {
                CurrentTool = Tools.Transform;
            }
            else
            {
                CurrentTool = Tools.None;
            }
        }
        if (Input.GetButtonDown("RotateTool"))
        {
            if (CurrentTool != Tools.Rotate)
            {
                CurrentTool = Tools.Rotate;
            }
            else
            {
                CurrentTool = Tools.None;
            }
        }
    }
}
