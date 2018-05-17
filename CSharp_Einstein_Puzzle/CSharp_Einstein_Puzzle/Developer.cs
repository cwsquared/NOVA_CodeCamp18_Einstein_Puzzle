using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum OS { RedHat, OSX, Android, ChromeOS, Windows }
public enum ComputerBrand { Mac, Dell, Samsung, HP, Acer }
public enum Language { Java, CCPlus, NodeJS, Angular, DotNet }
public enum Drink { Starbucks, Dunkin, Caribou, Mayorga, Peets }
public enum Snack { Cheetos, Chocolate, Popcorn, Carrots, SwedishFish }

struct Developer
{
    public OS OS { get; set; }
    public ComputerBrand ComputerBrand { get; set; }
    public Language Language { get; set; }
    public Drink Drink { get; set; }
    public Snack Snack { get; set; }
}