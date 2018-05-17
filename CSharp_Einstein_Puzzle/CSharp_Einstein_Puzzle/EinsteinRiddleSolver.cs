using System;
using System.Diagnostics;

class EinsteinRiddleSolver
{
    private Developer[] developers;
    private char[][] four_permutations;
    private int[][] five_permutations;

    
    public EinsteinRiddleSolver()
    {
        this.InitPermutations();

        // create five developers
        this.developers = new Developer[5];
        for (int i = 0; i < this.developers.Length; i++)
            this.developers[i] = new Developer();

        // Hint 8: "the developer in the center drinks Caribou"
        this.developers[2].Drink = Drink.Caribou;

        // Hint 9: "the Red Hat user is sitting on the far left"
        this.developers[0].OS = OS.RedHat;

        // Hint 14: "the Red Hat user sits next to the Acer owner"
        this.developers[1].ComputerBrand = ComputerBrand.Acer;
    }

    private void InitPermutations()
    {
        this.four_permutations = new char[][]
        {
            new char[] {'a','b','c','d'}, new char[] {'a','c','b','d'},
            new char[] {'b','a','c','d'}, new char[] {'b','c','a','d'},
            new char[] {'c','a','b','d'}, new char[] {'c','b','a','d'},
            new char[] {'a','b','d','c'}, new char[] {'a','c','d','b'},
            new char[] {'b','a','d','c'}, new char[] {'b','c','d','a'},
            new char[] {'c','a','d','b'}, new char[] {'c','b','d','a'},
            new char[] {'a','d','b','c'}, new char[] {'a','d','c','b'},
            new char[] {'b','d','a','c'}, new char[] {'b','d','c','a'},
            new char[] {'c','d','a','b'}, new char[] {'c','d','b','a'},
            new char[] {'d','a','b','c'}, new char[] {'d','a','c','b'},
            new char[] {'d','b','a','c'}, new char[] {'d','b','c','a'},
            new char[] {'d','c','a','b'}, new char[] {'d','c','b','a'}
        };

        this.five_permutations = new int[][]
        {
             new int[] { 0,1,2,3,4 }, new int[] { 0,1,2,4,3 },
             new int[] { 0,1,3,2,4 }, new int[] { 0,1,3,4,2 },
             new int[] { 0,1,4,2,3 }, new int[] { 0,1,4,3,2 },
             new int[] { 0,2,1,3,4 }, new int[] { 0,2,1,4,3 }, new int[] { 0,2,3,1,4 },
             new int[] { 0,2,3,4,1 }, new int[] { 0,2,4,1,3 }, new int[] { 0,2,4,3,1 },
             new int[] { 0,3,1,2,4 }, new int[] { 0,3,1,4,2 }, new int[] { 0,3,2,1,4 },
             new int[] { 0,3,2,4,1 }, new int[] { 0,3,4,1,2 }, new int[] { 0,3,4,2,1 },
             new int[] { 0,4,1,2,3 }, new int[] { 0,4,1,3,2 }, new int[] { 0,4,2,1,3 },
             new int[] { 0,4,2,3,1 }, new int[] { 0,4,3,1,2 }, new int[] { 0,4,3,2,1 },
             new int[] { 1,0,2,3,4 }, new int[] { 1,0,2,4,3 }, new int[] { 1,0,3,2,4 }, 
             new int[] { 1,0,3,4,2 }, new int[] { 1,0,4,2,3 }, new int[] { 1,0,4,3,2 },
             new int[] { 1,2,0,3,4 }, new int[] { 1,2,0,4,3 }, new int[] { 1,2,3,0,4 },
             new int[] { 1,2,3,4,0 }, new int[] { 1,2,4,0,3 }, new int[] { 1,2,4,3,0 },
             new int[] { 1,3,0,2,4 }, new int[] { 1,3,0,4,2 }, new int[] { 1,3,2,0,4 },
             new int[] { 1,3,2,4,0 }, new int[] { 1,3,4,0,2 }, new int[] { 1,3,4,2,0 },
             new int[] { 1,4,0,2,3 }, new int[] { 1,4,0,3,2 }, new int[] { 1,4,2,0,3 },
             new int[] { 1,4,2,3,0 }, new int[] { 1,4,3,0,2 }, new int[] { 1,4,3,2,0 },
             new int[] { 2,0,1,3,4 }, new int[] { 2,0,1,4,3 }, new int[] { 2,0,3,1,4 },
             new int[] { 2,0,3,4,1 }, new int[] { 2,0,4,1,3 }, new int[] { 2,0,4,3,1 },
             new int[] { 2,1,0,3,4 }, new int[] { 2,1,0,4,3 }, new int[] { 2,1,3,0,4 },
             new int[] { 2,1,3,4,0 }, new int[] { 2,1,4,0,3 }, new int[] { 2,1,4,3,0 },
             new int[] { 2,3,0,1,4 }, new int[] { 2,3,0,4,1 }, new int[] { 2,3,1,0,4 },
             new int[] { 2,3,1,4,0 }, new int[] { 2,3,4,0,1 }, new int[] { 2,3,4,1,0 },
             new int[] { 2,4,0,1,3 }, new int[] { 2,4,0,3,1 }, new int[] { 2,4,1,0,3 },
             new int[] { 2,4,1,3,0 }, new int[] { 2,4,3,0,1 }, new int[] { 2,4,3,1,0 },
             new int[] { 3,0,1,2,4 }, new int[] { 3,0,1,4,2 }, new int[] { 3,0,2,1,4 },
             new int[] { 3,0,2,4,1 }, new int[] { 3,0,4,1,2 }, new int[] { 3,0,4,2,1 },
             new int[] { 3,1,0,2,4 }, new int[] { 3,1,0,4,2 }, new int[] { 3,1,2,0,4 },
             new int[] { 3,1,2,4,0 }, new int[] { 3,1,4,0,2 }, new int[] { 3,1,4,2,0 },
             new int[] { 3,2,0,1,4 }, new int[] { 3,2,0,4,1 }, new int[] { 3,2,1,0,4 },
             new int[] { 3,2,1,4,0 }, new int[] { 3,2,4,0,1 }, new int[] { 3,2,4,1,0 },
             new int[] { 3,4,0,1,2 }, new int[] { 3,4,0,2,1 }, new int[] { 3,4,1,0,2 },
             new int[] { 3,4,1,2,0 }, new int[] { 3,4,2,0,1 }, new int[] { 3,4,2,1,0 },
             new int[] { 4,0,1,2,3 }, new int[] { 4,0,1,3,2 }, new int[] { 4,0,2,1,3 },
             new int[] { 4,0,2,3,1 }, new int[] { 4,0,3,1,2 }, new int[] { 4,0,3,2,1 },
             new int[] { 4,1,0,2,3 }, new int[] { 4,1,0,3,2 }, new int[] { 4,1,2,0,3 },
             new int[] { 4,1,2,3,0 }, new int[] { 4,1,3,0,2 }, new int[] { 4,1,3,2,0 },
             new int[] { 4,2,0,1,3 }, new int[] { 4,2,0,3,1 }, new int[] { 4,2,1,0,3 },
             new int[] { 4,2,1,3,0 }, new int[] { 4,2,3,0,1 }, new int[] { 4,2,3,1,0 },
             new int[] { 4,3,0,1,2 }, new int[] { 4,3,0,2,1 },
             new int[] { 4,3,1,0,2 }, new int[] { 4,3,1,2,0 },
             new int[] { 4,3,2,0,1 }, new int[] { 4,3,2,1,0 }
        };
    }

