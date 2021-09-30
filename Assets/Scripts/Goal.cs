using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    private CharacterControl character;

    private void Update()
    {
        if (character == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            character = player.GetComponent<CharacterControl>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        character = collision.GetComponent<CharacterControl>();

        if (character != null)
        {
            winUI.SetActive(true);
        }
    }
}
