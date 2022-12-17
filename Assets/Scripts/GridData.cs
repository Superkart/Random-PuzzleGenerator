using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridData : MonoBehaviour
{
    public List<GameObject> gridView = new List<GameObject>(9);
    public List<Color> Colors = new List<Color>(3);
    public bool isSelected = false;
    public List<Button> ColorButtons;
    int[][] patternArray = new int[][]

{
new int[] {0, 3, 6},
new int[] {1, 4, 7},
new int[] {2, 5, 8},
new int[] {0, 1, 2},
new int[] {3, 4, 5},
new int[] {6, 7, 8 },
new int[] {0, 4, 8},
new int[] {2, 4, 6},

};

    private Color colorSelected;

    public void Start()
    {
        Colors.Add(Color.red);
        Colors.Add(Color.green);
        Colors.Add(Color.blue);
    }

    public void ColorSelected()
    {

        string name = EventSystem.current.currentSelectedGameObject.name;
        if (name == "Blue")
        {
            colorSelected = Color.blue;
            Colors.Remove(Color.blue);
        }
        else if (name == "Green")
        {
            colorSelected = Color.green;
            Colors.Remove(Color.green);
        }
        else if (name == "Red")
        {
            colorSelected = Color.red;
            Colors.Remove(Color.red);
        }
        else
        {
            Debug.LogError("Invalid button selected!");
        }
       
        UpdateButtons(false);
        SetPattern();

      

    }


    public void SetPattern() 
    {
            int temprand = Random.Range(0, 8);
            int[] temparr = new int[3] { patternArray[temprand][0], patternArray[temprand][1], patternArray[temprand][2] };

            for (int i = 0; i < 3; i++)
            {
                gridView[temparr[i]].GetComponent<Image>().color = colorSelected;
                gridView[temparr[i]].GetComponent<Tile>().IsColorSet = true;
            }
                   
        
        for(int ele = 0 ; ele < gridView.Count; ele++)
        {
            if (!gridView[ele].GetComponent<Tile>().IsColorSet)
            {
                int randcolor = Random.Range(0, 2);
                Color randomcolor = Colors[randcolor];
                gridView[ele].GetComponent<Image>().color = randomcolor;
            }
        }
      
    }

    public void Regenerate()
    {
        for (int ele = 0; ele < gridView.Count; ele++)
        {
            gridView[ele].GetComponent<Image>().color = Color.white;
            gridView[ele].GetComponent<Tile>().IsColorSet = false;
        }
            SetPattern();
    }

   public void ResetButton()
    {
        Colors.Clear();
        Colors.Add(Color.red);
        Colors.Add(Color.green);
        Colors.Add(Color.blue);
        colorSelected = Color.white;
        UpdateButtons(true);
        for (int ele = 0; ele < gridView.Count; ele++)
        {
            gridView[ele].GetComponent<Image>().color = Color.white;
            gridView[ele].GetComponent<Tile>().IsColorSet = false;
        }

    }

    void UpdateButtons(bool status)
    {
        foreach (Button btn in ColorButtons)
        {
            btn.gameObject.SetActive(status);

        }
    }

}
