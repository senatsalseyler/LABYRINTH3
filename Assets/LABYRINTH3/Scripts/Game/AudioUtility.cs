using UnityEngine;
using UnityEngine.Audio;

namespace Labyrinth3.Game
{

    public  class AudioUtility
    {
        public static void CreateSFX(AudioClip clip, Vector3 position, float spatialBlend,
            float rolloffDistanceMin = 1f)
        {
            GameObject impactSfxInstance = new GameObject();
            impactSfxInstance.transform.position = position;
            AudioSource source = impactSfxInstance.AddComponent<AudioSource>();
            source.clip = clip;
            source.spatialBlend = spatialBlend;
            source.minDistance = rolloffDistanceMin;
            source.Play();


            TimedSelfDestruct timedSelfDestruct = impactSfxInstance.AddComponent<TimedSelfDestruct>();
            timedSelfDestruct.LifeTime = clip.length;
        }

    }
}