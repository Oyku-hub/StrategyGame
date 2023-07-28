using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{

    [SerializeField] private Unit unit;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    private void Start()
    {
       
        UnityActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual();

    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
    {
        UpdateVisual();
       
    }

    private void UpdateVisual()
    {
        if (UnityActionSystem.Instance.GetSelectedUnit() == unit)
        {
            meshRenderer.enabled = true;
        }
       else
        {
            meshRenderer.enabled = false;
            Debug.Log("dþsakdþkasid");

        }

    }

}
