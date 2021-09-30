using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool check;

    public Vector2Int Index;

    private CharacterControl characterControl;
    private LevelManager levelManager;

    private void Start()
    {
        GameObject levelManagerObj = GameObject.Find("SceneManager");
        levelManager = levelManagerObj.GetComponent<LevelManager>();
    }

    private CharacterControl CharacterControl
    {
        get
        {
            if (characterControl == null)
            {
                characterControl = FindObjectOfType<CharacterControl>();
            }

            return characterControl;
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = new Vector4(0, 1, 0, 1);
    }

    private void OnMouseExit()
    {
        if(this.gameObject.name == "Black(Clone)")
        {
            GetComponent<SpriteRenderer>().color = new Vector4(0.2f, 0.46f, 0.42f, 1);
        }

        if(this.gameObject.name == "White(Clone)")
        {
            GetComponent<SpriteRenderer>().color = new Vector4(0.55f, 0.82f, 0.78f, 1);
        }
    }

    private void OnMouseDown()
    {
        if (levelManager.CharacterDead == false)
        {
            foreach (Vector2Int pattern in CharacterControl.movePattern)
            {
                if (Index == pattern + CharacterControl.Index)
                {
                    CharacterControl.move(Index);
                }
            }
        }
    }
}
