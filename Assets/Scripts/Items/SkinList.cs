using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class SkinList : MonoBehaviour
{
    public CubeSkin[] skinList;

    private void Start()
    {
        string id = PlayerPrefs.GetString("currentSkin", "Default Cube");

        foreach (var skin in skinList)
        {
            if (skin.name == id)
            {
                GameObject.Find("Cube").GetComponent<MeshRenderer>().material = skin.material;
            }
        }
    }
}
