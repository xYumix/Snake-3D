using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GL : MonoBehaviour
{

    public GameObject Box;
    public GameObject bonus;
   
    public void DeleteUtility()
    {
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
   public void CreateUtility()
    {
        DeleteUtility();
        for (float i = 17.5f; i < 250; i += 12.5f)
        {
            int choose = Random.Range(0, 14);
            int count = Random.Range(0, 2);
            int doubler = Random.Range(0, 2);
            if (choose >= 8 && choose <= 10)
            {
                if (count == 0)
                {
                    var obj = Instantiate(Box, new Vector3(Random.Range(-2, 3) * 3, 0.5f, i), Quaternion.identity,transform);
                    obj.transform.GetChild(0).GetComponent<Box>().crashCount = Random.Range(4, 20);
                }
                else if (count == 1)
                {
                    var obj = Instantiate(Box, new Vector3(Random.Range(-2, 0) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj.transform.GetChild(0).GetComponent<Box>().crashCount = Random.Range(4, 20);
                    var obj2 = Instantiate(Box, new Vector3(Random.Range(1, 3) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj2.transform.GetChild(0).GetComponent<Box>().crashCount = Random.Range(4, 20);
                }

            }
            else if (choose >= 4 && choose <= 7)
            {
                if (count == 0)
                {
                    var obj = Instantiate(bonus, new Vector3(Random.Range(-2, 3) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj.transform.GetComponent<Bonus>().bonusCount = Random.Range(2, 6);
                }
                else if (count == 1)
                {
                    var obj = Instantiate(bonus, new Vector3(Random.Range(-2, 0) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj.transform.GetComponent<Bonus>().bonusCount = Random.Range(2, 6);
                    var obj2 = Instantiate(bonus, new Vector3(Random.Range(1, 3) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj2.transform.GetComponent<Bonus>().bonusCount = Random.Range(2, 6);
                }
            }
            else if (choose >= 11 && choose <= 13)
            {
                if (doubler == 0)
                {
                    var obj = Instantiate(bonus, new Vector3(Random.Range(-2, 0) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj.transform.GetComponent<Bonus>().bonusCount = Random.Range(2, 6);
                    var obj2 = Instantiate(Box, new Vector3(Random.Range(1, 3) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj2.transform.GetChild(0).GetComponent<Box>().crashCount = Random.Range(4, 20);
                }
                else if (doubler == 1)
                {
                    var obj = Instantiate(Box, new Vector3(Random.Range(-2, 0) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj.transform.GetChild(0).GetComponent<Box>().crashCount = Random.Range(4, 20);
                    var obj2 = Instantiate(bonus, new Vector3(Random.Range(1, 3) * 3, 0.5f, i), Quaternion.identity, transform);
                    obj2.transform.GetComponent<Bonus>().bonusCount = Random.Range(2, 6);
                }
            }
        }
    }
}
