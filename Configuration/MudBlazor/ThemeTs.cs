using MudBlazor;

namespace SupportHelper.Blazor.Configuration.MudBlazor
{
    public class ThemeTs : MudTheme
    {
        public ThemeTs() : base()
        {
            PaletteLight = SetPalleteLight();
            PaletteDark = SetPalleteDark();
        }

        private static PaletteLight SetPalleteLight()
        {
            return new PaletteLight
            {
                Primary = Colors.Pink.Default,
                Secondary = Colors.Pink.Lighten5,
                Tertiary = Colors.Pink.Lighten2
            };
        }

        private static PaletteDark SetPalleteDark()
        {
            return new PaletteDark
            {
                Primary = Colors.Pink.Default,
                Secondary = Colors.Pink.Lighten5,
                Tertiary = Colors.Pink.Accent2,
            };
        }
    }
}
