using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipGridManagerOld : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public GameObject panel;


    RectTransform panelTransform;
    GameData gameData;
    ShipController shipController;

    GridLayoutGroup gridLayoutGroup;
    List<GameObject> slots;
    SlotController[,] shipGrid;


    // Start is called before the first frame update
    void Start()
    {
        InitFields();
        InitGrid();
    }

    private void InitFields()
    {
        this.gameData = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<ParamLoader>().GameData;
        this.shipController = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>();
        this.panelTransform = panel.GetComponent<RectTransform>();

        this.slots = new List<GameObject>();
    }

    private void InitGrid()
    {
        ShipProperties shipProperties = gameData.ShipTypesDictionary[this.shipController.ShipType];

        this.gridLayoutGroup = this.panel.GetComponent<GridLayoutGroup>();

        panelTransform.sizeDelta = new Vector2(
            (gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x) * shipProperties.columns,
            (gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y) * shipProperties.rows
            );

        this.shipGrid = new SlotController[shipProperties.rows, shipProperties.columns];
        for (int i = 0; i < shipProperties.rows; i++)
        {
            for (int j = 0; j < shipProperties.columns; j++)
            {
                GameObject newSlot = Instantiate(ButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newSlot.transform.SetParent(this.panel.transform);
                newSlot.name = "Slot_" + (i * shipProperties.columns + j);
                // newButton.name = i + " " + j;
                newSlot.GetComponent<SlotController>().Init(j, i);
                // newButton.GetComponent<Button>().onClick.AddListener(newButton.GetComponent<SlotController>().OnClick);

                this.slots.Add(newSlot);
                this.shipGrid[i, j] = newSlot.GetComponent<SlotController>();
            }

        }
    }



    // Update is called once per frame
    void Update()
    {
    }


}
