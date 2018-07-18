using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour 
{
    public Camera myCamera;

    private GameObject parent;
    private StarDisplay starDisplay;

    // Create parent if necessary
    void Start()
    {
        parent = GameObject.Find("Defenders");
        starDisplay = FindObjectOfType<StarDisplay>();

        if(!parent)
        {
            parent = new GameObject("Defenders");
        }
    }

    // Instantiate selected Defender at rounded position
    void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("insufficient stars available");
        }
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;
        GameObject newDef = Instantiate(defender, roundedPos, zeroRot) as GameObject;
        newDef.transform.parent = parent.transform;
    }

    // Rounds click position in World Units
    Vector2 SnapToGrid (Vector2 rawWorldPos) 
    {
        float snapX = Mathf.RoundToInt(rawWorldPos.x);
        float snapY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(snapX, snapY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
