using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CardContainer
{
    void add(Card card);

    Vector3 nextCardPosition();
}
