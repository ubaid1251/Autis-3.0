using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public List<LockedCards> cards;
    private void Start()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (i % 2 == 0)
            {
                cards[i].eye1.Play("eye");
                cards[i].eye2.Play("eye");
            }
            else
            {
                cards[i].eye1.Play("eye2");
                cards[i].eye2.Play("eye2");
            }
        }
    }
}
