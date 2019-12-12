﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStatus : MonoBehaviour
{
    public static StepData.PL_STEP_TIMING GetPlStepTiming { get; private set; }
    public static Material GetPlMaterial { get; private set; }
    public static Vector3 GetPlModePos { get; private set; }

    public static StepData.ENEMY_ATTACK_TYPE GetEnemyAttackType { get; private set; }
    public static Material GetEnemyMaterial { get; private set; }
    public static Vector3 GetEnemyModePos { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                GameObject obj = hit.collider.gameObject;
                switch (obj.tag)
                {
                    case "EnemyMode":
                        GetEnemyAttackType = obj.GetComponent<EnemyModeObj>().enemyModeType;
                        GetEnemyMaterial = obj.GetComponent<Renderer>().material;
                        GetEnemyModePos = obj.transform.position;
                        break;

                    case "PlMode":
                        GetPlStepTiming = obj.GetComponent<PlModeObj>().plModeType;
                        GetPlMaterial = obj.GetComponent<Renderer>().material;
                        GetPlModePos = obj.transform.position;
                        break;

                    default:break;
                }
            }
        }
    }
}
