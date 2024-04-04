namespace PixelGunCheat.modules
{
    public interface ICheatModule
    {
        public void ToggleModule();
        public bool IsEnabled();
        public string GetName();
    }
}