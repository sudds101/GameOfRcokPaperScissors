using Microsoft.AspNetCore.Mvc;
using GameOfRcokPaperScissors.Models;
using System;

namespace GameOfRcokPaperScissors.Controllers
{// c# skills neeed some prtacing has been over 3 years and didnt spend much time using c# 
    public class GameController : Controller
    {

        public IActionResult Difficulty()
        {

            return View();
        }
        // this starts the webpage for cvc
        public IActionResult CVC()
        {
            TempData["data"] = 0;
            return View();
        }
        // this starts the webpage for pvc
        public IActionResult PVC()
        {
            return View();
        }



        public IActionResult DifficultySelection(int Difficulty)
        {
            if (Difficulty == 0)
                ViewBag.Diff = "Easy";
            else if (Difficulty == 1)
                ViewBag.Diff = "Medium";
            else
                ViewBag.Diff = "Hard";

            return View("PVC");

        }


        // all stats and statistical stuff will only be done on playervsplayer i done know how to use the modules ir if you can use them to store variables
        // so i figured it would be alot of the same copy and paste 

        // some comments are for me to under stand mvc and .net 


        public IActionResult PlayerVsCompEasy(int id, int Gamesplayed, int PW, int CW, int PD, int CD, int PRW, int PpW, int SW, int diff)
        {
            // keep tabs on how many games played increment everytime 
            Gamesplayed++;

            // give us the player choice from id and allows option , also crates computers choice as well
            Game playerchoice = new Game() { Option = (Option)id };

            Game computerChoice = new Game() { Option = (Option)ComputerChoiceeasy() };


            // give string
            string str;

            str = WinOrLose(playerchoice, computerChoice, true);
            // returns who wins

            //shows what choices were made maily the computer you want to see
            ViewBag.Choicesp1 = "Player : " + playerchoice.Option.ToString();
            ViewBag.Choicesc1 = "Computer : " + computerChoice.Option.ToString();
            ViewBag.Message = str;
            //shows what choices were made maily the computer you want to see, sends data back to keep tally
            TempData["GamesPlayed"] = Gamesplayed;

            int winner = NumberofwinsPVC(playerchoice, computerChoice, true);

            if (winner == 0) PW++;
            if (winner == 1) CW++;
            if (winner == 3) PD++;
            if (winner == 3) CD++;

            int Pl = Gamesplayed - (PD + PW);


            int CL = Gamesplayed - (CD + CW);

            // percentage of wins 
            float PoW = ((PW * 100) / Gamesplayed);

            // last of the analytical stuff

            //number of times rock won will only do this for player analysis
            if ((winner == 0) && (id == 0)) PRW++;
            // number of times paper won 
            if ((winner == 0) && (id == 1)) PpW++;
            // how many times won with scissors 
            SW = PW - (PRW + PpW);



            TempData["Pw"] = PW;    //player wins
            TempData["Cw"] = CW;    //computer wins
            TempData["Pd"] = PD;    //player draw
            TempData["Cd"] = CD;    //computer draw
            TempData["Pl"] = Pl;    //player loss
            TempData["Cl"] = CL;    //computer loss
            TempData["Rw"] = PRW;    //times player wins with rock 
            TempData["Ppw"] = PpW;   //time player wins with paper
            TempData["Sw"] = SW;    //time player wins with scissors
            TempData["Pow"] = PoW;
            ViewBag.Diff = "Easy";

            return View("PVC");
        }

        // computer vs computer function



        public IActionResult PlayerVsCompMed(int id, int Gamesplayed, int PW, int CW, int PD, int CD, int PRW, int PpW, int SW, int diff)
        {
            // keep tabs on how many games played increment everytime 
            Gamesplayed++;

            // give us the player choice from id and allows option , also crates computers choice as well
            Game playerchoice = new Game() { Option = (Option)id };

            Game computerChoice = new Game() { Option = (Option)ComputerChoicemedium() };


            // give string
            string str;

            str = WinOrLose(playerchoice, computerChoice, true);
            // returns who wins

            //shows what choices were made maily the computer you want to see
            ViewBag.Choicesp1 = "Player : " + playerchoice.Option.ToString();
            ViewBag.Choicesc1 = "Computer : " + computerChoice.Option.ToString();
            ViewBag.Message = str;
            //shows what choices were made maily the computer you want to see, sends data back to keep tally
            TempData["GamesPlayed"] = Gamesplayed;

            int winner = NumberofwinsPVC(playerchoice, computerChoice, true);

            if (winner == 0) PW++;
            if (winner == 1) CW++;
            if (winner == 3) PD++;
            if (winner == 3) CD++;

            int Pl = Gamesplayed - (PD + PW);


            int CL = Gamesplayed - (CD + CW);

            // percentage of wins 
            float PoW = ((PW * 100) / Gamesplayed);

            // last of the analytical stuff

            //number of times rock won will only do this for player analysis
            if ((winner == 0) && (id == 0)) PRW++;
            // number of times paper won 
            if ((winner == 0) && (id == 1)) PpW++;
            // how many times won with scissors 
            SW = PW - (PRW + PpW);



            TempData["Pw"] = PW;    //player wins
            TempData["Cw"] = CW;    //computer wins
            TempData["Pd"] = PD;    //player draw
            TempData["Cd"] = CD;    //computer draw
            TempData["Pl"] = Pl;    //player loss
            TempData["Cl"] = CL;    //computer loss
            TempData["Rw"] = PRW;    //times player wins with rock 
            TempData["Ppw"] = PpW;   //time player wins with paper
            TempData["Sw"] = SW;    //time player wins with scissors
            TempData["Pow"] = PoW;
            ViewBag.Diff = "Medium";


            return View("PVC");
        }

