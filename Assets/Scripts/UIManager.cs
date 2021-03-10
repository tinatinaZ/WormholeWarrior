using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject LayerPrefab;
    public Transform BackgroundPanel;

    public GameObject test;
    private int interpolationFramesCount;
    private Vector3 startScale = new Vector3 (0.5f, 0.5f, 0.5f);
    private Vector3 endScale = new Vector3 (2.0f, 2.0f, 2.0f);
    private float[] LayerScale = {2.0f, 1.4f, 0.9f, 0.5f};
    public List<GameObject> Layers = new List<GameObject>();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        interpolationFramesCount = 30 * 5;
    }

    int elapsedFrames = 0;
    // Update is called once per frame
    void Update()
    {
        //float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        //test.transform.localScale = Vector3.Lerp(startScale, endScale, interpolationRatio);

        //elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);

        UpdateBackground();
    }

    public void CreateLayer(int currentGlobalLayer)
    {
        GameObject layer = Instantiate(LayerPrefab, Vector3.zero, Quaternion.identity);
        layer.transform.SetParent(BackgroundPanel);
        layer.transform.localPosition = Vector3.zero;
        layer.transform.localScale = startScale;
        layer.name = "Layer_" + currentGlobalLayer;

        if(Layers.Count == 4)
        {
            Destroy(Layers[0]);
            Layers.RemoveAt(0);
        }

        Layers.Add(layer);
    }

    protected void UpdateBackground()
    {
        for (int i=0; i<Layers.Count; i++)
        {
            Layers[i].transform.localScale = new Vector3(LayerScale[i], LayerScale[i], LayerScale[i]);
        }
    }
}
