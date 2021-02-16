using System.Collections.Generic;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    public Sprite[] DefaultSpritesArray { get; set; }
    public Sprite[] FacesArray { get; set; }
    public Sprite[] ShopArray { get; set; }
    
    public Sprite[] musicTracksSpritesArray;
    public Sprite questionMarkForMusicList;
    public Sprite unnamedTrackSprite;

    public Dictionary<int, int> smallDigitsDict;
    public Dictionary<int, int> bigDigitsDict;
    public Dictionary<int, int> priceDigitsDict;

    void Awake()
    {
        FacesArray = Resources.LoadAll<Sprite>("Sprites/Faces");
        DefaultSpritesArray = Resources.LoadAll<Sprite>("Sprites/Sprites");
        ShopArray = Resources.LoadAll<Sprite>("Sprites/Shop/Shop");

        smallDigitsDict = new Dictionary<int, int>
        {
            {0, 39},
            {1, 5},
            {2, 40},
            {3, 48},
            {4, 41},
            {5, 49},
            {6, 42},
            {7, 50},
            {8, 43},
            {9, 51}
        };
        bigDigitsDict = new Dictionary<int, int>
        {
            {0, 17},
            {1, 9},
            {2, 30},
            {3, 31},
            {4, 32},
            {5, 33},
            {6, 44},
            {7, 45},
            {8, 46},
            {9, 47}
        };
        priceDigitsDict = new Dictionary<int, int>
        {
            {0, 13},
            {1, 14},
            {2, 15},
            {3, 16},
            {4, 17},
            {5, 18},
            {6, 19},
            {7, 20},
            {8, 21},
            {9, 22}
        };
    }
}
