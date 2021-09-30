using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAttackPattern : MonoBehaviour
{
    public List<Vector2Int> attackPatternSword = new List<Vector2Int>();
    public List<Vector2Int> attackPatternClaymore = new List<Vector2Int>();
    public List<Vector2Int> attackPatternBow = new List<Vector2Int>();

    private CharacterControl character;

    int randomItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        character = other.GetComponent<CharacterControl>();

        if (character != null)
        {
            
            randomItem = Random.Range(0, 6);
            Debug.Log(randomItem);

            if (randomItem == 0)
            {
                Debug.Log("You got a sword.");

                character.attackPattern.Clear();
                character.attackPattern = new List<Vector2Int>(attackPatternSword);

                character.attackPatternClaymoreUI.SetActive(false);
                character.attackPatternBowUI.SetActive(false);
                character.attackPatternSwordUI.SetActive(true);

                character.attackPower = 4;
                character.speed = 2;
            }

            if (randomItem == 1)
            {
                Debug.Log("You got a claymore.");

                character.attackPattern.Clear();
                character.attackPattern = new List<Vector2Int>(attackPatternClaymore);

                character.attackPatternSwordUI.SetActive(false);
                character.attackPatternBowUI.SetActive(false);
                character.attackPatternClaymoreUI.SetActive(true);

                character.attackPower = 7;
                character.speed = 1;
            }

            if (randomItem == 2)
            {
                Debug.Log("You got a bow.");

                character.attackPattern.Clear();
                character.attackPattern = new List<Vector2Int>(attackPatternBow);

                character.attackPatternSwordUI.SetActive(false);
                character.attackPatternClaymoreUI.SetActive(false);
                character.attackPatternBowUI.SetActive(true);

                character.attackPower = 3;
                character.speed = 5;
            }

            if (randomItem == 3)
            {
                Debug.Log("You got buff 1.");


            }

            if (randomItem == 4)
            {
                Debug.Log("You got a buff 2.");
            }

            if (randomItem == 5)
            {
                Debug.Log("You got a buff 3.");
            }

            if (randomItem == 6)
            {
                Debug.Log("You got nothing.");
            }
        }
    }
}
