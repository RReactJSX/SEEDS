/* 
-------------------------------------------------------
-------------------------------------------------------
--2020--2021 Game Design (facilitated by Ms. Rushing)--
-------------------------------------------------------
-------------------------------------------------------
----------------Project SEEDS! v0.1b-------------------
-------------------------------------------------------
----------Developed by Reactive Peak Studios-----------
-------------------------------------------------------
-------------------------------------------------------
----------------------SOURCES--------------------------
------------https://www.codegrepper.com/---------------
-------------https://stackoverflow.com/----------------
-----https://www.youtube.com/watch?v=qh7MCQzjH08-------
-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------
----Heavy inspiration from wintrmut3's Maelstromexe----
-------> http://wintrmut3.itch.io/maelstromexe <-------
-------------------------------------------------------
-------------------------------------------------------
*/
using System;
using System.Collections.Generic;
namespace Adventure
{
    class Program
    {
        public static System.Random random = new System.Random();
        public static string[] plotsList = { "a1", "a2", "a3", "b1", "b2", "b3", "c1", "c2", "c3" };
        public static bool[] plotsPlanted = { false, false, false, false, false, false, false, false, false };
        public static bool[] plotsWatered = { false, false, false, false, false, false, false, false, false };
        public static int[] plotsHarvestTime = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static bool dailyWateredA = false;
        public static int day = 1;
        public static int coins = 200;
        public static int difMin = 100000;
        public static int difMax = 150000;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(".\nSEEDS\n.\nWelcome to SEEDS! A not so calming farming game! Choose a difficulty.\n'1' for ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("EASY");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n'2' for ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("NORMAL");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n'3' for ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("HARD");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n'4' for ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("NIGHTMARE");
            Console.WriteLine("");
            Console.ResetColor();
            difSelect();
        }
        static void difSelect()
        {
            var dif = Console.ReadLine().ToLower();
            switch (dif)
            {
                case "1":
                    difMin = 150000;
                    difMax = 250000;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(".\nYou have selected ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("EASY");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\nLets begin by viewing all of our plots! Type 'list'.");
                    Console.ResetColor();
                    tutorialLs();
                    break;
                case "2":
                    difMin = 100000;
                    difMax = 150000;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(".\nYou have selected ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("NORMAL");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\nLets begin by viewing all of our plots! Type 'list'.");
                    Console.ResetColor();
                    tutorialLs();
                    break;
                case "3":
                    difMin = 50000;
                    difMax = 100000;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(".\nYou have selected ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("HARD");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\nLets begin by viewing all of our plots! Type 'list'.");
                    Console.ResetColor();
                    tutorialLs();
                    break;
                case "4":
                    difMin = 30000;
                    difMax = 50000;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(".\nYou have selected ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("NIGHTMARE");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\nLets begin by viewing all of our plots! Type 'list'.");
                    Console.ResetColor();
                    tutorialLs();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(".\nImproper syntax used. Please try again.");
                    Console.ResetColor();
                    difSelect();
                    break;
            }
        }
        static void tutorialLs()
        {
            var lsEx = Console.ReadLine().ToLower();
            switch (lsEx)
            {
                case "list":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\n.\nA list of all plots:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[{0}]", string.Join(", ", plotsList));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\nA list of plots planted:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[{0}]", string.Join(", ", plotsPlanted));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\nA list of plots watered for the day:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[{0}]", string.Join(", ", plotsWatered));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\nCurrent plant growth (max 4):");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[{0}]", string.Join(", ", plotsHarvestTime));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\nYou have " + coins + " coins.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\n.\nThese are your plots! Let's start off by planting our first crop using 'plant'.");
                    Console.ResetColor();
                    tutorialPlant();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                    Console.ResetColor();
                    tutorialLs();
                    break;
            }
        }
        static void tutorialPlant()
        {
            var plantEx = Console.ReadLine().ToLower();
            if (plantEx == "plant")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(".\nTo specify what plots you would like to plant on, use a plot name. An example of this would be a singular plot 'a1' or you can do multiple at a time 'a1 a2 a3'. For the tutorial, we're going to plant on 'a1'.");
                Console.ResetColor();
                var waterCropEx = Console.ReadLine().ToLower();
                if (waterCropEx == "a1")
                {
                    plotsPlanted[0] = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\nA list of plots planted:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[{0}]", string.Join(", ", plotsPlanted));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\n.\nCongradulations! You've just planted your first crop on plot a1! Let's water it, shall we? Use 'water' to water the crop on a1.");
                    Console.ResetColor();
                    tutorialWater();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                    Console.ResetColor();
                    tutorialPlant();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                Console.ResetColor();
                tutorialPlant();
            }
        }
        static void tutorialWater()
        {
            var waterEx = Console.ReadLine().ToLower();
            if (waterEx == "water")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(".\nSimilar to the previous command, we're going to use 'a1'.");
                Console.ResetColor();
                var waterCropEx = Console.ReadLine().ToLower();
                if (waterCropEx == "a1")
                {
                    plotsWatered[0] = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\nA list of plots watered for the day:");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[{0}]", string.Join(", ", plotsWatered));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\n.\nSweet! You've just watered your first crop on plot a1! To continue to the text day use 'wait'.");
                    Console.ResetColor();
                    tutorialWait();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                    Console.ResetColor();
                    tutorialWater();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                Console.ResetColor();
                tutorialWater();
            }
        }
        static void tutorialWait()
        {
            var nextDayEx = Console.ReadLine().ToLower();
            WIP();
            switch (nextDayEx)
            {
                case "wait":
                    day++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(".\n.\nA new day begins. You're currently on day " + day + ".");
                    Array.Clear(plotsWatered, 0, plotsWatered.Length);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\n.\nHere you'll be able to see that your current plant growth is at 1. Every day you water a plant and wait until the next day the plant growth is increased. Nomally a plant can only be harvested if it's fully grown (level 4) but for the sake of this tutorial, we're going to harvest this level 1 plant. We'll begin by typing in 'harvest'.");
                    Console.ResetColor();
                    tutorialHar();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                    Console.ResetColor();
                    tutorialWait();
                    break;
            }
        }
        static void tutorialHar()
        {
            var harEx = Console.ReadLine().ToLower();
            if (harEx == "harvest")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(".\nSimilar to the previous to the 'plant' and 'water' command, we're going to specify a plot. For the tutorial, use 'a1'.");
                Console.ResetColor();
                var harCropEx = Console.ReadLine().ToLower();
                if (harCropEx == "a1")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(".\n+20");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(".\n You've successfully harvested your first plant! You've gained 20 coins. Coins are used to plant with. Be extremely cautious of natual disasters as these can remove some of your plants! If you need to view the commands during the game, type 'help'. Good luck!");
                    plotsHarvestTime[0] = 0;
                    plotsPlanted[0] = false;
                    gameplay();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                    Console.ResetColor();
                    tutorialHar();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(".\n.\nImproper syntax used. Please try again.");
                Console.ResetColor();
                tutorialHar();
            }
        }
        static void gameplay()
        {
            var commandNA = Console.ReadLine().ToLower();
            switch (commandNA)
            {
                case "list": lsCMD(); break;
                case "day": dayCMD(); break;
                case "wait": waitCMD(); break;
                case "plant": plantCMD(); break;
                case "water": waterCMD(); break;
                case "harvest": harvestCMD(); break;
                case "help": helpCMD(); break;
                case "q;":
                    Console.ForegroundColor = ConsoleColor.Red;
                     Console.WriteLine(".\nExiting Game...");
                     Console.ResetColor();
                    break;
                default: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(".\n.\nImproper syntax used. Please try again."); Console.ResetColor(); gameplay(); break;
            }
        }
        static void lsCMD()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".\n.\nA list of all plots:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[{0}]", string.Join(", ", plotsList));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".\nA list of plots planted:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[{0}]", string.Join(", ", plotsPlanted));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".\nA list of plots watered for the day:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[{0}]", string.Join(", ", plotsWatered));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".\nCurrent plant growth (max 4):");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[{0}]", string.Join(", ", plotsHarvestTime));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".\nYou have " + coins + " coins.");
            Console.ResetColor();
            gameplay();
        }
        static void dayCMD()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".\n.\nYou're currently on day " + day + ".");
            Console.ResetColor();
            gameplay();
        }
        static void waitCMD()
        {
            day++;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(".\n.\nA new day begins. You're currently on day " + day + ".");
            var wtp = 0;
            foreach (bool watered in plotsWatered)
            {
                if (plotsPlanted[wtp] == true && watered == false && dailyWateredA == false)
                {
                    waitALERT();
                }
                wtp++;
            }
            plotsWatered.CopyTo(plotsPlanted, 0);
            var sacLoop = 0;
            foreach (bool planted in plotsPlanted)
            {
                if (planted == true && plotsHarvestTime[sacLoop] >= 4)
                {
                    plotsHarvestTime[sacLoop] = 4;
                }
                else
                {
                    plotsHarvestTime[sacLoop] = plotsHarvestTime[sacLoop] + 1;
                }
                if (planted == false)
                {
                    plotsHarvestTime[sacLoop] = 0;
                }
                sacLoop++;
            }
            Array.Clear(plotsWatered, 0, plotsWatered.Length);
            dailyWateredA = false;
            Console.ResetColor();
            gameplay();
        }
        static void waitALERT()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(".\n.\nALERT! Some crops have deteriorated. Make sure to water your plants each day or you are at risk of killing the plants!");
            dailyWateredA = true;
            Console.ResetColor();
        }
        static void plantCMD()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(".\nWhich plots would you like to plant on? 'exit' to cancel.");
            Console.ResetColor();
            string str = Console.ReadLine().ToLower();
            List<string> plantCompleted = new List<string>();
            if (str == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("'plant' has been terminated.");
                Console.ResetColor();
                gameplay();
            }
            else
            {
                string[] arrayPlanted = str.Split(' ');
                foreach (string value in arrayPlanted)
                {
                    switch (value)
                    {
                        case "a1":
                            if (plotsPlanted[0] == false && coins >= 15)
                            {
                                plotsPlanted[0] = true;
                                coins = coins - 15;
                                plantCompleted.Add("a1");
                            }
                            break;
                        case "a2":
                            if (plotsPlanted[1] == false && coins >= 15)
                            {
                                plotsPlanted[1] = true;
                                coins = coins - 15;
                                plantCompleted.Add("a2");
                            }
                            break;
                        case "a3":
                            if (plotsPlanted[2] == false && coins >= 15)
                            {
                                plotsPlanted[2] = true;
                                coins = coins - 15;
                                plantCompleted.Add("a3");
                            }
                            break;
                        case "b1":
                            if (plotsPlanted[3] == false && coins >= 15)
                            {
                                plotsPlanted[3] = true;
                                coins = coins - 15;
                                plantCompleted.Add("b1");
                            }
                            break;
                        case "b2":
                            if (plotsPlanted[4] == false && coins >= 15)
                            {
                                plotsPlanted[4] = true;
                                coins = coins - 15;
                                plantCompleted.Add("b2");
                            }
                            break;
                        case "b3":
                            if (plotsPlanted[5] == false && coins >= 15)
                            {
                                plotsPlanted[5] = true;
                                coins = coins - 15;
                                plantCompleted.Add("b3");
                            }
                            break;
                        case "c1":
                            if (plotsPlanted[6] == false && coins >= 15)
                            {
                                plotsPlanted[6] = true;
                                coins = coins - 15;
                                plantCompleted.Add("c1");
                            }
                            break;
                        case "c2":
                            if (plotsPlanted[7] == false && coins >= 15)
                            {
                                plotsPlanted[7] = true;
                                coins = coins - 15;
                                plantCompleted.Add("c2");
                            }
                            break;
                        case "c3":
                            if (plotsPlanted[8] == false && coins >= 15)
                            {
                                plotsPlanted[8] = true;
                                coins = coins - 15;
                                plantCompleted.Add("c3");
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have not specified a valid plot. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[{0}]", string.Join(", ", plantCompleted));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" have been planted successfully.\n");
            Console.ResetColor();
            gameplay();
        }
        static void waterCMD()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(".\nWhich plots would you like to water on? 'exit' to cancel.");
            Console.ResetColor();
            var str = Console.ReadLine().ToLower();
            List<string> waterCompleted = new List<string>();
            if (str == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("'water' has been terminated.");
                Console.ResetColor();
                gameplay();
            }
            else
            {
                string[] arrayWatered = str.Split(' ');
                foreach (string value in arrayWatered)
                {
                    switch (value)
                    {
                        case "a1":
                            if (plotsWatered[0] == false && plotsPlanted[0] == true)
                            {
                                plotsWatered[0] = true;
                                waterCompleted.Add("a1");
                            }
                            break;
                        case "a2":
                            if (plotsWatered[1] == false && plotsPlanted[1] == true)
                            {
                                plotsWatered[1] = true;
                                waterCompleted.Add("a2");
                            }
                            break;
                        case "a3":
                            if (plotsWatered[2] == false && plotsPlanted[2] == true)
                            {
                                plotsWatered[2] = true;
                                waterCompleted.Add("a3");
                            }
                            break;
                        case "b1":
                            if (plotsWatered[3] == false && plotsPlanted[3] == true)
                            {
                                plotsWatered[3] = true;
                                waterCompleted.Add("b1");
                            }
                            break;
                        case "b2":
                            if (plotsWatered[4] == false && plotsPlanted[4] == true)
                            {
                                plotsWatered[4] = true;
                                waterCompleted.Add("b2");
                            }
                            break;
                        case "b3":
                            if (plotsWatered[5] == false && plotsPlanted[5] == true)
                            {
                                plotsWatered[5] = true;
                                waterCompleted.Add("b3");
                            }
                            break;
                        case "c1":
                            if (plotsWatered[6] == false && plotsPlanted[6] == true)
                            {
                                plotsWatered[6] = true;
                                waterCompleted.Add("c1");
                            }
                            break;
                        case "c2":
                            if (plotsWatered[7] == false && plotsPlanted[7] == true)
                            {
                                plotsWatered[7] = true;
                                waterCompleted.Add("c2");
                            }
                            break;
                        case "c3":
                            if (plotsWatered[8] == false && plotsPlanted[8] == true)
                            {
                                plotsWatered[8] = true;
                                waterCompleted.Add("c3");
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have not specified a valid plot. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[{0}]", string.Join(", ", waterCompleted));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" have been planted successfully.\n");
                Console.ResetColor();
                gameplay();
            }
        }
        static void harvestCMD()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(".\nWhich plots would you like to harvest? 'exit' to cancel.");
            Console.ResetColor();
            var str = Console.ReadLine().ToLower();
            List<string> harvestCompleted = new List<string>();
            if (str == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("'harvest' has been terminated.");
                Console.ResetColor();
                gameplay();
            }
            else
            {
                var paycheck = 0;
                string[] arraySacrificed = str.Split(' ');
                foreach (string value in arraySacrificed)
                {
                    switch (value)
                    {

                        case "a1":
                            if (plotsPlanted[0] == true && plotsHarvestTime[0] >= 4)
                            {
                                plotsPlanted[0] = false;
                                plotsWatered[0] = false;
                                plotsHarvestTime[0] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("a1");
                            }
                            break;
                        case "a2":
                            if (plotsPlanted[1] == true && plotsHarvestTime[1] >= 4)
                            {
                                plotsPlanted[1] = false;
                                plotsWatered[1] = false;
                                plotsHarvestTime[1] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("a2");
                            }
                            break;
                        case "a3":
                            if (plotsPlanted[2] == true && plotsHarvestTime[2] >= 4)
                            {
                                plotsPlanted[2] = false;
                                plotsWatered[2] = false;
                                plotsHarvestTime[2] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("a3");
                            }
                            break;
                        case "b1":
                            if (plotsPlanted[3] == true && plotsHarvestTime[3] >= 4)
                            {
                                plotsPlanted[3] = false;
                                plotsWatered[3] = false;
                                plotsHarvestTime[3] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("b1");
                            }
                            break;
                        case "b2":
                            if (plotsPlanted[4] == true && plotsHarvestTime[4] >= 4)
                            {
                                plotsPlanted[4] = false;
                                plotsWatered[4] = false;
                                plotsHarvestTime[4] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("b2");
                            }
                            break;
                        case "b3":
                            if (plotsPlanted[5] == true && plotsHarvestTime[5] >= 4)
                            {
                                plotsPlanted[5] = false;
                                plotsWatered[5] = false;
                                plotsHarvestTime[5] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("b3");
                            }
                            break;
                        case "c1":
                            if (plotsPlanted[6] == true && plotsHarvestTime[6] >= 4)
                            {
                                plotsPlanted[6] = false;
                                plotsWatered[6] = false;
                                plotsHarvestTime[6] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("c1");
                            }
                            break;
                        case "c2":
                            if (plotsPlanted[7] == true && plotsHarvestTime[7] >= 4)
                            {
                                plotsPlanted[7] = false;
                                plotsWatered[7] = false;
                                plotsHarvestTime[7] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("c2");
                            }
                            break;
                        case "c3":
                            if (plotsPlanted[8] == true && plotsHarvestTime[8] >= 4)
                            {
                                plotsPlanted[8] = false;
                                plotsWatered[8] = false;
                                plotsHarvestTime[8] = 0;
                                coins = coins + 20;
                                paycheck = paycheck + 20;
                                harvestCompleted.Add("c3");
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("An error occured sarcificing your plant for 1 or more of these reasons:\n1. Invalid plot provided\n2. There isn't a plant on this plot\n3. Your plant isn't fully grown");
                            Console.ResetColor();
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[{0}]", string.Join(", ", harvestCompleted));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" have been planted successfully.\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(".\n+" + paycheck + "\n.");
                Console.ResetColor();
                gameplay();
            }
        }
        static void WIP()
        {
            int DisasterSlp = random.Next(difMin, difMax);
            int destOrNot = 0;
            int sacLoop = 0;
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                int randoString = random.Next(0, 5);
                string[] story = {
            ".\nA light drizzle turns into a heavy thunderstorm. Check your plots to see if any have been damaged.",
            ".\nA flash flood pours into the city and wipes out some of the crops. Check your plots to see if any have been damaged.",
            ".\nLightning lights up the sky. Check your plots to see if any have been damaged.",
            ".\nA large gust approaches. Check your plots to see if any have been damaged.",
            ".\nA small tornado strikes part of town. Check your plots to see if any have been damaged.",
            ".\nMr. Krabs runs up on your plots and he gets strafed by an A10-Warthog. Check your plots to see if any have been damaged.",
            ".\n",
            ".\nSomeone threw a gender reveal party next by your crops. Check your plots to see if any have been damaged.",
            ".\nA flock of Naruto runners trample your crops. Check your plots to see if any have been damaged.",
            ".\nA gas leak causes you too hallucinate and you accidentially watered your crops with vegetable oil. Check your plots to see if any have been damaged.",
            ".\nKindergardeners take a tour of your farm they try to uproot your farm. Check your plots to see if any have been damaged.",
            ".\nDonald Trump is reelected president for 2020 and he decides to build a wall. Unfortunately the wall is built over your plots. Check your plots to see if any have been damaged.",
            };
                foreach (bool planted in plotsPlanted)
                {
                    var plantedTF = random.Next(2) == 1;
                    if (plotsPlanted[destOrNot] == true)
                    {
                        plotsPlanted[destOrNot] = plantedTF;
                    }
                    if (planted == false && plotsWatered[destOrNot] == false)
                    {
                        plotsWatered[destOrNot] = plotsPlanted[destOrNot];
                        plotsHarvestTime[sacLoop] = 0;
                    }
                    destOrNot++;
                    sacLoop++;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(story[randoString]);
                Console.ResetColor();

                WIP();
                timer.Dispose();
            },
            null, DisasterSlp, System.Threading.Timeout.Infinite);
        }
        static void helpCMD()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("list");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("list the stats of the game. (plots, planted, watered, growth)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("day");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("display the current day.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("wait");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("skip to the next day.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("plant");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("plant on any specified plot.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("water");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("water on any specified plot.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("harvest");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("harvest any fully grown plant (plant level 4).");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("q;");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("quit game.");
            Console.ResetColor();
            gameplay();
        }
    }
}