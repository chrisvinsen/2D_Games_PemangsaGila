using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] torches;
    public int[] barrels;
    public int[] shelves;

    public bool reset;

    public float cameraRange;

    public int cntTorch;
    public int cntBarrel;
    public int cntShelf;

    public Vector3 currentPos;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
