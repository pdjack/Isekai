using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BerryBush : MonoBehaviour
{
    public GameObject berryPre;
    
    private int _berryCount;
    private float _berryX;
    private float _berryY;

    private void Start()
    {
        MakeBerry();
    }

    private void MakeBerry()
    {
        if (_berryCount < 4)
        {
            float berryX = Random.Range(-0.25f, 0.25f);
            float berryY = Random.Range(-0.25f, 0.25f);
            Debug.Log("berryX :" + berryX);
            Debug.Log("berryY :" + berryY);
            
            while (berryX != _berryX && berryY != _berryY)
            {
                Debug.Log("while");
                berryX = Random.Range(-0.25f, 0.25f);
                berryY = Random.Range(-0.25f, 0.25f);
            }
            _berryX = berryX;
            _berryY = berryY;
            Debug.Log("_berryX :" + _berryX);
            Debug.Log("_berryY :" + _berryY);
            
            GameObject berry =  Instantiate(berryPre, transform.position + new Vector3(berryX, berryY, 0), Quaternion.identity, this.gameObject.transform);
            berry.GetComponent<SpriteRenderer>().sortingLayerName = "Item";
            _berryCount ++;
            Debug.Log(_berryCount);
            
            int berryMakeTime =  Random.Range(3, 6);
            Invoke(nameof(MakeBerry), berryMakeTime);
        }
    }
}
