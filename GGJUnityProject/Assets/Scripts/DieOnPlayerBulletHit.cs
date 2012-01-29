using UnityEngine;
using System.Collections;

public class DieOnPlayerBulletHit : MonoBehaviour 
{
	public GameObject ExplosionPrefab;
	public GameObject soundObject;
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.name.Equals("Bullet(Clone)")) 
		{
			// Die
			Destroy(this.gameObject);
			// Also destroy the player's bullet
			Destroy(other.gameObject);
			Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
			soundObject.audio.Play();
		}
	}
}
