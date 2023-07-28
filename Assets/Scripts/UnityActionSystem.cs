using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityActionSystem : MonoBehaviour
{
    public static UnityActionSystem Instance { get; private set; }
    public event EventHandler OnSelectedUnitChanged;
    [SerializeField] private Unit SelectedUnit;
    [SerializeField] private LayerMask unitLayerMask;



    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UnitActionSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;

        }
        Instance = this;
    }
    private void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandlerUnitSelection()) return;
            SelectedUnit.Move(MouseWorld.GetPosition());
        }

    }

    private bool TryHandlerUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if( Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SelectedUnit= unit;
                SetSelectedUnit(unit);
                return true;
               
            }

            
        }
       return false;
    }

    
    private void SetSelectedUnit(Unit unit)
    {
        SelectedUnit= unit;
        //null check
        OnSelectedUnitChanged?.Invoke(this,EventArgs.Empty);
        
    }

    public Unit GetSelectedUnit()
    {
        return SelectedUnit;
    }
}
