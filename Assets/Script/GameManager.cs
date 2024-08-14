using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<SpawnObject> spawnObjects;

    [SerializeField] private Transform PathManager;
    [SerializeField] private Transform SlotManager;
    [SerializeField] List<MapDataSO> mapDataSOs;
    [SerializeField] private GameObject Barrier;
    [SerializeField] private GameObject WinPanel;
    
    private int CurrentmapID;
    private MapDataSO currentMap;
    public static GameManager Instance;
    private int currentEnemy;


    private void Awake()
    {


        CurrentmapID = 0;
        currentMap = mapDataSOs[CurrentmapID];
        Instance = this;
        currentEnemy = currentMap.AmountEnemy * currentMap.PathHolders.Count;
       CreateMap();
    }

    public void CheckNextMap()
    {
        currentEnemy = currentEnemy - 1;
        if (currentEnemy == 0)
        {
            CurrentmapID += 1;
            if (CurrentmapID >= mapDataSOs.Count)
            {
                WinPanel.SetActive(true);
                Time.timeScale = 0;
                return ;
            }
            currentMap = mapDataSOs[CurrentmapID];
            CreateMap();
        }
        Barrier.SetActive(CurrentmapID % 2 == 0 && CurrentmapID!=0);
       /* if (CurrentmapID % 2 == 0)
        {
            Barrier.SetActive(true);
            
        }
        else
        {
            Barrier.SetActive(false);
        }*/

    }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateMap();
        }

    }
    // Update is called once per frame
    private void CreateMap()
    {
        resetMap();
        currentEnemy= currentMap.AmountEnemy * currentMap.PathHolders.Count;
        Debug.Log("ga");
        SlotHolder slotHolder = Instantiate(currentMap.SlotHolder, SlotManager).GetComponent<SlotHolder>();
        for(int i = 0; i < currentMap.PathHolders.Count; i++)
        {
            PathHolder pathHolder = Instantiate(currentMap.PathHolders[i], PathManager).GetComponent<PathHolder>();
            spawnObjects[i].Initdata(pathHolder, slotHolder.GetSlotHolder(i), currentMap.AmountEnemy);
            
        }



    }
    private void clearObject(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
    private void resetMap()
    {
        clearObject(SlotManager.transform);
        clearObject(PathManager.transform);
    }

}
