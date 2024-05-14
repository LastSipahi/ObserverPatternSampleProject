using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Controls : MonoBehaviour
{
    private ShipControls shipControls;
    CharacterController characterController;
    Vector2 Movement;
    Vector2 Aim;
    float PlayerMoveSpeed = 8;
    [SerializeField]Transform imgCrossHair;
    [SerializeField]Transform PlayerGun;
    Camera MainCam;
    [SerializeField] GameObject preBullet;
    int DestroyedEnemyCount = 0;
    [SerializeField]TextMeshProUGUI txtDestroyedShips;
    private void Awake()
    {
        shipControls= new ShipControls();
    }
    private void OnEnable()
    {
        shipControls.Enable();
        EnemyHP.OnEnemyDestroyed += EnemyHP_OnEnemyDestroyed;
    }

    private void EnemyHP_OnEnemyDestroyed()
    {
        DestroyedEnemyCount++;
        txtDestroyedShips.text="Destroyed Enemies: "+DestroyedEnemyCount.ToString();
    }

    private void OnDisable()
    {
        shipControls.Disable();
        EnemyHP.OnEnemyDestroyed -= EnemyHP_OnEnemyDestroyed;
    }
    void Start()
    {
        MainCam = Camera.main;
        characterController=GetComponent<CharacterController>();
    }

    
    void Update()
    {
        HandleMovement();
        HandleInput();
        HandleRotation();
    }
    public void HandleMovement()
    {
        
        characterController.Move(new Vector3(-Movement.x, 0, Movement.y) * PlayerMoveSpeed * Time.deltaTime);
    }

    void HandleInput()
    {
        Movement = shipControls.Starship.Move.ReadValue<Vector2>();
        Aim = shipControls.Starship.Aim.ReadValue<Vector2>();

        if (shipControls.Starship.Fire.triggered)
        {
            FireProjectile();            
        }


    }
    void HandleRotation() //or aim can be used
    {
        Vector3 lookAtPos = Input.mousePosition;
        lookAtPos.z = MainCam.transform.position.y - transform.position.y;
        lookAtPos = Camera.main.ScreenToWorldPoint(lookAtPos);
        PlayerGun.forward = lookAtPos - PlayerGun.position;
        PlayerGun.transform.eulerAngles = new Vector3(0, PlayerGun.transform.eulerAngles.y, 0);
        imgCrossHair.position = Input.mousePosition;
    }

    public void FireProjectile()
    {
        GameObject temp= Instantiate(preBullet, PlayerGun.transform.GetChild(0).position, Quaternion.identity);
        temp.transform.eulerAngles = PlayerGun.transform.eulerAngles;
        Destroy(temp, 5);
    }
}
