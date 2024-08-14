using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/MapDataSO")]
public class MapDataSO : ScriptableObject
{
    public new int AmountEnemy;
    public GameObject SlotHolder;
    public List<GameObject> PathHolders; 
  
}
