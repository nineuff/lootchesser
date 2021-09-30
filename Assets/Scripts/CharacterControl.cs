using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public Vector2Int Index;
    public List<Vector2Int> movePattern = new List<Vector2Int>();
    public List<Vector2Int> attackPattern;

    private MainBoard mainBoard;

    public LayerMask enemyLayer;

    private Enemy enemyToAttack;

    public int health = 20;
    public int attackPower = 0;
    [Range(0, 5)] public int speed = 3;

    public GameObject attackPatternSwordUI;
    public GameObject attackPatternClaymoreUI;
    public GameObject attackPatternBowUI;

    [SerializeField] private GameObject deadUI;

    //[SerializeField] private TMPro.TextMeshProUGUI playerHP;
    //[SerializeField] private TMPro.TextMeshProUGUI playerATK;
    //[SerializeField] private TMPro.TextMeshProUGUI playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        mainBoard = FindObjectOfType<MainBoard>();
    }

    private void Update()
    {
        //playerHP.SetText("HP : " + health);
        //playerATK.SetText("ATK : " + attackPower);
        //playerSpeed.SetText("Speed : " + speed);
    }

    public void move(Vector2Int index)
    {
        Index = index;
        transform.position = mainBoard.GetTileAtIndex(index).transform.position;

        foreach (Vector2Int attack in attackPattern)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(attack.x, attack.y), 0.4f, enemyLayer);

            if (hits.Length > 0)
            {
                Debug.Log("hit");
                foreach (Collider2D hit in hits)
                {
                    enemyToAttack = hit.GetComponent<Enemy>();
                    if (enemyToAttack != null)
                    {
                        Attack(enemyToAttack);
                    }
                }
            }
        }
    }

    private void Attack(Enemy enemyToAttack)
    {
        if (speed > enemyToAttack.speed)
        {
            enemyToAttack.health -= attackPower;

            if (enemyToAttack.health <= 0)
            {
                Destroy(enemyToAttack.gameObject);
                return;
            }

            else
            {
                health -= enemyToAttack.attack;
            }
        }

        else
        {
            health -= enemyToAttack.attack;

            if (health <= 0)
            {
                Time.timeScale = 0;
            }

            else
            {
                enemyToAttack.health -= attackPower;
            }
        }

        if (enemyToAttack.health <= 0)
        {
            Destroy(enemyToAttack.gameObject);
        }

        if (health <= 0)
        {
            Time.timeScale = 0;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (Vector2Int attack in attackPattern)
        {
            Gizmos.DrawWireSphere(transform.position + new Vector3(attack.x, attack.y), 0.4f);
        }
    }
}
