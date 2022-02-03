using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForDamage : MonoBehaviour
{
    public GameMenu gameMenu;
    public List<GameObject> prefabTarget = new List<GameObject>();
    public List<GameObject> destroyedTarget = new List<GameObject>();


    private void Win()
    {
        if (prefabTarget.Count == 0)
        {
            gameMenu.OnPlayerRaechFinish();
        }
    }

    private void Update()
    {
        
            for (int i = 0; i <= prefabTarget.Count-1; i++)
            {
           // print(prefabTarget[i]);
                if (prefabTarget[i] == null)
                {
                    destroyedTarget.Add(prefabTarget[i]);
                    prefabTarget.Remove(prefabTarget[i]);
                }
            }
        
        //print(destroyedTarget.Count);
        Win();


    }
}