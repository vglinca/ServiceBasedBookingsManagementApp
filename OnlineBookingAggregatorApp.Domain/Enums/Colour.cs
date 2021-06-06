using OnlineBookingAggregatorApp.Domain.Entities;

namespace OnlineBookingAggregatorApp.Domain.Enums
{
    public enum Colour
    {
        Red = 1,
        Pink,
        Purple,
        DeepPurple,
        Indigo,
        Blue,
        LightBlue,
        Cyan,
        Teal,
        Green,
        LightGreen,
        Lime,
        Yellow,
        Amber,
        Orange,
        DeepOrange,
        Brown,
        Grey,
        BlueGrey
    }

    public class ColourEntity : EnumEntity<Colour>
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public ColourEntity() {}

        public ColourEntity(Colour id, string name, string primary, string secondary) : base(id, name)
        {
            Primary = primary;
            Secondary = secondary;
        }
    }

    public class ColourEntityFactory : EnumEntityFactory<Colour, ColourEntity>
    {
        public static ColourEntityFactory Instance { get; } = new ColourEntityFactory();

        public ColourEntityFactory()
        {
            Register(
                new ColourEntity(Colour.Red, "Red", "#ff1744", "#ef5350"),
                new ColourEntity(Colour.Pink, "Pink", "#f06292", "#ec407a"),
                new ColourEntity(Colour.Purple, "Purple", "#9c27b0", "#7b1fa2"),
                new ColourEntity(Colour.DeepPurple, "Deep Purple", "#7e57c2", "#673ab7"),
                new ColourEntity(Colour.Indigo, "Indigo", "#3f51b5", "#303f9f"),
                new ColourEntity(Colour.Blue, "Blue", "#1e88e5", "#1565c0"),
                new ColourEntity(Colour.LightBlue, "Light Blue", "#29b6f6", "#03a9f4"),
                new ColourEntity(Colour.Cyan, "Cyan", "#4dd0e1", "#00acc1"),
                new ColourEntity(Colour.Teal, "Teal", "#26a69a", "#00897b"),
                new ColourEntity(Colour.Green, "Green", "#66bb6a", "#43a047"),
                new ColourEntity(Colour.LightGreen, "Light Green", "#9ccc65", "#7cb342"),
                new ColourEntity(Colour.Lime, "Lime", "#cddc39", "#c0ca33"),
                new ColourEntity(Colour.Yellow, "Yellow", "#ffeb3b", "#fdd835"),
                new ColourEntity(Colour.Amber, "Amber", "#ffca28", "#ffb300"),
                new ColourEntity(Colour.Orange, "Orange", "#ff9800", "#f57c00"),
                new ColourEntity(Colour.DeepOrange, "Deep Orange", "#ff7043", "#ff5722"),
                new ColourEntity(Colour.Brown, "Brown", "#795548", "#5d4037"),
                new ColourEntity(Colour.Grey, "Grey", "#9e9e9e", "#757575"),
                new ColourEntity(Colour.BlueGrey, "Blue Grey", "#78909c", "#546e7a")
                );
        }
    }
}