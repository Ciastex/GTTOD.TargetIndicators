using Reactor.API.Attributes;
using Reactor.API.Interfaces.Systems;
using Reactor.API.Logging;
using Reactor.API.Storage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GTTOD.TargetIndicators
{
    [ModEntryPoint(ModID)]
    public class Mod : MonoBehaviour
    {
        public const string ModID = "com.github.ciastex/EnemyIndicatorGTTOD";

        private readonly FileSystem _fs = new FileSystem();
        private readonly Log _log = LogManager.GetForCurrentAssembly();

        public void Initialize(IManager manager)
        {
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Textures.Initialize(_fs);
        }

        public void Update()
        {
            var enemies = GameObject.FindObjectsOfType<Respawner>();

            foreach (var e in enemies)
            {
                if (!e.gameObject.GetComponent<TargetIndicator>())
                    e.gameObject.AddComponent<TargetIndicator>();
            }
        }
    }
}
