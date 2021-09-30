using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //[SerializeField] private TMPro.TextMeshProUGUI playerHP;
    //[SerializeField] private TMPro.TextMeshProUGUI playerATK;
    //[SerializeField] private TMPro.TextMeshProUGUI playerSpeed;

    [SerializeField] private GameObject deadUI;

    private CharacterControl playerCharacter;
    //[SerializeField] private LevelManager levelmanager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacter == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            playerCharacter = player.GetComponent<CharacterControl>();
        }

        //playerHP.SetText("HP : " + playerCharacter.health);
        //playerATK.SetText("ATK : " + playerCharacter.attackPower);
        //playerSpeed.SetText("Speed : " + playerCharacter.speed);

        if (playerCharacter.health <= 0)
        {
            deadUI.SetActive(true);
        }
    }
}
