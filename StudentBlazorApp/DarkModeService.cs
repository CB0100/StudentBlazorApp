namespace StudentBlazorApp
{
    public class DarkModeService
    {
        private bool isDarkMode = false;

        public bool IsDarkMode => isDarkMode;

        public void ToggleDarkMode()
        {
            isDarkMode = !isDarkMode;
        }
    }

}
