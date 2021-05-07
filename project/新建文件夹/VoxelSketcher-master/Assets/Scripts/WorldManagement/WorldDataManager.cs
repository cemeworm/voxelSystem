using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class WorldDataManager : Singleton<WorldDataManager>
{
    private List<WorldData> m_availableWorlds;
    public int objectCount;

    public WorldData ActiveWorld { get; private set; }

    new private void Awake()
    {
        base.Awake();
        m_availableWorlds = new List<WorldData>();
    }



    public WorldData CreateNewWorld(string name)
    {
        WorldData world = new WorldData(name);
        m_availableWorlds.Add(world);
        return world;
    }
    public void CreateNewWorld(WorldData world)
    {
        m_availableWorlds.Add(world);
    }
    public void ActivateWorld(string name)
    {
        if (ActiveWorld != null)
        {
            for (int i = objectCount-1; i >= 0; i--)
            {
                ActiveWorld.DeleteObject(i);
                Debug.Log("DeleteObject! " + i);
            }
            //ActiveWorld.UpdateAllObjects();
        }
        ActiveWorld = m_availableWorlds.Find(x => x.name == name);
        if(System.IO.Directory.Exists(Application.dataPath + "/saveScene/" + ActiveWorld.name + ".save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            var path = Application.dataPath + "/saveScene/" + ActiveWorld.name + ".save";
            if (System.IO.Directory.Exists(path))
            {
                Debug.Log("Load Path Doesn't Exist!");
                var fs = File.Open(Application.dataPath + "/saveScene/" + ActiveWorld.name + ".save", FileMode.Open);
                fs.Seek(0, SeekOrigin.Begin);
                SaveData saveData = (SaveData)bf.Deserialize(fs);
                fs.Close();
                Debug.Log("Load " + ActiveWorld.name);
                ActiveWorld.WorldInit(saveData.Objs, saveData.worldSize);
                WorldDataManager.Instance.objectCount = WorldDataManager.Instance.ActiveWorld.ObjectList.Count;
            }
        }
        else
        {
            ActiveWorld.worldSize = 0.05f;
        }
    }

    public void NextWorld()
    {
        // 只有一个world时无法切换
        if (m_availableWorlds.Count > 1)
        {
            if (ActiveWorld != null)
            {
                SaveData.SaveWorldData(ActiveWorld.name);
            }
            int counter = (Convert.ToInt32(ActiveWorld.name) + 1) % m_availableWorlds.Count;
            string name = counter.ToString();
            Debug.Log("m_availableWorlds.Count! " + m_availableWorlds.Count);
            Debug.Log("name! "+ name);
            objectCount = ActiveWorld.ObjectList.Count;
            Debug.Log("objectCount:" + objectCount);
            ActivateWorld(name);
        }
        
    }

    public WorldData[] GetAvailableWorlds()
    {
        return m_availableWorlds.ToArray();
    }


}