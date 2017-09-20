using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject defenderParent;
    private StarDisplay starDisplay;

    private void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    private void OnMouseDown()
    {
        //GameObject newDefender = Instantiate(Button.selectedDefender, SnapToGrid(CaculateMouseWorldPointOfMouseClick()), Quaternion.identity) as GameObject;

        Vector2 rawPos = CaculateMouseWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;
        int defenderCost = defender.GetComponent<Defender>().starCost;

        if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
        
    }

    private void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRotation = Quaternion.identity;
        GameObject newDefender = Instantiate(defender, roundedPos, zeroRotation) as GameObject;


        newDefender.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
        float newX = Mathf.RoundToInt(rawWorldPosition.x);
        float newY = Mathf.RoundToInt(rawWorldPosition.y);

        return new Vector2(newX, newY);
    }

    Vector2 CaculateMouseWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
