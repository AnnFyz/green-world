using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinManager : MonoBehaviour
{
    public static TrashBinManager Instance { get; private set; }
    private bool allTrashCollected;
    private int collectedTrash;
    public TrashSpawner trashSpawner;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        collectedTrash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        KeepTrackOfCollectedTrashAmount();
    }

    public void SetCollectedTrash()
    {
        this.collectedTrash++;
    }

    //public void SetAllTrashCollected(bool allTrashCollected)
    //{
    //    this.allTrashCollected = allTrashCollected;
    //}

    public int GetCollectedTrash()
    {
        return this.collectedTrash;
    }

    public bool GetAllTrashCollected()
    {
        return this.allTrashCollected;
    }

    private void KeepTrackOfCollectedTrashAmount()
    {
        if (collectedTrash >= trashSpawner.GetNumberOfTrashToSpawn() - 8)
        {
            allTrashCollected = true;
            GameManager.Instance.isWon = true;
            GameManager.Instance.onWinning?.Invoke();
        }
    }

}