    public void SolvePuzzle()
    {
        // iterate languages
        for (int i = 0; i < this.five_permutations.Length; i++)
        {
            int[] perm1 = this.five_permutations[i];
            this.developers[perm1[0]].Language = Language.Java;
            this.developers[perm1[1]].Language = Language.CCPlus;
            this.developers[perm1[2]].Language = Language.NodeJS;
            this.developers[perm1[3]].Language = Language.Angular;
            this.developers[perm1[4]].Language = Language.DotNet;

            // iterate snacks
            for (int j = 0; j < this.five_permutations.Length; j++)
            {
                int[] perm2 = this.five_permutations[j];
                this.developers[perm2[0]].Snack = Snack.Chocolate;
                this.developers[perm2[1]].Snack = Snack.Popcorn;
                this.developers[perm2[2]].Snack = Snack.Cheetos;
                this.developers[perm2[3]].Snack = Snack.SwedishFish;
                this.developers[perm2[4]].Snack = Snack.Carrots;

                //Short circuit iteration by checking hints snack related hints, if they fail, go to the next permutation
                // See if the person who writes in Java eats Chocolate
                if (!this.Hint_06_Verify())
                    continue;

                // See if the developer who writes C/C+ sits next to the one who eats Popcorn
                if (!this.Hint_10_Verify())
                    continue;

                // See if the person who eats Carrots sits next to the person who writes NodeJS
                if (!this.Hint_11_Verify())
                    continue;

                // iterate drinks
                for (int k = 0; k < this.four_permutations.Length; k++)
                {
                    char[] perm3 = this.four_permutations[k];

                    int k1 =
                        (perm3[0] == 'a') ? 0 : (perm3[0] == 'b') ? 1 :
                        (perm3[0] == 'c') ? 3 : 4;
                    int k2 =
                        (perm3[1] == 'a') ? 0 : (perm3[1] == 'b') ? 1 :
                        (perm3[1] == 'c') ? 3 : 4;
                    int k3 =
                        (perm3[2] == 'a') ? 0 : (perm3[2] == 'b') ? 1 :
                        (perm3[2] == 'c') ? 3 : 4;
                    int k4 =
                        (perm3[3] == 'a') ? 0 : (perm3[3] == 'b') ? 1 :
                        (perm3[3] == 'c') ? 3 : 4;

                    this.developers[k1].Drink = Drink.Mayorga;
                    this.developers[k2].Drink = Drink.Dunkin;
                    this.developers[k3].Drink = Drink.Starbucks;
                    this.developers[k4].Drink = Drink.Peets;

                    //Short circuit iteration by checking hints drink related hints, if they fail, go to the next permutation
                    // See if the developer who writes Angular drinks Mayorga
                    if (!this.Hint_12_Verify())
                        continue;

                    // See if the developer who writes C/C+ sits next to someone who drinks Peets
                    if (!this.Hint_15_Verify())
                        continue;

                    // iterate computer brands
                    for (int l = 0; l < this.four_permutations.Length; l++)
                    {
                        char[] perm4 = this.four_permutations[l];

                        int l1 =
                            (perm4[0] == 'a') ? 0 : (perm4[0] == 'b') ? 2 :
                            (perm4[0] == 'c') ? 3 : 4;
                        int l2 =
                            (perm4[1] == 'a') ? 0 : (perm4[1] == 'b') ? 2 :
                            (perm4[1] == 'c') ? 3 : 4;
                        int l3 =
                            (perm4[2] == 'a') ? 0 : (perm4[2] == 'b') ? 2 :
                            (perm4[2] == 'c') ? 3 : 4;
                        int l4 =
                            (perm4[3] == 'a') ? 0 : (perm4[3] == 'b') ? 2 :
                            (perm4[3] == 'c') ? 3 : 4;

                        this.developers[l1].ComputerBrand = ComputerBrand.Dell;
                        this.developers[l2].ComputerBrand = ComputerBrand.Mac;
                        this.developers[l3].ComputerBrand = ComputerBrand.Samsung;
                        this.developers[l4].ComputerBrand = ComputerBrand.HP;

                        //Short circuit iteration by checking hints computer brand related hints, if they fail, go to the next permutation
                        // See if the Dell owner is on the left of the Samsung owner
                        if (!this.Hint_04_Verify())
                            continue;

                        // See if the Dell owner drinks Dunkin’
                        if (!this.Hint_05_Verify())
                            continue;

                        // See if the owner of the HP writes NodeJS
                        if (!this.Hint_07_Verify())
                            continue;

                        // iterate OSs
                        for (int m = 0; m < this.four_permutations.Length; m++)
                        {
                            char[] perm5 = this.four_permutations[m];

                            int m1 =
                                (perm5[0] == 'a') ? 1 : (perm5[0] == 'b') ? 2 :
                                (perm5[0] == 'c') ? 3 : 4;
                            int m2 =
                                (perm5[1] == 'a') ? 1 : (perm5[1] == 'b') ? 2 :
                                (perm5[1] == 'c') ? 3 : 4;
                            int m3 =
                                (perm5[2] == 'a') ? 1 : (perm5[2] == 'b') ? 2 :
                                (perm5[2] == 'c') ? 3 : 4;
                            int m4 =
                                (perm5[3] == 'a') ? 1 : (perm5[3] == 'b') ? 2 :
                                (perm5[3] == 'c') ? 3 : 4;

                            this.developers[m1].OS = OS.OSX;
                            this.developers[m2].OS = OS.Android;
                            this.developers[m3].OS = OS.ChromeOS;
                            this.developers[m4].OS = OS.Windows;

                            // Check the remaining hints now that the potential solution table is complete
                            // See if the Mac uses OSX
                            if (!this.Hint_01_Verify())
                                continue;

                            // See if the Android user eats Cheetos
                            if (!this.Hint_02_Verify())
                                continue;

                            // See if the ChromeOS user drinks Starbucks
                            if (!this.Hint_03_Verify())
                                continue;

                            // See if the Windows user writes .net
                            if (!this.Hint_13_Verify())
                                continue;

                            // print solution if things make it this far
                            this.PrintSolution();
                        }
                    }
                }
            }
        }
    }

