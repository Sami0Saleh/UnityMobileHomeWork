using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shoot : MonoBehaviour
{
    [SerializeField] const float TimeShoot = .5f;
    [SerializeField] GameObject ballPlayer;
    [SerializeField] Transform ballsParent;
    GameObject copy, ball;
    internal List<GameObject> ballCopys = new List<GameObject>();
    void Awake()
    {
        for (byte n = 0; n < 10; n++) MakeBall();
    }
    GameObject MakeBall()
    {
        ball = Instantiate(ballPlayer, transform.position, transform.rotation, ballsParent);
        ball.SetActive(false);
        ballCopys.Add(ball);
        return ball;
    }
    void Start()
    {
        StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeShoot);
            copy = GatBall();
            copy.transform.position = transform.position;
            copy.transform.rotation = transform.rotation;
            copy.SetActive(true);
        }
    }
    GameObject GatBall()
    {
        foreach (GameObject g in ballCopys)
        {
            if (g.activeInHierarchy == false)
            {
                return g;
            }
        }
        return MakeBall();
    }
}