using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkinManager : MonoBehaviour
{

    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int currentSkin = 0;
    public GameObject playerSkin;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextSkin()
    {
        currentSkin++;
        if (currentSkin >= skins.Count)
        {
            currentSkin = 0;
        }
        sr.sprite = skins[currentSkin];
    }

    public void previousSkin()
    {
        currentSkin--;
        if (currentSkin < 0)
        {
            currentSkin = skins.Count - 1;
        }
        sr.sprite = skins[currentSkin];
    }

    public void selectSkin()
    {
        PrefabUtility.SaveAsPrefabAsset(playerSkin, "Assets/Prefabs/PlayerShip.prefab");    
    }
}
