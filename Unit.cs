using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{


    public GameObject hitShow;
    public DamageIcons damageNumbers;

    public bool selected;
    TurnManager gm;

    public Vector2 goOver;
    public Vector3 goOverMore;

    public bool hasWalked;
    public int TileSpeed;

    public float mo;

    public int playerNum;

    public int attackRange;
    public int attackDamage;
    public int defenseDamage;
    public int armor;
    public int health;


    public Color hitColor;
    public SpriteRenderer rendr;

    List<Unit> EnemiesInRange = new List<Unit>();

    public bool hasAttacked;

    public GameObject smoke;

    public GameObject part;

    void Start()
    {
        gm = FindObjectOfType<TurnManager>();
        goOver = transform.position;
        ResetIcons();



    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Clicked");
        ResetIcons();
        if (selected == true)
        {
            selected = false;
            gm.unitSelected = null;
            gm.ResetTiles();

        } else
        {
            if (gm.unitSelected != null)
            {
                gm.unitSelected.selected = false;
            }
            selected = true;
            gm.unitSelected = this;
            gm.ResetTiles();
            GetEnemies();
            GetWalkableTiles();
        }

        Collider2D col = Physics2D.OverlapCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.20f);
        Unit unit = col.GetComponent<Unit>();
        if (gm.unitSelected != null)
        {
            Debug.Log("Prepare the attack");
            Debug.Log(EnemiesInRange);
            if (gm.unitSelected.EnemiesInRange.Contains(unit) && gm.unitSelected.hasAttacked == false)
            {
                Debug.Log("ATTACK!!!!!");
                gm.unitSelected.Attack(unit);
            }
        }
    }

    void GetWalkableTiles()
    {
        if (hasWalked == true)
        {

            return;

        } else
        { if (playerNum == gm.playerTurn)
            {
                Debug.Log("Do tile thingy");
                foreach (TileScript tile in FindObjectsOfType<TileScript>())
                {
                    if (Mathf.Abs(transform.position.x - tile.transform.position.x) + Mathf.Abs(transform.position.y - tile.transform.position.y) <= TileSpeed)
                    {
                        Debug.Log("Highlight");
                        tile.Highlight();
                    }

                }
            }

        }




    }

    void GetEnemies()
    {
        EnemiesInRange.Clear();
        foreach (Unit unit in FindObjectsOfType<Unit>())
        {
            if (Mathf.Abs(transform.position.x - unit.transform.position.x) + Mathf.Abs(transform.position.y - unit.transform.position.y) <= attackRange)
            {
                if (unit.playerNum != gm.playerTurn && hasAttacked == false && unit)
                {
                    EnemiesInRange.Add(unit);
                    if (unit != this)
                    {
                        unit.smoke.SetActive(true);
                        Debug.Log("There are Enemies");
                    }

                }
            }

        }


    }

    public void ResetIcons()
    {
        foreach (Unit unit in FindObjectsOfType<Unit>())
        {
            unit.smoke.SetActive(false);
        }
    }

    public void Attack(Unit enemy)
    {
        hasAttacked = true;

        int enemyDamaged = attackDamage - enemy.armor;
        int friendDamaged = enemy.defenseDamage - armor;

        if (enemy.health >= 1)
        {
            if (enemyDamaged > 0)
            {
                enemy.health -= enemyDamaged;
                Debug.Log("Ouch!!");
                enemy.ShowDamage();
            } else
            {
                enemy.health -= 0;
            }

        }

        if (health >= 1)
        {
            if (friendDamaged > 0)
            {
                health -= friendDamaged;
                Debug.Log("More Ouch!!");
            }else
            {
                health -= 0;
            }
        }

        if (enemy.health <= 0)
        {
            Destroy(enemy.gameObject);
            GetWalkableTiles();
        }

        if (health <= 0)
        {
            gm.ResetTiles();
            Destroy(this.gameObject);
        }


    }



    public void MoveIt(Vector2 tilePos)
    {
        gm.ResetTiles();
        StartCoroutine(StartMovement(tilePos));
    }



    IEnumerator StartMovement(Vector2 tilePos)
    {
        while (transform.position.x != tilePos.x)
        {
            goOver = Vector2.MoveTowards(transform.position, new Vector2(tilePos.x, transform.position.y), mo * Time.deltaTime);
            transform.position = new Vector3(goOver.x, goOver.y, transform.position.z);
            yield return null;
        }
        while (transform.position.y != tilePos.y)
        {
            goOver = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, tilePos.y), mo * Time.deltaTime);
            transform.position = new Vector3(goOver.x, goOver.y, transform.position.z);

            yield return null;
        }
        hasWalked = true;
        ResetIcons();
        GetEnemies();

    }
    public float magnify;

    void OnMouseEnter()
    {


        transform.localScale += Vector3.one * magnify;


    }
    void OnMouseExit()
    {


        transform.localScale -= Vector3.one * magnify;


    }

    public void ShowDamage()
    {
        Debug.Log("POW!!");
        Instantiate(part, transform.position, Quaternion.identity);
    }

    public UnitInfoBox infoBox;

    void OnMouseOver()
    {
        Debug.Log("Mouse Over it");
        if (Input.GetMouseButtonDown(1))
        {
            if (infoBox.huphuphay == 0)
            {
                Debug.Log("Show the box!!!!!");
                infoBox.ShowBox();
            }else
            {
                
                infoBox.HideBox();
            }
        }
    }

    void Update()
    {

    }


}
