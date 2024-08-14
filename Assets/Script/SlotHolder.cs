using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHolder : MonoBehaviour
{
   /* [SerializeField] private SerializableList<List<GameObject>> slotHolders;
    public SerializableList<List<GameObject>> SlotHolders => slotHolders;*/
    [SerializeField] List<GameObject> slotHolder1;
    [SerializeField] List<GameObject> slotHolder2;

    public List<GameObject> GetSlotHolder(int ID)
    {
        List<GameObject> slotHolder = new List<GameObject>();
        switch (ID){
            case 0:
                slotHolder = slotHolder1;
                break;
            case 1:
                slotHolder = slotHolder2;
                break;
             default:
                slotHolder = slotHolder1;
                break;

        }
        return slotHolder;
            

    }


}
