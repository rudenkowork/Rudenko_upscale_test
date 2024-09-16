using Infrastructure.Services.SceneManagement;

namespace Extensions
{
    public static class TypeExtensions
    {
        public static string ToStringFormat(this SceneType sceneType)
        {
            return sceneType switch
            {
                SceneType.UNKNOWN => null,
                SceneType.GAMEPLAY => "Gameplay",
                _ => null
            };
        }
    }
}