        public IActionResult PlayerVsComp(int id, int Gamesplayed, int PW, int CW, int PD, int CD, int PRW, int PpW, int SW, int diff)
        {
            // keep tabs on how many games played increment everytime 
            Gamesplayed++;

            // give us the player choice from id and allows option , also crates computers choice as well
            Game playerchoice = new Game() { Option = (Option)id };

            Game computerChoice = new Game() { Option = (Option)ComputerChoice() };


            // give string
            string str;

            str = WinOrLose(playerchoice, computerChoice, true);
            // returns who wins

            //shows what choices were made maily the computer you want to see
            ViewBag.Choicesp1 = "Player : " + playerchoice.Option.ToString();
            ViewBag.Choicesc1 = "Computer : " + computerChoice.Option.ToString();
            ViewBag.Message = str;
            //shows what choices were made maily the computer you want to see, sends data back to keep tally
            TempData["GamesPlayed"] = Gamesplayed;

            int winner = NumberofwinsPVC(playerchoice, computerChoice, true);

            if (winner == 0) PW++;
            if (winner == 1) CW++;
            if (winner == 3) PD++;
            if (winner == 3) CD++;

            int Pl = Gamesplayed - (PD + PW);


            int CL = Gamesplayed - (CD + CW);

            // percentage of wins 
            float PoW = ((PW * 100) / Gamesplayed);

            // last of the analytical stuff

            //number of times rock won will only do this for player analysis
            if ((winner == 0) && (id == 0)) PRW++;
            // number of times paper won 
            if ((winner == 0) && (id == 1)) PpW++;
            // how many times won with scissors 
            SW = PW - (PRW + PpW);



            TempData["Pw"] = PW;    //player wins
            TempData["Cw"] = CW;    //computer wins
            TempData["Pd"] = PD;    //player draw
            TempData["Cd"] = CD;    //computer draw
            TempData["Pl"] = Pl;    //player loss
            TempData["Cl"] = CL;    //computer loss
            TempData["Rw"] = PRW;    //times player wins with rock 
            TempData["Ppw"] = PpW;   //time player wins with paper
            TempData["Sw"] = SW;    //time player wins with scissors
            TempData["Pow"] = PoW;
            



            return View("PVC");
        }
        public IActionResult CompVSComp(int Gamesplayed, int C1W, int C1D, int C1L, int C2W, int C2D, int C2l)
        {

            Gamesplayed++;
            Game Comp1choice = new Game() { Option = (Option)ComputerChoice() };
            Game Comp2choice = new Game() { Option = (Option)ComputerChoice() };

            string str = WinOrLoseCVC(Comp1choice, Comp2choice, false);

            ViewBag.Choices = "Computer 1 : " + Comp1choice.Option.ToString() + "\nComputer 2 :" + Comp2choice.Option.ToString();
            ViewBag.Message = str;
            TempData["GamesPlayed"] = Gamesplayed;

            return View("CVC");
        }


        // compter choice generation
        private int ComputerChoice()
        {
            Random ran = new Random();
            return ran.Next(0, 3);
        }


        private int ComputerChoiceeasy()
        {
            Random ran = new Random();
            return ran.Next(0, 1);

        }


        private int ComputerChoicemedium()
        {
            Random ran = new Random();
            return ran.Next(0, 2);

        }


        private int NumberofwinsPVC(Game p1, Game p2, bool type)
        {
            int number = 0;

            if ((int)p2.Option == (int)(p1.Option + 1) % 3) number = 1; // so if computer wins player loses CPW+1 PL+1
            else if ((int)p1.Option == (int)(p2.Option + 1) % 3) number = 0; // so if player wins computer loses  CPL+1 PW+1
            else number = 3; // CPD +1 PD+1

            return number;


        }
        private String WinOrLose(Game p1, Game p2, bool type)
        {
            string output = "The Winner is ";
            if ((int)p2.Option == (int)(p1.Option + 1) % 3) output += "Computer"; // so if computer wins player loses CPW+1 PL+1
            else if ((int)p1.Option == (int)(p2.Option + 1) % 3) output += "Player 1"; // so if player wins computer loses  CPL+1 PW+1
            else output = "Its a Draw"; // CPD +1 PD+1

            return output;


        }

        private String WinOrLoseCVC(Game p1, Game p2, bool type)
        {

            string output = "The Winner is ";
            if ((int)p2.Option == (int)(p1.Option + 1) % 3) output += "Computer 1"; // so if computer wins player loses CPW+1 PL+1
            else if ((int)p1.Option == (int)(p2.Option + 1) % 3) output += " Computer 2"; // so if player wins computer loses  CPL+1 PW+1
            else output = "It's a draw"; // CPD +1 PD+1

            return output;


        }
    }
}
