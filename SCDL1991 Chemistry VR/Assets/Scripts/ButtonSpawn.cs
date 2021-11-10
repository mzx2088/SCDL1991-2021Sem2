using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject equipPrefab;
    public Button button;
    public List<GameObject> createdObjects = new List<GameObject>();

    private void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //removes any previously spawned objects
        foreach (GameObject x in createdObjects)
        {
            Destroy(x);
        }
        createdObjects.Clear();

        //spawns a new object
        GameObject Prefab = Instantiate(equipPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        createdObjects.Add(Prefab);
    }
}