    // Hint 1: "the Mac uses OSX"
    private bool Hint_01_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].OS == OS.OSX)
            {
                if (this.developers[i].ComputerBrand == ComputerBrand.Mac)
                {
                    tip = true;
                }
                break;
            }
        }
        return tip;
    }

    // Hint 2: "the Android user eats Cheetos"
    private bool Hint_02_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].OS == OS.Android)
            {
                if (this.developers[i].Snack == Snack.Cheetos)
                {
                    tip = true;
                } 
                break;
            }
        }
        return tip;
    }

    // Hint 3: "the ChromeOS user drinks Starbucks"
    private bool Hint_03_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].OS == OS.ChromeOS)
            {
                if (this.developers[i].Drink == Drink.Starbucks)
                {
                    tip = true;
                }
                break;
            }
        }
        return tip;
    }

    // Hint 4: "the Dell owner is on the left of the Samsung owner"
    private bool Hint_04_Verify()
    {
        if ((this.developers[2].ComputerBrand == ComputerBrand.Dell &&
                this.developers[3].ComputerBrand == ComputerBrand.Samsung) ||
            (this.developers[3].ComputerBrand == ComputerBrand.Dell &&
                this.developers[4].ComputerBrand == ComputerBrand.Samsung))
        {
            return true;
        }
        else
            return false;
    }

    // Hint 5: "the Dell owner drinks Dunkin"
    private bool Hint_05_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].ComputerBrand == ComputerBrand.Dell)
            {
                if (this.developers[i].Drink == Drink.Dunkin)
                {
                    tip = true;
                }
                break;
            }
        }
        return tip;
    }

    // Hint 6: "the person who writes in Java eats Chocolate"
    private bool Hint_06_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].Language == Language.Java)
            {
                if (this.developers[i].Snack == Snack.Chocolate)
                {
                    tip = true;
                }
                break;
            }
        }
        return tip;
    }

    // Hint 7: "the owner of the HP writes NodeJS"
    private bool Hint_07_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].ComputerBrand == ComputerBrand.HP)
            {
                if (this.developers[i].Language == Language.NodeJS)
                {
                    tip = true;
                }
                break;
            }
        }
        return tip;
    }

    // Hint 8: "the developer in the center drinks Caribou"
    // See the constructor

    // Hint 9: "the Red Hat user is sitting on the far left"
    // See the constructor

    // Hint 10: "the developer who writes C/C+ sits next to the one who eats Popcorn"
    private bool Hint_10_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].Language == Language.CCPlus)
            {
                if (i == 0)
                {
                    if (this.developers[1].Snack == Snack.Popcorn)
                        tip = true;
                }
                else if (i == 4)
                {
                    if (this.developers[3].Snack == Snack.Popcorn)
                        tip = true;
                }
                else if (this.developers[i - 1].Snack == Snack.Popcorn ||
                    this.developers[i + 1].Snack == Snack.Popcorn)
                    tip = true;

                break;
            }
        }

        return tip;
    }

    // Hint 11: "the person who eats Carrots sits next to the person who writes NodeJS"
    private bool Hint_11_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].Snack == Snack.Carrots)
            {
                if (i == 0)
                {
                    if (this.developers[1].Language == Language.NodeJS)
                        tip = true;
                }
                else if (i == 4)
                {
                    if (this.developers[3].Language == Language.NodeJS)
                        tip = true;
                }
                else if (this.developers[i - 1].Language == Language.NodeJS ||
                            this.developers[i + 1].Language == Language.NodeJS)
                        tip = true;
            
                break;
            }
        }
        return tip;
    }

    // Hint 12: "the developer who writes Angular drinks Mayorga"
    private bool Hint_12_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].Language == Language.Angular)
            {
                if (this.developers[i].Drink == Drink.Mayorga)
                    tip = true;

                break;
            }
        }
        return tip;
    }

    // Hint 13: "the Windows user writes .net"
    private bool Hint_13_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].OS == OS.Windows)
            {
                if (this.developers[i].Language == Language.DotNet)
                    tip = true;

                break;
            }
        }
        return tip;
    }

    // Hint 14: "the Red Hat user sits next to the Acer owner"
    // See the constructor

    // Hint 15: "the developer who writes C/C+ sits next to someone who drinks Peets"
    private bool Hint_15_Verify()
    {
        bool tip = false;
        for (int i = 0; i < 5; i++)
        {
            if (this.developers[i].Language == Language.CCPlus)
            {
                if (i == 0)
                {
                    if (this.developers[1].Drink == Drink.Peets)
                        tip = true;
                }
                else if (i == 4)
                {
                    if (this.developers[3].Drink == Drink.Peets)
                        tip = true;
                }
                else if (this.developers[i - 1].Drink == Drink.Peets ||
                    this.developers[i + 1].Drink == Drink.Peets)
                        tip = true;

                break;
            }
        }
        return tip;
    }

    public void PrintSolution()
    {
        for (int n = 0; n < 5; n++)
            if (this.developers[n].Snack == Snack.SwedishFish)
                Console.WriteLine("\nThe {0} owner, who writes {1}, eats the Swedish Fish.\n", this.developers[n].ComputerBrand, this.developers[n].Language);
    }
}

