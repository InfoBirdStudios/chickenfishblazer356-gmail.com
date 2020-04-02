using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{

    public float magnify;

    public Color highlightColor;
    public bool isWalkable;
    TurnManager gm;
    public SpriteRenderer rend;

    void Start()
    {
        gm = FindObjectOfType<TurnManager>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        transform.localScale += Vector3.one * magnify;
        
    }
    void OnMouseExit()
    {
        transform.localScale -= Vector3.one * magnify;

    }

    public void Highlight()
    {
        rend.color = highlightColor;
        isWalkable = true;
    }
    public void Reset()
    {
        rend.color = Color.white;
        isWalkable = false;
    }


    void OnMouseDown()
    {
        if (isWalkable == true && gm.unitSelected != null)
        {
            gm.unitSelected.MoveIt(this.transform.position);
        }

    }
}
