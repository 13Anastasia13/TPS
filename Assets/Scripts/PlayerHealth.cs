using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 30;
    public RectTransform valueRectTransform;
    private float _maxHealth;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    private void Start()
    {
        _maxHealth = health;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }

    void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

    void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2( health / _maxHealth , 1);
    }
}
