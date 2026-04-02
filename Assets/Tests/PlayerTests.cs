using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTests
{
    private const string SceneName = "SampleScene";
    [UnityTest]
    public IEnumerator TestPlayerSetup()
    {
        SceneManager.LoadScene(SceneName);

        yield return null;

        PlayerController playerController = GameObject.FindFirstObjectByType<PlayerController>();

        Assert.IsNotNull(playerController, "PlayerController is null");

        GameObject playerGO = playerController.gameObject;

        Rigidbody2D rigidBody2d = playerGO.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rigidBody2d, "Player has no RigidBody2d");

        Collider2D collider2d = playerGO.GetComponent<Collider2D>();
        Assert.IsNotNull(collider2d, "Player has no Collider2d");

        Assert.AreEqual(RigidbodyType2D.Dynamic, rigidBody2d.bodyType, "RigidBody2d is not dynamic");

        Assert.AreEqual(0, rigidBody2d.gravityScale, "Gravity Scale is not 0");
    }
}
