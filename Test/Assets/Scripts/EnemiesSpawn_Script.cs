using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn_Script : MonoBehaviour
{

    [SerializeField] Transform topRight, bottomLeft;
    [SerializeField] private GameObject phantomMelee, phantomLight;
    [SerializeField] private int amountMelee, amountLight,idSpawn;
    [SerializeField] private List<GameObject> enemies1, enemies2;

    public bool active;

    public void spawnEnemies()
    {
        // spawn Melee enemies
   
        for (int i = 0; i<amountMelee; i++)
        {
            Vector2 pos = new Vector2(Random.Range(topRight.position.x, bottomLeft.position.x),
                                     Random.Range(topRight.position.y, bottomLeft.position.y));
            GameObject enemy = Instantiate(phantomMelee, pos, Quaternion.identity);
            enemy.GetComponent<BasicEnemy_Script>().spawnID = idSpawn;
            enemies1.Add(enemy);
        }
        // spawn Light enemies
        for (int i = 0; i < amountLight; i++)
        {
            Vector2 pos = new Vector2(Random.Range(topRight.position.x, bottomLeft.position.x),
                                     Random.Range(topRight.position.y, bottomLeft.position.y));
            GameObject enemy = Instantiate(phantomLight, pos, Quaternion.identity);
            enemy.GetComponent<enemyLight_script>().spawnID = idSpawn;
            enemies2.Add(enemy);
        }
    }

    public void clearEnemies()
    {
        // clear Melee enemies

        for (int i = 0; i < enemies1.Count; i++)
        {
            Destroy(enemies1[i]);
        }
        // clear Light enemies
        for (int i = 0; i < enemies2.Count; i++)
        {
            Destroy(enemies2[i]);
        }
    }

}
