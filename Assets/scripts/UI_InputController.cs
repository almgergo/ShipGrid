using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_InputController : MonoBehaviour
{
    public Texture2D selectedTurret;

    ShipGridManager shipGridManager;

    // UI Raycast
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    // Start is called before the first frame update
    void Awake()
    {
        this.shipGridManager = GameObject.FindGameObjectWithTag("ShipGrid").GetComponent<ShipGridManager>();
        InitRaycaster();
    }

    private void InitRaycaster()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        this.m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        this.m_EventSystem = GetComponent<EventSystem>();
        Debug.Log(this.m_Raycaster);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouse();
    }

    private void HandleMouse()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event 
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                SlotController slotController = result.gameObject.GetComponent<SlotController>();
                if (slotController != null)
                {
                    Debug.Log("Texture set for slot: " + slotController.gameObject.name);
                    slotController.Texture = selectedTurret;
                }
                Debug.Log("Hit " + result.gameObject.name);
            }
        }
    }
}
